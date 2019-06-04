using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core
{
    /// <summary>
    /// Manages the applications languages.
    /// </summary>
    public class LanguageManager : AndritzHydro.Core.ApplicationObject
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Core.Data.Language _Current = null;

        /// <summary>
        /// Gets or sets the language which is used.
        /// </summary>
        /// <remarks>If no language is set, the
        /// first language from the list is returned.</remarks>
        public AndritzHydro.Core.Data.Language Current
        {
            get
            {
                if (this._Current == null && this.List.Count > 0)
                {
                    this._Current = this.List[0];
                }

                return this._Current;
            }
            set
            {
                this._Current = value;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Core.Data.LanguageList _List = null;

        /// <summary>
        /// Gets the supported languages.
        /// </summary>
        /// <remarks>The languages are ordered by name.</remarks>
        public AndritzHydro.Core.Data.LanguageList List
        {
            get
            {
                if (this._List == null)
                {
                    //this._List = this.Controller.GetResourceLanguages();
                    this._List = new Data.LanguageList();

                    this._List.AddRange(
                        (from l in this.Controller.GetResourceLanguages()
                         orderby l.Name select l).ToArray());
           
                }

                return this._List;
            }
        }

        /// <summary>
        /// Internal field for the property
        /// </summary>
        private AndritzHydro.Core.Controller.LanguageController _Controller = null;

        /// <summary>
        /// Gets the Language Controller to read and write languages as Xml.
        /// </summary>
        private AndritzHydro.Core.Controller.LanguageController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<AndritzHydro.Core.Controller.LanguageController>();
                }

                return this._Controller;
            }
        }

        /// <summary>
        /// Ensures that the content uses the correct language.
        /// </summary>
        public void Refresh()
        {
            string currentCode = null;

            ////12/05/2018 Bug: The current language is not translated
            if (this._Current != null)
            {
                currentCode = this._Current.Code;
            }
            this._List = null;
            this._Controller = null;

            if (currentCode != null)
            {
                this._Current = this.List.Find(currentCode);
            }
        }
    }
}
