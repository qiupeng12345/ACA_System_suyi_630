using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACA_Common
{
   public class CheckNew:CheckBox
    {
        private string address;
        private int no;

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public int No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }
        //public string Address { get{} address; set{} address = value; }
        //public int No { get{} no; set{} no = value; }
    }
}
