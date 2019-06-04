using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Provides the database infrastructure to all objects
    /// </summary>
    /// <remarks>This class can be used as a base ViewModel</remarks>
    public abstract class DataApplicationObject 
        : AndritzHydro.Core.ApplicationObject, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the infrastructure object for database applications.
        /// </summary>
        /// <remarks>Needed for casting DataApplicationContext to ApplicationContext.</remarks>
        public new DataApplicationContext Context
        {
            get
            {
                return base.Context as DataApplicationContext;
            }
            set
            {
                base.Context = value;
            }
        }

        /// <summary>
        /// Raised if the content of a property was changed.
        /// </summary>
        /// <remarks>Needed for WPF data binding.</remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property changed</param>
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        //                                                                                                     ^-> for an optional parameter
        //                                                                  ^-> Attribute that initializes the value with the name of the caller
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private bool _IsBusy = false;

        /// <summary>
        /// Gets or sets a boolean showing 
        /// if the application is working on a job.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this._IsBusy;
            }
            set
            {
                this._IsBusy = value;
                //-> not funny...
                //this.OnPropertyChanged("IsBusy");
                this.OnPropertyChanged();
                //                     ^-> the default value of
                //                         the parameter is automatically
                //                         set to the caller name
            }
        }

        /// <summary>
        /// Internal helper for SetBusyOn and SetBusyOff
        /// </summary>
        private int _BusyCounter = 0;

        /// <summary>
        /// Sets IsBusy to true and adds a log entry.
        /// </summary>
        /// <param name="caller">The name of the calling method or property.</param>
        public virtual void SetBusyOn([System.Runtime.CompilerServices.CallerMemberName]string caller = "")
        {
            this._BusyCounter++;
            this.Context.Log.WriteEntry($"{caller} gets busy...", LogEntryType.Busy);
            this.IsBusy = true;
        }

        /// <summary>
        /// Sets IsBusy to false if it's the last call
        /// and adds a log entry.
        /// </summary>
        /// <param name="caller">The name of the calling method or property</param>
        public virtual void SetBusyOff([System.Runtime.CompilerServices.CallerMemberName]string caller = "")
        {
            this._BusyCounter--;
            if (this._BusyCounter < 0) this._BusyCounter = 0;

            if (this._BusyCounter == 0)
            {
                this.IsBusy = false;
            }

            this.Context.Log.WriteEntry($"{caller} is not busy any longer...");
        }
    }
}
