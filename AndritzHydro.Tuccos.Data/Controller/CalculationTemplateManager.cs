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
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        /// <remarks>Nur das sollte bei einer anderen
        /// Datenbank ausgetauscht werden müssen.</remarks>
        private CalculationTemplateController _Controller = null;

        /// <summary>
        /// Ruft den Dienst zum Lesen und Schreiben
        /// der Lottodaten ab.
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
        /// Provides all SubAssemblies.
        /// </summary>
        public CalculationTemplates GetCalculationTemplates(int? SubId)
        {
            try
            {
                return this.Controller.GetCalculationTemplates(SubId);
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
