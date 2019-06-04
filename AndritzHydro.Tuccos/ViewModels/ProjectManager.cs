
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AndritzHydro.Core.Data.Extensions;


namespace AndritzHydro.Tuccos.ViewModels
{
    public class ProjectManager : AndritzHydro.Core.Data.DataApplicationObject
    {

        /// <summary>
        /// Provides a list of lottery countries.
        /// </summary>
        public class Countries : System.Collections.Generic.List<Country>
        {

        }

        /// <summary>
        /// Provides information about a country
        /// where the lottery game is supported.
        /// </summary>
        public class Country
        {
            /// <summary>
            /// Gets or set the ISO code of the country.
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// Gets or sets the readable name of the country.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the highest lottery number in this country.
            /// </summary>
            public int MaxNumber { get; set; }

            /// <summary>
            /// Gets or sets the count of numbers in a lottery bet.
            /// </summary>
            public int NumberCount { get; set; }

        }



        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private static Country[] _Countries = null;

        /// <summary>
        /// Gets the supported countries.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public Country[] CountriesNew
        {
            get
            {

                //if (_Countries == null)
                //{
                //    this.InitializeCountriesAsync();
                //}

                return _Countries;
            }
        }

        public Country[] GetCountriesMethod()
        {

            localhost.ProjectClient mc = new localhost.ProjectClient();

            var result = mc.GetCountries("AT");

            var countries = new System.Collections.Generic.List<Country>();

            foreach (object c in result)
            {
                //countries.Add(
                //    new Country
                //    {
                //        //Following code isn't funny...
                //        Code = c.GetType().GetProperty("Code").GetValue(c).ToString(),
                //        Name = c.GetType().GetProperty("Name").GetValue(c).ToString()
                //    });


                countries.Add(c.CopyTo<Country>());
            }
            return countries.ToArray();
        }

        public ProjectManager()
        {


            var ProjectList = GetCountriesMethod();

            var TypeofProject = ProjectList.GetType();



            ProjectList = ProjectList;
        }

        public WindowManager Owner { get; set; }
    }
}

