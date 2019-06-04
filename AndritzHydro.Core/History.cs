using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core
{
    /// <summary>
    /// Provides a service to go back or to go forward.
    /// </summary>
    public class History : System.Object
    {
        /// <summary>
        /// Inserts the item to the history.
        /// </summary>
        /// <param name="item">Object for the history</param>
        /// <remarks>The forward cache is cleared.</remarks>
        public void Add(object item)
        {
            this.ForwardCache.Clear();
            this.OnNoForwardPossible(EventArgs.Empty);

            this.BackCache.Push(item);
            if (this.BackCache.Count > 1)
            {
                this.OnGoBackPossible(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Returns the object needed for to go back.
        /// </summary>
        /// <remarks>Exception is thrown if no previous object exists.
        /// Listen carefully to the events.</remarks>
        public object GetPreviousItem()
        {
            //Remove the top object of the back cache and put it to the forward cache and 
            //raise the event forward possible
            this.ForwardCache.Push(this.BackCache.Pop());
            this.OnForwardPossible(System.EventArgs.Empty);

            //return the top object from the back cache
            //without removing it. If only one object is in
            //the back cache, raise the event no go back.
            if (this.BackCache.Count <= 1)
            {
                this.OnNoGoBackPossible(System.EventArgs.Empty);
            }

            return this.BackCache.Peek();

        }

        /// <summary>
        /// Returns the object needed for to forward.
        /// </summary>
        public object GetNextItem()
        {
            //Get the top object from the forward cache
            //return this after moving to the back cache

            this.BackCache.Push(this.ForwardCache.Pop());
            if (this.ForwardCache.Count == 0)
            {
                this.OnNoForwardPossible(System.EventArgs.Empty);
            }

            if (this.BackCache.Count > 1)
            {
                this.OnGoBackPossible(System.EventArgs.Empty);
            }

            return this.BackCache.Peek();
        }

        /// <summary>
        /// Raises if a previous object exists.
        /// </summary>
        public event System.EventHandler GoBackPossible;

        /// <summary>
        /// Raises if no previous object exists.
        /// </summary>
        public event System.EventHandler NoGoBackPossible;

        /// <summary>
        /// Raises if a forward object exists.
        /// </summary>
        public event System.EventHandler ForwardPossible;

        /// <summary>
        /// Raises if no forward object exists.
        /// </summary>
        public event System.EventHandler NoForwardPossible;

        /// <summary>
        /// Raises the GoBackPossible event.
        /// </summary>
        protected virtual void OnGoBackPossible(System.EventArgs e)
        {
            if (this.GoBackPossible != null)
            {
                this.GoBackPossible(this, e);
            }
        }

        /// <summary>
        /// Raises the NoGoBackPossible event.
        /// </summary>
        protected virtual void OnNoGoBackPossible(System.EventArgs e)
        {
            if (this.NoGoBackPossible != null)
            {
                this.NoGoBackPossible(this, e);
            }
        }

        /// <summary>
        /// Raises the ForwardPossible event.
        /// </summary>
        protected virtual void OnForwardPossible(System.EventArgs e)
        {
            if (this.ForwardPossible != null)
            {
                this.ForwardPossible(this, e);
            }
        }
       
        /// <summary>
        /// Raises the NoForwardPossible event.
        /// </summary>
        protected virtual void OnNoForwardPossible(System.EventArgs e)
        {
            if (this.NoForwardPossible != null)
            {
                this.NoForwardPossible(this, e);
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Collections.Stack _BackCache = null;

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Collections.Stack _ForwardCache = null;

        /// <summary>
        /// Gets the Last-In-First-Out list containing the previous objects
        /// </summary>
        protected System.Collections.Stack BackCache
        {
            get
            {
                if (this._BackCache == null)
                {
                    this._BackCache = new System.Collections.Stack();
                }

                return this._BackCache;
            }
        }

        /// <summary>
        /// Gets the Last-In-First-Out list containing the objects to go forward.
        /// </summary>
        protected System.Collections.Stack ForwardCache
        {
            get
            {
                if (this._ForwardCache == null)
                {
                    this._ForwardCache = new System.Collections.Stack();
                }

                return this._ForwardCache;
            }
        }
    }
}
