using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Describes a log entry.
    /// </summary>
    public enum LogEntryType
    {
        /// <summary>
        /// Information to the users.
        /// </summary>
        Normal,
        /// <summary>
        /// A class was initialized.
        /// </summary>
        NewObject,
        /// <summary>
        /// Remarkable information to the users.
        /// </summary>
        Warning,
        /// <summary>
        /// An exception occurred.
        /// </summary>
        Error,
        /// <summary>
        /// Shows that an activity is running
        /// </summary>
        Busy
    }

    /// <summary>
    /// Provides a list of log entries.
    /// </summary>
    /// <remarks>ObservableCollection is optimized for WPF.</remarks>
    public class LogEntryCollection 
        : System.Collections.ObjectModel.ObservableCollection<LogEntry>
    {

    }

    /// <summary>
    /// Provides information about a log entry.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private DateTime _Timestamp = DateTime.Now;

        /// <summary>
        /// Gets the time this entry was created.
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return this._Timestamp;
            }
        }

        /// <summary>
        /// Gets or sets the information level of the entry.
        /// </summary>
        public LogEntryType Type { get; set; }

        /// <summary>
        /// Gets or set the information of the entry.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Returns a string that represents this LogEntry.
        /// </summary>
        public override string ToString()
        {
            return $"{this.GetType().Name}(Type={this.Type}, Text=\"{this.Text}\")";
        }
    }
}
