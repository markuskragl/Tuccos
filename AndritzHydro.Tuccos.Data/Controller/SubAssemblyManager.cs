using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    public class SubAssemblyManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private SubAssemblyController _Controller = null;
        /// <summary>
        /// Provides the service to read from the database.
        /// </summary>
        private SubAssemblyController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<SubAssemblyController>();
                }
                return this._Controller;
            }
        }

        /// <summary>
        /// Provides all SubAssemblies.
        /// </summary>
        public SubAssemblies GetSubAssemblies()
        {
            try
            {
                return this.Controller.GetSubAssemblies();
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return new SubAssemblies();
            }
        }
    }
}
