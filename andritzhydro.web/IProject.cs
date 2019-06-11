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
        /// Returns the supportet countries.
        /// </summary>
        /// <param name="language">Microsoft code for the used language</param>
        [OperationContract]
        AndritzHydro.Tuccos.Data.Countries GetCountries(string language);

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

    }
}
