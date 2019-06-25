using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.Controller
{
    public class CalculationManager : AndritzHydro.Core.Data.DataApplicationObject
    {
        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        /// <remarks>Nur das sollte bei einer anderen
        /// Datenbank ausgetauscht werden müssen.</remarks>
        private CalculationController _Controller = null;

        /// <summary>
        /// Ruft den Dienst zum Lesen und Schreiben
        /// der Lottodaten ab.
        /// </summary>
        private CalculationController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Context.Create<CalculationController>();
                }

                return this._Controller;
            }
        }


        /// <summary>
        /// Provides all calculations.
        /// </summary>
        public Calculations GetCalculations()
        {
            try
            {
                return this.Controller.GetCalculations();
            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return new Calculations();
            }
        }



        /// <summary>
        /// Adds a  calculation to the database.
        /// </summary>
        /// <param name="calculation">The calculation which
        /// should be added.</param>
        public virtual void AddCalculation(Calculation calculation)
        {
            try
            {
                this.Controller.AddCalculation(calculation);
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new Core.ErrorOccurredEventArgs(ex));
            }
        }


        /// <summary>
        /// Deletes a  calculation from the database.
        /// </summary>
        /// <param name="calculation">The calculation which
        /// should be deleted.</param>
        public virtual void DeleteCalculation(Calculation calculation)
        {
            try
            {
                this.Controller.DeleteCalculation(calculation);
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new Core.ErrorOccurredEventArgs(ex));
            }
        }



        /// <summary>
        /// Provides all orifice calculations.
        /// </summary>
        public Parameters GetParameters(int? calcId)
        {
            try
            {
                return this.Controller.GetParameters(calcId);

            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return new Parameters();
            }
        }

        /// <summary>
        /// Provides all orifice calculations.
        /// </summary>
        public double OrificeCalculationTime(Parameter[] inputparameter)
        {
            try
            {
                CalculationsCollection calc = new CalculationsCollection();
                
                return calc.OrificeCalculationTime(inputparameter);

            }
            catch (System.Exception ex)
            {
                this.Context.Log.WriteEntry(
                    $"{this} hat eine Ausnahme verursacht:\r\n{ex.Message}",
                    Core.Data.LogEntryType.Error);
                return 0;
            }
        }

        /// <summary>
        /// Adds a  parameter to the database.
        /// </summary>
        /// <param name="parameter">The parameter which
        /// should be added.</param>
        public virtual void AddParameter(Parameter parameter)
        {
            try
            {
                this.Controller.AddParameter(parameter);
            }
            catch (System.Exception ex)
            {
                this.OnErrorOccurred(new Core.ErrorOccurredEventArgs(ex));
            }
        }
    }
}
