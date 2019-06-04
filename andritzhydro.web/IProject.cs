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
    }
}
