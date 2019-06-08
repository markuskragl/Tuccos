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
        public double OrificeCalculationTime()
        {

            List<double> partialstroke = new List<double> {200,300,100};

            List<double> partialforce = new List<double> { 100, 200, 50 };

            double D_Cyl = 400; //[mm]

            double d_Cyl = 0; //[mm]

            double D_Orifice = 1.2; //[mm]

            double loss_value = 0.8; //[-]

            double oil_density = 8E-7; //[kg/mm³]

            double oil_viscosity = 4E-7; //[MPa*s]

            double oil_pipe_length = 10000; //[mm]

            double oil_pipe_diameter = 25; //[mm]

            //Cylinder

            double A_Cyl = (Math.Pow(D_Cyl,2) - Math.Pow(d_Cyl,2)) * Math.PI / 4;

            //Pressure loss

            List<double> delta_p = new List<double> { };

            foreach (double l in partialforce)
            {
                delta_p.Add(l / A_Cyl);
            }

            //Orifice 

            double A_Orifice = Math.Pow(D_Orifice,2) * Math.PI / 4;

            //Flow

            List<double> Q = new List<double> { };

            foreach (double l in delta_p)
            {
                Q.Add(loss_value*A_Orifice*Math.Sqrt(l/oil_density));
            }

            //Pressure loss in orifice

            List<double> delta_p_orifice = new List<double> { };

            foreach(double l in Q)
            {
                delta_p_orifice.Add(Math.Pow(l/(loss_value*A_Orifice),2)/(2/oil_density));
            }





            //Oil

            //

          

            return 0;
        }

    }
}
