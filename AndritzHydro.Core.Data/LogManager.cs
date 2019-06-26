using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Provides an application log.
    /// </summary>
    /// <remarks>This class belongs to the "Model" in MVVM pattern.</remarks>
    public class LogManager : DataApplicationObject
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private LogEntryCollection _Entries = null;

        /// <summary>
        /// Gets the list with the current entries.
        /// </summary>
        public LogEntryCollection Entries
        {
            get
            {
                if (this._Entries == null)
                {
                    //Please:
                    //Always use own classes to work with generic.
                    //NOT:
                    //this._Entries = System.Collections.ObjectModel.ObservableCollection<LogEntry>();
                    //                |-----------------------------no such lines !!!!

                    this._Entries = new LogEntryCollection();
                }

                return this._Entries;
            }
        }

        /// <summary>
        /// Adds a normal log entry.
        /// </summary>
        /// <param name="text">The information to be added.</param>
        public virtual void WriteEntry(string text)
        {
            this.WriteEntry(
                new LogEntry()
                {
                    Type = LogEntryType.Normal,
                    Text = text
                });
        }

        /// <summary>
        /// Adds a log entry.
        /// </summary>
        /// <param name="text">The information to be added.</param>
        /// <param name="type">The type of the information.</param>
        public virtual void WriteEntry(string text, LogEntryType type)
        {
            this.WriteEntry(
                new LogEntry()
                {
                    Type = type,
                    Text = text
                });
        }

        /// <summary>
        /// Helper for WriteEntry(LogEntry) method
        /// </summary>
        private delegate void AddEntryCallback(LogEntry item);

        /// <summary>
        /// Adds a log entry.
        /// </summary>
        /// <param name="item">The log entry to be added.</param>
        /// <remarks>If a dispatcher is present thread safety is ensured.</remarks>
        public virtual void WriteEntry(LogEntry item)
        {
            if (this.Context.Dispatcher != null)
            {
                var invokeInfo = this.Context.Dispatcher.GetType()
                    .GetMethod("BeginInvoke", new Type[] { typeof(System.Delegate), typeof(object[]) });

                //AddEntryCallback callback = new AddEntryCallback(this.Entries.Add);
                //invokeInfo.Invoke(this.Context.Dispatcher, new object[] { callback, new object[] { item } });

                invokeInfo.Invoke(this.Context.Dispatcher, new object[]
                {
                    new Action(()=>{
                        this.Entries.Add(item);
                        this.Callbacks.ExcecuteAllDelegates(); }),
                    null
                });

            }
            else
            {
                //not thread safe
                this.Entries.Add(item);
                //Inform all subcribers that there
                this.Callbacks.ExcecuteAllDelegates();
            }

            //Set unread Errors to true, if
            //a new Error entry was added
            if (item.Type == LogEntryType.Error)
            {
                this.UnreadError = true;
            }

            //this.SaveEntry(item);
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private WeakReferenceMethodList _Callbacks = null;

        /// <summary>
        /// Gets the list with the methods which should called by this LogManager.
        /// </summary>
        protected WeakReferenceMethodList Callbacks
        {
            get
            {
                if (this._Callbacks == null)
                {
                    this._Callbacks = new WeakReferenceMethodList();
                    this.WriteEntry($"{this} initialized the callback list");

                    this._Callbacks.DeadItemsFound += (sender, e) =>
                        this.WriteEntry(
                            $"{this} found not living callback targets.\r\nEnsure that all subscribers unsubscribe their callbacks!", 
                            LogEntryType.Error);
                }

                return this._Callbacks;
            }
        }

        /// <summary>
        /// Asks the LogManager to call the given method
        /// if a new entry is inserted.
        /// </summary>
        /// <param name="callback">Method, which should be called from LogManager.</param>
        public void Subscribe(System.Action callback)
        {
            var existingCallback = (from c in this.Callbacks
                                    where c.ExecuteDelegate.Target == callback.Target
                                    && c.ExecuteDelegate.Method == callback.Method
                                    select c).FirstOrDefault();

            if (existingCallback == null)
            {
                this.Callbacks.Add(new WeakRefernceMethod(callback));
                this.WriteEntry(
                    $"{this} subscribed a method for {callback.Target}({callback.Target.GetHashCode()})...", 
                    LogEntryType.Warning);
            }
            else
            {
                this.WriteEntry($"{this} confirms a subscription for {callback.Target}({callback.Target.GetHashCode()})...");
            }
        }

        /// <summary>
        /// Removes the given method from the callblack list.
        /// </summary>
        /// <param name="callback">Method, which should not be called any longer.</param>
        public void Unsubscribe(System.Action callback)
        {

            this.Callbacks.Remove(
                (from c in this.Callbacks
                 where c.ExecuteDelegate.Method == callback.Method 
                 && c.ExecuteDelegate.Target == callback.Target
                 select c).FirstOrDefault());

            this.WriteEntry($"{this} unsubscribed a method for {callback.Target}({callback.Target.GetHashCode()})...");

        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private bool _UnreadError = false;

        /// <summary>
        /// Gets or set a boolean if there are unread errors in the log.
        /// </summary>
        public bool UnreadError
        {
            get
            {
                return this._UnreadError;
            }
            set
            {
                this._UnreadError = value;
                if (value)
                {
                    //The following method does not 
                    //"block" the current thread because
                    //of it uses its own thread (TAP)
                    this.DoUnreadErrorPulseAsync();
                }
                    
                this.OnPropertyChanged("UnreadError");

            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private bool _UnreadErrorPulse = false;

        /// <summary>
        /// Gets pulsy true or false if there are unread errors.
        /// </summary>
        /// <remarks>To switch off UnreadError need to be false.</remarks>
        public bool UnreadErrorPulse
        {
            get
            {
                return this._UnreadErrorPulse;
            }
        }

        /// <summary>
        /// Helper to the DuUnreadErrorPulseAsync.
        /// </summary>
        private bool _DoUnreadErrorPulseWorking = false;

        /// <summary>
        /// Pulses the UnreadErrorPulse propererty from true to false.
        /// </summary>
        /// <remarks>The (new) Task Asynchronous Pattern (TAP) is used.</remarks>
        protected virtual async void DoUnreadErrorPulseAsync()
        //                  ^-> first keyword for TAP
        {
            //The following code needs his own thread...
            /*
            while (this._UnreadError)
            {
                this._UnreadErrorPulse = !this.UnreadErrorPulse;
                System.Threading.Thread.Sleep(this._UnreadErrorPulse ? 1000 : 500);
            }
            */
            if (!this._DoUnreadErrorPulseWorking)
            {
                this._DoUnreadErrorPulseWorking = true;
                await System.Threading.Tasks.Task.Run(() =>
                //                      ^-> the .Net parallel library
                //-> the second keyword for TAP
                {
                    while (this._UnreadError)
                    {
                        this._UnreadErrorPulse = !this._UnreadErrorPulse;
                        this.OnPropertyChanged("UnreadErrorPulse");
                        System.Threading.Thread.Sleep(this._UnreadErrorPulse ? 1000 : 500);
                    }

                    this._DoUnreadErrorPulseWorking = false;
                    //To switch the error LED to black
                    this._UnreadErrorPulse = false;
                    this.OnPropertyChanged("UnreadErrorPulse");
                });
            }
        }

        /// <summary>
        /// Gets or sets the full path where the
        /// log entries should be saved.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Internal field of the property
        /// </summary>
        private static int? _MaxTypeLength = null; 

        /// <summary>
        /// Gets the number of chars of the lengthiest LogType
        /// </summary>
        protected int MaxTypeLength
        {
            get
            {
                if (LogManager._MaxTypeLength == null)
                {
                    LogManager._MaxTypeLength 
                        = (from e in System.Enum.GetNames(typeof(LogEntryType))
                            select e.Length).Max();
                }

                return LogManager._MaxTypeLength.Value;
            }
        }

        /// <summary>
        /// Writes the entry into the file behind the Path property if not String.Empty
        /// </summary>
        /// <param name="entry">The log enty that should be written to the path.</param>
        protected void SaveEntry(LogEntry entry)
        {
            if (this.Path != null && this.Path != string.Empty)
            {

                int retryCounter = 10;

                do
                {
                    try
                    {
                        using (var w = new System.IO.StreamWriter(this.Path, append: true))
                        {
                            var linePattern = "{0} {3}\t{1}\t{2}";

                            w.WriteLine(
                                string.Format(
                                    linePattern,
                                    entry.Timestamp,                                    //{0} 
                                    entry.Type.ToString().PadRight(this.MaxTypeLength), //{1}
                                    //the seperator char and the end line char 
                                    //isn't allowed in the text
                                    entry.Text.Replace("\t"," ").Replace("\r\n"," "),   //{2}
                                    retryCounter                                        //{3}
                                    ));

                            retryCounter = 0;
                        }
                    }

                    //It's possible that the log file is locked from another thread
                    catch (System.IO.IOException ioEx)
                    {
                        System.Threading.Thread.Sleep(this.Context.Random.Next(500));
                        retryCounter--;
                    }

                    //All exceptions extend System.Exception
                    //so the 'default' catch has to be the last one
                    catch (System.Exception ex)
                    {
                        this.Path = string.Empty;
                        retryCounter = 0;
                        this.WriteEntry($"Because of an exception \"{ex.Message}\" SaveEntry is switched off.", LogEntryType.Error);
                    }

                } while (retryCounter != 0);
            }
        }

        /// <summary>
        /// Zips the current log file and removes it.
        /// </summary>
        /// <param name="maxGenerations">Number of old zips that should be kept</param>
        public virtual void CleanUp(int maxGenerations)
        {
            if (System.IO.File.Exists(this.Path))
            {
                maxGenerations = maxGenerations < 0 ? 0 : maxGenerations;

                //Rename old zips
                for (int i = maxGenerations; i > 1; i--)
                {
                    var oldName = $"{this.Path}.{i}.zip";
                    var newName = $"{this.Path}.{i - 1}.zip";

                    if (System.IO.File.Exists(oldName))
                    {
                        System.IO.File.Delete(oldName);
                    }

                    if (System.IO.File.Exists(newName))
                    {
                        System.IO.File.Move(newName, oldName);
                    }
                }

                //Create the new zip
                using (var zipFile = new System.IO.FileStream(this.Path + ".1.zip", System.IO.FileMode.Create))
                {
                    using (var zipArchiv = new System.IO.Compression.ZipArchive(zipFile, System.IO.Compression.ZipArchiveMode.Create))
                    {
                        using (var writer = new System.IO.StreamWriter(zipArchiv.CreateEntry(System.IO.Path.GetFileName(this.Path)).Open()))
                        {
                            using (var reader = new System.IO.StreamReader(this.Path, System.Text.Encoding.Default))
                            {
                                writer.Write(reader.ReadToEnd());
                            }
                        }
                    }
                }

                //Delete the current log file
                System.IO.File.Delete(this.Path);
                this.WriteEntry($"The old log was cleared. {maxGenerations} generations are kept.");
            }
        }
    }
}
