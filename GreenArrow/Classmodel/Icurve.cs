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
    public abstract class Icurve
    {       
        [XmlIgnore]
        public SketchSegment skSegment { get; set; }

        public abstract void Trace(ModelDoc2 swModel);
        public void SelectBy()
        {
            if (skSegment != null)
                skSegment.Select(true);
        }
    }

    [Serializable]
    public class Lines : Icurve
    {
        public double X_start;
        public double Y_start;
        public double X_end;
        public double Y_end;
        public bool centrline;

        public Lines()
        {
            this.X_start = 0.0;
            this.Y_start = 0.0;
            this.X_end = 0.0;
            this.Y_end = 0.0;
            this.centrline = false;
        }

        public Lines(double X_s, double Y_s, double X_e, double Y_e, bool centrline = false)
        {
            this.X_start = X_s;
            this.Y_start = Y_s;
            this.X_end = X_e;
            this.Y_end = Y_e;
            this.centrline = centrline;
        }

        public override void Trace(ModelDoc2 swModel)
        {
            skSegment = (SketchSegment)swModel.SketchManager.CreateLine(X_start, Y_start, 0.0, X_end, Y_end, 0.0);
            skSegment.ConstructionGeometry = centrline;
        }

        public override string ToString()
        {
            return X_start + " " + Y_start + " " + X_end + " " + Y_end;
        }
    }

    [Serializable]
    public class Arcs : Icurve
    {
        public double X_start;
        public double Y_start;
        public double X_end;
        public double Y_end;
        public double X_center;
        public double Y_center;
        public short Direction;

        public Arcs()
        { }

        public Arcs(double X_c, double Y_c, double X_s, double Y_s, double X_e, double Y_e, short Direction)
        {
            this.X_start = X_s;
            this.Y_start = Y_s;
            this.X_end = X_e;
            this.Y_end = Y_e;
            this.X_center = X_c;
            this.Y_center = Y_c;
            this.Direction = Direction;
        }

        public override void Trace(ModelDoc2 swModel)
        {
            skSegment = (SketchSegment)swModel.SketchManager.CreateArc(X_center, Y_center, 0.0, X_start, Y_start, 0.0, X_end, Y_end, 0.0, Direction);            
        }

        public override string ToString()
        {
            return X_start + " " + Y_start + " " + X_end + " " + Y_end + " " + X_center + " " + Y_center;
        }
    }

    [Serializable]
    public class Circles : Icurve
    {
        public double X_center;
        public double Y_center;
        public double X_end;
        public double Y_end;
        public bool forconstruct;

        public Circles()
        { }

        public Circles(double X_c, double Y_c, double X_e, double Y_e, bool forconstruct = false)
        {
            this.X_center = X_c;
            this.Y_center = Y_c;
            this.X_end = X_e;
            this.Y_end = Y_e;
            this.forconstruct = forconstruct;
        }

        public override void Trace(ModelDoc2 swModel)
        {
            skSegment = (SketchSegment)swModel.SketchManager.CreateCircle(X_center, Y_center, 0.0, X_end, Y_end, 0.0);
            skSegment.ConstructionGeometry = forconstruct;
        }

        public override string ToString()
        {
            return X_center + " " + Y_center + " " + X_end + " " + Y_end;
        }
    }

    [Serializable]
    public class SketchMirror : Icurve
    {
        public BindingList<String> Sselect;

        public SketchMirror() { }

        public SketchMirror(string[] listcount)
        {
            this.Sselect = new BindingList<string>(listcount.OfType<String>().ToList());
        }

        public override void Trace(ModelDoc2 swModel)
        {
            SmartTools.SelectFromList(swModel, Sselect);
            swModel.SketchMirror();
        }
    }

    [Serializable]
    public class CreateCircularSketchStepAndRepeat : Icurve
    {
        public BindingList<String> Sselect;

        public double ArcRadius;
        public double ArcAngle;
        public int PatternNum;
        public double PatternSpacing;
        public bool PatternRotate;
        public string DeleteInstances;
        public bool RadiusDim;
        public bool AngleDim;
        public bool CreateNumOfInstancesDim;        

        public CreateCircularSketchStepAndRepeat() { }

        public CreateCircularSketchStepAndRepeat(double ArcRadius,
                                               double ArcAngle,
                                               int PatternNum,
                                               double PatternSpacing,
                                               bool PatternRotate,
                                               string DeleteInstances,
                                               bool RadiusDim,
                                               bool AngleDim,
                                               bool CreateNumOfInstancesDim,
                                               string[] listcount)
        {
            this.ArcRadius = ArcRadius;
            this.ArcAngle = ArcAngle;
            this.PatternNum = PatternNum;
            this.PatternSpacing = PatternSpacing;
            this.PatternRotate = PatternRotate;
            this.DeleteInstances = DeleteInstances;
            this.RadiusDim = RadiusDim;
            this.AngleDim = AngleDim;
            this.CreateNumOfInstancesDim = CreateNumOfInstancesDim;
            this.Sselect = new BindingList<String>(listcount.OfType<String>().ToList());
        }

        public override void Trace(ModelDoc2 swModel)
        {
            SmartTools.SelectFromList(swModel, Sselect);
            swModel.SketchManager.CreateCircularSketchStepAndRepeat(ArcRadius, ArcAngle, PatternNum, PatternSpacing,
                                  PatternRotate, DeleteInstances, RadiusDim, AngleDim, CreateNumOfInstancesDim);
        }
    }
}
