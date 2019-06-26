using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;


namespace AndritzHydro.Tuccos.Data
{
    /// <summary>
    /// Provides a class for the parameter
    /// </summary>
    public class Parameter
    {

        public int CalculationId { get; set; }

        public string ParameterType { get; set; }

        public double ParameterValue { get; set; }

        public string ParameterUnit { get; set; }

    }

    /// <summary>
    /// Provides a class for the parameter list
    /// </summary>
    public class Parameters : System.Collections.Generic.List<Parameter>
    {

    }

    /// <summary>
    /// Provides a class for the calculation
    /// </summary>
    public class Calculation
    {
        public string ProjectId { get; set; }

        public int SubAssemblyId { get; set; }

        public int CalculationId { get; set; }

        public string CalculationType { get; set; }

        public Parameters InputParameter { get; set; }
    }

    /// <summary>
    /// Provides a class for the calculation list
    /// </summary>
    public class Calculations : System.Collections.Generic.List<Calculation>
    {

    }

    /// <summary>
    /// Provides a set of different calculation methods
    /// </summary>
    public class CalculationsCollection
    {
        // Density of the oil
        // [kg/mm³]

        protected const double oil_density = 8E-10;

        // Dynamic oil viscosity
        // [MPa*s]

        protected const double oil_viscosity = 4E-7;

        /// <summary>
        /// Provides a calculation for the orifice time
        /// </summary>
        /// <param name="inputParameter"></param>
        /// <returns>time of orifice</returns>
        public double OrificeCalculationTime(Parameter[] inputParameter)
        {
            List<double> partialStroke = new List<double>();
            List<double> singleForce = new List<double>();
            List<double> k_Aux = new List<double>();
            double d_Cyl = default(double);
            double dI_Cyl = default(double);
            double d_Orifice = default(double);
            double l_OilPipe = default(double);
            double d_OilPipe = default(double);
            double lossValue = default(double);

            foreach (Parameter l in inputParameter)
            {
                var type = l.ParameterType;

                if (type.Contains("PartialStroke"))
                {
                    partialStroke.Add(l.ParameterValue);
                }
                else if (type.Contains("SingleForce"))
                {
                    singleForce.Add(l.ParameterValue);
                }
                else if (type.Contains("K_Aux"))
                {
                    k_Aux.Add(l.ParameterValue);
                }
                else if (type == "D_Cyl")
                {
                    d_Cyl = l.ParameterValue;
                }
                else if (type == "DI_Cyl")
                {
                    dI_Cyl = l.ParameterValue;
                }
                else if (type == "D_Orifice")
                {
                    d_Orifice = l.ParameterValue;
                }
                else if (type == "L_OilPipe")
                {
                    l_OilPipe = l.ParameterValue;
                }
                else if (type == "D_OilPipe")
                {
                    d_OilPipe = l.ParameterValue;
                }
                else if (type == "LossValue")
                {
                    lossValue = l.ParameterValue;
                }
                
            }

            // Step time for the iterative calculation
            // [mm³/s]

            double step = 0.01; 

            // Oil viscosity kinematic

            double oil_viscosity_kin = oil_viscosity / oil_density;

            // Cylinder area

            double a_Cyl = (Pow(d_Cyl, 2) - Pow(dI_Cyl, 2)) * PI / 4;

            // Pressure loss

            List<double> delta_p = new List<double> { };

            foreach (double l in singleForce)
            {
                delta_p.Add(l / a_Cyl);
            }

            // Orifice section

            double a_Orifice = Pow(d_Orifice, 2) * PI / 4;

            // Time initial

            List<double> t = new List<double> { };

            double k_Aux_sum = k_Aux.Sum();

            int i = 0;
            foreach (double l in partialStroke)
            {
                double delta_p_act = 0;
                double delta_p_orifice = 0;
                double delta_p_aux = 0;
                double delta_p_pipe = 0;
                double q_act = 0;

                do
                {
                    q_act = q_act + step;
                    delta_p_orifice = (oil_density / 2 * Pow(q_act / (Pow(d_Orifice, 2) * PI / 4), 2) * (lossValue));
                    delta_p_aux = q_act * k_Aux_sum;
                    delta_p_pipe = ((128 * l_OilPipe * oil_density * oil_viscosity_kin * q_act) / (Pow(d_OilPipe, 4) * PI));
                    delta_p_act = delta_p_orifice + delta_p_aux + delta_p_pipe;
                } while (delta_p[i] > delta_p_act);

                i += 1;
                t.Add(a_Cyl * l / q_act);
            }
            return t.Sum();
        }

    }


}
