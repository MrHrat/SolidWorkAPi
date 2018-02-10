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


            //SldWorks SwApp = (SldWorks)System.Runtime.InteropServices.Marshal.GetActiveObject("sldworks.Application");

            //ModelDoc2 SwModel = (ModelDoc2)SwApp.ActiveDoc;

            //DrawingDoc SwDraw = (DrawingDoc)SwModel;

            //Activating the drawing view and add the dimension.

            //MessageBox.Show(""+swSketch.GetLineCount());
            Double[] obj = swSketch.GetLines();
            //MessageBox.Show("" + obj.GetLength(0));
            //foreach(Double i in obj)
            //{
            //    textBox1.Text += i + " ";
            //}

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
            //MessageBox.Show("" + obj.GetLength(0));
            //foreach(Double i in obj)
            //{
            //    textBox1.Text += i + " ";
            //}

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
            /*
            //ModelDoc2 swModel = default(ModelDoc2);

            //ModelDocExtension swModelDocExt = default(ModelDocExtension);
            SelectionMgr swSelMgr = default(SelectionMgr);
            Feature swFeat = default(Feature);
            
            string featName = null;
            string featType = null;



            //swModel = (ModelDoc2)swApp.ActiveDoc;

            //swSelMgr = (SelectionMgr)swModel.SelectionManager;
            swSelMgr = (SelectionMgr)swModel.SelectionManager;
            //swModel

            //swModelDocExt = (ModelDocExtension)swModel.Extension;

            //swModelDocExt.SelectAll();

            // Get the selected feature

            swFeat = (Feature)swSelMgr.GetSelectedObject6(1, -1);

            swModel.ClearSelection2(true);
            
            featName = swFeat.GetNameForSelection(out featType);

            SketchRelationManager swSkRelMgr = default(SketchRelationManager);
            swSkRelMgr = swSketch.RelationManager;
            object[] vSkRelArr = null;
            object[] vDefEntArr = null;
            vSkRelArr = (object[])swSkRelMgr.GetRelations((int)swSketchRelationFilterType_e.swAll);

            //swModelDocExt.SelectByID2(featName, featType, 0, 0, 0, true, 0, null, 0);
  
            textBox1.Text += "Feature type: " + featType + System.Environment.NewLine;
            textBox1.Text += "Feature name: " + featName + System.Environment.NewLine;            

            int i = 0, j = 0;
            SketchRelation swSkRel = default(SketchRelation);
            SketchPoint swSkPt = default(SketchPoint);
            SketchSegment swSkSeg = default(SketchSegment);
            int[] vEntTypeArr = null;
            object[] vEntArr = null;

            foreach (SketchRelation vRel in vSkRelArr)
            {
                swSkRel = (SketchRelation)vRel;

                textBox1.Text += "    Relation(" + i + ")" + System.Environment.NewLine;
                textBox1.Text += "      Type         = " + swSkRel.GetRelationType() + System.Environment.NewLine;

                vEntTypeArr = (int[])swSkRel.GetEntitiesType();
                vEntArr = (object[])swSkRel.GetEntities();
                
                SelectData swSelData = default(SelectData);
                swSelData = (SelectData)swSelMgr.CreateSelectData();
                //MessageBox.Show(swSkRel.GetEntitiesCount().ToString());
                vDefEntArr = (object[])swSkRel.GetDefinitionEntities();
                if ((vDefEntArr == null))
                {
                }
                else
                {
                    textBox1.Text += "    Number of definition entities in this relation: " + vDefEntArr.GetUpperBound(0) + System.Environment.NewLine;
                }

                if ((vEntTypeArr != null) & (vEntArr != null))
                {

                    if (vEntTypeArr.GetUpperBound(0) == vEntArr.GetUpperBound(0))
                    {
                        j = 0;

                        foreach (swSketchRelationEntityTypes_e vType in vEntTypeArr)
                        {
                            textBox1.Text += "        EntType    = " + vType + System.Environment.NewLine;

                            switch (vType)
                            {
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Unknown:
                                    textBox1.Text += "          Not known" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_SubSketch:
                                    textBox1.Text += "SubSketch" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Point:
                                    swSkPt = (SketchPoint)vEntArr[j];
                                    //swSkSeg = (SketchSegment)vEntArr[j];
                                    swSkPt.Select(true);
                                   
                                    textBox1.Text += swSkPt.X + " " + swSkPt.Y+ " " + swSkPt.Z + System.Environment.NewLine;
                                    //Debug.Assert((swSkPt != null));

                                    textBox1.Text += "          SkPoint ID = [" + ((int[])(swSkPt.GetID()))[0] + ", " + ((int[])(swSkPt.GetID()))[1] + "]" + System.Environment.NewLine;

                                    swSkPt.Select4(true, swSelData);
                                    //
                                    break;

                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Line:
                                    ISketchSegment swSkLine = (ISketchSegment)vEntArr[j];
                                    swSkSeg = (SketchSegment)vEntArr[j];
                                    swSkSeg.Select(true);

                                    textBox1.Text += vEntArr[j].GetType() + "    " + System.Environment.NewLine;

                                    //swSkPt.Select4(true, swSelData);
                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Arc:
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Ellipse:
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Parabola:
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Spline:

                                    swSkSeg = (SketchSegment)vEntArr[j];
                                    swSkSeg.Select(true);

                                    textBox1.Text += "          SkSeg   ID = [" + ((int[])(swSkSeg.GetID()))[0] + ", " + ((int[])(swSkSeg.GetID()))[1] + "]" + System.Environment.NewLine;

                                    swSkSeg.Select4(true, swSelData);

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Hatch:
                                    textBox1.Text += "Hatch" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Text:
                                    textBox1.Text += "Text" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Plane:
                                    textBox1.Text += "Plane" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Cylinder:
                                    textBox1.Text += "Cylinder" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Sphere:
                                    textBox1.Text += "Sphere" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Surface:
                                    textBox1.Text += "Surface" + System.Environment.NewLine;

                                    break;
                                case swSketchRelationEntityTypes_e.swSketchRelationEntityType_Dimension:
                                    textBox1.Text += "Dimension" + System.Environment.NewLine;

                                    break;
                                default:
                                    textBox1.Text += "Something else" + System.Environment.NewLine;

                                    break;
                            }

                            j = j + 1;

                        }
                    }
                }
            
                i = i + 1;

            }*/

        }
        }
    
}
