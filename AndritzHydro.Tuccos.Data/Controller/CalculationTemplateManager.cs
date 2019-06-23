using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    public class CalculationTemplateManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private CalculationTemplateController _Controller = null;
        /// <summary>
        /// Provides the service to read from the database.
        /// </summary>
        private CalculationTemplateController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<CalculationTemplateController>();
                }
                return this._Controller;
            }
        }

        /// <summary>
        /// Provides all calculation templates.
        /// </summary>
        public CalculationTemplates GetCalculationTemplates(int? subId)
        {
            try
            {
                return this.Controller.GetCalculationTemplates(subId);
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return new CalculationTemplates();
            }
        }
    }
}
