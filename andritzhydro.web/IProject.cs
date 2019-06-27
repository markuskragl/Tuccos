using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace andritzhydro.web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iproject" in both code and config file together.
    [ServiceContract]
    public interface IProject
    {

        /// <summary>
        /// Returns all Projects
        /// </summary>
        [OperationContract]
        AndritzHydro.Tuccos.Data.Projects GetProjectList();


        /// <summary>
        /// Add a project to the database.
        /// </summary>
        /// <param name="ticket">The project which should be saved.</param>
        [OperationContract]
        void SaveProject(AndritzHydro.Tuccos.Data.Project project);


        /// <summary>
        /// Delete a project from the database.
        /// </summary>
        /// <param name="project">The project which should be deleted.</param>
        [OperationContract]
        void DeleteProject(AndritzHydro.Tuccos.Data.Project project);


        /// <summary>
        /// Returns all SubAssemlies
        /// </summary>
        [OperationContract]
        AndritzHydro.Tuccos.Data.SubAssemblies GetSubAssemblies();


        /// <summary>
        /// Returns all CalculationTemplates
        /// </summary>
        [OperationContract]
        AndritzHydro.Tuccos.Data.CalculationTemplates GetCalculationTemplates(int? SubId);


        /// <summary>
        /// Add a calculation to the database.
        /// </summary>
        [OperationContract]
        AndritzHydro.Tuccos.Data.Calculations GetCalculations(string projectId, int? subassemblyId);


        /// <summary>
        /// Delete a calculation from the database.
        /// </summary>
        /// <param name="calculation">The calculation which should be deleted.</param>
        [OperationContract]
        void DeleteCalculation(AndritzHydro.Tuccos.Data.Calculation calculation);


        /// <summary>
        /// Add a calculation to the database.
        /// </summary>
        /// <param name="calculation">The calculation which should be added.</param>
        [OperationContract]
        void AddCalculation(AndritzHydro.Tuccos.Data.Calculation calculation);


        /// <summary>
        /// Adds a calculation from the database.
        /// </summary>
        [OperationContract]
        AndritzHydro.Tuccos.Data.Calculations GetOrificeCalculation(int? calcId);


        /// <summary>
        /// Returns ExampleCalculation
        /// </summary>
        [OperationContract]
        AndritzHydro.Tuccos.Data.ExampleCalculations GetExampleCalculations(int calcId);


        /// <summary>
        /// Returns ExampleCalculationExecute
        /// </summary>
        [OperationContract]
        int ExampleCalculationSum(int a, int b);

        /// <summary>
        /// Add a example calculation to the database.
        /// </summary>
        /// <param name="exampleCalculation">The calculation which should be added.</param>
        [OperationContract]
        void AddExampleCalculation(AndritzHydro.Tuccos.Data.ExampleCalculation exampleCalculation);

        /// <summary>
        /// Add a example calculation to the database.
        /// </summary>
        /// <param name="calcId">The calculation id for the parameters which should be added.</param>
        [OperationContract]
        AndritzHydro.Tuccos.Data.Parameters GetParameters(int? calcId);

        /// <summary>
        /// Delete a calculation from the database.
        /// </summary>
        /// <param name="calculation">The calculation which should be deleted.</param>
        [OperationContract]
        double OrificeCalculationTime(AndritzHydro.Tuccos.Data.Parameter[] inputparameter);

        /// <summary>
        /// Add a parameter to the database.
        /// </summary>
        /// <param name="parameter">The parameter which should be saved.</param>
        [OperationContract]
        void AddParameter(AndritzHydro.Tuccos.Data.Parameter parameter);
        


    }
}
