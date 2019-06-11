using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndritzHydro.Core.Data;

using AndritzHydro.Core.Data.Extensions;
using AndritzHydro.Tuccos.Data;

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
        public Country[] GetCountries(string language = "AT")
        {

            localhost.ProjectClient mc = new localhost.ProjectClient();

            var result = mc.GetCountries("AT");

            var countries = new System.Collections.Generic.List<Country>();

            foreach (object c in result)
            {
                countries.Add(c.CopyTo<Country>());
            }
            return countries.ToArray();
        }

        public Project[] GetProjectsList()
        {

            localhost.ProjectClient mc = new localhost.ProjectClient();

            var result = mc.GetProjectList();

            var projects = new System.Collections.Generic.List<Project>();

            foreach (object c in result)
            {
                projects.Add(c.CopyTo<Project>());
            }
            Project[] _projects = projects.ToArray();
            return projects.ToArray();
        }
    }
}
