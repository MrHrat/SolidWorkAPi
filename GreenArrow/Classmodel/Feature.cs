using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO; // это для работы с файлами
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization; //это для сохранения классов — что и есть серилизация (стрёмное слово)

namespace GreenArrow
{
    [Serializable]
    public class FeatureRevolve : Skeths
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

        public BindingList<String> Sselect;

        public FeatureRevolve() : base() { }

        public FeatureRevolve(Skeths sketh,
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
                                bool UseAutoSelect)
            : base(sketh)
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
            this.Sselect = null;
        }

        public FeatureRevolve(Skeths sketh,
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
                                bool UseAutoSelect,
                                string[] listcount) : base(sketh)
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
            this.Sselect = new BindingList<string>(listcount.OfType<String>().ToList());
        }

        public override void Bild(ModelDoc2 swModel)
        {
            base.Bild(swModel);
            swModel.ClearSelection2(true);
            if (Sselect == null || Sselect.Count == 0) base.SelectByAll();
            else SmartTools.SelectFromList(swModel, Sselect);
            swModel.FeatureManager.FeatureRevolve2(SingleDir,
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

    [Serializable]
    public class FeatureCut : Skeths
    {
        public bool Sd;
        public bool Flip;
        public bool Dir;
        public int T1;
        public int T2;
        public double D1;
        public double D2;
        public bool Dchk1;
        public bool Dchk2;
        public bool Ddir1;
        public bool Ddir2;
        public double Dang1;
        public double Dang2;
        public bool OffsetReverse1;
        public bool OffsetReverse2;
        public bool TranslateSurface1;
        public bool TranslateSurface2;
        public bool NormalCut;
        public bool UseFeatScope;
        public bool UseAutoSelect;
        public bool AssemblyFeatureScope;
        public bool AutoSelectComponents;
        public bool PropagateFeatureToParts;
        public int T0;
        public double StartOffset;
        public bool FlipStartOffset;

        public FeatureCut() : base() { }

        public FeatureCut(Skeths sketh,
                            bool Sd,
                            bool Flip,
                            bool Dir,
                            int T1,
                            int T2,
                            double D1,
                            double D2,
                            bool Dchk1,
                            bool Dchk2,
                            bool Ddir1,
                            bool Ddir2,
                            double Dang1,
                            double Dang2,
                            bool OffsetReverse1,
                            bool OffsetReverse2,
                            bool TranslateSurface1,
                            bool TranslateSurface2,
                            bool NormalCut,
                            bool UseFeatScope,
                            bool UseAutoSelect,
                            bool AssemblyFeatureScope,
                            bool AutoSelectComponents,
                            bool PropagateFeatureToParts,
                            int T0,
                            double StartOffset,
                            bool FlipStartOffset)
            : base(sketh)
        {
            this.Sd = Sd;
            this.Flip = Flip;
            this.Dir = Dir;
            this.T1 = T1;
            this.T2 = T2;
            this.D1 = D1;
            this.D2 = D2;
            this.Dchk1 = Dchk1;
            this.Dchk2 = Dchk2;
            this.Ddir1 = Ddir1;
            this.Ddir2 = Ddir2;
            this.Dang1 = Dang1;
            this.Dang2 = Dang2;
            this.OffsetReverse1 = OffsetReverse1;
            this.OffsetReverse2 = OffsetReverse2;
            this.TranslateSurface1 = TranslateSurface1;
            this.TranslateSurface2 = TranslateSurface2;
            this.NormalCut = NormalCut;
            this.UseFeatScope = UseFeatScope;
            this.UseAutoSelect = UseAutoSelect;
            this.AssemblyFeatureScope = AssemblyFeatureScope;
            this.AutoSelectComponents = AutoSelectComponents;
            this.PropagateFeatureToParts = PropagateFeatureToParts;
            this.T0 = T0;
            this.StartOffset = StartOffset;
            this.FlipStartOffset = FlipStartOffset;
        }

        public override void Bild(ModelDoc2 swModel)
        {
            base.Bild(swModel);
            swModel.ClearSelection2(true);
            base.SelectByAll();
            swModel.FeatureManager.FeatureCut3(Sd,
                                               Flip,
                                               Dir,
                                               T1,
                                               T2,
                                               D1,
                                               D2,
                                               Dchk1,
                                               Dchk2,
                                               Ddir1,
                                               Ddir2,
                                               Dang1,
                                               Dang2,
                                               OffsetReverse1,
                                               OffsetReverse2,
                                               TranslateSurface1,
                                               TranslateSurface2,
                                               NormalCut,
                                               UseFeatScope,
                                               UseAutoSelect,
                                               AssemblyFeatureScope,
                                               AutoSelectComponents,
                                               PropagateFeatureToParts,
                                               T0,
                                               StartOffset,
                                               FlipStartOffset);
        }
    }

    [Serializable]
    public class FeatureExtrusion : Skeths
    {
        public bool Sd;
        public bool Flip;
        public bool Dir;
        public int T1;
        public int T2;
        public double D1;
        public double D2;
        public bool Dchk1;
        public bool Dchk2;
        public bool Ddir1;
        public bool Ddir2;
        public double Dang1;
        public double Dang2;
        public bool OffsetReverse1;
        public bool OffsetReverse2;
        public bool TranslateSurface1;
        public bool TranslateSurface2;
        public bool Merge;
        public bool UseFeatScope;
        public bool UseAutoSelect;
        public int T0;
        public double StartOffset;
        public bool FlipStartOffset;

        public FeatureExtrusion() : base() { }

        public FeatureExtrusion(Skeths sketh,
                                bool Sd,
                                bool Flip,
                                bool Dir,
                                int T1,
                                int T2,
                                double D1,
                                double D2,
                                bool Dchk1,
                                bool Dchk2,
                                bool Ddir1,
                                bool Ddir2,
                                double Dang1,
                                double Dang2,
                                bool OffsetReverse1,
                                bool OffsetReverse2,
                                bool TranslateSurface1,
                                bool TranslateSurface2,
                                bool Merge,
                                bool UseFeatScope,
                                bool UseAutoSelect,
                                int T0,
                                double StartOffset,
                                bool FlipStartOffset)
                                : base(sketh)
        {
            this.Sd = Sd;
            this.Flip = Flip;
            this.Dir = Dir;
            this.T1 = T1;
            this.T2 = T2;
            this.D1 = D1;
            this.D2 = D2;
            this.Dchk1 = Dchk1;
            this.Dchk2 = Dchk2;
            this.Ddir1 = Ddir1;
            this.Ddir2 = Ddir2;
            this.Dang1 = Dang1;
            this.Dang2 = Dang2;
            this.OffsetReverse1 = OffsetReverse1;
            this.OffsetReverse2 = OffsetReverse2;
            this.TranslateSurface1 = TranslateSurface1;
            this.TranslateSurface2 = TranslateSurface2;
            this.Merge = Merge;
            this.UseFeatScope = UseFeatScope;
            this.UseAutoSelect = UseAutoSelect;
            this.T0 = T0;
            this.StartOffset = StartOffset;
            this.FlipStartOffset = FlipStartOffset;
        }

        public override void Bild(ModelDoc2 swModel)
        {
            base.Bild(swModel);
            swModel.ClearSelection2(true);
            base.SelectByAll();
            swModel.FeatureManager.FeatureExtrusion2( Sd, Flip, Dir, T1, T2, D1, D2, Dchk1, Dchk2, Ddir1, Ddir2, Dang1, Dang2, OffsetReverse1, OffsetReverse2,
            TranslateSurface1, TranslateSurface2, Merge, UseFeatScope, UseAutoSelect, T0, StartOffset, FlipStartOffset);
        }
    }

    [Serializable]
    public class InsertFeatureChamfer : Iitem
    {
        public BindingList<String> Sselect;

        public int Options;
        public int ChamferType;
        public double Width;
        public double Angle;
        public double OtherDist;
        public double VertexChamDist1;
        public double VertexChamDist2;
        public double VertexChamDist3;

        public InsertFeatureChamfer() : base() { }

        public InsertFeatureChamfer(int Options,
                                    int ChamferType,
                                    double Width,
                                    double Angle,
                                    double OtherDist,
                                    double VertexChamDist1,
                                    double VertexChamDist2,
                                    double VertexChamDist3,
                                    string[] listcount)
            : base()
        {
            this.Options = Options;
            this.ChamferType = ChamferType;
            this.Width = Width;
            this.Angle = Angle;
            this.OtherDist = OtherDist;
            this.VertexChamDist1 = VertexChamDist1;
            this.VertexChamDist2 = VertexChamDist2;
            this.VertexChamDist3 = VertexChamDist3;
            this.Sselect = new BindingList<string>(listcount.OfType<String>().ToList());
        }

        public override void Bild(ModelDoc2 swModel)
        {
            SmartTools.SelectFromList(swModel, Sselect);
            swModel.FeatureManager.InsertFeatureChamfer(Options, ChamferType, Width, Angle, OtherDist, VertexChamDist1, VertexChamDist2, VertexChamDist3);
        }
    }

    [Serializable]
    public class InsertAxis : Iitem
    {
        public BindingList<String> Sselect;

        public InsertAxis() { }

        public InsertAxis(string[] listcount)
        {
            this.Sselect = new BindingList<string>(listcount.OfType<String>().ToList());
        }

        public override void Bild(ModelDoc2 swModel)
        {
            SmartTools.SelectFromList(swModel, Sselect);
            swModel.InsertAxis2(true);
        }
    }

    [Serializable]
    public class FeatureCircularPattern : Iitem
    {
        public BindingList<String> Sselect;

        public int Number;
        public double Spacing;
        public bool FlipDirection;
        public string DName;
        public bool GeometryPattern;
        public bool EqualSpacing;
        public bool VaryInstance;

        public FeatureCircularPattern() { }

        public FeatureCircularPattern(int Number, double Spacing, bool FlipDirection, string DName, bool GeometryPattern, bool EqualSpacing, bool VaryInstance, string[] listcount)
        {
            this.Number = Number;
            this.Spacing = Spacing;
            this.FlipDirection = FlipDirection;
            this.DName = DName;
            this.GeometryPattern = GeometryPattern;
            this.EqualSpacing = EqualSpacing;
            this.VaryInstance = VaryInstance;
            this.Sselect = new BindingList<string>(listcount.OfType<String>().ToList());
        }

        public override void Bild(ModelDoc2 swModel)
        {
            swModel.ActivateSelectedFeature();
            swModel.ClearSelection2(true);
            SmartTools.SelectFromList(swModel, Sselect);
            swModel.FeatureManager.FeatureCircularPattern4(Number, Spacing, FlipDirection, DName, GeometryPattern, EqualSpacing, VaryInstance);
        }
    }

    [Serializable]
    public class InsertMirrorFeature : Iitem
    {
        public BindingList<String> Sselect;

        public bool BMirrorBody;
        public bool BGeometryPattern;
        public bool BMerge;
        public bool BKnit;

        public InsertMirrorFeature() { }

        public InsertMirrorFeature(bool BMirrorBody, bool BGeometryPattern, bool BMerge, bool BKnit, string[] listcount)
        {
            this.BMirrorBody = BMirrorBody;
            this.BGeometryPattern = BGeometryPattern;
            this.BMerge = BMerge;
            this.BKnit = BKnit;            
            this.Sselect = new BindingList<string>(listcount.OfType<String>().ToList());
        }

        public override void Bild(ModelDoc2 swModel)
        {
            SmartTools.SelectFromList(swModel, Sselect);
            swModel.FeatureManager.InsertMirrorFeature(BMirrorBody, BGeometryPattern, BMerge, BKnit);
        }
    }

    [Serializable]
    public class FeatureFillet : Iitem
    {
        public BindingList<String> Sselect;

        public int Options;
        public double R1;
        public int Ftyp;
        public int OverflowType;
        public object Radii;
        public object SetBackDistances;
        public object PointRadiusArray;

        public FeatureFillet() { }

        public FeatureFillet(int Options, double R1, int Ftyp, int OverflowType, object Radii, object SetBackDistances, object PointRadiusArray, string[] listcount)
        {
            this.Options = Options;
            this.R1 = R1;
            this.Ftyp = Ftyp;
            this.OverflowType = OverflowType;
            this.Radii = Radii;
            this.SetBackDistances = SetBackDistances;
            this.PointRadiusArray = PointRadiusArray;
            this.Sselect = new BindingList<string>(listcount.OfType<String>().ToList());
        }

        public override void Bild(ModelDoc2 swModel)
        {
            SmartTools.SelectFromList(swModel, Sselect);
            swModel.FeatureManager.FeatureFillet(Options, R1, Ftyp, OverflowType, Radii, SetBackDistances, PointRadiusArray);
        }
    }
}
