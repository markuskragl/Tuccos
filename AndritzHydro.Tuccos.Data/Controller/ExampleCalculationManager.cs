using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    public class ExampleCalculationManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Internal field for the property.
        /// </summary>
        private ExampleCalculationController _Controller = null;
        /// <summary>
        /// Provides the service to read from the database.
        /// </summary>
        private ExampleCalculationController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<ExampleCalculationController>();
                }
                return this._Controller;
            }
        }

        /// <summary>
        /// Provides all calculation templates.
        /// </summary>
        public ExampleCalculations GetExampleCalculations(string calcId)
        {
            try
            {
                return this.Controller.GetExampleCalculations(calcId);
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return new ExampleCalculations();
            }
        }


        /// <summary>
        /// Adds a  calculation to the database.
        /// </summary>
        /// <param name="exampleCalculation">The calculation which
        /// should be added.</param>
        public virtual void AddExampleCalculation(ExampleCalculation exampleCalculation)
        {
            try
            {
                this.Controller.AddExampleCalculation(exampleCalculation);
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new Core.ErrorOccurredEventArgs(ex));
            }
        }


    }

    public class ExampleCalculationExecute
    {

        public int ExampleCalculationSum(int a, int b)
        {
            int c = a + b;
            return c;

        }

        public int ExampleCalculationSubstract(int a, int b)
        {
            int c = a - b;
            return c;
        }
    }
}
