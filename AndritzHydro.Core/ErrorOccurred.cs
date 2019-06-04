using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core
{
    //If an event without additional data is needed:
    //Use System.EventHandler (with System.EventArgs -> empty)
    //You can start with step 3

    //2. Step

    /// <summary>
    /// Represents the method which will handle the ErrorOccurred event.
    /// </summary>
    public delegate void ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);

    //1. Step

    /// <summary>
    /// Provides the data for the ErrorOccurred Event.
    /// </summary>
    public class ErrorOccurredEventArgs : System.EventArgs
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Exception _Reason = null;

        /// <summary>
        /// Gets the exception which was trown.
        /// </summary>
        public System.Exception Reason
        {
            get
            {
                return this._Reason;
            }
        }

        /// <summary>
        /// Initializes a new ErrorOccurredEventArgs object.
        /// </summary>
        /// <param name="reason">The exception which was trown.</param>
        public ErrorOccurredEventArgs(System.Exception reason)
        {
            this._Reason = reason;
        }
    }
}
