using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AndritzHydro.Tuccos.Data


{
    /// <summary>
    /// Provides a set of different calculation methods
    /// </summary>
    public class Calculations 
    {

        /// <summary>
        /// Provides a calculation for the orifice time
        /// </summary>
        /// <returns></returns>
        double OrificeCalculationTime(List<double> partialstroke, List<double> partialforce, 
            double D_Cyl, double d_Cyl, double D_Orifice,
            double oil_pipe_length, double oil_pipe_diameter, double zeta_orifice, List<double> k_aux)
        {

            //List<double> partialstroke = new List<double> { 300, 200, 200, 200, 200, 200, 200, 200, 200 };

            //List<double> partialforce = new List<double> { 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500 };

            //double D_Cyl = 400; //[mm]

            //double d_Cyl = 0; //[mm]

            //double D_Orifice = 1.2; //[mm]

            const double oil_density = 8E-10; //[kg/mm³]

            const double oil_viscosity = 4E-7; //[MPa*s]

            //double oil_pipe_length = 10000; //[mm]

            //double oil_pipe_diameter = 25; //[mm]

            //double zeta_orifice = 1.562; //

            //List<double> k_aux = new List<double> { 0.00000, };

            //Step time for the iterative calculation

            double step = 0.01; //[mm³/s]

            //Oil viscosity kinematic

            double oil_viscosity_kin = oil_viscosity / oil_density;

            //Cylinder

            double A_Cyl = (Math.Pow(D_Cyl, 2) - Math.Pow(d_Cyl, 2)) * Math.PI / 4;

            //Pressure loss

            List<double> delta_p = new List<double> { };

            foreach (double l in partialforce)
            {
                delta_p.Add(l / A_Cyl);
            }

            //Orifice 

            double A_Orifice = Math.Pow(D_Orifice, 2) * Math.PI / 4;

            //Time initial

            List<double> t = new List<double> { };

            double k_aux_sum = k_aux.Sum();

            int i = 0;
            foreach (double l in partialstroke)
            {
                double delta_p_act = 0;
                double delta_p_orifice = 0;
                double delta_p_aux = 0;
                double delta_p_pipe = 0;
                double Q_act = 0;

                do
                {

                    Q_act = Q_act + step;

                    delta_p_orifice = (oil_density / 2 * Math.Pow(Q_act / (Math.Pow(D_Orifice, 2) * Math.PI / 4), 2) * (zeta_orifice));
                    delta_p_aux = Q_act * k_aux_sum;
                    delta_p_pipe = ((128 * oil_pipe_length * oil_density * oil_viscosity_kin * Q_act) / (Math.Pow(oil_pipe_diameter, 4) * Math.PI));

                    delta_p_act = delta_p_orifice + delta_p_aux + delta_p_pipe;

                } while (delta_p[i] > delta_p_act);

                i += 1;
                t.Add(A_Cyl * l / Q_act);
            }


            return t.Sum();
        }

    }
}
