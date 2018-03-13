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
    public class BilderParts
    {
        protected Parts obj;
        protected ModelDoc2 swModel;

        //створити клас моделі
        public BilderParts()
        {
            obj = new Parts();
        }

        //відкрити параметри
        public void OpenDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "./";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                obj = (Parts)SmartTools.OpenXML(typeof(Parts), openFileDialog1.FileName);
        }

        //зберегти параметри даної моделі
        public void SaveDialog()
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();

            saveFile1.DefaultExt = "*.xml";
            saveFile1.Filter = "xml files (*.xml)|*.xml";

            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
                SmartTools.SaveXML(obj, saveFile1.FileName.ToString());
        }

        //відкрити програму Solidworks та створити Модель
        public void OpenProgramNewPart()
        {
            if (obj.isEpmty())
                swModel = SmartTools.WorkSolid();            
            else
                MessageBox.Show("Загрузіть модель!");
        }

        //заповнити список назви розмірів
        public void FillupCombobox(ComboBox namedimen)
        {
            obj.getNameDimention(namedimen);
        }

        //відобразити заданий розмір в текстбокс
        public void Resizedimention(ComboBox namedimen, TextBox size)
        {
            size.Text = obj.getCountDimention(namedimen.Text).ToString("N");
        }

        //оновити розмір заданого в комбобокс
        public void Updatedimention(ComboBox namedimen, TextBox value)
        {
            double number;

            if (Double.TryParse(value.Text, out number))
                obj.setCountDimention(namedimen.Text, number);
            else
                MessageBox.Show("Введіть число!");
        }

        //побудувати модель
        public void BildModel()
        {
            OpenProgramNewPart();
            obj.Bild(swModel);
        }

        //параметрезувати модель
        public void ChangeDimensions()
        {
            String message;
            if (obj.isValidation(swModel, out message))
                obj.setDimensions(swModel);
            else
                MessageBox.Show(message);
        }

        //змінити матеріал
        public void ChangeMaterial(ComboBox namematerial)
        {
            if (obj != null)
            {
                obj.material = namematerial.Text;
                if (swModel != null)
                    SmartTools.SetMaterial(swModel, namematerial.Text);
            }
            else MessageBox.Show("Загрузіть модель!");
        }

        //змінити матеріал
        public void GivePropertiMass()
        {
            if (obj != null)
            {
                swModel.Extension.SelectByID2("Boss-Extrude1", "BODYFEATURE", 0, 0, 0, false, 0, null, 0); ;
                swModel.ToolsMassProps();
            }
            else MessageBox.Show("Загрузіть модель!");
        }

        //змінити матеріал
        public void LoadPNG(PictureBox pb)
        {
            if (obj != null)
            {            
                //@"C:\Users\Руслан\Desktop\GreenArrow\GreenArrow\Images\2017-03-27_073846.jpg"
                if (obj.waysPng != null)
                {
                    Bitmap image = new Bitmap(obj.waysPng);                    
                    pb.Size = image.Size;
                    pb.Image = image;
                    pb.Invalidate();
                }
            }
            else MessageBox.Show("Загрузіть модель!");
        }
    }

    [Serializable(), XmlInclude(typeof(Skeths)), XmlInclude(typeof(FeatureCut)), XmlInclude(typeof(FeatureRevolve)), XmlInclude(typeof(InsertFeatureChamfer)), XmlInclude(typeof(InsertAxis)), XmlInclude(typeof(FeatureCircularPattern))]
    public class Parts
    {
        public BindingList<Iitem> item;
        public String material;
        public String waysPng;

        public Parts()
        {
            item = new BindingList<Iitem>();
        }

        public void AddItem(Iitem skt)
        {
            item.Add(skt);
        }

        public void Bild(ModelDoc2 swModel)
        {
            if (swModel != null)
            foreach (Iitem I in item)
            {
                I.Bild(swModel);
            }
        }

        public bool isValidation(ModelDoc2 swModel, out String Message)
        {
            if (swModel != null)
            foreach (Iitem I in item)
            {
                Skeths ske = I as Skeths;
                if (ske != null) if (!ske.isValidation(swModel, out Message))
                return false;
            }

            Message = "Все вірно!";
            return true;
        }

        public void setDimensions(ModelDoc2 swModel)
        {
            if (swModel != null)
            foreach (Iitem I in item)
            {
                Skeths ske = I as Skeths;
                if (ske != null) ske.setDim(swModel);
            }
        }

        public void getNameDimention(ComboBox cbox)
        {
                cbox.Items.Clear();
                foreach (Iitem I in item)
                {
                    Skeths ske = I as Skeths;
                    if (ske != null) cbox.Items.AddRange(ske.Getlistdimension());
                }
                if (item.Count != 0 && cbox.Items.Count != 0) cbox.SelectedIndex = 0;
            
        }

        public double getCountDimention(String name)
        {
            foreach (Iitem I in item)
            {
                Skeths ske = I as Skeths;
                if (ske != null)
                {
                    String[] str = ske.Getlistdimension();

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (name == str[i])
                            return ske.Getcountdimension(name);
                    }
                }
            }
            return 0.0;
        }

        public void setCountDimention(String name, Double value)
        {
            foreach (Iitem I in item)
            {
                Skeths ske = I as Skeths;
                if (ske != null) ske.Setcountdimension(name, value);
            }
        }

        public bool isEpmty()
        {
            if (item.Count == 0)
                return false;
            else
                return true;
        }
    }

    public class SmartTools
    {
        public static void SelectByID(ModelDoc2 swModel, String select)
        {
            //Point1@Origin#EXTSKETCHPOINT#X$Y$Z#*Top$5#Mark
            int caseSwitch = 6 - select.Split('#').Length;
            int Mark = 0;
            Double X = 0.0;
            Double Y = 0.0;
            Double Z = 0.0;
            String Typesel = "SKETCHSEGMENT";
            String Name = "";

            switch (caseSwitch)
            {
                case 1:
                    Int32.TryParse(select.Split('#')[4].Split('$')[0], out Mark);
                    goto case 2;
                case 2:
                    if (select.Split('#')[3] != "")
                    {
                        Int32 Viewid = 0;
                        Int32.TryParse(select.Split('#')[3].Split('$')[1], out Viewid);
                        swModel.ShowNamedView2(select.Split('#')[3].Split('$')[0], Viewid);
                        swModel.ViewZoomtofit2();
                    }
                    goto case 3;
                case 3:
                    if (select.Split('#')[2] != "")
                    {
                        Double.TryParse(select.Split('#')[2].Split('$')[0], out X);
                        Double.TryParse(select.Split('#')[2].Split('$')[1], out Y);
                        Double.TryParse(select.Split('#')[2].Split('$')[2], out Z);
                    }
                    goto case 4;
                case 4:
                    if (select.Split('#')[1] != "")
                        Typesel = select.Split('#')[1];
                    goto default;
                default:
                    Name = select.Split('#')[0];
                    break;
            }

            swModel.Extension.SelectByID2(Name, Typesel, X, Y, Z, true, Mark, null, 0);
        }

        public static void UpdateModel(ModelDoc2 swModel)
        {
            swModel.EditRebuild3();
        }

        public static void SelectFromList(ModelDoc2 swModel, BindingList<String> Sselect)
        {
            swModel.ClearSelection2(true);
            foreach (String str in Sselect)
                SmartTools.SelectByID(swModel, str);
        }

        public static SldWorks SwApp = null;

        public static ModelDoc2 WorkSolid(SldWorks SwApp = null)
        {
            ModelDoc2 swModel = null;
            try
            {
                if (SwApp == null)
                {
                    Process[] processers = Process.GetProcessesByName("SLDWORKS");
                    foreach (Process process in processers)
                    {
                        process.CloseMainWindow();
                        process.Kill();
                    }

                    //створення процесу
                    object processSW = System.Activator.CreateInstance(System.Type.GetTypeFromProgID("SldWorks.Application"));
                    //Guid myGuid1 = new Guid("0D825E02-9000-4D82-B4AB-D6BDC2872797");
                    //object processSW = System.Activator.CreateInstance(System.Type.GetTypeFromCLSID(myGuid1));
                    
                    SwApp = (SldWorks)processSW;
                    SwApp.Visible = true;
                }

                //створення моделі
                int errors = 0, warnings = 0;
                String Document = "C:\\ProgramData\\SolidWorks\\SolidWorks 2013\\templates\\Part.prtdot";
                SwApp.OpenDoc6(Document, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
                swModel = (ModelDoc2)SwApp.NewPart();
                SwApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                SwApp = null;
            }
            catch (Exception ex)
            {
                string erorr = ex.ToString();
            }
            return swModel;
        }

        public static void SaveXML(Object obj, String FileName = "temple.xml")
        {
            using (Stream writer = new FileStream(FileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
            }
        }

        public static object OpenXML(System.Type types, String FileName = "./temple.xml")
        {
            Object obj = null;

            try
            {
                using (Stream stream = new FileStream(FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(types);
                    obj = serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }

            return obj;
        }

        public static void SetMaterial(ModelDoc2 swModel, String material = "Cast alloy steel")
        {
            PartDoc myswModel = (PartDoc)swModel;
            myswModel.SetMaterialPropertyName2("Default", "C:/PROGRA~1/SOLIDW~1/SOLIDW~1/lang/english/sldmaterials/SolidWorks Materials.sldmat", material);
        }

        public static void ShowPropertiMass(ModelDoc2 swModel)
        {
                swModel.Extension.SelectByID2("Boss-Extrude1", "BODYFEATURE", 0, 0, 0, false, 0, null, 0); ;
                swModel.ToolsMassProps();
        }
    }
}