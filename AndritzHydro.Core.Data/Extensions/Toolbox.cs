using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Core.Data.Extensions
{
    /// <summary>
    /// Provides helper extension methods.
    /// </summary>
    public static class Toolbox
    {
        /// <summary>
        /// Returns the modified base path ended with the second path.
        /// </summary>
        /// <param name="basePath">The first part of the wished path</param>
        /// <param name="endPath">The second part of the wished path</param>
        /// <remarks>The existence of the path is not checked</remarks>
        public static string CreatePath(this string basePath, string endPath)
        {
            var baseParts = basePath.Split(System.IO.Path.DirectorySeparatorChar);
            var newParts = endPath.Split(System.IO.Path.DirectorySeparatorChar);
            var backCounter = (from p in newParts where p == ".." select p).Count();

            var parts = (from p in baseParts select p)
                            .Take(baseParts.Length - backCounter)
                        .Union((from p in newParts select p).Skip(backCounter))
                        .ToArray();

            if (parts.Length > 0 && parts[0].EndsWith(":"))
            {
                parts[0] += System.IO.Path.DirectorySeparatorChar;
            }

            return System.IO.Path.Combine(parts);
        }

        /// <summary>
        /// Returns a copy of the object.
        /// </summary>
        /// <typeparam name="T">Type of the needed object.</typeparam>
        /// <param name="source">The object where a copy is needed.</param>
        public static T CopyTo<T>(this object source) where T : new()
        {
            var r = new T();

            if (source == null)
            {
                return r;
            }

            foreach (var p in source.GetType().GetProperties())
            {
                var rP = r.GetType().GetProperty(p.Name);
                if (rP != null)
                {
                    if (p.PropertyType == rP.PropertyType)
                    {
                        rP.SetValue(r, p.GetValue(source));
                    }
                    else
                    {
                        if (!p.PropertyType.IsArray && !rP.PropertyType.IsArray)
                        {
                            //TODO: 
                            //Check if both sides are implementing
                            //System.Collections.IList or Arrays, if so you have to
                            //copy in a loop!

                            //This is called a recursion
                            //we call the method before finishing it
                            rP.SetValue(r, p.GetValue(source).CopyTo(rP.PropertyType));
                        }
                        else
                        {

                            //One of the properties is an array
                            if (!p.PropertyType.IsArray) //&& rP.PropertyType.IsArray)
                            {
                                var sourceData = p.GetValue(source) as System.Collections.IList;
                                var sourceDataType = p.PropertyType.BaseType.GenericTypeArguments[0];
                                var targetDataType = (from t in rP.PropertyType.Assembly.DefinedTypes
                                                      where t.Name == sourceDataType.Name
                                                      select t).FirstOrDefault();
                                var targetData = System.Array.CreateInstance(targetDataType, sourceData.Count);

                                for (int i = 0; i < sourceData.Count; i++)
                                {
                                    targetData.SetValue(sourceData[i].CopyTo(targetDataType), i);
                                }

                                rP.SetValue(r, targetData);
                            }
                            else //if (p.PropertyType.IsArray && !rP.PropertyType.IsArray)
                            {
                                var targetData = System.Activator.CreateInstance(rP.PropertyType) as System.Collections.IList;
                                var targetDataType = rP.PropertyType.BaseType.GenericTypeArguments[0];
                                var sourceData = p.GetValue(source) as System.Array;

                                foreach (var element in sourceData)
                                {
                                    targetData.Add(element.CopyTo(targetDataType));
                                }

                                rP.SetValue(r, targetData);
                            }
                        }
                    }
                }
            }

            return r;
        }

        /// <summary>
        /// Returns a copy of the object.
        /// </summary>
        /// <param name="source">The object where a copy is needed.</param>
        /// <param name="type">The type of the returned object</param>
        public static object CopyTo(this object source, Type type)
        {
            //Call the generic version CopyTo<T>()

            //Reason:   we don't want to modify
            //          the loop in two methods
            //var r = System.Activator.CreateInstance(type);

            //foreach (var p in source.GetType().GetProperties())
            //{
            //    var rP = r.GetType().GetProperty(p.Name);
            //    rP.SetValue(r, p.GetValue(source));
            //}

            //return r;

            var m = typeof(Toolbox).GetMethod("CopyTo", new Type[] { typeof(object) });

            return m.MakeGenericMethod(type).Invoke(null, new object[] { source });

        }


    }
}
