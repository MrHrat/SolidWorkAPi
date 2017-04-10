using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace GreenArrow
{
    class Detal1 : BildModel, IBildmode
    {

        String ways = "C:\\Users\\Hrat1\\Desktop\\";

        Double[,] myLines = {
                {6,	0,	0,	0,	0,	0.12,	0},
                {2,	0.044,	0,	0,	0.075,	0,	0},
                {2,	0.078,	0.003,	0,	0.13,	0.003,	0},
                {2,	0.22,	0.03,	0,	0.092,	0.03,	0},
                {2,	0.13,	0.003,	0,	0.22,	0.022,	0},
                {2,	0.22,	0.022,	0,	0.22,	0.03,	0},
                {2,	0.092,	0.03,	0,	0.092,	0.043,	0},
                {2,	0.092,	0.043,	0,	0.1025,	0.043,	0},
                {2,	0.104,	0.0445,	0,	0.104,	0.0625,	0},
                {2,	0.1025,	0.043,	0,	0.104,	0.0445,	0},
                {2,	0.1025,	0.064,	0,	0.06675,	0.064,	0},
                {2,	0.104,	0.0625,	0,	0.1025,	0.064,	0},
                {2,	0.06525,	0.0655,	0,	0.06525,	0.0692928932188134,	0},
                {2,	0.0675,	0.0719571067811865,	0,	0.0675,	0.118,	0},
                {2,	0.0655,	0.12,	0,	0.0455,	0.12,	0},
                {2,	0.0675,	0.118,	0,	0.0655,	0.12,	0},
                {2,	0.044,	0.115,	0,	0.044,	0,	0},
                {2,	0.0455,	0.1165,	0,	0.0455,	0.12,	0},
                {2,	0.0455,	0.1165,	0,	0.044,	0.115,	0},
                {2,	0.0655428932188135,	0.07,	0,	0.0675,	0.0719571067811865,	0}
        };

        public Detal1(string ways)
        {
            this.ways = ways;
            SwApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
        }

        public void Bild3d()
        {
            swModel.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            for (int i = 0; i < myLines.GetLength(0); i++)
            {
                swModel.SketchManager.CreateLine(myLines[i, 1], myLines[i, 2], myLines[i, 3], myLines[i, 4], myLines[i, 5], myLines[i, 6]);
            }
            //swModel.SketchManager.CreateCenterLine(0, 0.12, 0, 0, 0, 0);
            //swModel.ViewZoomtofit2();
            //swModel.SketchManager.CreateLine(0.044, 0, 0, 0.075, 0, 0);
            //swModel.SketchManager.Create3PointArc(0.075, 0, 0, 0.078, 0.003, 0, 0.076029, 0.002021, 0);
            //swModel.SketchManager.CreateLine(0.078, 0.003, 0, 0.13, 0.003, 0);
            //swModel.SketchManager.CreateLine(0.13, 0.003, 0, 0.22, 0.022, 0);
            //swModel.SketchManager.CreateLine(0.22, 0.022, 0, 0.22, 0.03, 0);
            //swModel.ViewZoomtofit2();
            //swModel.SketchManager.CreateLine(0.22, 0.03, 0, 0.092, 0.03, 0);
            //swModel.SketchManager.CreateLine(0.092, 0.03, 0, 0.092, 0.043, 0);
            //swModel.SketchManager.CreateLine(0.092, 0.043, 0, 0.1025, 0.043, 0);
            //swModel.SketchManager.CreateLine(0.1025, 0.043, 0, 0.104, 0.0445, 0);
            //swModel.SketchManager.CreateLine(0.104, 0.0445, 0, 0.104, 0.0625, 0);
            //swModel.SketchManager.CreateLine(0.104, 0.0625, 0, 0.1025, 0.064, 0);
            //swModel.SketchManager.CreateLine(0.1025, 0.064, 0, 0.06675, 0.064, 0);
            //swModel.SketchManager.Create3PointArc(0.06675, 0.064, 0, 0.06525, 0.0655, 0, 0.065704, 0.064378, 0);
            //swModel.SketchManager.CreateLine(0.06525, 0.0655, 0, 0.06525, 0.069293, 0);
            //swModel.SketchManager.Create3PointArc(0.06525, 0.069293, 0, 0.065543, 0.07, 0, 0.065351, 0.069686, 0);
            //swModel.SketchManager.CreateLine(0.065543, 0.07, 0, 0.0675, 0.071957, 0);
            //swModel.SketchManager.CreateLine(0.0675, 0.071957, 0, 0.0675, 0.118, 0);
            //swModel.SketchManager.CreateLine(0.0675, 0.118, 0, 0.0655, 0.12, 0);
            //swModel.SketchManager.CreateLine(0.0655, 0.12, 0, 0.0455, 0.12, 0);
            //swModel.SketchManager.CreateLine(0.0455, 0.12, 0, 0.0455, 0.1165, 0);
            //swModel.SketchManager.CreateLine(0.0455, 0.1165, 0, 0.044, 0.115, 0);
            //swModel.SketchManager.CreateLine(0.044, 0.115, 0, 0.044, 0, 0);
            swModel.ViewZoomtofit2();
            swModel.ShowNamedView2("*Front", 1);
            swModel.SketchManager.InsertSketch(true);
            //SetConstraints();
            swModel.ViewZoomtofit2();
            //SetDimention();
            swModel.ViewZoomtofit2();
            SwApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);

            //swModel.ClearSelection2(true);
            //swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0.24, 0, false, 16, null, 0);
            //swModel.FeatureManager.FeatureRevolve2(true, true, false, false, false, false, 0, 0, Math.PI, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);
            //swModel.SelectionManager.EnableContourSelection = false;
            //swModel.ClearSelection2(true);
            //swModel.ShowNamedView2("*Isometric", 7);

            //SwApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
            /*
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Line1@Sketch1", "EXTSKETCHSEGMENT", 0, 0, 0, false, 16, null, 0);
            swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, true, 2, null, 0);
            swModel.SelectionManager.EnableContourSelection = true;
            swModel.Extension.SelectByID2("Sketch1", "SKETCHREGION", 7.45650658767354E-02, 5.17014578574159E-02, 2.82900459146349E-02, true, 2, null, 0);
            swModel.FeatureManager.FeatureRevolve2(true, true, false, false, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);
            swModel.SelectionManager.EnableContourSelection = false;

            swModel.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCenterLine(0, 0, 0, 0, 0.06675, 0);
            swModel.SetPickMode();
            swModel.SketchManager.CreateLine(0.012, 0, 0, -0.012, 0, 0);
            swModel.SketchManager.CreateLine(-0.012, 0, 0, -0.012, 0.0512, 0);
            swModel.SketchManager.CreateLine(-0.012, 0.0512, 0, 0.012, 0.0512, 0);
            swModel.SketchManager.CreateLine(0.012, 0.0512, 0, 0.012, 0, 0);
            swModel.SketchManager.CreateCenterLine(-0.012, 0.0512, 0, 0.012, 0, 0);
            swModel.SketchManager.CreateCenterLine(-0.012, 0, 0, 0.012, 0.0512, 0);
            swModel.FeatureManager.FeatureCutThin2(true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, 0.01, 0.01, 0.01, 0, 0, false, 0.005, true, true, 0, 0, false);
            swModel.SelectionManager.EnableContourSelection = false;

            swModel.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCenterLine(0, 0, 0, 0, 0.12, 0);
            swModel.SetPickMode();
            swModel.SketchManager.CreateCircle(0, 0.1, 0, 0.005499, 0.09752, 0);
            swModel.SketchManager.CreateCircle(0, 0.075, 0, 0.005523, 0.07286, 0);
            swModel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            swModel.FeatureManager.FeatureCut3(true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            swModel.SelectionManager.EnableContourSelection = false;

            swModel.ShowNamedView2("*Isometric", 7);
            swModel.Extension.SelectByID2("", "FACE", -0.132428814362186, 2.99999999999727E-02, -7.48877117905522E-02, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCircle(0, 0.115, 0, 0.007702, 0.116817, 0);
            swModel.FeatureManager.FeatureCut3(true, false, false, 0, 0, 0.008, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            swModel.SelectionManager.EnableContourSelection = false;

            swModel.Extension.SelectByID2("", "FACE", -3.43773665423441E-03, 2.19999999999345E-02, -0.117487310845689, true, 0, null, 0);
            swModel.FeatureManager.InsertFeatureChamfer(4, 1, 0.004, 1.08210413623649, 0, 0, 0, 0);

            swModel.Extension.SelectByID2("", "FACE", -2.16049448638955E-02, 6.23546102343653E-02, -3.83304886146334E-02, false, 0, null, 0);
            swModel.InsertAxis2(true);

            swModel.Extension.SelectByID2("Cut-Extrude2", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
            swModel.Extension.SelectByID2("Chamfer1", "BODYFEATURE", 0, 0, 0, true, 4, null, 0);
            swModel.Extension.SelectByID2("Axis1", "AXIS", 0, 0, 0, true, 1, null, 0);
            swModel.FeatureManager.FeatureCircularPattern4(4, 6.2831853071796, false, "NULL", false, true, false);
            //swModel.SketchManager.CreateLine(0.1025, 0.064, 0, 0.06675, 0.064, 0);
            //swModel.SketchManager.Create3PointArc(0.06675, 0.06400, 0, 0.06525, 0.0655, 0, 0.065718, 0.064425, 0);//(0.06675, 0.06400, 0, 0.06525, 0.0655, 0, 0.065718, 0.064425, 0);
            //swModel.SketchManager.CreateLine(0.06525, 0.0655, 0, 0.06525, 0.069293, 0);
            //swModel.SketchManager.Create3PointArc(0.06525, 0.069293, 0, 0.065543, 0.07, 0, 0.065351, 0.069686, 0);
            /*swModel.SketchManager.CreateLine(0.065543, 0.07, 0, 0.0675, 0.071957, 0);
            swModel.SketchManager.CreateLine(0.0675, 0.071957, 0, 0.0675, 0.118, 0);
            swModel.SketchManager.CreateLine(0.0675, 0.118, 0, 0.0655, 0.12, 0);
            swModel.SketchManager.CreateLine(0.0655, 0.12, 0, 0.06542, 0.119982, 0);
            swModel.SketchManager.CreateLine(0.0655, 0.12, 0, 0.0455, 0.12, 0);
            swModel.SketchManager.CreateLine(0.0455, 0.12, 0, 0.0455, 0.1165, 0);
            swModel.SketchManager.CreateLine(0.0455, 0.1165, 0, 0.044, 0.115, 0);
            swModel.SketchManager.CreateLine(0.044, 0.115, 0, 0.044, 0, 0);*/

            /*swModel.SketchManager.CreateLine(0, 0, 0, 0, 0.038, 0);
            swModel.SketchManager.CreateLine(0, 0.038, 0, -0.023, 0.038, 0);
            swModel.SketchManager.CreateLine(-0.023, 0.038, 0, -0.023, 0.012, 0);
            swModel.SketchManager.CreateLine(-0.023, 0.012, 0, -0.056, 0.012, 0);
            swModel.SketchManager.CreateLine(-0.056, 0.012, 0, -0.056, 0.018, 0);
            swModel.SketchManager.CreateLine(-0.056, 0.018, 0, -0.065, 0.018, 0);
            swModel.SketchManager.CreateLine(-0.065, 0.018, 0, -0.065, 0, 0);
            swModel.SketchManager.CreateLine(-0.065, 0, 0, 0, 0, 0);
            swModel.SketchManager.InsertSketch(true);

            swModel.ShowNamedView2("*Trimetric", 8);
            swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 4, null, 0);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 6, 0, 0.03, 0.01, false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

            swModel.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.SketchManager.CreateCenterRectangle(0, 0, 0, 5.00E-03, 9.00E-03, 0);
            swModel.SketchManager.InsertSketch(true);

            swModel.Extension.SelectByID2("Sketch2", "SKETCH", 0, 0, 0, false, 4, null, 0);
            swModel.FeatureManager.FeatureCut3(true, false, true, 1, 0, 0.039, 0.01, false, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            swModel.ClearSelection2(true);

            SetDimention();

            swModel.SaveAs3(ways + "Labs3_1.SLDPRT", 0, 2);*/
        }

        public void SetDimention()
        {
            swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);

            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", -1.9316951860629E-04, 2.62414474023297E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0.220060134264509, 2.76232121688486E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(0.118914953355324, -5.30718501958561E-02, 0);
            
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", -1.9316951860629E-04, 2.62414474023297E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line20", "SKETCHSEGMENT", 4.45760089166066E-02, 7.17309362436866E-03, 0, true, 0, null, 0);
            swModel.AddDimension2(2.30204785589115E-02, -2.98582021183383E-02, 0);
            
            swModel.Extension.SelectByID2("Point9", "SKETCHPOINT", 0.13, 3.03813616149865E-03, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0.22088919312442, 2.37542708225956E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(0.173080132202866, -4.25704379703123E-02, 0);
            
            swModel.Extension.SelectByID2("Line15", "SKETCHSEGMENT", 6.86187158540357E-02, 0.111081804066591, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 6.3588934130504E-04, 0.101685803654262, 0, true, 0, null, 0);
            swModel.AddDimension2(0.031311067158025, 0.135400863957324, 0);
            
            swModel.Extension.SelectByID2("Line18", "SKETCHSEGMENT", 4.56264667979064E-02, 0.118557244577279, 0, false, 0, null, 0);
            swModel.AddDimension2(2.28754475369838E-02, 0.129007473520095, 0);
            
            swModel.Extension.SelectByID2("Line19", "SKETCHSEGMENT", 4.51950300814638E-02, 0.116120089229841, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line20", "SKETCHSEGMENT", 4.39924965557773E-02, 0.11465032603178, 0, true, 0, null, 0);
            swModel.AddDimension2(4.80009416413988E-02, 0.123892018868073, 0);
            
            swModel.Extension.SelectByID2("Point34", "SKETCHPOINT", 6.56308715879476E-02, 7.00878715879475E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line17", "SKETCHSEGMENT", 6.02015640391192E-02, 0.120503926196769, 0, true, 0, null, 0);
            swModel.AddDimension2(9.01416890621829E-02, 9.64112208021827E-02, 0);
            
            swModel.Extension.SelectByID2("Line14", "SKETCHSEGMENT", 6.69172126110211E-02, 0.071368843946985, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line15", "SKETCHSEGMENT", 6.74269284112759E-02, 7.27523582619624E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(7.58283934957548E-02, 9.07196320869549E-02, 0);
            
            swModel.Extension.SelectByID2("Line12", "SKETCHSEGMENT", 9.38270903563069E-02, 6.51738776150076E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line8", "SKETCHSEGMENT", 9.82609991303433E-02, 4.26348413469895E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(0.132254299731289, 0.053350120884244, 0);
            
            swModel.Extension.SelectByID2("Arc3", "SKETCHSEGMENT", 6.52162390239766E-02, 6.95630005311284E-02, 0, false, 0, null, 0);
            swModel.AddDimension2(6.43582946207999E-02, 0.069824568946731, 0);

            swModel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 6.56224351008265E-02, 6.41995506048031E-02, 0, false, 0, null, 0);
            swModel.AddDimension2(6.30583463234314E-02, 6.25866560512803E-02, 0);
            
            swModel.Extension.SelectByID2("Line8", "SKETCHSEGMENT", 9.86696648949511E-02, 4.28353201374257E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 9.95203410086617E-02, 3.00751784317673E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(7.74027620521872E-02, 3.60299112277412E-02, 0);
            
            swModel.Extension.SelectByID2("Line9", "SKETCHSEGMENT", 0.102593868344443, 4.31457691542636E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line8", "SKETCHSEGMENT", 0.102174665144575, 4.29916503307826E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(0.103173355120731, 4.32320756954129E-02, 0);
            
            swModel.Extension.SelectByID2("Line12", "SKETCHSEGMENT", 0.102017745937085, 0.064013557083733, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line11", "SKETCHSEGMENT", 0.10310989924078, 0.063346130064808, 0, true, 0, null, 0);
            swModel.AddDimension2(0.105375106092889, 6.27798283517807E-02, 0);
            
            swModel.Extension.SelectByID2("Line16", "SKETCHSEGMENT", 6.68126777750114E-02, 0.118740056805255, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line17", "SKETCHSEGMENT", 6.44133251583882E-02, 0.119841398989935, 0, true, 0, null, 0);
            swModel.AddDimension2(7.03920398752197E-02, 0.117756715568934, 0);
            
            swModel.Extension.SelectByID2("Point41", "SKETCHPOINT", 0.0655, 0.12, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line15", "SKETCHSEGMENT", 0.067442950462456, 0.117587826758861, 0, true, 0, null, 0);
            swModel.AddDimension2(6.62717411447835E-02, 0.122020631644736, 0);
            
            swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 7.61145832711908E-02, 2.32259691749715E-03, 0, false, 0, null, 0);
            swModel.AddDimension2(7.35974152262001E-02, 4.26768131589909E-03, 0);
            
            swModel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 6.73764506048572E-02, 7.2540859835421E-05, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0.102429383872369, 2.5323958259766E-03, 0, true, 0, null, 0);
            swModel.AddDimension2(1.85893271097236E-02, 1.91743208444131E-03, 0);
            
            swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0.126617957706091, 3.7623233090472E-03, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point11", "SKETCHPOINT", 0.22, 2.20381361614986E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(0.235671527871683, 0.013806731087457, 0);
            
            swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0.120758505668352, 4.01683774599218E-03, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0.202164094217645, 3.12496425484535E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(0.267171434713843, 1.69011755019954E-02, 0);
            
            swModel.Extension.SelectByID2("Line7", "SKETCHSEGMENT", 9.14759198592542E-02, 3.56420304198182E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", -1.7857372322308E-04, 3.47635528455453E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(2.03192363431456E-02, 1.80724789343593E-02, 0);
            
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 2.76612887696148E-04, 5.26966390302395E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line10", "SKETCHSEGMENT", 0.103171495301822, 0.052465933015858, 0, true, 0, null, 0);
            swModel.AddDimension2(2.70385105559442E-02, 4.66982826563218E-02, 0);
            
            swModel.Extension.SelectByID2("Line12", "SKETCHSEGMENT", 7.37891984022162E-02, 6.42530620944447E-02, 5.00000000000619E-05, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point34", "SKETCHPOINT", 6.56308715879476E-02, 7.00878715879475E-02, 0, true, 0, null, 0);
            swModel.AddDimension2(5.65241810429658E-02, 6.67687790835376E-02, 0);
            
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 4.94597796420186E-04, 9.8610135961044E-03, 4.99999999998161E-05, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point4", "SKETCHPOINT", 0.075, 0, 0, true, 0, null, 0);
            swModel.AddDimension2(2.72321480282697E-02, -4.28544973723716E-02, 0);
            
            swModel.Extension.SelectByID2("Line8", "SKETCHSEGMENT", 0.100999060599951, 0.042711631052697, 5.00000000001321E-05, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point21", "SKETCHPOINT", 0.10400030668578, 0.044493724288062, 0, true, 0, null, 0);
            swModel.AddDimension2(0.108679546703725, 4.71337291124457E-02, 0);
            
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", -1.71603897055575E-04, 0.069991208107577, 5.00000000000128E-05, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line13", "SKETCHSEGMENT", 0.065186692036639, 6.68907648151226E-02, 5.00000000000225E-05, true, 0, null, 0);
            swModel.AddDimension2(0.05078333714285, 6.69342794824755E-02, 0);
            
            swModel.Extension.SelectByID2("Line18", "SKETCHSEGMENT", 4.56017441536607E-02, 0.118867841381246, 4.99999999999851E-05, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", -3.01539800107262E-04, 0.117815013767627, 4.99999999999924E-05, true, 0, null, 0);
            swModel.AddDimension2(1.32799364155718E-02, 0.129080269233346, 0);

            Dimension myDimension;
            myDimension = swModel.Parameter("D13@Sketch1");
            myDimension.SystemValue = 0.7853981633975;
            
            myDimension = swModel.Parameter("D14@Sketch1");
            myDimension.SystemValue = 0.7853981633975;
            
            myDimension = swModel.Parameter("D15@Sketch1");
            myDimension.SystemValue = 0.7853981633974;
            
            myDimension = swModel.Parameter("D6@Sketch1");
            myDimension.SystemValue = 0.7853981633974;

            /*swModel.ClearSelection2(true);
            swModel.SketchManager.InsertSketch(true);*/
            
        }

        public void SetParameter(double L, double L1, double L2, double L3, double L4, double A1, double A2, double A3, double B1, double B2, double B3, double C1, double C2, double C3, double R1, double R2, double R3, double P, double P1, double P2, double P3, double P4)
        {
            Dimension myDimension;

            myDimension = swModel.Parameter("D1@Sketch1");
            myDimension.SystemValue = L;

            myDimension = swModel.Parameter("D2@Sketch1");
            myDimension.SystemValue = L1;

            myDimension = swModel.Parameter("D24@Sketch1");
            myDimension.SystemValue = L2;

            myDimension = swModel.Parameter("D21@Sketch1");
            myDimension.SystemValue = L3;

            myDimension = swModel.Parameter("D3@Sketch1");
            myDimension.SystemValue = L4;

            myDimension = swModel.Parameter("D18@Sketch1");
            myDimension.SystemValue = A1;

            myDimension = swModel.Parameter("D19@Sketch1");
            myDimension.SystemValue = A2;

            myDimension = swModel.Parameter("D20@Sketch1");
            myDimension.SystemValue = A3;
            
            myDimension = swModel.Parameter("D12@Sketch1");
            myDimension.SystemValue = B1;

            myDimension = swModel.Parameter("D25@Sketch1");
            myDimension.SystemValue = B2;
            
            myDimension = swModel.Parameter("D9@Sketch1");
            myDimension.SystemValue = B3;

            swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
        }

        public void SetParameter(DataGridView Dg)
        {
            Dimension myDimension;
            //DataGridViewRow dr = Dg.SelectedRows;

            //MessageBox.Show(" "+Dg.Columns[1].Name);
            myDimension = swModel.Parameter("D1@Sketch1");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["AL"].Value) / 1000.0;

            myDimension = swModel.Parameter("D2@Sketch1");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["A1"].Value) / 1000.0;

            myDimension = swModel.Parameter("D3@Sketch1");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["A2"].Value) / 1000.0;

            myDimension = swModel.Parameter("D4@Sketch1");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["BL"].Value) / 1000.0;

            myDimension = swModel.Parameter("D5@Sketch1");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["B1"].Value) / 1000.0;

            myDimension = swModel.Parameter("D6@Sketch1");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["B2"].Value) / 1000.0;

            myDimension = swModel.Parameter("D1@Sketch2");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["C1"].Value) / 1000.0;

            myDimension = swModel.Parameter("D2@Sketch2");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["A21"].Value) / 1000.0;

            myDimension = swModel.Parameter("D1@Boss-Extrude1");
            myDimension.SystemValue = Convert.ToDouble(Dg.CurrentRow.Cells["CL"].Value) / 1000.0;

            swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
        }

        public void SetConstraints()
        { 
            swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Point2", "SKETCHPOINT", 0, 0, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point1@Исходная точка", "EXTSKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgCOINCIDENT");
            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 6.13024227528094E-03, 5.19243595505618E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 5.96631905898877E-02, -1.31445168539324E-03, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgHORIZONTAL2D");
            swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 9.87834220505618E-02, 4.56828988764046E-03, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgHORIZONTAL2D");
            swModel.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0.221144446769663, 2.42754741573034E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0.147610177106742, 3.13347640449438E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgHORIZONTAL2D");
            swModel.Extension.SelectByID2("Line7", "SKETCHSEGMENT", 0.091135858005618, 3.63350943820225E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.Extension.SelectByID2("Line8", "SKETCHSEGMENT", 9.64303254213483E-02, 4.39826584269663E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgHORIZONTAL2D");
            swModel.Extension.SelectByID2("Line10", "SKETCHSEGMENT", 0.105548574859551, 5.39833191011236E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.Extension.SelectByID2("Line12", "SKETCHSEGMENT", 8.43707051966293E-02, 6.45722539325843E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgHORIZONTAL2D");
            swModel.Extension.SelectByID2("Line13", "SKETCHSEGMENT", 6.50202432644923E-02, 0.067656452589476, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.Extension.SelectByID2("Line15", "SKETCHSEGMENT", 6.81514166675974E-02, 0.084525773721325, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.Extension.SelectByID2("Line17", "SKETCHSEGMENT", 5.89125333435147E-02, 0.119146047131976, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgHORIZONTAL2D");
            swModel.Extension.SelectByID2("Line18", "SKETCHSEGMENT", 4.56482179874298E-02, 0.11916607246612, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Line20", "SKETCHSEGMENT", 4.29840054858562E-02, 4.58675598970808E-02, 0, false, 0, null, 0);
            swModel.SketchAddConstraints("sgVERTICAL2D");
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 5.59205595730353E-02, -1.22149698025098E-03, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Point2", "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgCOINCIDENT");
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 7.72735338883662E-02, 3.04616937449152E-03, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 8.48048005907781E-02, 2.9470737599861E-03, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgTANGENT");
            swModel.Extension.SelectByID2("Line11", "SKETCHSEGMENT", 0.103376881464186, 6.32383636475022E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line9", "SKETCHSEGMENT", 0.103456855294426, 4.38846967294255E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line11", "SKETCHSEGMENT", 0.102977012312987, 6.34782851382222E-02, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgSAMELENGTH");
            swModel.Extension.SelectByID2("Line12", "SKETCHSEGMENT", 6.73844808641926E-02, 6.38934539896525E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 6.59023850256901E-02, 6.43380827412033E-02, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgTANGENT");
            swModel.Extension.SelectByID2("Line13", "SKETCHSEGMENT", 6.53095466902891E-02, 6.63759645191442E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 0.065568913462027, 6.47456590967914E-02, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgTANGENT");
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Line13", "SKETCHSEGMENT", 6.53095466902891E-02, 6.87843702567107E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Arc3", "SKETCHSEGMENT", 6.54207038781768E-02, 6.97106801557747E-02, 0, true, 0, null, 0);
            swModel.Extension.SelectByID2("Line14", "SKETCHSEGMENT", 6.63099613812783E-02, 7.06369900548388E-02, 0, true, 0, null, 0);
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Line13", "SKETCHSEGMENT", 6.51242847104763E-02, 6.79321651495718E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Arc3", "SKETCHSEGMENT", 6.51983895024014E-02, 6.96365753638496E-02, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgTANGENT");
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("Arc3", "SKETCHSEGMENT", 6.53836514822142E-02, 6.95624705719245E-02, 0, false, 0, null, 0);
            swModel.Extension.SelectByID2("Line14", "SKETCHSEGMENT", 6.61988041933906E-02, 7.05258328669511E-02, 0, true, 0, null, 0);
            swModel.SketchAddConstraints("sgTANGENT");
            swModel.ClearSelection2(true);
            swModel.SketchManager.InsertSketch(true);
        }
    }
}
