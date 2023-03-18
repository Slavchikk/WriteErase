using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteErase.classes
{
    public partial class PointIssueD
    {
        public string punkt
        {
            get
            {
                return PostCode + " " + City + " " + Street + " " + NumberHome + ".";
               // return null;
            }
            set
            {

            }
        }
    }
}
