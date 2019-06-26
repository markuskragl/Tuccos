
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
        /// Provides the calculations
        /// </summary>
        /// <returns></returns>
        public Calculation[] GetCalculationsMethod()
        {
            var VM = new Model.ProjectClient();
            return VM.GetCalculations();
        }


        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private Calculation[] _Calculations;

        /// <summary>
        /// Gets the supported calculations.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public Calculation[] Calculations
        {
            get
            {
                this._Calculations = this.GetCalculationsMethod();
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

        public int SelectedIndex { get; set; }


        #endregion ProjectList

        #region Parameter
        /// <summary>
        /// Provides the parameter array for the actual calcualtion.
        /// </summary>
        /// <returns>Array of parameters belonging to calculation id</returns>
        public Parameter[] GetParametersMethod()
        {
            try
            {                  
                var VM = new Model.ProjectClient();
                return VM.GetParameters(this.CurrentCalculation.CalculationId);
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry($"{ex.Message}", Core.Data.LogEntryType.Error);
            }

            return null;

        }

        #region ParameterCol
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private List<Parameter> _ParameterCol = new List<Parameter>();

        /// <summary>
        /// Gets the outer diameter of the cylinder of the actual calculation id.
        /// </summary>
        public List<Parameter> ParameterCol
        {
            get
            {
                bool isEmpty = !this._ParameterCol.Any();
                if (isEmpty)
                {
                    List<Parameter> local = this.GetParametersMethod().ToList();
                    this._ParameterCol = local;
                }

                return this._ParameterCol;
            }

            set
            {
                if (_ParameterCol != value)
                {
                    _ParameterCol = value;
                    OnPropertyChanged("ParameterCol");
                }
            }
        }

        #endregion ParameterCol



        private AndritzHydro.Tuccos.Helpers.Command _AddParameter = null;

        /// <summary>
        /// Gets the command to add a parameter to the database.
        /// </summary>
        public AndritzHydro.Tuccos.Helpers.Command AddParameter
        {

            get
            {
                if (this._AddParameter == null)
                {
                    this.Owner.SetBusyOn();

                    this._AddParameter = new AndritzHydro.Tuccos.Helpers.Command(
                        data =>
                        {
                            this.Owner.SetBusyOn();

                            foreach(Parameter l in this.ParameterCol)
                            {
                            this.Controller.AddParameter(new Parameter { CalculationId = CurrentCalculation.CalculationId, ParameterType = l.ParameterType , ParameterValue = l.ParameterValue, ParameterUnit = l.ParameterUnit });

                            }


                            this.CloseController();

                            OnPropertyChanged("AddParameter");

                            this.Owner.SetBusyOff();

                        });

                    this.Owner.SetBusyOff();
                }

                
                return this._AddParameter;
            }
        }

        #region OuterDiameterCylinder
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _OuterDiameterCylinder;

        /// <summary>
        /// Gets the outer diameter of the cylinder of the actual calculation id.
        /// </summary>
        public double OuterDiameterCylinder
        {
            get
            {

                const string comp = "D_Cyl";
                List<Parameter> parameterlist = new List<Parameter>();
                foreach (Parameter l in this.ParameterCol)
                {
                    parameterlist.Add(l);
                }
                parameterlist.RemoveAll (u => !u.ParameterType.Contains(comp));
                this._OuterDiameterCylinder = parameterlist[0].ParameterValue;
                return this._OuterDiameterCylinder;
            }

            set
            {
                if (_OuterDiameterCylinder != value)
                {
                    _OuterDiameterCylinder = value;
                    OnPropertyChanged("OuterDiameterCylinder");
                }
            }
        }

        #endregion OuterDiameterCylinder

        #region InnerDiameterCylinder
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _InnerDiameterCylinder;

        /// <summary>
        /// Gets or sets the inner diameter of the cylinder of the actual calculation id.
        /// </summary>
        public double InnerDiameterCylinder
        {
            get
            {
                const string comp = "DI_Cyl";
                List<Parameter> parameterlist = new List<Parameter>();
                foreach (Parameter l in this.ParameterCol)
                {
                    parameterlist.Add(l);
                }
                parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                this._InnerDiameterCylinder = parameterlist[0].ParameterValue;
                return this._InnerDiameterCylinder;
            }

            set
            {
                if (_InnerDiameterCylinder != value)
                {
                    _InnerDiameterCylinder = value;
                    OnPropertyChanged("InnerDiameterCylinder");
                }
            }
        }
        #endregion InnerDiameterCylinder
        
        #region DiameterOrifice
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _DiameterOrifice;

        /// <summary>
        /// Gets or sets the diameter of the orifice of the actual calculation id.
        /// </summary>
        public double DiameterOrifice
        {
            get
            {
                const string comp = "D_Orifice";
                List<Parameter> parameterlist = new List<Parameter>();
                foreach (Parameter l in this.ParameterCol)
                {
                    parameterlist.Add(l);
                }
                parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                this._DiameterOrifice = parameterlist[0].ParameterValue;
                return this._DiameterOrifice;
            }

            set
            {
                if (_DiameterOrifice != value)
                {
                    _DiameterOrifice = value;
                    OnPropertyChanged("DiameterOrifice");
                }
            }
        }

        #endregion DiameterOrifice

        #region LengthOilPipe
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _LengthOilPipe;

        /// <summary>
        /// Gets or sets the length of the oil pipe of the actual calculation id.
        /// </summary>
        public double LengthOilPipe
        {
            get
            {
                if(this._LengthOilPipe == 0)
                {
                    const string comp = "L_OilPipe";
                    List<Parameter> parameterlist = new List<Parameter>();
                    foreach (Parameter l in this.ParameterCol)
                    {
                        parameterlist.Add(l);
                    }
                    parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                    this._LengthOilPipe = parameterlist[0].ParameterValue;
                }

                return this._LengthOilPipe;
            }

            set
           {
                if (_LengthOilPipe != value)
                {
                    _LengthOilPipe = value;
                    foreach(Parameter l in this.ParameterCol)
                    {
                        if(l.ParameterType == "L_OilPipe")
                        {
                            l.ParameterValue = value;

                            Console.WriteLine(l.ParameterValue);
                        }
                    }

                    foreach(Parameter l in this.ParameterCol)
                    {
                        Console.WriteLine(l.ParameterValue);
                    }
                    OnPropertyChanged("LengthOilPipe");
                }
            }
        }

        #endregion LengthOilPipe

        #region DiameterOilPipe
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _DiameterOilPipe;

        /// <summary>
        /// Gets or sets the diameter of the oil pipe of the actual calculation id.
        /// </summary>
        public double DiameterOilPipe
        {
            get
            {
                const string comp = "D_OilPipe";
                List<Parameter> parameterlist = new List<Parameter>();
                foreach (Parameter l in this.ParameterCol)
                {
                    parameterlist.Add(l);
                }
                parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                this._DiameterOilPipe = parameterlist[0].ParameterValue;
                return this._DiameterOilPipe;
            }

            set
            {
                if (_DiameterOilPipe != value)
                {
                    _DiameterOilPipe = value;
                    OnPropertyChanged("DiameterOilPipe");
                }
            }
        }
        #endregion DiameterOilPipe

        #region LossValue
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _LossValue;

        /// <summary>
        /// Gets or sets the loss value of the actual calculation id.
        /// </summary>
        public double LossValue
        {
            get
            {
                const string comp = "LossValue";
                List<Parameter> parameterlist = new List<Parameter>();
                foreach (Parameter l in this.ParameterCol)
                {
                    parameterlist.Add(l);
                }
                parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                this._LossValue = parameterlist[0].ParameterValue;
                return this._LossValue;
            }

            set
            {
                if (_LossValue != value)
                {
                    _LossValue = value;
                    OnPropertyChanged("LossValue");
                }
            }
        }
        #endregion LossValue

        #region SingleForce
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private List<double> _SingleForce = new List<double>();

        /// <summary>
        /// Gets or sets the single forces of the actual calculation id.
        /// </summary>
        public List<double> SingleForce
        {
            get
            {
                if (!this._SingleForce.Any())
                {
                    const string comp = "SingleForce";
                    List<Parameter> parameterlist = new List<Parameter>();
                    foreach (Parameter l in this.ParameterCol)
                    {
                        parameterlist.Add(l);
                    }
                    parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                    foreach (Parameter l in parameterlist)
                    {
                        this._SingleForce.Add(l.ParameterValue);
                    }
                }

                return this._SingleForce;
            }

            set
            {
                if (_SingleForce != value)
                {
                    _SingleForce = value;
                    OnPropertyChanged("SingleForce");
                }
            }
        }

        #endregion SingleForce

        #region PartialStroke
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private List<double> _PartialStroke = new List<double>();

        /// <summary>
        /// Gets or sets the partial stroke of the actual calculation id.
        /// </summary>
        public List<double> PartialStroke
        {
            get
            {
                if (!this._PartialStroke.Any())
                {
                    string comp = "PartialStroke";
                    List<Parameter> parameterlist = new List<Parameter>();
                    foreach (Parameter l in this.ParameterCol)
                    {
                        parameterlist.Add(l);
                    }
                    parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                    foreach (Parameter l in parameterlist)
                    {
                        this._PartialStroke.Add(l.ParameterValue);
                    }

                }

                return this._PartialStroke;
            }

            set
            {
                if (_PartialStroke != value)
                {
                    _PartialStroke = value;
                    OnPropertyChanged("PartialStroke");
                }
            }
        }

        #endregion PartialStroke

        #region TotalStroke
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private List<double> _TotalStroke = new List<double>();

        /// <summary>
        /// Gets the total stroke of the actual calculation id.
        /// </summary>
        public List<double> TotalStroke
        {
            get
            {
                double total = 0;
                foreach (double l in this.PartialStroke)
                {
                    total = total + l;
                    this._TotalStroke.Add(total);
                }
                return this._TotalStroke;
            }
        }

        #endregion TotalStroke

        #region SingleWorkCapacity
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private List<double> _SingleWorkCapacity = new List<double>();

        /// <summary>
        /// Gets the single work capacity of the actual calculation id.
        /// </summary>
        public List<double> SingleWorkCapacity
        {
            get
            {
                if (!this._SingleWorkCapacity.Any())
                {
                    int i = 0;
                    foreach (double l in this.PartialStroke)
                    {
                        double cap = 0;
                        cap = l * this.SingleForce[i];
                        this._SingleWorkCapacity.Add(cap);
                        i += 1;
                    }
                }

                return this._SingleWorkCapacity;
            }
        }

        #endregion SingleWorkCapacity

        #region TotalWorkCapacity
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _TotalWorkCapacity = default(double);

        /// <summary>
        /// Gets the total work capacity of the actual calculation id.
        /// </summary>
        public double TotalWorkCapacity
        {
            get
            {
                this._TotalWorkCapacity = this._SingleWorkCapacity.Sum();
                return this._TotalWorkCapacity;
            }
            set
            {
                if (_TotalWorkCapacity != value)
                {
                    _TotalWorkCapacity = value;
                    OnPropertyChanged("TotalWorkCapacity");
                }
            }
        }



        #endregion TotalWorkCapacity

        #region KAuxiliaries
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private List<double> _KAuxiliaries = new List<double>();

        /// <summary>
        /// Gets or sets the loss values of the auxiliaries of the actual calculation id.
        /// </summary>
        public List<double> KAuxiliaries
        {
            get
            {
                if (!this._KAuxiliaries.Any())
                {
                    const string comp = "K_Aux";
                    List<Parameter> parameterlist = new List<Parameter>();
                    foreach (Parameter l in this.ParameterCol)
                    {
                        parameterlist.Add(l);
                    }
                    parameterlist.RemoveAll(u => !u.ParameterType.Contains(comp));
                    foreach (Parameter l in parameterlist)
                    {
                        this._KAuxiliaries.Add(l.ParameterValue);
                    }

                }

                return this._KAuxiliaries;
            }

            set
            {
                if (_KAuxiliaries != value)
                {
                    _KAuxiliaries = value;
                    OnPropertyChanged("KAuxiliaries");
                }
            }
        }

        #endregion KAuxiliaries

        #region TotalKAuxiliaries
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _TotalKAuxiliaries = default(double);

        /// <summary>
        /// Gets the total loss values of the auxiliaries of the actual calculation id.
        /// </summary>
        public double TotalKAuxiliaries
        {
            get
            {
                this._TotalKAuxiliaries = this._KAuxiliaries.Sum();
                return this._TotalKAuxiliaries;
            }
            set
            {
                if (_TotalKAuxiliaries != value)
                {
                    _TotalKAuxiliaries = value;
                    OnPropertyChanged("TotalKAuxiliaries");
                }
            }
        }

        #endregion TotalKAuxiliaries

        #region Time
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private double _Time;

        /// <summary>
        /// Gets the time for the servo closing of the actual calculation id.
        /// </summary>
        public double Time
        {
            get
            {
                
                var VM = new Model.ProjectClient();
                this._Time = VM.OrificeCalculationTime(this.ParameterCol.ToArray());
                return this._Time;
            }
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        #endregion Time

        #endregion Parameter

    }
}

