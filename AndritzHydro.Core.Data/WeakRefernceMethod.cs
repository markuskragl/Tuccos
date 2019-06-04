using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Implements a list for WeakReferenceMethod objects.
    /// </summary>
    public class WeakReferenceMethodList : System.Collections.Generic.List<WeakRefernceMethod>
    {
        /// <summary>
        /// Occurs if there are elements found with not living targets.
        /// </summary>
        public event System.EventHandler DeadItemsFound;

        /// <summary>
        /// Raises the DeadItemsFound event.
        /// </summary>
        protected virtual void OnDeadItemsFound()
        {
            //Because of multithreading work with a copy
            //so the Garbage Collection cannot despose the object
            var deadItemsFound = this.DeadItemsFound;
            if (deadItemsFound!=null)
            {
                deadItemsFound(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Collections.ArrayList _DeadItems = null;

        /// <summary>
        /// Gets the elements with not living targets.
        /// </summary>
        protected System.Collections.ArrayList DeadItems
        {
            get
            {
                if (this._DeadItems == null)
                {
                    this._DeadItems = new System.Collections.ArrayList();
                }

                return this._DeadItems;
            }
        }

        /// <summary>
        /// Calls each method stored in this list.
        /// </summary>
        /// <remarks>If methods with not living targes are found
        /// they are removed automatically</remarks>
        public virtual void ExcecuteAllDelegates()
        {
            //Inform all object who subscribed the log
            foreach (var c in this)
            {
                if (c.ExecuteDelegate != null)
                {
                    c.ExecuteDelegate.Method.Invoke(c.ExecuteDelegate.Target, null);
                }
                else
                {
                    this.DeadItems.Add(c);
                }
            }

            //Automatically remove objects without living target
            if (this.DeadItems.Count > 0)
            {
                foreach (WeakRefernceMethod d in this.DeadItems)
                {
                    this.Remove(d);
                }

                this.DeadItems.Clear();

                this.OnDeadItemsFound();
            }
        }
    }

    /// <summary>
    /// Hides a delegate allowing the garbage collection to remove the owner object.
    /// </summary>
    public class WeakRefernceMethod
    {
        /// <summary>
        /// Internal field to save a method allowing the garbage collection to remove the owner.
        /// </summary>
        private System.WeakReference _CallbackMethod = null;

        /// <summary>
        /// Initializes a new WeakReferenceMethode object.
        /// </summary>
        /// <param name="callback">Delegate of the methode which should be called.</param>
        public WeakRefernceMethod(System.Action callback)
        //                                          ^-> here the address is blocked.
        //                                              Garbage Collection cannot remove the owner
        {
            this._CallbackMethod = new WeakReference(callback);
            //      ^-> now the address of the delegate isn't blocked
            //          any longer. If is needed the garbage collection can remove the owner

        }


        /// <summary>
        /// Gets the original method.
        /// </summary>
        public Delegate ExecuteDelegate
        {
            get
            {

                if (this._CallbackMethod.IsAlive)
                {
                    var t = this._CallbackMethod.Target as System.Action;
                    return t.Method.CreateDelegate(typeof(System.Action), t.Target);
                }

                return null;
            }
        }
    }
}
