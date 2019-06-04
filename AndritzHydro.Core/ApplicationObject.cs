using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core
{
    /// <summary>
    /// Provides the application context to all AndritzHydro objects.
    /// </summary>
    public abstract class ApplicationObject : System.Object, IApplicationObject
    //                                                          ^-> but as many interfaces as needed possible
    //                                          ^-> only one base class allowed
    {
        /// <summary>
        /// Internal field for the property
        /// </summary>
        private ApplicationContext _Context = null;

        /// <summary>
        /// Gets or set the infrastructure object of the application.
        /// </summary>
        public ApplicationContext Context
        {
            get
            {
                if (this._Context == null)
                {
                    this._Context = new ApplicationContext();
                }

                return this._Context;
            }
            set
            {
                this._Context = value;
            }
        }

        //Step 3 (or 1)

        /// <summary>
        /// Occurres if there was an exception executing the code.
        /// </summary>
        public event AndritzHydro.Core.ErrorOccurredEventHandler ErrorOccurred;

        //Step 4 (or 2)

        /// <summary>
        /// Raises the ErrorOccured event.
        /// </summary>
        protected void OnErrorOccurred(AndritzHydro.Core.ErrorOccurredEventArgs e)
        {
            //Because of multi threading (Part II)
            //Save the memory address to a copy because of
            //the Garbage Collector will not remove the object

            var EventHandlerCopy = this.ErrorOccurred;

            if (EventHandlerCopy != null)
            {
                EventHandlerCopy(this, e);
            }
        }
    }
}
