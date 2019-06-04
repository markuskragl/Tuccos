using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core
{
    /// <summary>
    /// Provides the Context property for ApplicationObject classes.
    /// </summary>
    public interface IApplicationObject
    {
        /// <summary>
        /// Gets or sets the infrastructor object of the application
        /// </summary>
        AndritzHydro.Core.ApplicationContext Context { get; set; }
    }
}
