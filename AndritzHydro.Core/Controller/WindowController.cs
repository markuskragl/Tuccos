using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Controller
{


    /*
     
    /// <summary>
    /// Reads or writes WindowList objects from or to Xml files.
    /// </summary>
    /// <remarks>Here's the Xml Serialization from .Net is shown.</remarks>
    internal class WindowController : AndritzHydro.Core.ApplicationObject
    {
        /// <summary>
        /// Writes the objects from the window list to a xml file.
        /// </summary>
        /// <param name="windows">The collection with the windows which should be saved.</param>
        /// <param name="path">The filename including the folder where the Xml file should be created.</param>
        public void SaveAsXml(AndritzHydro.Core.Data.WindowList windows, string path)
        {
            try
            {
                //"using" as a statement, not a directive (for extension methods)
                using (var writer = new System.IO.StreamWriter(path))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(windows.GetType());

                    serializer.Serialize(writer, windows);

                } // <- writer.Dispose() is called
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new ErrorOccurredEventArgs(ex));
            }
        }

        /// <summary>
        /// Returns the window collection created with SaveAsXml.
        /// </summary>
        /// <param name="path">The filename including the folder where the Xml file is located.</param>
        /// <returns>The content of the Xml file or an empty colletion</returns>
        /// <remarks>Best practice: Never return null!</remarks>
        public AndritzHydro.Core.Data.WindowList ReadXml(string path)
        {
            AndritzHydro.Core.Data.WindowList result = null;

            try
            {
                using (var reader = new System.IO.StreamReader(path))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(AndritzHydro.Core.Data.WindowList));

                    result = (AndritzHydro.Core.Data.WindowList)serializer.Deserialize(reader);
                }
            }
            catch (System.Exception ex)
            {
                result = new Data.WindowList();
                this.OnErrorOccurred(new ErrorOccurredEventArgs(ex));
            }

            return result;
        }
    }

    */

    /// <summary>
    /// Reads or writes WindowList objects from or to Xml files.
    /// </summary>
    /// <remarks>Here's the Xml Serialization from .Net is shown.</remarks>
    internal class WindowController 
        : AndritzHydro.Core.Generic.XmlController<AndritzHydro.Core.Data.WindowList>
    {

    }
}
