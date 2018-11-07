using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACA_Common
{
    public partial class ButtonNew : Button
    {
        private string address;
        private string stateAddress;
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

        public string StateAddress
        {
            get
            {
                return stateAddress;
            }

            set
            {
                stateAddress = value;
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

        public ButtonNew()
        {
            InitializeComponent();
        }

        //public string Address { get{} address; set{} address = value; }
        //public string StateAddress { get{} stateAddress; set{} stateAddress = value; }
        //public int No { get{} no; set{} no = value; }

        private void ButtonNew_Click(object sender, EventArgs e)
        {

        }
    }
}
