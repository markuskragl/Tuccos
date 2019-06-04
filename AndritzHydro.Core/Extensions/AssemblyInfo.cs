using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Extensions
{
    /// <summary>
    /// Provides the assembly info as extensions to methods.
    /// </summary>
    /// <remarks>To activate the extensions type "using Extensions" namespace</remarks>
    public static class AssemblyInfo
    {
        /// <summary>
        /// Returns the AssemblyCompanyAttribute setting.
        /// </summary>
        public static string GetCompany(this object instance)
        {
            var values = System.Reflection.Assembly.GetEntryAssembly()
                .GetCustomAttributes(
                    typeof(System.Reflection.AssemblyCompanyAttribute),
                    inherit: false);

            if (values.Length > 0)
            {
                return ((System.Reflection.AssemblyCompanyAttribute)values[0]).Company;
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns the AssemblyTitleAttribute setting.
        /// </summary>
        public static string GetTitle(this object instance)
        {
            var values = System.Reflection.Assembly.GetEntryAssembly()
                .GetCustomAttributes(
                    typeof(System.Reflection.AssemblyTitleAttribute),
                    inherit: false);

            if (values.Length > 0)
            {
                return ((System.Reflection.AssemblyTitleAttribute)values[0]).Title;
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns the assembly version attribute.
        /// </summary>
        /// <returns>Only Major and Minor version, e.g. "1.0"</returns>
        public static string GetVersion(this object instance)
        {
            var assemblyVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

            return $"{assemblyVersion.Major}.{assemblyVersion.Minor}";
        }

        /// <summary>
        /// Returns the AssemblyCopyrightAttribute setting.
        /// </summary>
        public static string GetCopyright(this object instance)
        {
            var values = System.Reflection.Assembly.GetEntryAssembly()
                .GetCustomAttributes(
                    typeof(System.Reflection.AssemblyCopyrightAttribute),
                    inherit: false);

            if (values.Length > 0)
            {
                return ((System.Reflection.AssemblyCopyrightAttribute)values[0]).Copyright;
            }

            return string.Empty;
        }
    }
}
