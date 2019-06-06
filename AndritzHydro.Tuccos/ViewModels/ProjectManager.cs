
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AndritzHydro.Tuccos.Data;
using AndritzHydro.Tuccos.Helpers;
using AndritzHydro.Tuccos.Model;
using AndritzHydro.Tuccos.Data.Controller;
using AndritzHydro.Core.Data.Extensions;
using System.Collections.ObjectModel;
using AndritzHydro.Tuccos.localhost;

namespace AndritzHydro.Tuccos.ViewModels
{
    public class ProjectManager : AndritzHydro.Core.Data.DataApplicationObject
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


        private Country[] _CountriesFinal;

        public Country[] CountriesFinal
        {
            get
            {
                this._CountriesFinal = this.GetCountries();
                return this._CountriesFinal;
            }
        }

        public WindowManager Owner { get; set; }
    }
}

