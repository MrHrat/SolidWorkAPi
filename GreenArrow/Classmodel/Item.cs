using SolidWorks.Interop.sldworks;
using System;
using System.ComponentModel;
using System.Xml.Serialization; //это для сохранения классов — что и есть серилизация (стрёмное слово)

namespace GreenArrow
{   
    [Serializable()]
    public abstract class Iitem
    {    
        public abstract void Bild(ModelDoc2 swModel);
    }

    [Serializable(), XmlInclude(typeof(Lines)), XmlInclude(typeof(Arcs)), XmlInclude(typeof(Circles))]
    public class Skeths : Iitem
    {
        public BindingList<Icurve> line;
        public Bindings binding;
        public Dimensions dimension;
        public Validation validation;

        public string SmartSelect;

        public Skeths()
        {
            line = new BindingList<Icurve>();
            binding = new Bindings();
            dimension = new Dimensions();
            validation = new Validation();
            SmartSelect = "";
        }

        public Skeths(Skeths sketh)
        {
            line = sketh.line;
            binding = sketh.binding;
            dimension = sketh.dimension;
            validation = sketh.validation;
            SmartSelect = sketh.SmartSelect;
        }

        public Skeths(string Sselect) : this()
        {
            SmartSelect = Sselect;
        }
        
        public void Addcurve(Icurve obj)
        {
            line.Add(obj);
        }

        public void Addholdon(string name, string[] listcount)
        {
            binding.AddBindings(name, listcount);
        }

        public void AddDimensions(string name, string parameter, double defaultvalue, double Xkor, double Ykor, double Zkor, string[] listcount)
        {
            dimension.AddDimensions(name, parameter, defaultvalue, Xkor, Ykor, Zkor, listcount);
        }

        public void Addvalidation(String[][] ineq)
        {
            validation.AddInequality(new Inequality(ineq));
        }

        public override void Bild(ModelDoc2 swModel)
        {
            SmartTools.SelectByID(swModel, SmartSelect);
            swModel.SketchManager.InsertSketch(true);
            foreach (Icurve I in line)
            {
                I.Trace(swModel);
            }
            binding.makeBindings(swModel);
            dimension.makeDimensions(swModel);
            swModel.SketchManager.InsertSketch(true);
        }

        public void SelectByAll()
        {
            foreach (Icurve I in line)
            {
                I.SelectBy();
            }
        }

        public void setDim(ModelDoc2 swModel)
        {
            dimension.changeDimensions(swModel);
        }

        public bool isValidation(ModelDoc2 swModel, out String Message)
        {
            return validation.isTrue(dimension, out Message);
        }

        public String[] Getlistdimension()
        {
            return dimension.getName();
        }

        public double Getcountdimension(String name)
        {
            return dimension.getcount(name);
        }

        public void Setcountdimension(String name, Double value)
        {
            dimension.setcount(name, value);
        }
    }    
}
