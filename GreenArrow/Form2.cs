using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GreenArrow
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        protected SldWorks SwApp;
        protected ModelDoc2 swModel;
        protected Sketch swSketch;

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processers = Process.GetProcessesByName("SLDWORKS.exe");
            foreach (Process process in processers)
            {
                process.CloseMainWindow();
                process.Kill();
            }

            //створення процесу
            object processSW = System.Activator.CreateInstance(System.Type.GetTypeFromProgID("SldWorks.Application"));

            SwApp = (SldWorks)processSW;
            SwApp.Visible = true;

            swModel = SwApp.IActiveDoc2;

            swSketch = swModel.GetActiveSketch();
            MessageBox.Show(""+swSketch.GetLineCount());
            Double[] obj = swSketch.GetLines();
            MessageBox.Show("" + obj.GetLength(0));
            //foreach(Double i in obj)
            //{
            //    textBox1.Text += i + " ";
            //}

            for (int i = 0; i < obj.Length; i += 7)
            {
                textBox1.Text += "{" + obj[i] + ",\t" + obj[i+1] + ",\t" + obj[i+2] + ",\t" + obj[i+3] + ",\t" + obj[i+4] + ",\t" + obj[i+5] + ",\t" + obj[i+6] + "}," + System.Environment.NewLine;
            }
        }
    }
}
