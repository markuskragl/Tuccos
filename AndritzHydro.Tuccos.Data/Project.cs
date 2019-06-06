using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndritzHydro.Tuccos.Data
{
    public class Project
    {

        private string _ProjectId = "FEN17";

        public string ProjectId
        {
            get
            {
                return this._ProjectId;
            }

            set
            {
                this._ProjectId = value;
            }
        }

        private string _ProjectName = "Feng Ning 2";

        public string ProjectName
        {
            get
            {
                return this._ProjectName;
            }

            set
            {
                this._ProjectName = value;
            }
        }

        private int _ProjectYear = 2017;

        public int ProjectYear
        {
            get
            {
                return this._ProjectYear;
            }

            set
            {
                this._ProjectYear = value;
            }
        }

        private System.Collections.Generic.List<object> _Subassembly = new List<object>();

        public List<object> Subassembly
        {
            get
            {
                _Subassembly.Add("Valve 1");
                _Subassembly.Add("GVM 2");
                return this._Subassembly;
            }

            set
            {
                this._Subassembly = value;
            }
        }



    }
}


