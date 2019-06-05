using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Model
{
    /// <summary>
    /// Provides a service to manage the applications tasks.
    /// </summary>
    public class TaskManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private TaskList _List = null;

        /// <summary>
        /// Gets the features supported in the application.
        /// </summary>
        public TaskList List
        {
            get
            {
                if (this._List == null)
                {
                    this._List = this.CreateTaskList();
                    this.Context.Log.WriteEntry(
                        "The application initialized the tasks",
                        Core.Data.LogEntryType.NewObject);
                }

                return this._List;
            }
        }

        /// <summary>
        /// Returns the features of the application
        /// </summary>
        protected TaskList CreateTaskList()
        {
            var list = new TaskList();

            //Todo:
            list.Add(new Task(Properties.Strings.TaskProjectViewer, typeof(ProjectViewer)) { WingdingsIcon = "&" });
            list.Add(new Task(Properties.Strings.TaskProjectCreate, typeof(ProjectCreate)) { WingdingsIcon = "3" });
            //list.Add(new Task(Properties.Strings.TaskLotteryTip, typeof(LotteryTip)) { WingdingsIcon = "@" });
            //list.Add(new Task(Properties.Strings.TaskLotteryDistribution, typeof(LotteryDistribution)) { WingdingsIcon = "\u008C" });
            //list.Add(new Task(Properties.Strings.TaskLog, typeof(LogViewer)) { WingdingsIcon = "2" });

            return list;
        }
    }
}
