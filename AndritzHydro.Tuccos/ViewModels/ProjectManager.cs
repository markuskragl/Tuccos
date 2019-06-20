
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using AndritzHydro.Tuccos.Model;

namespace AndritzHydro.Tuccos.ViewModels
{
    public class ProjectManager : AndritzHydro.Core.Data.DataApplicationObject, INotifyPropertyChanged
    {
        public WindowManager Owner { get; set; }


        #region ProjectList

        /// <summary>
        /// Provides the project list
        /// </summary>
        /// <returns></returns>
        public Project[] GetProjectListMethod()
        {
            var VM = new Model.ProjectClient();
            return VM.GetProjectList();
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
        /// Provides the SubAssembly list
        /// </summary>
        /// <returns></returns>
        public SubAssembly[] GetSubAssembliesMethod()
        {
            var VM = new Model.ProjectClient();
            return VM.GetSubAssemblies();
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private SubAssembly[] _SubAssemblies;

        /// <summary>
        /// Gets the supported projects.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public SubAssembly[] SubAssemblies
        {
            get
            {
                this._SubAssemblies = this.GetSubAssembliesMethod();
                return this._SubAssemblies;
            }
        }

        /// <summary>
        /// Provides the template calculation list
        /// </summary>
        /// <returns></returns>
        public CalculationTemplate[] GetCalcualationTemplatesMethod()
        {
                try
                {
                    //int? _helper = this.SelectedSubAssembly.SubAssemblyId;                    
                    var VM = new Model.ProjectClient();
                    //var _helper1 = VM.GetCalculationTemplates(this.SelectedSubAssembly.SubAssemblyId);
                    return VM.GetCalculationTemplates(this.SelectedSubAssembly.SubAssemblyId);
                }
                catch (System.Exception ex)
                {
                    this.Context.Log.WriteEntry($"{ex.Message}", Core.Data.LogEntryType.Error);
                }
            
            return null;

        }

                       /// <summary>
        /// Internal field for the property.
        /// </summary>
        private CalculationTemplate[] _CalculationTemplates;

        /// <summary>
        /// Gets the supported projects.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public CalculationTemplate[] CalculationTemplates
        {
            get
            {
                this._CalculationTemplates = this.GetCalcualationTemplatesMethod();
                return this._CalculationTemplates;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Model.SubAssembly _SelectedSubAssembly = null;

        /// <summary>
        /// Gets or set the date of the draw that should be shown.
        /// </summary>
        public Model.SubAssembly SelectedSubAssembly
        {
            get
            {

                return this._SelectedSubAssembly;
                
            }
            set
            {

                this._SelectedSubAssembly = value;
                OnPropertyChanged("CalculationTemplates");
                OnPropertyChanged("Calculations");
                this._SelectedSubAssembly = null;
            }
        }





        #region Calculations

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Model.CalculationTemplate _SelectedCalculationTemplate = null;

        /// <summary>
        /// Gets or set the date of the draw that should be shown.
        /// </summary>
        public Model.CalculationTemplate SelectedCalculationTemplate
        {
            get
            {

                return this._SelectedCalculationTemplate;

            }
            set
            {
                this._SelectedCalculationTemplate = value;
                //OnPropertyChanged("Calculations");
                //this._SelectedCalculationTemplate = null;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Model.Calculation _SelectedCalculation = null;

        /// <summary>
        /// Gets or set the date of the calculation that should be deleted.
        /// </summary>
        public Model.Calculation SelectedCalculation
        {
            get
            {

                return this._SelectedCalculation;

            }
            set
            {
                this._SelectedCalculation = value;
                //OnPropertyChanged("Calculations");
                //this._SelectedCalculation = null;
            }
        }



        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Model.Calculation _CurrentCalculation = null;

        /// <summary>
        /// Gets or set the date of the calculation that should be deleted.
        /// </summary>
        public Model.Calculation CurrentCalculation
        {
            get
            {

                return this._CurrentCalculation;

            }
            set
            {
                this._CurrentCalculation = value;
                this.OnPropertyChanged("CurrentCalculationViewer");
                this.OnPropertyChanged("CurrentCalculation");


                //this._SelectedCalculation = null;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Type _ViewerCalculationType = null;

        /// <summary>
        /// Gets the type of the viewer used for this task.
        /// </summary>
        public System.Type ViewerCalculationType
        {
            get
            {
                return this._ViewerCalculationType;
            }
            set
            {
                this._ViewerCalculationType = value;
            }

        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private System.Windows.Controls.UserControl _CurrentCalculationViewer = null;

        /// <summary>
        /// Gets the viewer used for the current task.
        /// </summary>
        public System.Windows.Controls.UserControl CurrentCalculationViewer
        {
            get
            {
                try
                {
                    this._CurrentCalculationViewer = System.Activator.CreateInstance(Type.GetType("AndritzHydro.Tuccos." + CurrentCalculation.CalculationType))
                        as System.Windows.Controls.UserControl;
                }
                catch (System.Exception ex)
                {
                    this.Context.Log.WriteEntry($"{ex.Message}", Core.Data.LogEntryType.Error);
                }

                return this._CurrentCalculationViewer;
            }
        }



        /// <summary>
        /// Provides the template calculation list
        /// </summary>
        /// <returns></returns>
        public Calculation[] GetCalcualationMethod()
        {
            try
            {
                //int? _helper = this.SelectedSubAssembly.SubAssemblyId;                    
                var VM = new Model.ProjectClient();
                //var _helper1 = VM.GetCalculationTemplates(this.SelectedSubAssembly.SubAssemblyId);
                return VM.GetCalculations(this.SelectedSubAssembly.SubAssemblyId, this.SelectedProject.ProjectId);
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry($"{ex.Message}", Core.Data.LogEntryType.Error);
            }

            return null;

        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Calculation[] _Calculations;

        /// <summary>
        /// Gets the supported projects.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public Calculation[] Calculations
        {
            get
            {
                this._Calculations = this.GetCalcualationsMethod();
                return this._Calculations;
            }
        }


        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _AddCalculation= null;

        /// <summary>
        /// Gets the command to add a lottery ticket to the database.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command AddCalculation
        {

            get
            {
                if (this._AddCalculation == null)
                {
                    this.Owner.SetBusyOn();

                    this._AddCalculation = new AndritzHydro.Tuccos.Helpers.Command(
                        data =>
                        {
                            this.Owner.SetBusyOn();

                            var MaxCalculationId= 0;
                            foreach (Calculation c in this.Controller.GetCalculations())
                            {
                                if ((int)c.CalculationId > MaxCalculationId)
                                {
                                    MaxCalculationId = (int)c.CalculationId;
                                }
                            }
                            int CurrentCalculationid = MaxCalculationId + 1;

                            var _helper = this.SelectedCalculationTemplate;

                            this.Controller.AddCalculation(new Calculation {
                                ProjectId = this.SelectedProject.ProjectId,
                                SubAssemblyId = this.SelectedCalculationTemplate.SubAssemblyId,
                                CalculationId = CurrentCalculationid,
                                CalculationType = this.SelectedCalculationTemplate.CalculationType});

                            this.CloseController();

                            
                            OnPropertyChanged("Calculations");

                            this.Owner.SetBusyOff();

                        });

                    this.Owner.SetBusyOff();
                }

                return this._AddCalculation;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _DeleteCalculation = null;

        /// <summary>
        /// Gets the command to delete a project from the database.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command DeleteCalculation
        {

            get
            {
                if (this._DeleteCalculation == null)
                {
                    this.Owner.SetBusyOn();

                    this._DeleteCalculation = new AndritzHydro.Tuccos.Helpers.Command(
                        data =>
                        {
                            this.Owner.SetBusyOn();

                            this.Controller.DeleteCalculation(SelectedCalculation);
                            this.CloseController();

                            OnPropertyChanged("Calculations");

                            this.Owner.SetBusyOff();
                        });

                    this.Owner.SetBusyOff();
                }

                return this._DeleteCalculation;
            }
        }


        #endregion Calculations



        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Model.IProject _Controller = null;

        /// <summary>
        /// Gets the object working with the lottery methods.
        /// </summary>
        /// <remarks>Either the web service or the local assembly
        /// controlled by the "UseWebService" app setting.</remarks>
        private Model.IProject Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = new Model.ProjectClient();
                    this.Context.Log.WriteEntry(
                        $"{this._Controller} is opened...",
                        Core.Data.LogEntryType.NewObject);
                    
                }

                return this._Controller;
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
        /// If the web service is used, this
        /// method closes the server connection
        /// and sets the field to null again.
        /// </summary>
        protected void CloseController()
        {
            return;
            if (this._Controller != null)
            {
                this.Context.Log.WriteEntry($"{this._Controller} is closed.");
                ((AndritzHydro.Tuccos.Model.ProjectClient)this._Controller).Close();
                this._Controller = null;
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
                if (this._SaveProject == null)
                {
                    this.Owner.SetBusyOn();

                    this._SaveProject = new AndritzHydro.Tuccos.Helpers.Command(
                        data =>
                        {
                            this.Owner.SetBusyOn();

                            this.Controller.SaveProject(new  Project { ProjectId = ProjectId, ProjectName = ProjectName, ProjectYear = ProjectYear });

                            this.CloseController();

                            OnPropertyChanged("ProjectListFinal");

                            this.Owner.SetBusyOff();

                        });

                    this.Owner.SetBusyOff();
                }

                //this.Controller.SaveProject(new Project { Id = ProjectId, Name = ProjectName, Year = ProjectYear });
                return this._SaveProject;
            }
        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private AndritzHydro.Tuccos.Helpers.Command _DeleteProject = null;

        /// <summary>
        /// Gets the command to delete a project from the database.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command DeleteProject
        {

            get
            {
                if (this._DeleteProject == null)
                {
                    this.Owner.SetBusyOn();

                    this._DeleteProject = new AndritzHydro.Tuccos.Helpers.Command(
                        data =>
                        {
                            this.Owner.SetBusyOn();

                            this.Controller.DeleteProject(SelectedProject);
                            this.CloseController();

                            OnPropertyChanged("ProjectListFinal");

                            this.Owner.SetBusyOff();
                        });

                    this.Owner.SetBusyOff();
                }

                return this._DeleteProject;
            }
        }

        Project _SelectedProject;
        public Project SelectedProject
        {
            get
            {
                return _SelectedProject;
            }
            set
            {
                if (_SelectedProject != value)
                {
                    _SelectedProject = value;
                    OnPropertyChanged("SelectedProject");
                }
            }
        }


        #endregion ProjectList

        /// <summary>
        /// Provides the template calculation list
        /// </summary>
        /// <returns></returns>
        public Calculation[] GetOrificeCalcualationMethod()
        {
            try
            {
                //int? _helper = this.SelectedSubAssembly.SubAssemblyId;                    
                var VM = new Model.ProjectClient();
                //var _helper1 = VM.GetCalculationTemplates(this.SelectedSubAssembly.SubAssemblyId);
                var helper = VM.GetOrificeCalculation(999);
                return VM.GetOrificeCalculation(999);

            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry($"{ex.Message}", Core.Data.LogEntryType.Error);
            }

            return null;

        }

        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Calculation[] _OrificeCalculation;

        /// <summary>
        /// Gets the supported projects.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public Calculation[] OrificeCalculation
        {
            get
            {
                this._OrificeCalculation = this.GetOrificeCalcualationMethod();
                return this._OrificeCalculation;
            }
        }

    }
}

