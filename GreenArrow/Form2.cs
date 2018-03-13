using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swdimxpert;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
            Double[] obj = swSketch.GetLines();            

            for (int i = 0; i < obj.Length; i += 7)
            {
                textBox1.Text += "obj1.Addcurve(new Lines(" +   Math.Round(obj[i + 1], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " + 
                                                                Math.Round(obj[i + 2], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " + 
                                                                Math.Round(obj[i + 4], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " + 
                                                                Math.Round(obj[i + 5], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                if (obj[i] == 6) textBox1.Text += ", true";
                textBox1.Text += "));" + System.Environment.NewLine;
            }

            Double[] obj1 = swSketch.GetArcs();            
            
            for (int i = 0; i < obj1.Length; i += 11)
            {
                textBox1.Text += "obj1.Addcurve(new Arcs(" + Math.Round(obj1[i + 7], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " +
                                                                Math.Round(obj1[i + 8], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " +
                                                                Math.Round(obj1[i + 1], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " +
                                                                Math.Round(obj1[i + 2], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " +
                                                                Math.Round(obj1[i + 4], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " +
                                                                Math.Round(obj1[i + 5], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ", " +
                                                                Math.Round(obj1[i + 10], 14).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                if (obj1[i] == 6) textBox1.Text += ", true";
                textBox1.Text += "));" + System.Environment.NewLine;
            }
        }
        }
    
}
