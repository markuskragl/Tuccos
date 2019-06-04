using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Extensions
{
    /// <summary>
    /// Supplies helpful extension methods.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Returns the path with the subfolder for the current culture.
        /// </summary>
        /// <param name="path">The directory name where a localized subfolder is needed.</param>
        /// <returns>The same path if no subfolder for the current culture exists
        /// or the path combined with the subfolder for the current culture.</returns>
        public static string GetLocalFolder(this string path)
        {
            var cultureCode = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            var newPath = System.IO.Path.Combine(path, cultureCode);

            while (!System.IO.Directory.Exists(newPath) && cultureCode != string.Empty)
            {
                var lastMinus = cultureCode.LastIndexOf('-');

                if (lastMinus != -1)
                {
                    cultureCode = cultureCode.Substring(0, lastMinus);
                }
                else
                {
                    cultureCode = string.Empty;
                }

                newPath = System.IO.Path.Combine(path, cultureCode);
           }

            return newPath;
        }
    }
}
