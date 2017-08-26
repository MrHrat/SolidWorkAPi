using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [Serializable]
    public class Bindings
    {
        public BindingList<String[]> pack;
        
        public Bindings()
        {
            pack = new BindingList<string[]>();
        }

        public void AddBindings(string name, string[] listcount)
        {
            List<string> parts = new List<string>();
            parts.Add(name);
            parts.AddRange(listcount);

            pack.Add(parts.ToArray());
        }

        public void makeBindings(ModelDoc2 swModel, BindingList<Icurve> line)
        {
            foreach (string[] list in pack)
            {
                swModel.ClearSelection2(true);
                for (int i = 1; i < list.Length; i++)
                {
                    line[Convert.ToInt32(list[i])].SelectBy();                
                }
                swModel.SketchAddConstraints(list[0]);
            }
        }

        public void makeBindingsXY(ModelDoc2 swModel, double X, double Y)
        {

        }
    }

    public class Dimensions
    {
        public BindingList<String[]> pack;

        public Dimensions()
        {
            pack = new BindingList<String[]>();
        }

        //AddDimensions("L1", "P1", 17.5, 0.0, 0.0, ["1", "2"]);
        public void AddDimensions(string name, string parameter, double defaultvalue, double Xkor, double Ykor, string[] listcount)
        {
            List<string> parts = new List<string>();
            parts.Add(name);                            //Назва розміру
            parts.Add(parameter);                       //назва за яким виділяється розмір
            parts.Add(defaultvalue.ToString());         //Зазамовчуванням - використовується для збірки
            parts.Add(Xkor.ToString());                 //координати х у
            parts.Add(Ykor.ToString());                 //
            parts.AddRange(listcount);                  //ціле число номер кривої в списку
            
            pack.Add(parts.ToArray());            
        }

        public void makeDimensions(ModelDoc2 swModel, BindingList<Icurve> line)
        {            
            foreach (string[] list in pack)
            {
                swModel.ClearSelection2(true);
                for (int i = 5; i < list.Length; i++)
                {
                    int d;
                    if (int.TryParse(list[i], out d))
                    {                        
                        line[d].SelectBy();
                    }
                    else
                        swModel.Extension.SelectByID2(list[i], "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);                
                }
                swModel.AddDimension2(Convert.ToDouble(list[3]), Convert.ToDouble(list[4]), 0);
            }
        }
    }
}
