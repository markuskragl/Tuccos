using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data.SubAssembly
{
    class BV : Project
    {

        private int? _RngNr = null;

        public int? RngNr
        {
            get
            {
                return this._RngNr;
            }

            set
            {
                this._RngNr = value;
            }
        }
    }
}
