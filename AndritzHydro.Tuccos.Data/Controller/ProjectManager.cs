using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    public class ProjectManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private ProjectController _Controller = null;
        /// <summary>
        /// Provides the service to read from the database.
        /// </summary>
        private ProjectController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<ProjectController>();
                }

                return this._Controller;
            }
        }


        /// <summary>
        /// Provides all projects.
        /// </summary>
        public Projects GetProjectList()
        {
            try
            {
                return this.Controller.GetProjectList();
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return new Projects();
            }
        }


        /// <summary>
        /// Adds a  project to the database.
        /// </summary>
        /// <param name="project">The project which
        /// should be added.</param>
        public virtual void SaveProject(Project project)
        {
            try
            {
                this.Controller.SaveProject(project);
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new Core.ErrorOccurredEventArgs(ex));
            }
        }


        /// <summary>
        /// Deletes a  project from the database.
        /// </summary>
        /// <param name="project">The project which
        /// should be deleted.</param>
        public virtual void DeleteProject(Project project)
        {
            try
            {
                this.Controller.DeleteProject(project);
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new Core.ErrorOccurredEventArgs(ex));
            }
        }
    }
}
