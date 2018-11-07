using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Test
{
    
    public partial class frmTest : Form
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        Process softKey;
        private delegate void show();
        private System.Threading.Timer tim;
        static int i = 0;
        Thread th = new Thread(qp);
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th.IsBackground = true;
            th.Start();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            //tim = new System.Threading.Timer(display, this, 0, 100);
            //Thread th = new Thread(display);
            //th.IsBackground = true;
            //th.Start();


        }
        public static void qp()
        {
            i++;
            Thread.Sleep(100);
        }
        private void display()
        {
            if (InvokeRequired)
            {
                show d = new show(display);
                textBox1.Invoke(d);
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            softKey=Process.Start("C:\\Windows\\System32\\osk.exe");
        }
    }
}
