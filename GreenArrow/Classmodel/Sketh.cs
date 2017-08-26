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
    [Serializable(), XmlInclude(typeof(Lines)), XmlInclude(typeof(Arcs)), XmlInclude(typeof(Circles))]
    public class Skeths
    {
        public BindingList<Icurve> line;
        public Bindings holdon;
        public Dimensions Dimensions;

        public Skeths()
        {
            line = new BindingList<Icurve>();
            holdon = new Bindings();
            Dimensions = new Dimensions();
        }

        public void Addcurve(Icurve obj)
        {
            obj.Setseqnumber(line.Count);
            line.Add(obj);
        }

        public void Addholdon(string name, string[] listcount)
        {
            holdon.AddBindings(name, listcount);
        }

        public void AddDimensions(string name, string parameter, double defaultvalue, double Xkor, double Ykor, string[] listcount)
        {
            Dimensions.AddDimensions(name, parameter, defaultvalue, Xkor, Ykor, listcount);
        }

        public void Savexml(string name)
        {

        }

        public void SelectSketh()
        {
            foreach (Icurve I in line)
            {
                I.SelectBy();
            }
        }

        public virtual void Bild(ModelDoc2 swModel)
        {
            foreach (Icurve I in line)
            {
                I.Trace(swModel);
            }
            holdon.makeBindings(swModel, line);
            Dimensions.makeDimensions(swModel, line);
            swModel.SketchManager.InsertSketch(true);
        }
    }

    [Serializable]
    public abstract class Icurve
    {
        public int Seqnumber;
        [XmlIgnore]
        public SketchSegment skSegment;

        public void SelectBy()
        {
            skSegment.Select(true);
        }

        public void Setseqnumber(int namber)
        {
            Seqnumber = namber;
        }

        abstract public void Trace(ModelDoc2 swModel);
        abstract public string ShowParam();
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

        public Lines(double X_s, double Y_s, double X_e, double Y_e)
        {
            this.X_start = X_s;
            this.Y_start = Y_s;
            this.X_end = X_e;
            this.Y_end = Y_e;
            this.centrline = false;
        }

        public Lines(double X_s, double Y_s, double X_e, double Y_e, bool centrline)
        {
            this.X_start = X_s;
            this.Y_start = Y_s;
            this.X_end = X_e;
            this.Y_end = Y_e;
            this.centrline = centrline;
        }
        
        public override void Trace(ModelDoc2 swModel)
        {
            if (centrline)
                skSegment = (SketchSegment)swModel.SketchManager.CreateCenterLine(X_start, Y_start, 0.0, X_end, Y_end, 0.0);
            else
                skSegment = (SketchSegment)swModel.SketchManager.CreateLine(X_start, Y_start, 0.0, X_end, Y_end, 0.0);
        }

        public override string ShowParam()
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

        public override string ShowParam()
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

        public Circles()
        { }

        public Circles(double X_c, double Y_c, double X_e, double Y_e)
        {
            this.X_center = X_c;
            this.Y_center = Y_c; 
            this.X_end = X_e;
            this.Y_end = Y_e;
        }

        public override void Trace(ModelDoc2 swModel)
        {
            skSegment = (SketchSegment)swModel.SketchManager.CreateCircle(X_center, Y_center, 0.0, X_end, Y_end, 0.0);
        }

        public override string ShowParam()
        {
            return X_center + " " + Y_center + " " + X_end + " " + Y_end;
        }
    }

    [Serializable()]
    public class Feature : Skeths
    {
        //public Skeths sketh;
        [XmlIgnore]
        public ModelDoc2 swModel;

        public Feature() { }

        public Feature(Skeths sketh, ModelDoc2 swModel)
        {
            this.line = sketh.line;
            this.holdon = sketh.holdon;
            this.Dimensions = sketh.Dimensions;
            this.swModel = swModel;
        }        
    }

    [Serializable()]
    public class FeatureRevolve : Feature
    {
        public bool SingleDir;
        public bool IsSolid;
        public bool IsThin;
        public bool IsCut;
        public bool ReverseDir;
        public bool BothDirectionUpToSameEntity;
        public int Dir1Type;
        public int Dir2Type;
        public double Dir1Angle;
        public double Dir2Angle;
        public bool OffsetReverse1;
        public bool OffsetReverse2;
        public double OffsetDistance1;
        public double OffsetDistance2;
        public int ThinType;
        public double ThinThickness1;
        public double ThinThickness2;
        public bool Merge;
        public bool UseFeatScope;
        public bool UseAutoSelect;

        public FeatureRevolve() : base() { }

        public FeatureRevolve(  Skeths sketh,
                                ModelDoc2 swModel,
                                bool SingleDir,
                                bool IsSolid,
                                bool IsThin,
                                bool IsCut,
                                bool ReverseDir,
                                bool BothDirectionUpToSameEntity,
                                int Dir1Type,
                                int Dir2Type,
                                double Dir1Angle,
                                double Dir2Angle,
                                bool OffsetReverse1,
                                bool OffsetReverse2,
                                double OffsetDistance1,
                                double OffsetDistance2,
                                int ThinType,
                                double ThinThickness1,
                                double ThinThickness2,
                                bool Merge,
                                bool UseFeatScope,
                                bool UseAutoSelect) : base(sketh,swModel)
        { 
            this.SingleDir = SingleDir;
            this.IsSolid = IsSolid;
            this.IsThin = IsThin;
            this.IsCut = IsCut;
            this.ReverseDir = ReverseDir;
            this.BothDirectionUpToSameEntity = BothDirectionUpToSameEntity;
            this.Dir1Type = Dir1Type;
            this.Dir2Type = Dir2Type;
            this.Dir1Angle = Dir1Angle;
            this.Dir2Angle = Dir2Angle;
            this.OffsetReverse1 = OffsetReverse1;
            this.OffsetReverse2 = OffsetReverse2;
            this.OffsetDistance1 = OffsetDistance1;
            this.OffsetDistance2 = OffsetDistance2;
            this.ThinType = ThinType;
            this.ThinThickness1 = ThinThickness1;
            this.ThinThickness2 = ThinThickness2;
            this.Merge = Merge;
            this.UseFeatScope = UseFeatScope;
            this.UseAutoSelect = UseAutoSelect;
        }

        public override void Bild(ModelDoc2 swModel)
        {
            base.Bild(swModel);
            swModel.ClearSelection2(true);
            base.SelectSketh();
            swModel.FeatureManager.FeatureRevolve2( SingleDir,
                                                    IsSolid,
                                                    IsThin,
                                                    IsCut,
                                                    ReverseDir,
                                                    BothDirectionUpToSameEntity,
                                                    Dir1Type,
                                                    Dir2Type,
                                                    Dir1Angle,
                                                    Dir2Angle,
                                                    OffsetReverse1,
                                                    OffsetReverse2,
                                                    OffsetDistance1,
                                                    OffsetDistance2,
                                                    ThinType,
                                                    ThinThickness1,
                                                    ThinThickness2,
                                                    Merge,
                                                    UseFeatScope,
                                                    UseAutoSelect);
        }
    }

}
