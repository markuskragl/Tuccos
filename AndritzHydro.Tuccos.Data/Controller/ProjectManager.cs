using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    public class ProjectManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        /// <remarks>Nur das sollte bei einer anderen
        /// Datenbank ausgetauscht werden müssen.</remarks>
        private ProjectController _Controller = null;

        /// <summary>
        /// Ruft den Dienst zum Lesen und Schreiben
        /// der Lottodaten ab.
        /// </summary>
        private ProjectController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<ProjectController>();
                }

                return this._Controller;
            }
        }

        /// <summary>
        /// Gibt die unterstützten Lottoländer zurück.
        /// </summary>
        /// <param name="sprache">Die Anwendungsprache,
        /// in der die Namen der Länder geliefert werden sollen.</param>
        public Countries GetCountries(string language)
        {
            try
            {
                return this.Controller.GetCountries(language);
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return new Countries();
            }
        }
    }
}
