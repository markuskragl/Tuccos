using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndritzHydro.Core.Data;

using AndritzHydro.Core.Data.Extensions;


namespace AndritzHydro.Tuccos.Model
{
    /// <summary>
    /// Stellt einen Dienst zum Nachladen
    /// der WIFI.Sisharp.Teil2.Daten Assembly bereit.
    /// </summary>
    /// <remarks>Wird gerne als "Wrapper" bezeichnet.
    /// Wir haben bewusst keinen Verweis auf Assembly,
    /// damit diese aus dem Kundenordner gelöscht werden,
    /// wenn nur online gearbeitet werden soll.</remarks>
    internal class ProjectController : AndritzHydro.Core.Data.DataApplicationObject
    {


        //        /// <summary>
        //        /// Die Bezeichnung der dynamisch geladenen Assembly.
        //        /// </summary>
        //        /// <remarks>Muss sich in demselben Ordner befinden,
        //        /// wie die Anwendung.</remarks>
        //        private const string AssemblyName = "AndritzHydro.Tuccos.Data";

        //        /// <summary>
        //        /// Der Name der Klasse, die die benötigten Dienste bereitstellt.
        //        /// </summary>
        //        private const string ManagerName = "AndritzHydro.Tuccos.Data.ProjectManager";

        //        /// <summary>
        //        /// Internes Feld für die Eigenschaft.
        //        /// </summary>
        //        private System.Reflection.Assembly _Assembly = null;

        //        /// <summary>
        //        /// Ruft die Assembly ab, die die Logik bereitstellt.
        //        /// </summary>
        //        private System.Reflection.Assembly Assembly
        //        {
        //            get
        //            {
        //                if (this._Assembly == null)
        //                {
        //                    this._Assembly = System.Reflection.Assembly.Load(ProjectController.AssemblyName);
        //                    this.Context.Log.WriteEntry($"{this} hat die {this._Assembly} geladen...");
        //                }

        //                return this._Assembly;
        //            }
        //        }

        //        /// <summary>
        //        /// Internal field for the property.
        //        /// </summary>
        //        private object _Manager = null;

        //        /// <summary>
        //        /// Gets the instance of the manager providing the lottery logic.
        //        /// </summary>
        //        protected object Manager
        //        {
        //            get
        //            {
        //                if (this._Manager == null)
        //                {
        //                    //It's not possible...
        //                    //this._Manager = this.Context.Create < this.ManagerType > ();
        //                    this._Manager = this.Context.Create(this.ManagerType);
        //                    //                              ^-> calls Create<T>
        //                }

        //                return this._Manager;
        //            }
        //        }

        //        /// <summary>
        //        /// Internes Feld für die Eigenschaft.
        //        /// </summary>
        //        private Type _ManagerType = null;

        //        /// <summary>
        //        /// Ruft den Typ - die Klasse - ab, die
        //        /// die benötigten Dienste bereitstellt.
        //        /// </summary>
        //        protected Type ManagerType
        //        {
        //            get
        //            {
        //                if (this._ManagerType == null)
        //                {
        //                    this._ManagerType = this.Assembly.GetType(ProjectController.ManagerName);
        //                    this.Context.Log.WriteEntry($"{this} hat den Lottomanager Type ermittelt und gecachet...");
        //                }

        //                return this._ManagerType;
        //            }
        //        }


        //        /// <summary>
        //        /// Gets the supported the countries.
        //        /// </summary>
        //        /// <param name="language">Microsoft code of the used language</param>
        //        public Country[] GetCountries(string language)
        //        {
        //            var result = this.GetCountriesMethod.Invoke(
        //                this.Manager,
        //                new object[] { language }) as System.Collections.IList;

        //            var countries = new System.Collections.Generic.List<Country>();

        //            foreach (object c in result)
        //            {
        //                //countries.Add(
        //                //    new Country
        //                //    {
        //                //        //Following code isn't funny...
        //                //        Code = c.GetType().GetProperty("Code").GetValue(c).ToString(),
        //                //        Name = c.GetType().GetProperty("Name").GetValue(c).ToString()
        //                //    });


        //                countries.Add(c.CopyTo<Country>());
        //            }

        //            return countries.ToArray();
        //        }
    }
}
