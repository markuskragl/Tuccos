using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Generic
{
    /// <summary>
    /// Reads or writes List objects from or to Xml files.
    /// </summary>
    /// <remarks>Here's the Xml Serialization from .Net is shown.</remarks>
    public class XmlController<T> : AndritzHydro.Core.ApplicationObject where T : new()
    {
        /// <summary>
        /// Writes the objects from the list to a xml file.
        /// </summary>
        /// <param name="data">The collection which should be saved.</param>
        /// <param name="path">The filename including the folder where the Xml file should be created.</param>
        public void SaveAsXml(T data, string path)
        {
            try
            {
                //"using" as a statement, not a directive (for extension methods)
                using (var writer = new System.IO.StreamWriter(path))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(data.GetType());

                    serializer.Serialize(writer, data);

                } // <- writer.Dispose() is called
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new ErrorOccurredEventArgs(ex));
            }
        }

        /// <summary>
        /// Returns the collection created with SaveAsXml.
        /// </summary>
        /// <param name="path">The filename including the folder where the Xml file is located.</param>
        /// <returns>The content of the Xml file or an empty colletion</returns>
        /// <remarks>Best practice: Never return null!</remarks>
        public T ReadXml(string path)
        {
            T result = default(T);

            try
            {
                using (var reader = new System.IO.StreamReader(path))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                    result = (T)serializer.Deserialize(reader);
                }
            }
            catch (System.Exception ex)
            {
                result = new T();
                this.OnErrorOccurred(new ErrorOccurredEventArgs(ex));
            }

            return result;
        }
    }
}
