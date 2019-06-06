
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AndritzHydro.Tuccos.Data;

namespace AndritzHydro.Tuccos.ViewModels
{
    public class ProjectManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        public WindowManager Owner { get; set; }


        #region Country

        /// <summary>
        /// Provides the country lsit
        /// </summary>
        /// <returns></returns>
        public Country[] GetCountriesMethod()
        {
            var VM = new Model.ProjectController();
            return VM.GetCountries();
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Country[] _CountriesFinal;


        /// <summary>
        /// Gets the supported projects.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public Country[] CountriesFinal
        {
            get
            {
                this._CountriesFinal = this.GetCountriesMethod();
                return this._CountriesFinal;
            }
        }

        #endregion Country


        #region ProjectList

        /// <summary>
        /// Provides the country lsit
        /// </summary>
        /// <returns></returns>
        public Project[] GetProjectListMethod()
        {
            var VM = new Model.ProjectController();
            return VM.GetProjectsList();
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Project[] _ProjectListFinal;


        /// <summary>
        /// Gets the supported projects.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public Project[] ProjectListFinal
        {
            get
            {
                this._ProjectListFinal = this.GetProjectListMethod();
                return this._ProjectListFinal;
            }
        }


        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private localhost.IProject _Controller = null;

        /// <summary>
        /// Gets the object working with the lottery methods.
        /// </summary>
        /// <remarks>Either the web service or the local assembly
        /// controlled by the "UseWebService" app setting.</remarks>
        private localhost.IProject Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = new localhost.ProjectClient();
                    this.Context.Log.WriteEntry(
                        $"{this._Controller} is opened...",
                        Core.Data.LogEntryType.NewObject);
                    
                }

                return this._Controller;
            }
        }


        /// <summary>
        /// Internal field the property.
        /// </summary>
        private Project _CurrentProject = null;

        /// <summary>
        /// Gets or sets the lottery ticket which was calculatet.
        /// </summary>
        public Project CurrentProject
        {
            get
            {
                return this._CurrentProject;
            }
            set
            {
                this._CurrentProject = value;
                this.OnPropertyChanged();
            }
        }


        private string _ProjectId;
        public string ProjectId
        {
            get
            {
                return _ProjectId;
            }
            set
            {
                if (_ProjectId != value)
                {
                    _ProjectId = value;
                    OnPropertyChanged("ProjectId");
                }
            }
        }

        private string _ProjectName;
        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }
            set
            {
                if (_ProjectName != value)
                {
                    _ProjectName = value;
                    OnPropertyChanged("ProjectName");
                }
            }
        }

        private int _ProjectYear;
        public int ProjectYear
        {
            get
            {
                return _ProjectYear;
            }
            set
            {
                if (_ProjectYear != value)
                {
                    _ProjectYear = value;
                    OnPropertyChanged("ProjectYear");
                }
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _SaveProject = null;

        /// <summary>
        /// Gets the command to add a lottery ticket to the database.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command SaveProject
        {
            get
            {
                this.Controller.SaveProject(new Project { Id=ProjectId, Name = ProjectName, Year = ProjectYear });
                return this._SaveProject;
            }
        }

        #endregion ProjectList





    }
}

