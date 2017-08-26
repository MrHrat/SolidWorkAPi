using System;
using System.Diagnostics;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

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

            /*swSketch = swModel.GetActiveSketch();
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
            }*/

            //ModelDoc2 swModel = default(ModelDoc2);

            ModelDocExtension swModelDocExt = default(ModelDocExtension);
            SelectionMgr swSelMgr = default(SelectionMgr);
            Feature swFeat = default(Feature);

            string featName = null;
            string featType = null;



            //swModel = (ModelDoc2)swApp.ActiveDoc;

            //swSelMgr = (SelectionMgr)swModel.SelectionManager;
            swSelMgr = (SelectionMgr)swModel.SelectionManager;
            //swModel

            swModelDocExt = (ModelDocExtension)swModel.Extension;

            swModelDocExt.SelectAll();

            // Get the selected feature

            //swFeat = (Feature)swSelMgr.GetSelectedObject6(1, -1);

            swModel.ClearSelection2(true);



            // Get the feature's type and name

            /*featName = swFeat.GetNameForSelection(out featType);

            swModelDocExt.SelectByID2(featName, featType, 0, 0, 0, true, 0, null, 0);*/



            // Print the feature's type and name

            // to the Immediate window

            textBox1.Text += "Feature type: " + featType + System.Environment.NewLine;

            textBox1.Text += "Feature name: " + featName + System.Environment.NewLine;
        }
        }
    
}
