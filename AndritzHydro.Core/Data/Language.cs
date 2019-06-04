using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data
{
    /// <summary>
    /// Stores Languages used by the application.
    /// </summary>
    /// <remarks>Typifies a generic class.</remarks>
    public class LanguageList : System.Collections.Generic.List<Language>
    {
        /// <summary>
        /// Returns the language with the given code.
        /// </summary>
        /// <param name="code">Microsoft key for the language to search for.</param>
        /// <returns>null, if not language with the given code exists.</returns>
        /// <remarks>It's not case sensitiv.</remarks>
        public Language Find(string code)
        {
            //-> this would be case sensitiv...
            //return this.Find(l => l.Code == code);

            return this.Find(l => string.Compare(l.Code, code, ignoreCase: true) == 0);
        }
    }

    /// <summary>
    /// Contains information about an applications language.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private string _Code = null;

        /// <summary>
        /// Gets or set the Microsoft key for this language.
        /// </summary>
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
                //OnPropertyChanged("Code");
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private string _Name = null;

        /// <summary>
        /// Gets or sets the user friendly description.
        /// </summary>
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                //OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Returns a string which represents this language.
        /// </summary>
        public override string ToString()
        {
            //return base.ToString();

            const string resultPattern = "{0}(Code=\"{1}\", Name=\"{2}\")";

            return string.Format(
                resultPattern, 
                this.GetType().Name, 
                this.Code, 
                this.Name);
        }
    }
}
