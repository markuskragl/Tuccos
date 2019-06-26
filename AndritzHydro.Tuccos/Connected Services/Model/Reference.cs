﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AndritzHydro.Tuccos.Model {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Project", Namespace="http://schemas.datacontract.org/2004/07/AndritzHydro.Tuccos.Data")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AndritzHydro.Tuccos.Model.SubAssembly))]
    public partial class Project : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProjectYearField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProjectId {
            get {
                return this.ProjectIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectIdField, value) != true)) {
                    this.ProjectIdField = value;
                    this.RaisePropertyChanged("ProjectId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProjectName {
            get {
                return this.ProjectNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectNameField, value) != true)) {
                    this.ProjectNameField = value;
                    this.RaisePropertyChanged("ProjectName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProjectYear {
            get {
                return this.ProjectYearField;
            }
            set {
                if ((this.ProjectYearField.Equals(value) != true)) {
                    this.ProjectYearField = value;
                    this.RaisePropertyChanged("ProjectYear");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubAssembly", Namespace="http://schemas.datacontract.org/2004/07/AndritzHydro.Tuccos.Data")]
    [System.SerializableAttribute()]
    public partial class SubAssembly : AndritzHydro.Tuccos.Model.Project {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SubAssemblyIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubAssemblyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SubAssemblyRngNrField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> SubAssemblyId {
            get {
                return this.SubAssemblyIdField;
            }
            set {
                if ((this.SubAssemblyIdField.Equals(value) != true)) {
                    this.SubAssemblyIdField = value;
                    this.RaisePropertyChanged("SubAssemblyId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SubAssemblyName {
            get {
                return this.SubAssemblyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SubAssemblyNameField, value) != true)) {
                    this.SubAssemblyNameField = value;
                    this.RaisePropertyChanged("SubAssemblyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> SubAssemblyRngNr {
            get {
                return this.SubAssemblyRngNrField;
            }
            set {
                if ((this.SubAssemblyRngNrField.Equals(value) != true)) {
                    this.SubAssemblyRngNrField = value;
                    this.RaisePropertyChanged("SubAssemblyRngNr");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CalculationTemplate", Namespace="http://schemas.datacontract.org/2004/07/AndritzHydro.Tuccos.Data")]
    [System.SerializableAttribute()]
    public partial class CalculationTemplate : AndritzHydro.Tuccos.Model.Calculation {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> CalculationTemplateIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> CalculationTemplateId {
            get {
                return this.CalculationTemplateIdField;
            }
            set {
                if ((this.CalculationTemplateIdField.Equals(value) != true)) {
                    this.CalculationTemplateIdField = value;
                    this.RaisePropertyChanged("CalculationTemplateId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Calculation", Namespace="http://schemas.datacontract.org/2004/07/AndritzHydro.Tuccos.Data")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AndritzHydro.Tuccos.Model.ExampleCalculation))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AndritzHydro.Tuccos.Model.CalculationTemplate))]
    public partial class Calculation : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CalculationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CalculationTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AndritzHydro.Tuccos.Model.Parameter[] InputParameterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SubAssemblyIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CalculationId {
            get {
                return this.CalculationIdField;
            }
            set {
                if ((this.CalculationIdField.Equals(value) != true)) {
                    this.CalculationIdField = value;
                    this.RaisePropertyChanged("CalculationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CalculationType {
            get {
                return this.CalculationTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.CalculationTypeField, value) != true)) {
                    this.CalculationTypeField = value;
                    this.RaisePropertyChanged("CalculationType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AndritzHydro.Tuccos.Model.Parameter[] InputParameter {
            get {
                return this.InputParameterField;
            }
            set {
                if ((object.ReferenceEquals(this.InputParameterField, value) != true)) {
                    this.InputParameterField = value;
                    this.RaisePropertyChanged("InputParameter");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProjectId {
            get {
                return this.ProjectIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectIdField, value) != true)) {
                    this.ProjectIdField = value;
                    this.RaisePropertyChanged("ProjectId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SubAssemblyId {
            get {
                return this.SubAssemblyIdField;
            }
            set {
                if ((this.SubAssemblyIdField.Equals(value) != true)) {
                    this.SubAssemblyIdField = value;
                    this.RaisePropertyChanged("SubAssemblyId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExampleCalculation", Namespace="http://schemas.datacontract.org/2004/07/AndritzHydro.Tuccos.Data")]
    [System.SerializableAttribute()]
    public partial class ExampleCalculation : AndritzHydro.Tuccos.Model.Calculation {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CalculationDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ParameteraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ParameterbField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ResultcField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CalculationDescription {
            get {
                return this.CalculationDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.CalculationDescriptionField, value) != true)) {
                    this.CalculationDescriptionField = value;
                    this.RaisePropertyChanged("CalculationDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Parametera {
            get {
                return this.ParameteraField;
            }
            set {
                if ((this.ParameteraField.Equals(value) != true)) {
                    this.ParameteraField = value;
                    this.RaisePropertyChanged("Parametera");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Parameterb {
            get {
                return this.ParameterbField;
            }
            set {
                if ((this.ParameterbField.Equals(value) != true)) {
                    this.ParameterbField = value;
                    this.RaisePropertyChanged("Parameterb");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Resultc {
            get {
                return this.ResultcField;
            }
            set {
                if ((this.ResultcField.Equals(value) != true)) {
                    this.ResultcField = value;
                    this.RaisePropertyChanged("Resultc");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Parameter", Namespace="http://schemas.datacontract.org/2004/07/AndritzHydro.Tuccos.Data")]
    [System.SerializableAttribute()]
    public partial class Parameter : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CalculationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParameterTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParameterUnitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ParameterValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CalculationId {
            get {
                return this.CalculationIdField;
            }
            set {
                if ((this.CalculationIdField.Equals(value) != true)) {
                    this.CalculationIdField = value;
                    this.RaisePropertyChanged("CalculationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParameterType {
            get {
                return this.ParameterTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ParameterTypeField, value) != true)) {
                    this.ParameterTypeField = value;
                    this.RaisePropertyChanged("ParameterType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParameterUnit {
            get {
                return this.ParameterUnitField;
            }
            set {
                if ((object.ReferenceEquals(this.ParameterUnitField, value) != true)) {
                    this.ParameterUnitField = value;
                    this.RaisePropertyChanged("ParameterUnit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double ParameterValue {
            get {
                return this.ParameterValueField;
            }
            set {
                if ((this.ParameterValueField.Equals(value) != true)) {
                    this.ParameterValueField = value;
                    this.RaisePropertyChanged("ParameterValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Model.IProject")]
    public interface IProject {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetProjectList", ReplyAction="http://tempuri.org/IProject/GetProjectListResponse")]
        AndritzHydro.Tuccos.Model.Project[] GetProjectList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetProjectList", ReplyAction="http://tempuri.org/IProject/GetProjectListResponse")]
        System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.Project[]> GetProjectListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/SaveProject", ReplyAction="http://tempuri.org/IProject/SaveProjectResponse")]
        void SaveProject(AndritzHydro.Tuccos.Model.Project project);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/SaveProject", ReplyAction="http://tempuri.org/IProject/SaveProjectResponse")]
        System.Threading.Tasks.Task SaveProjectAsync(AndritzHydro.Tuccos.Model.Project project);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/DeleteProject", ReplyAction="http://tempuri.org/IProject/DeleteProjectResponse")]
        void DeleteProject(AndritzHydro.Tuccos.Model.Project project);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/DeleteProject", ReplyAction="http://tempuri.org/IProject/DeleteProjectResponse")]
        System.Threading.Tasks.Task DeleteProjectAsync(AndritzHydro.Tuccos.Model.Project project);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetSubAssemblies", ReplyAction="http://tempuri.org/IProject/GetSubAssembliesResponse")]
        AndritzHydro.Tuccos.Model.SubAssembly[] GetSubAssemblies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetSubAssemblies", ReplyAction="http://tempuri.org/IProject/GetSubAssembliesResponse")]
        System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.SubAssembly[]> GetSubAssembliesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetCalculationTemplates", ReplyAction="http://tempuri.org/IProject/GetCalculationTemplatesResponse")]
        AndritzHydro.Tuccos.Model.CalculationTemplate[] GetCalculationTemplates(System.Nullable<int> SubId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetCalculationTemplates", ReplyAction="http://tempuri.org/IProject/GetCalculationTemplatesResponse")]
        System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.CalculationTemplate[]> GetCalculationTemplatesAsync(System.Nullable<int> SubId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetCalculations", ReplyAction="http://tempuri.org/IProject/GetCalculationsResponse")]
        AndritzHydro.Tuccos.Model.Calculation[] GetCalculations(string projectId, System.Nullable<int> subassemblyId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetCalculations", ReplyAction="http://tempuri.org/IProject/GetCalculationsResponse")]
        System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.Calculation[]> GetCalculationsAsync(string projectId, System.Nullable<int> subassemblyId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/DeleteCalculation", ReplyAction="http://tempuri.org/IProject/DeleteCalculationResponse")]
        void DeleteCalculation(AndritzHydro.Tuccos.Model.Calculation calculation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/DeleteCalculation", ReplyAction="http://tempuri.org/IProject/DeleteCalculationResponse")]
        System.Threading.Tasks.Task DeleteCalculationAsync(AndritzHydro.Tuccos.Model.Calculation calculation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/AddCalculation", ReplyAction="http://tempuri.org/IProject/AddCalculationResponse")]
        void AddCalculation(AndritzHydro.Tuccos.Model.Calculation calculation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/AddCalculation", ReplyAction="http://tempuri.org/IProject/AddCalculationResponse")]
        System.Threading.Tasks.Task AddCalculationAsync(AndritzHydro.Tuccos.Model.Calculation calculation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetExampleCalculations", ReplyAction="http://tempuri.org/IProject/GetExampleCalculationsResponse")]
        AndritzHydro.Tuccos.Model.ExampleCalculation[] GetExampleCalculations(int calcId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetExampleCalculations", ReplyAction="http://tempuri.org/IProject/GetExampleCalculationsResponse")]
        System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.ExampleCalculation[]> GetExampleCalculationsAsync(int calcId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/ExampleCalculationSum", ReplyAction="http://tempuri.org/IProject/ExampleCalculationSumResponse")]
        int ExampleCalculationSum(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/ExampleCalculationSum", ReplyAction="http://tempuri.org/IProject/ExampleCalculationSumResponse")]
        System.Threading.Tasks.Task<int> ExampleCalculationSumAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/AddExampleCalculation", ReplyAction="http://tempuri.org/IProject/AddExampleCalculationResponse")]
        void AddExampleCalculation(AndritzHydro.Tuccos.Model.ExampleCalculation exampleCalculation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/AddExampleCalculation", ReplyAction="http://tempuri.org/IProject/AddExampleCalculationResponse")]
        System.Threading.Tasks.Task AddExampleCalculationAsync(AndritzHydro.Tuccos.Model.ExampleCalculation exampleCalculation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetParameters", ReplyAction="http://tempuri.org/IProject/GetParametersResponse")]
        AndritzHydro.Tuccos.Model.Parameter[] GetParameters(System.Nullable<int> calcId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/GetParameters", ReplyAction="http://tempuri.org/IProject/GetParametersResponse")]
        System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.Parameter[]> GetParametersAsync(System.Nullable<int> calcId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/OrificeCalculationTime", ReplyAction="http://tempuri.org/IProject/OrificeCalculationTimeResponse")]
        double OrificeCalculationTime(AndritzHydro.Tuccos.Model.Parameter[] inputparameter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/OrificeCalculationTime", ReplyAction="http://tempuri.org/IProject/OrificeCalculationTimeResponse")]
        System.Threading.Tasks.Task<double> OrificeCalculationTimeAsync(AndritzHydro.Tuccos.Model.Parameter[] inputparameter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/AddParameter", ReplyAction="http://tempuri.org/IProject/AddParameterResponse")]
        void AddParameter(AndritzHydro.Tuccos.Model.Parameter parameter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/AddParameter", ReplyAction="http://tempuri.org/IProject/AddParameterResponse")]
        System.Threading.Tasks.Task AddParameterAsync(AndritzHydro.Tuccos.Model.Parameter parameter);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProjectChannel : AndritzHydro.Tuccos.Model.IProject, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProjectClient : System.ServiceModel.ClientBase<AndritzHydro.Tuccos.Model.IProject>, AndritzHydro.Tuccos.Model.IProject {
        
        public ProjectClient() {
        }
        
        public ProjectClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProjectClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProjectClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProjectClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AndritzHydro.Tuccos.Model.Project[] GetProjectList() {
            return base.Channel.GetProjectList();
        }
        
        public System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.Project[]> GetProjectListAsync() {
            return base.Channel.GetProjectListAsync();
        }
        
        public void SaveProject(AndritzHydro.Tuccos.Model.Project project) {
            base.Channel.SaveProject(project);
        }
        
        public System.Threading.Tasks.Task SaveProjectAsync(AndritzHydro.Tuccos.Model.Project project) {
            return base.Channel.SaveProjectAsync(project);
        }
        
        public void DeleteProject(AndritzHydro.Tuccos.Model.Project project) {
            base.Channel.DeleteProject(project);
        }
        
        public System.Threading.Tasks.Task DeleteProjectAsync(AndritzHydro.Tuccos.Model.Project project) {
            return base.Channel.DeleteProjectAsync(project);
        }
        
        public AndritzHydro.Tuccos.Model.SubAssembly[] GetSubAssemblies() {
            return base.Channel.GetSubAssemblies();
        }
        
        public System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.SubAssembly[]> GetSubAssembliesAsync() {
            return base.Channel.GetSubAssembliesAsync();
        }
        
        public AndritzHydro.Tuccos.Model.CalculationTemplate[] GetCalculationTemplates(System.Nullable<int> SubId) {
            return base.Channel.GetCalculationTemplates(SubId);
        }
        
        public System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.CalculationTemplate[]> GetCalculationTemplatesAsync(System.Nullable<int> SubId) {
            return base.Channel.GetCalculationTemplatesAsync(SubId);
        }
        
        public AndritzHydro.Tuccos.Model.Calculation[] GetCalculations(string projectId, System.Nullable<int> subassemblyId) {
            return base.Channel.GetCalculations(projectId, subassemblyId);
        }
        
        public System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.Calculation[]> GetCalculationsAsync(string projectId, System.Nullable<int> subassemblyId) {
            return base.Channel.GetCalculationsAsync(projectId, subassemblyId);
        }
        
        public void DeleteCalculation(AndritzHydro.Tuccos.Model.Calculation calculation) {
            base.Channel.DeleteCalculation(calculation);
        }
        
        public System.Threading.Tasks.Task DeleteCalculationAsync(AndritzHydro.Tuccos.Model.Calculation calculation) {
            return base.Channel.DeleteCalculationAsync(calculation);
        }
        
        public void AddCalculation(AndritzHydro.Tuccos.Model.Calculation calculation) {
            base.Channel.AddCalculation(calculation);
        }
        
        public System.Threading.Tasks.Task AddCalculationAsync(AndritzHydro.Tuccos.Model.Calculation calculation) {
            return base.Channel.AddCalculationAsync(calculation);
        }
        
        public AndritzHydro.Tuccos.Model.ExampleCalculation[] GetExampleCalculations(int calcId) {
            return base.Channel.GetExampleCalculations(calcId);
        }
        
        public System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.ExampleCalculation[]> GetExampleCalculationsAsync(int calcId) {
            return base.Channel.GetExampleCalculationsAsync(calcId);
        }
        
        public int ExampleCalculationSum(int a, int b) {
            return base.Channel.ExampleCalculationSum(a, b);
        }
        
        public System.Threading.Tasks.Task<int> ExampleCalculationSumAsync(int a, int b) {
            return base.Channel.ExampleCalculationSumAsync(a, b);
        }
        
        public void AddExampleCalculation(AndritzHydro.Tuccos.Model.ExampleCalculation exampleCalculation) {
            base.Channel.AddExampleCalculation(exampleCalculation);
        }
        
        public System.Threading.Tasks.Task AddExampleCalculationAsync(AndritzHydro.Tuccos.Model.ExampleCalculation exampleCalculation) {
            return base.Channel.AddExampleCalculationAsync(exampleCalculation);
        }
        
        public AndritzHydro.Tuccos.Model.Parameter[] GetParameters(System.Nullable<int> calcId) {
            return base.Channel.GetParameters(calcId);
        }
        
        public System.Threading.Tasks.Task<AndritzHydro.Tuccos.Model.Parameter[]> GetParametersAsync(System.Nullable<int> calcId) {
            return base.Channel.GetParametersAsync(calcId);
        }
        
        public double OrificeCalculationTime(AndritzHydro.Tuccos.Model.Parameter[] inputparameter) {
            return base.Channel.OrificeCalculationTime(inputparameter);
        }
        
        public System.Threading.Tasks.Task<double> OrificeCalculationTimeAsync(AndritzHydro.Tuccos.Model.Parameter[] inputparameter) {
            return base.Channel.OrificeCalculationTimeAsync(inputparameter);
        }
        
        public void AddParameter(AndritzHydro.Tuccos.Model.Parameter parameter) {
            base.Channel.AddParameter(parameter);
        }
        
        public System.Threading.Tasks.Task AddParameterAsync(AndritzHydro.Tuccos.Model.Parameter parameter) {
            return base.Channel.AddParameterAsync(parameter);
        }
    }
}
