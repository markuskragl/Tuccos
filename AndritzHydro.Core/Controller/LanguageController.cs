using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Controller
{
    /// <summary>
    /// Reads or writes language from Xml.
    /// </summary>
    internal class LanguageController 
        : AndritzHydro.Core.Generic.XmlController<AndritzHydro.Core.Data.LanguageList>
    {

        /// <summary>
        /// Returns the languages from the resources.
        /// </summary>
        public AndritzHydro.Core.Data.LanguageList GetResourceLanguages()
        {
            var result = new AndritzHydro.Core.Data.LanguageList();

            var xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.LoadXml(AndritzHydro.Core.Properties.Resources.Languages);

            foreach (System.Xml.XmlNode l in xmlDocument.DocumentElement.ChildNodes)
            {
                result.Add(
                    new AndritzHydro.Core.Data.Language {
                            Code = l.Attributes["code"].Value,
                            Name = l.Attributes["name"].Value
                    });
            }

            return result;
        }

    }
}
