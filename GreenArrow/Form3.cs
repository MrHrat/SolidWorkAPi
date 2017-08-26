using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO; // это для работы с файлами
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization; //это для сохранения классов — что и есть серилизация (стрёмное слово)
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;

namespace GreenArrow
{
    public partial class Form3 : Form
    {
        public Form3()
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
            //SwApp.SendMsgToUser2("Привет, Solidworks! ", (int)swMessageBoxIcon_e.swMbInformation, (int)swMessageBoxBtn_e.swMbOk);
            
            //створення моделі
            SwApp.NewDocument(@"C:\ProgramData\SolidWorks\SolidWorks 2013\templates\Part.prtdot", 0, 0, 0);
            
            swModel = SwApp.IActiveDoc2;
            SwApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
            swModel.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);

            Skeths obj = new Skeths();
            obj.Addcurve(new Lines(0, 0, 0, 0.12, true));
            obj.Addcurve(new Lines(0.044, 0.0, 0.075, 0.0));
            obj.Addcurve(new Lines(0.078, 0.003, 0.13, 0.003));
            obj.Addcurve(new Lines(0.13, 0.003, 0.22, 0.022));
            obj.Addcurve(new Lines(0.22, 0.022, 0.22, 0.03));

            obj.Addcurve(new Lines(0.22, 0.03, 0.092, 0.03));
            obj.Addcurve(new Lines(0.092, 0.03, 0.092, 0.043));
            obj.Addcurve(new Lines(0.092, 0.043, 0.1025, 0.043));
            obj.Addcurve(new Lines(0.1025, 0.043, 0.104, 0.0445));
            obj.Addcurve(new Lines(0.104, 0.0445, 0.104, 0.0625));

            obj.Addcurve(new Lines(0.104, 0.0625, 0.1025, 0.064));
            obj.Addcurve(new Lines(0.1025, 0.064, 0.06675, 0.064));
            obj.Addcurve(new Lines(0.06525, 0.0655, 0.06525, 0.069293));
            obj.Addcurve(new Lines(0.065543, 0.07, 0.0675, 0.071957));
            obj.Addcurve(new Lines(0.0675, 0.071957, 0.0675, 0.118));

            obj.Addcurve(new Lines(0.0675, 0.118, 0.0655, 0.12));
            obj.Addcurve(new Lines(0.0655, 0.12, 0.0455, 0.12));
            obj.Addcurve(new Lines(0.0455, 0.12, 0.0455, 0.1165));
            obj.Addcurve(new Lines(0.0455, 0.1165, 0.044, 0.115));
            obj.Addcurve(new Lines(0.044, 0.115, 0.044, 0.0));

            obj.Addcurve(new Arcs(0.078, 0.0, 0.075, 0.0, 0.078, 0.003, -1));
            obj.Addcurve(new Arcs(0.06675, 0.0655, 0.06675, 0.064, 0.06525, 0.0655, -1));
            obj.Addcurve(new Arcs(0.06625, 0.069293, 0.06525, 0.069293, 0.065543, 0.07, 1));

            obj.Addholdon("sgFIXED", new string[] { "0", "1"});
            obj.Addholdon("sgVERTICAL2D", new string[] { "4", "6", "9", "12", "14", "17", "19" });
            obj.Addholdon("sgHORIZONTAL2D", new string[] { "2", "5", "7", "11", "16"});
            obj.Addholdon("sgTANGENT", new string[] { "2", "20" });
            obj.Addholdon("sgTANGENT", new string[] { "11", "21" });
            obj.Addholdon("sgTANGENT", new string[] { "12", "21" });
            obj.Addholdon("sgTANGENT", new string[] { "12", "22" });
            obj.Addholdon("sgTANGENT", new string[] { "13", "22" });
            obj.Addholdon("sgSAMELENGTH", new string[] { "8", "10" });

            obj.AddDimensions("L1", "P1", 5.0, 0.01, -0.01, new string[] { "0", "19"});
            obj.AddDimensions("L2", "P2", 7.0, 0.01, -0.015, new string[] { "0", "Point4"});
            obj.AddDimensions("L3", "P3", 7.0, 0.01, -0.02, new string[] { "0", "6" });
            obj.AddDimensions("L4", "P4", 7.0, 0.01, -0.025, new string[] { "Point6", "4" });
            obj.AddDimensions("L" , "P5", 7.0, 0.01, -0.03, new string[] { "0", "4" });

            obj.AddDimensions("A1", "P6", 7.0, 0.01, 0.01, new string[] { "Point4", "2" });
            obj.AddDimensions("A2", "P7", 7.0, -0.01, 0.0127, new string[] { "2", "Point8" });
            obj.AddDimensions("A3", "P7", 7.0, -0.01, 0.0127, new string[] { "2", "5" });

            obj.AddDimensions("B1", "P7", 7.0, 0.01, 0.04, new string[] { "5", "7" });
            obj.AddDimensions("B2", "P7", 7.0, 0.016, 0.046, new string[] { "7", "Point18" });
            obj.AddDimensions("B3", "P7", 7.0, 0.016, 0.046, new string[] { "7", "11" });

            obj.AddDimensions("C1", "P7", 7.0, 0.054, 0.067, new string[] { "11", "Point27" });
            obj.AddDimensions("C2", "P7", 7.0, 0.082, 0.088, new string[] { "Point27", "16" });
            obj.AddDimensions("C3", "P7", 7.0, 0.012, 0.0011, new string[] { "17" });

            obj.AddDimensions("P", "P7", 7.0, 0.052, 0.0014, new string[] { "0", "9" });
            obj.AddDimensions("P1", "P7", 7.0, 0.052, 0.0014, new string[] { "0", "12" });
            obj.AddDimensions("P2", "P7", 7.0, 0.052, 0.0014, new string[] { "0", "14" });
            obj.AddDimensions("P3", "P7", 7.0, 0.052, 0.0014, new string[] { "0", "17" });
            obj.AddDimensions("P4", "P7", 7.0, 0.052, 0.0014, new string[] { "14", "Point32" });

            obj.AddDimensions("R1", "P7", 7.0, 0.052, 0.0014, new string[] { "Arc1" });
            obj.AddDimensions("R2", "P7", 7.0, 0.052, 0.0014, new string[] { "Arc2" });
            obj.AddDimensions("R3", "P7", 7.0, 0.052, 0.0014, new string[] { "Arc3" });

            obj.AddDimensions("", "P7", 7.0, 0.052, 0.0014, new string[] { "Line8", "Line9" });
            obj.AddDimensions("", "P7", 7.0, 0.052, 0.0014, new string[] { "Line11", "Line12" });
            obj.AddDimensions("", "P7", 7.0, 0.052, 0.0014, new string[] { "Line13", "Line14" });
            obj.AddDimensions("", "P7", 7.0, 0.052, 0.0014, new string[] { "Line16", "Line17" });
            obj.AddDimensions("", "P7", 7.0, 0.052, 0.0014, new string[] { "Line19", "Line20" });

            //BindingList<Icurve> obj = new BindingList<Icurve>();
            //obj.Add(new Lines(0, 0, 0, 0.12));           

            obj = new FeatureRevolve(obj, swModel, true, true, false, false, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);
            obj.Bild(swModel);           
            
            //SwApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
            using (Stream writer = new FileStream("temple.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Skeths obj = new Skeths();
            // загружаем данные из файла program.xml 
            using (Stream stream = new FileStream("temple.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                // в тут же созданную копию класса iniSettings под именем iniSet
                obj = (Skeths)serializer.Deserialize(stream);

                MessageBox.Show(obj.line[0].ShowParam());

            }
        }
    }
}
