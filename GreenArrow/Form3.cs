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

        #region Main disk
        private Parts ModelMainDisk()
        {            
            Skeths obj = new Skeths("Front Plane#PLANE");
            obj.Addcurve(new Lines(0.0, 0.0, 0.0, 0.12, true));
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
            
            obj.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Line2" });
            obj.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "Line17" });
            obj.Addholdon("sgMERGEPOINTS", new string[] { "Point27#SKETCHPOINT", "Point48#SKETCHPOINT" });
            obj.Addholdon("sgVERTICAL2D", new string[] { "Line1", "Line5", "Line7", "Line10", "Line13", "Line15", "Line18", "Line20" });
            obj.Addholdon("sgHORIZONTAL2D", new string[] { "Line2", "Line3", "Line6", "Line8", "Line12", "Line17" });
            obj.Addholdon("sgTANGENT", new string[] { "Arc1", "Line3" });
            obj.Addholdon("sgTANGENT", new string[] { "Arc2", "Line12" });
            obj.Addholdon("sgTANGENT", new string[] { "Arc2", "Line13" });
            obj.Addholdon("sgTANGENT", new string[] { "Arc3", "Line13" });
            obj.Addholdon("sgTANGENT", new string[] { "Arc3", "Line14" });
            obj.Addholdon("sgSAMELENGTH", new string[] { "Line9", "Line11" });

            obj.AddDimensions("L1", "D1@Sketch1", 44.0, 1.92410562632759E-02, -7.07066997571618E-03, 0, new string[] { "Line1", "Line20" });
            obj.AddDimensions("L2", "D2@Sketch1", 75.0, 1.91940014638582E-02, -1.23223783068875E-02, 0, new string[] { "Line1", "Point4#SKETCHPOINT" });
            obj.AddDimensions("L3", "D3@Sketch1", 92.0, 1.91940014638582E-02, -1.72250381368784E-02, 0, new string[] { "Line1", "Line7" });
            obj.AddDimensions("L4", "D4@Sketch1", 90.0, 0.171442859186185, -7.71614083277133E-03, 0, new string[] { "Point6#SKETCHPOINT", "Line5" });
            obj.AddDimensions("L", "D5@Sketch1", 220.0, 0.112791962512324, -2.72664397240583E-02, 0, new string[] { "Line1", "Line5" });

            obj.AddDimensions("A1", "D6@Sketch1", 3.0, 0.235672988877163, -5.19323145671756E-03, 0, new string[] { "Point6#SKETCHPOINT", "Line2" });
            obj.AddDimensions("A2", "D7@Sketch1", 19.0, 0.238905357094653, -1.30047879823179E-02, 0, new string[] { "Line3", "Point8#SKETCHPOINT" });
            obj.AddDimensions("A3", "D8@Sketch1", 27.0, 0.246824659227503, -1.25468691515069E-02, 0, new string[] { "Line3", "Point10#SKETCHPOINT" });

            obj.AddDimensions("B1", "D9@Sketch1", 13.0, 8.22971169572715E-02, 3.62618909325893E-02, 0, new string[] { "Line6", "Line8" });
            obj.AddDimensions("B2", "D10@Sketch1", 1.5, 0.113651088666923, 2.01000498451402E-02, 0, new string[] { "Line8", "Point18#SKETCHPOINT" });
            obj.AddDimensions("B3", "D11@Sketch1", 21.0, 0.125287614249886, 5.24237320200384E-02, 0, new string[] { "Line8", "Line12" });

            obj.AddDimensions("C1", "D12@Sketch1", 6.0, 5.90049514012385E-02, 6.69016973383437E-02, 0, new string[] { "Line12", "Point27" });
            obj.AddDimensions("C2", "D13@Sketch1", 50.0, 5.88632977527308E-02, 9.44411843099708E-02, 0, new string[] { "Point27#SKETCHPOINT", "Line17" });
            obj.AddDimensions("C3", "D14@Sketch1", 3.5, 0.047866828442385, 0.113617966235732, 0, new string[] { "Line18" });

            obj.AddDimensions("P ", "D15@Sketch1", 104.0, 5.08178229385648E-02, 0.165455523343392, 0, new string[] { "Line1", "Line10" });
            obj.AddDimensions("P1", "D16@Sketch1", 65.25, 3.24109454172402E-02, 0.151788178610754, 0, new string[] { "Line1", "Line13" });
            obj.AddDimensions("P2", "D17@Sketch1", 67.5, 8.25536664541829E-02, 0.146099739238891, 0, new string[] { "Line1", "Line15" });
            obj.AddDimensions("P3", "D18@Sketch1", 45.5, 2.16705530106305E-02, 0.139608282277779, 0, new string[] { "Line1", "Line18" });
            obj.AddDimensions("P4", "D19@Sketch1", 2.0, 7.57069271072886E-02, 0.126125295452838, 0, new string[] { "Line15", "Point32#SKETCHPOINT" });

            obj.AddDimensions("R1", "D20@Sketch1", 3.0, 0.101996461833947, -1.08404055644014E-02, 0, new string[] { "Arc1" });
            obj.AddDimensions("R2", "D21@Sketch1", 1.5, 5.87019814261912E-02, 5.90262209351121E-02, 0, new string[] { "Arc2" });
            obj.AddDimensions("R3", "D22@Sketch1", 1.0, 5.38627028895404E-02, 7.68964645758224E-02, 0, new string[] { "Arc3" });

            obj.AddDimensions("", "D23@Sketch1", 7.0, 0.1179443469952, 4.82912958762281E-02, 0, new string[] { "Line8", "Line9" });
            obj.AddDimensions("", "D24@Sketch1", 7.0, 0.112618975211204, 0.059042518157126, 0, new string[] { "Line11", "Line12" });
            obj.AddDimensions("", "D25@Sketch1", 7.0, 6.91276137444525E-02, 0.07704703712233, 0, new string[] { "Line14", "Line15" });
            obj.AddDimensions("", "D26@Sketch1", 7.0, 7.20344600119221E-02, 0.117241021486221, 0, new string[] { "Line16", "Line17" });
            obj.AddDimensions("", "D27@Sketch1", 7.0, 4.80599774687718E-02, 0.124456279203618, 0, new string[] { "Line18", "Line19" });

            obj.Addvalidation(new String[][] {
                    new String[] {"L1"}, 
                    new String[] {"L2"}                    
                });            

            obj = new FeatureRevolve(obj, true, true, false, false, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj1 = new Skeths("Top Plane#PLANE");
            obj1.Addcurve(new Lines(0.0, 0.0, 0.012, 0.0));
            obj1.Addcurve(new Lines(0.012, 0.0, 0.012, 0.0512));
            obj1.Addcurve(new Lines(0.012, 0.0512, -0.012, 0.0512));
            obj1.Addcurve(new Lines(-0.012, 0.0512, -0.012, 0.0));
            obj1.Addcurve(new Lines(-0.012, 0.0, 0.0, 0.0));

            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line2", "Line4" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line3", "Line5" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line1", "Line5" });

            obj1.AddDimensions("Ls1", "D1@Sketch2", 24.0, -1.07E-03, 0, -0.075, new string[] { "Line3" });
            obj1.AddDimensions("Ls2", "D2@Sketch2", 51.2, 2.77E-02, 0, -2.62E-02, new string[] { "Line2" });

            obj1 = new FeatureCut(obj1, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            
            Skeths obj2 = new Skeths("Front Plane#PLANE");

            obj2.Addcurve(new Lines(0.0, 0.0, 0.0, 0.12, true));
            obj2.Addcurve(new Circles(0.0, 0.108, 0.006, 0.108));
            obj2.Addcurve(new Circles(0.0, 0.082, 0.006, 0.082));

            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point4#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point6#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj2.Addholdon("sgSAMELENGTH", new string[] { "Arc1", "Arc2" });          
            obj2.Addholdon("sgCOINCIDENT", new string[] { "#EDGE#3,2329318600858E-03$0,120601207763059$4,53849991912421E-02", "Point2#SKETCHPOINT" });  

            obj2.AddDimensions("Lo1", "D1@Sketch3", 12.0, 1.78077438386126E-02, 0.106767487919033, 0, new string[] { "Arc1" });
            obj2.AddDimensions("Lo2", "D2@Sketch3", 12.0, 1.08908839165999E-02, 0.113437317129546, 0, new string[] { "Point2#SKETCHPOINT", "Point4#SKETCHPOINT" });
            obj2.AddDimensions("Lo3", "D3@Sketch3", 26.0, 1.91940014638582E-02, -1.23223783068875E-02, 0, new string[] { "Point4#SKETCHPOINT", "Point6#SKETCHPOINT" });

            obj2 = new FeatureCut(obj2, true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj3 = new Skeths("#FACE#-9,95552624226514E-03$2,99998932188146E-02$0,173838804384169#*Top$5");
            
            obj3.Addcurve(new Circles(0.0, 0.0, 0.0, -0.115, true));
            obj3.Addcurve(new Lines(0.0, 0.0, 0.0, -0.115, true));
            obj3.Addcurve(new Circles(0.0, -0.115, 0.008, -0.115));

            obj3.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point2#SKETCHPOINT" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point3#SKETCHPOINT" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point4#SKETCHPOINT" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point6#SKETCHPOINT" });
            obj3.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point6#SKETCHPOINT" });

            obj3.AddDimensions("Dr1", "D1@Sketch4", 230.0, 6.76258708892342E-02, 2.99998932188135E-02, 0.149717335319497, new string[] { "Arc1" });
            obj3.AddDimensions("Dr2", "D2@Sketch4", 16.0, -0.098164809038237, 2.99998932188135E-02, 0.141104832466122, new string[] { "Arc2" });

            obj3 = new FeatureCut(obj3, true, false, false, 0, 0, 0.008, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            InsertFeatureChamfer obj4 = new InsertFeatureChamfer(4, 2, 0.004, 0, 0.008, 0, 0, 0,
            new string[] { "#FACE#-4,08368783160995E-03$2,19998932188901E-02$0,110652144080802#*Isometric$7" });

            InsertAxis obj5 = new InsertAxis(new string[] { "#FACE#-3.16988322693987E-02$8.93674636061519E-02$-3.05153081707203E-02" });

            FeatureCircularPattern obj6 = new FeatureCircularPattern(4, 6.2831853071796, false, "NULL", false, true, false,
            new string[] { "Axis1#AXIS###1", "Cut-Extrude3#BODYFEATURE###4", "Chamfer1#BODYFEATURE###4" });

            Skeths obj7 = new Skeths("#FACE#6,63813705514258E-02$6,39999999998508E-02$3,79767921819507E-02");

            obj7.Addcurve(new Circles(0.0, 0.0, 0.000035, 0.09592, true));
            obj7.Addcurve(new Arcs(0, 0, -0.010458, 0.114523, 0.010458, 0.114523, -1));
            obj7.Addcurve(new Lines(0, 0, 0, 0.115, true));
            obj7.Addcurve(new Arcs(0, 0.096828, 0.001813, 0.095983, -0.001813, 0.095983, -1));
            obj7.Addcurve(new Lines(0.001813, 0.095983, 0.010458, 0.114523));
            obj7.Addcurve(new Lines(-0.001813, 0.095983, -0.010458, 0.114523));

            obj7.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point2#SKETCHPOINT" });
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point5#SKETCHPOINT" });
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point6#SKETCHPOINT" });
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point8#SKETCHPOINT", "Arc1" });
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point9#SKETCHPOINT", "Arc1" }); 
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point10#SKETCHPOINT", "Line1" });
            obj7.Addholdon("sgATMIDDLE", new string[] { "Point7#SKETCHPOINT", "Arc2" });
            obj7.Addholdon("sgSAMELENGTH", new string[] { "Line2", "Line3" });
            obj7.Addholdon("sgTANGENT", new string[] { "Line3", "Arc3" });

            obj7.AddDimensions("Drr1", "D1@Sketch5", 115.0, -0.042459050642795, 6.39998932188135E-02, -0.129035592855359, new string[] { "Arc2" });
            obj7.AddDimensions("Dd2", "D2@Sketch5", 192.0, -6.22746173183176E-02, 6.39998932188135E-02, -0.10948423373551, new string[] { "Arc1" });
            obj7.AddDimensions("Dd3", "D3@Sketch5", 2.0, -2.00157865461459E-04, 0.06, -9.49623814562773E-02, new string[] { "Arc3" });
            obj7.AddDimensions("", "D4@Sketch5", Math.PI / 4.0, -8.01496704130032E-03, 6.39998932188135E-02, -0.126580095644763, new string[] { "Line1", "Line3" });
            obj7 = new FeatureCut(obj7, true, false, false, 2, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            FeatureCircularPattern obj8 = new FeatureCircularPattern(50, 6.2831853071796, false, "NULL", false, true, false,
            new string[] { "Axis1#AXIS###1", "Cut-Extrude4#BODYFEATURE###4" });

            Parts objpart = new Parts();
            objpart.AddItem(obj);
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);
            objpart.AddItem(obj5);
            objpart.AddItem(obj6);
            objpart.AddItem(obj7);
            objpart.AddItem(obj8);

            objpart.waysPng = "./imeg/Основний диск.jpg";
            objpart.material = "Основний диск.jpg";
            SmartTools.SaveXML(objpart);

            return objpart;
        }
        #endregion
        #region Base Bild
        private Parts ModelBase()
        {
            Skeths obj1 = new Skeths("Top Plane#PLANE");
            obj1.Addcurve(new Lines(0.048, -0.0245, 0.048, 0.0315));
            obj1.Addcurve(new Lines(0.036, 0.0435, -0.08, 0.0435));
            obj1.Addcurve(new Lines(-0.092, 0.0315, -0.092, -0.0245));
            obj1.Addcurve(new Lines(-0.08, -0.0365, 0.036, -0.0365));

            obj1.Addcurve(new Arcs(0.036, 0.0315, 0.048, 0.0315, 0.036, 0.0435, 1));
            obj1.Addcurve(new Arcs(-0.08, 0.0315, -0.08, 0.0435, -0.092, 0.0315, 1));
            obj1.Addcurve(new Arcs(-0.08, -0.0245, -0.092, -0.0245, -0.08, -0.0365, 1));
            obj1.Addcurve(new Arcs(0.036, -0.0245, 0.036, -0.0365, 0.048, -0.0245, 1));

            obj1.Addcurve(new Lines(-0.092, 0.0085, 0.048, 0.0085, true));
            obj1.Addcurve(new Lines(-0.057, -0.0365, -0.057, 0.0435, true));
            obj1.Addcurve(new Circles(0, 0, 0, 0.025, true));
            obj1.Addcurve(new Circles(0, 0.025, 0.002, 0.025));

            obj1.Addcurve(new Circles(-0.08, 0.0315, -0.08, 0.0341));
            obj1.Addcurve(new Circles(0.036, 0.0315, 0.036, 0.0341));
            obj1.Addcurve(new Circles(0.036, -0.0245, 0.036, -0.0219));
            obj1.Addcurve(new Circles(-0.08, -0.0245, -0.08, -0.0219));

            obj1.Addcurve(new Circles(-0.057, 0.0285, -0.057, 0.03175));
            obj1.Addcurve(new Circles(-0.057, 0.0185, -0.057, 0.021));

            obj1.Addcurve(new SketchMirror(new string[] { "Arc11", "Arc12", "Line5" }));
            obj1.Addcurve(new CreateCircularSketchStepAndRepeat(0.025, 4.71238898038472, 4, 1.5707963267949, true, "", false, false, true, new string[] { "Arc6" }));

            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point26#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point28#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point51#SKETCHPOINT" });

            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1", "Line3", "Line6" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line2", "Line4", "Line5" });

            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line1" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line2" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line2" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line3" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc3", "Line3" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc3", "Line4" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc4", "Line4" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc4", "Line1" });

            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line3", "Point21#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point22#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point24#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line4", "Point23#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line6", "Point40#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line6", "Point38#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc5", "Point28#SKETCHPOINT" });

            obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc1", "Arc2", "Arc3", "Arc4" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc7", "Arc8", "Arc9", "Arc10" });

            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point11#SKETCHPOINT", "Point32#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point14#SKETCHPOINT", "Point30#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point17#SKETCHPOINT", "Point36#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point20#SKETCHPOINT", "Point34#SKETCHPOINT" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 6, 0, 0.012, 0.01, false, false, false, false,
                1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Skeths obj2 = new Skeths("Top Plane#PLANE");
            obj2.Addcurve(new Lines(-0.092, 0.0085, 0.048, 0.0085, true));
            obj2.Addcurve(new Lines(-0.092, 0.0085, 0, 0.0085));
            obj2.Addcurve(new Lines(-0.003, 0.0115, -0.077, 0.0115));
            obj2.Addcurve(new Lines(-0.077, 0.0115, -0.077, 0.0125));

            obj2.Addcurve(new Lines(-0.077, 0.0125, -0.092, 0.0125));
            obj2.Addcurve(new Lines(-0.092, 0.0125, -0.092, 0.0085));
            obj2.Addcurve(new Arcs(-0.003, 0.0085, -0.003, 0.0115, 0, 0.0085, -1));

            obj2.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line2", "Line3", "Line5" });
            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line4" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point14#SKETCHPOINT" });
            obj2.Addholdon("sgTANGENT", new string[] { "Arc1", "Line3" });
            obj2.Addholdon("sgCOLINEAR", new string[] { "Line6", "#EDGE#-9,22192952634023E-02$5,99999999997181E-03$-0,011245942918453" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point1#SKETCHPOINT", "Point3#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "#EDGE#4,81978189481414E-02$5,99999999997181E-03$-5,22844944338617E-03" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point15#SKETCHPOINT" });
            obj2.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point4#SKETCHPOINT" });

            obj2 = new FeatureRevolve(obj2, true, true, false, true, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj3 = new Skeths("Top Plane#PLANE");
            obj3.Addcurve(new Lines(-0.092, 0.0085, 0.048, 0.0085, true));
            obj3.Addcurve(new Lines(-0.057, -0.0365, -0.057, 0.0435, true));
            obj3.Addcurve(new Lines(0, -0.0365, 0, 0.0435, true));

            obj3.Addcurve(new Circles(-0.057, 0.0085, -0.060, 0.0085));
            obj3.Addcurve(new Circles(-0.003, 0.0085, -0.006, 0.0085));

            obj3.Addholdon("sgHORIZONTAL2D", new string[] { "Line1" });
            obj3.Addholdon("sgVERTICAL2D", new string[] { "Line2", "Line3" });

            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point1", "#EDGE#-0,092043108024888$5,99999999997181E-03$-3,50000000000005E-03" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point2", "#EDGE#4,86079717992823E-02$5,99999999997181E-03$-1,47972754878852E-02" });

            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point3", "#EDGE#-5,40089472156746E-02$5,99999999997181E-03$3,66053279819923E-02" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point5", "#EDGE#-9,38470903852823E-03$5,99999999997181E-03$3,69819038315885E-02" });

            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point4", "#EDGE#-4,77954456973378E-02$5,99999999997181E-03$-4,36053279819924E-02" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point6", "#EDGE#-4,77954456973378E-02$5,99999999997181E-03$-4,36053279819924E-02" });

            obj3.Addholdon("sgATINTERSECT", new string[] { "Line1", "Line2", "Point8#SKETCHPOINT" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point10#SKETCHPOINT" });
            obj3.Addholdon("sgTANGENT", new string[] { "Line3", "Arc2" });

            obj3.Addholdon("sgSAMELENGTH", new string[] { "Arc1", "Arc2" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Line3", "Point1@Origin#EXTSKETCHPOINT" });

            obj3 = new FeatureCut(obj3, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj4 = new Skeths("#FACE#3,57776891632966E-05$6,00000000008549E-03$1,35059250396807E-03");

            obj4.Addcurve(new Circles(-0.057, 0.0085, -0.0515, 0.0085));
            obj4.Addholdon("sgCONCENTRIC", new string[] { "Arc1", "#EDGE#-5,59701767411774E-02$5,99999999997181E-03$-1,13519896146238E-02" });

            obj4 = new FeatureCut(obj4, true, false, false, 0, 0, 0.0015, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj5 = new Skeths("Top Plane#PLANE");

            obj5.Addcurve(new Lines(-0.092, 0.0085, 0.048, 0.0085, true));
            obj5.Addcurve(new Circles(-0.057, 0.0285, -0.0515, 0.0285));
            obj5.Addcurve(new SketchMirror(new string[] { "Arc1", "Line1" }));

            obj5.Addholdon("sgHORIZONTAL2D", new string[] { "Line1" });
            obj5.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "#EDGE#-9,24196838744842E-02$5,99999999997181E-03$-1,31026841647024E-02" });
            obj5.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "#EDGE#0,048043108024888$5,99999999997181E-03$-1,25378203903082E-02" });
            obj5.Addholdon("sgCONCENTRIC", new string[] { "Arc1", "#EDGE#-5,51386747644631E-02$5,99999999997181E-03$-2,60945509757704E-02" });

            obj5 = new FeatureCut(obj5, true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);
            objpart.AddItem(obj5);

            return objpart;
        }
        #endregion
        #region Bearing Support
        private Parts ModelBearingSupport()
        {
            Skeths obj1 = new Skeths("Top Plane#PLANE");
            obj1.Addcurve(new Lines(0.0, 0.0, 0.0, 0.017, true));
            obj1.Addcurve(new Lines(0.0055, -0.004, 0.0175, -0.004));
            obj1.Addcurve(new Lines(0.0175, -0.004, 0.0175, 0));
            obj1.Addcurve(new Lines(0.0175, 0, 0.008, 0));
            obj1.Addcurve(new Lines(0.008, 0, 0.008, 0.017));

            obj1.Addcurve(new Lines(0.008, 0.017, 0.00275, 0.017));
            obj1.Addcurve(new Lines(0.00275, 0.017, 0.00275, 0.012));
            obj1.Addcurve(new Lines(0.00275, 0.012, 0.0055, 0.012));
            obj1.Addcurve(new Lines(0.0055, 0.012, 0.0055, 0.0091));
            obj1.Addcurve(new Lines(0.0055, 0.0091, 0.006, 0.0091));

            obj1.Addcurve(new Lines(0.006, 0.0091, 0.006, 0.008));
            obj1.Addcurve(new Lines(0.006, 0.008, 0.0055, 0.008));
            obj1.Addcurve(new Lines(0.0055, 0.008, 0.0055, -0.004));

            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1", "Line3", "Line5", "Line7", "Line9", "Line11", "Line13" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line2", "Line4", "Line6", "Line8", "Line10", "Line12" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Line4" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "Line6" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line9", "Line13" });

            obj1.AddDimensions("L1", "D1@Sketch1", 44.0, 8.13358059348787E-03, 0, 7.12875694574078E-03, new string[] { "Line1", "Line3" });
            obj1.AddDimensions("L2", "D1@Sketch1", 21.0, 3.4056735566341E-03, 0, -1.92129571977826E-02, new string[] { "Line1", "Line5" });
            obj1.AddDimensions("L3", "D2@Sketch1", 30.0, 2.72143870036511E-03, 0, -2.90830620150508E-03, new string[] { "Line13" });
            obj1.AddDimensions("L4", "D2@Sketch1", 10.0, 2.72143870036511E-03, 0, -9.99329195250215E-03, new string[] { "Line9" });
            obj1.AddDimensions("M1", "D2@Sketch1", 4.0, 3.18763960577776E-03, 0, -8.53676563977858E-03, new string[] { "Line11" });
            obj1.AddDimensions("M2", "D2@Sketch1", 1.0, -3.85714344927279E-03, 0, -7.05984340789838E-03, new string[] { "Line1" });
            obj1.AddDimensions("M3", "D2@Sketch1", 14.0, 1.66259747521645E-03, 0, -1.41774040736871E-02, new string[] { "Line7" });
            
            obj1 = new FeatureRevolve(obj1, true, true, false, false, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj2 = new Skeths("Front Plane#PLANE##*Isometric$7");
            obj2.Addcurve(new Lines(0, 0, 0, 0.013, true));
            obj2.Addcurve(new Circles(0, 0.013, 0.002, 0.013));

            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point4#SKETCHPOINT" });

            obj2 = new FeatureCut(obj2, true, false, true, 2, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            InsertFeatureChamfer obj3 = new InsertFeatureChamfer(4, 1, 0.0003, 0.78539816339745, 0, 0, 0, 0,
            new string[] { "#EDGE#1,69795213764701E-04$1,09517084366075E-02$4,05186918618483E-03" });

            InsertAxis obj4 = new InsertAxis(new string[] { "#FACE#-2,67799749605047E-03$-4,80399098773887E-03$8,24244501700377E-04" });

            FeatureCircularPattern obj5 = new FeatureCircularPattern(4, 6.2831853071796, false, "NULL", false, true, false,
            new string[] { "Axis1#AXIS###1", "Cut-Extrude1#BODYFEATURE###4", "Chamfer1#BODYFEATURE###4" });

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);
            objpart.AddItem(obj5);

            SmartTools.SaveXML(objpart, "temlatestf");
            return objpart;
        }
        #endregion        
        #region Counter Weight
        private Parts ModelCounterWeight(bool B)
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE");
            obj1.Addcurve(new Arcs(0, -0.015, -0.025, -0.015, 0.025, -0.015, 1));
            obj1.Addcurve(new Lines(0.025, -0.015, 0.006, -0.015));
            obj1.Addcurve(new Lines(0.006, -0.015, 0.006, 0));
            obj1.Addcurve(new Lines(-0.025, -0.015, -0.006, -0.015));
            obj1.Addcurve(new Lines(-0.006, -0.015, -0.006, 0));
            obj1.Addcurve(new Arcs(0, 0, 0.006, 0, -0.006, 0, 1));
            obj1.Addcurve(new Circles(0, 0, 0, 0.003));

            obj1.Addholdon("sgATINTERSECT", new string[] { "Line1", "Line3", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point3#SKETCHPOINT", "Point14#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point14#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point14#SKETCHPOINT", "Point16#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line2", "Line4" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line3" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line2" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line4" });
            
            if (B)
            {
                obj1.Addcurve(new Circles(0, -0.015, 0.003086, -0.01467));
                obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc3", "Arc4" });
                obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point3#SKETCHPOINT", "Point18#SKETCHPOINT" });
            }

            obj1 = new FeatureExtrusion(obj1, true, false, false, 6, 0, 0.008, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Skeths obj2 = new Skeths("Top Plane#PLANE");
            obj2.Addcurve(new Circles(0, 0, 0, 0.0015));
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point2#SKETCHPOINT" });

            obj2 = new FeatureCut(obj2, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);

            return objpart;
        }
        #endregion
        #region Crank Rod
        private Parts ModelCrankRod()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE");
            obj1.Addcurve(new Lines(0, 0, 0, 0.006, true));
            obj1.Addcurve(new Lines(0, 0, 0.037, 0, true));
            obj1.Addcurve(new Arcs(0.031, 0, 0.0285, 0, 0.0335, 0, -1));
            obj1.Addcurve(new Arcs(0.031, 0, 0.037, 0, 0.031, 0.006, 1));
            obj1.Addcurve(new Lines(0.031, 0.006, 0, 0.006));
            obj1.Addcurve(new SketchMirror(new string[] { "Line2", "Line3", "Arc1", "Arc2" }));
            obj1.Addcurve(new SketchMirror(new string[] { "Line1", "Line3", "Line4", "Arc1", "Arc2", "Arc3" }));

            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line2", "Line3" });
            
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point7#SKETCHPOINT", "Line2" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point10#SKETCHPOINT", "Line2" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point8#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point12#SKETCHPOINT" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point5#SKETCHPOINT", "Point6#SKETCHPOINT", "Point7#SKETCHPOINT" });
            obj1.Addholdon("sgCONCENTRIC", new string[] { "Arc1", "Arc2" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line3" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 6, 0, 0.006, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Skeths obj2 = new Skeths("#FACE#-6,6932509672597E-03$3,62660635914835E-04$3,00000000004275E-03");
            obj2.Addcurve(new Lines(0, 0, 0, 0.00475, true));
            obj2.Addcurve(new Lines(0, 0, 0.02625, 0, true));
            obj2.Addcurve(new Lines(0.026641, 0.00475, 0, 0.00475));

            obj2.Addcurve(new Arcs(0.031, 0, 0.02625, 0, 0.027399, 0.003098, -1));
            obj2.Addcurve(new Arcs(0.026641, 0.00375, 0.026641, 0.00475, 0.027399, 0.003098, -1));
            obj2.Addcurve(new SketchMirror(new string[] { "Line2", "Line3", "Arc1", "Arc2" }));
            obj2.Addcurve(new SketchMirror(new string[] { "Line3", "Arc2", "Arc1", "Arc3", "Arc4", "Line4", "Line1" }));

            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj2.Addholdon("sgHORIZONTAL2D", new string[] { "Line2", "Line3" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point3#SKETCHPOINT" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point6#SKETCHPOINT" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point7#SKETCHPOINT" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point8#SKETCHPOINT", "Point11#SKETCHPOINT" });            
            obj2.Addholdon("sgTANGENT", new string[] { "Arc1", "Arc2" });
            obj2.Addholdon("sgTANGENT", new string[] { "Line3", "Arc1" });
            obj2.Addholdon("sgTANGENT", new string[] { "Line3", "Arc2" });
            obj2.Addholdon("sgCONCENTRIC", new string[] { "Arc1", "#EDGE#2,87094966620016E-02$8,7298306155529E-04$2,9999999999859E-03" });

            obj2 = new FeatureCut(obj2, true, false, false, 0, 0, 0.001, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            InsertMirrorFeature obj3 = new InsertMirrorFeature(false, false, false, false,
            new string[] { "Cut-Extrude1#BODYFEATURE###1", "Front Plane#PLANE###2" });

            InsertFeatureChamfer obj4 = new InsertFeatureChamfer(4, 1, 0.0005, 0.78539816339745, 0, 0, 0, 0,
            new string[] { "#EDGE#2,90949205775064E-02$6,05021085414137E-03$2,94979730557543E-03",
                           "#EDGE#2,88000182713972E-02$5,93993643315116E-03$-2,93994619454452E-03",
                           "#EDGE#3,47478413740987E-02$4,57988920982189E-03$3,11547000802648E-03",
                           "#EDGE#3,59642851244075E-02$3,34981741559659E-03$-2,98441703381513E-03",
                           "#EDGE#2,28059868964579E-02$-6,00885795699924E-03$3,00885651762428E-03",
                           "#EDGE#-3,67173040681905E-02$2,29068034195734E-03$3,09214288910198E-03",
                           "#EDGE#-3,44050125750641E-02$4,87946599173483E-03$-2,98782740884462E-03#*Bottom$6",
                           "#EDGE#-3,44050125750641E-02$4,87946599173483E-03$-2,98782740884462E-03#*Isometric$7"});

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);

            return objpart;
        }
        #endregion
        #region Crank Shaft
        private Parts ModelCrankShaft()
        {
            Skeths obj1 = new Skeths("Right Plane#PLANE");
            obj1.Addcurve(new Circles(0, -0.002, 0.002496, -0.002009));
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point2#SKETCHPOINT" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 6, 0, 0.035, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            InsertFeatureChamfer obj2 = new InsertFeatureChamfer(4, 1, 0.0005, 0.78539816339745, 0, 0, 0, 0,
            new string[] { "#EDGE#-1,74917823150622E-02$4,66866129045229E-04$3,4351909630459E-04", 
                           "#EDGE#1,74313435956037E-02$5,30615812920132E-04$2,33017234620547E-04" });

            Skeths obj3 = new Skeths("Top Plane#PLANE");
            obj3.Addcurve(new Lines(0, 0, 0, 0.002496, true));
            obj3.Addcurve(new Lines(0.0095, 0.0025, 0.0175, 0.0025));
            obj3.Addcurve(new Lines(0.0095, -0.0025, 0.0175, -0.0025));
            obj3.Addcurve(new Lines(0.0095, -0.0025, 0.0095, 0.0025));
            obj3.Addcurve(new Lines(0.0175, -0.0025, 0.0175, 0.0025));
            obj3.Addcurve(new Lines(0, 0, 0.0175, 0, true));
            obj3.Addcurve(new SketchMirror(new string[] { "Line1", "Line2", "Line3", "Line4", "Line5" }));

            obj3.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point10#SKETCHPOINT" });            
            obj3.Addholdon("sgCOLINEAR", new string[] { "Line5", "#EDGE#1,75268219832708E-02$-6,11254546356577E-06$-9,21606895014724E-05" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });
            obj3.Addholdon("sgVERTICAL2D", new string[] { "Line1", "Line4" });
            obj3.Addholdon("sgHORIZONTAL2D", new string[] { "Line2", "Line3", "Line6" });
            obj3.Addholdon("sgATMIDDLE", new string[] { "Point12#SKETCHPOINT", "Line5" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point11#SKETCHPOINT" });

            obj3 = new FeatureCut(obj3, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);

            return objpart;
        }
        #endregion
        #region Cross Head
        private Parts ModelCrossHead()
        {
            Skeths obj1 = new Skeths("Right Plane#PLANE");
            obj1.Addcurve(new Lines(0, 0, 0.005, 0, true));
            obj1.Addcurve(new Lines(0, 0, 0, 0.007, true));
            obj1.Addcurve(new Lines(0.005, 0, 0.005, 0.007));
            obj1.Addcurve(new Lines(0.005, 0.007, -0.005, 0.007));
            obj1.Addcurve(new Lines(-0.005, 0.007, -0.005, 0.005));
            obj1.Addcurve(new Lines(-0.005, 0.005, 0.002, 0.005));
            obj1.Addcurve(new Lines(0.002, 0.005, 0.002, 0));
            obj1.Addcurve(new SketchMirror(new string[] { "Line1", "Line3", "Line4", "Line5", "Line6", "Line7" }));

            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line2", "Line3", "Line5", "Line7" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line4", "Line6" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgATMIDDLE", new string[] { "Line4", "Point4#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point1#SKETCHPOINT", "Point5#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point14#SKETCHPOINT" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 6, 0, 0.05, 0.01, false, false, false, false, 
                1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Skeths obj2 = new Skeths("#FACE#6,898255944634E-04$0,007000000000005$-9,58451389010406E-05");
            obj2.Addcurve(new Lines(0, 0, 0.005, 0, true));
            obj2.Addcurve(new Lines(-0.01, 0.005, 0.005, 0.005));
            obj2.Addcurve(new Lines(-0.01, -0.005, 0.005, -0.005));
            obj2.Addcurve(new Lines(0.005, -0.005, 0.005, 0.005));
            obj2.Addcurve(new Lines(-0.01, -0.005, -0.01, 0.005));

            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line4", "Line5" });
            obj2.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line2", "Line3" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });
            obj2.Addholdon("sgATMIDDLE", new string[] { "Line4", "Point2#SKETCHPOINT" });

            obj2 = new FeatureExtrusion(obj2, true, false, false, 0, 0, 0.012, 0.01, false, false, false, false, 
                1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Skeths obj3 = new Skeths("Front Plane#PLANE");
            obj3.Addcurve(new Lines(0, 0, 0.019, 0, true));
            obj3.Addcurve(new Lines(0, 0, 0, 0.003, true));
            obj3.Addcurve(new Lines(0, 0.003, 0.016, 0.003));
            obj3.Addcurve(new Arcs(0.016, 0, 0.016, 0.003, 0.019, 0, -1));
            obj3.Addcurve(new SketchMirror(new string[] { "Line1", "Line3", "Arc1" }));
            obj3.Addcurve(new SketchMirror(new string[] { "Line2", "Line3", "Line4", "Line5", "Arc1", "Arc2", "Arc5" }));

            obj3.Addholdon("sgVERTICAL2D", new string[] { "Line2" });
            obj3.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line3" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point3#SKETCHPOINT" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point9#SKETCHPOINT" });
            obj3.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point5#SKETCHPOINT" });
            obj3.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point8#SKETCHPOINT" });
            obj3.Addholdon("sgTANGENT", new string[] { "Arc1", "Line3" });

            obj3 = new FeatureCut(obj3, true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj4 = new Skeths("#FACE#-2,06212630172331E-03$1,90000000000623E-02$1,88700474552661E-04");
            obj4.Addcurve(new Circles(0, 0, 0, 0.0025));
            obj4.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });

            obj4 = new FeatureCut(obj4, true, false, false, 0, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, 
                false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj5 = new Skeths("#FACE#-9,99999999987722E-03$1,29384201252947E-02$-1,54283338815731E-05#*Left$3");
            obj5.Addcurve(new Lines(0, 0, 0, 0.013, true));
            obj5.Addcurve(new Lines(0, 0.013, 0.005, 0.013, true));
            obj5.Addcurve(new Circles(0, 0.013, 0.00225, 0.013));

            obj5.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point1#SKETCHPOINT" });            
            obj5.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point6#SKETCHPOINT" });
            obj5.Addholdon("sgMERGEPOINTS", new string[] { "Point3#SKETCHPOINT", "Point2#SKETCHPOINT" });
            obj5.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj5.Addholdon("sgATMIDDLE", new string[] { "Point4#SKETCHPOINT", "#EDGE#-9,99999999999091E-03$1,13618604539381E-02$4,90735511777073E-03" });
            obj5.Addholdon("sgHORIZONTAL2D", new string[] { "Line2###*Isometric$7" });

            obj5 = new FeatureCut(obj5, true, false, false, 2, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            InsertFeatureChamfer obj6 = new InsertFeatureChamfer(4, 1, 0.0005, 0.78539816339745, 0, 0, 0, 0,
                new string[] { "#EDGE#-2,49873537040912E-03$0,019118082819773$-6,98073949365607E-04" });

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);
            objpart.AddItem(obj5);
            objpart.AddItem(obj6);

            return objpart;
        }
        #endregion
        #region Cylinder Cover
        private Parts ModelCylinderCover()
        {
            Skeths obj1 = new Skeths("Top Plane#PLANE");
            obj1.Addcurve(new Lines(-0.005, 0, 0.027, 0, true));
            obj1.Addcurve(new Lines(0.027, 0.0025, 0.027, 0.008));
            obj1.Addcurve(new Lines(0.027, 0.008, 0, 0.008));
            obj1.Addcurve(new Lines(0, 0.008, 0, 0.023));
            obj1.Addcurve(new Lines(0, 0.023, -0.005, 0.023));
            obj1.Addcurve(new Lines(-0.005, 0.023, -0.005, 0.0025));
            obj1.Addcurve(new Lines(-0.005, 0.0025, 0.027, 0.0025));

            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line1" });

            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line4", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line6", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point2#SKETCHPOINT" });

            obj1.Addholdon("sgPARALLEL", new string[] { "Line1", "Line7" });            
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line6", "Line7" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line2", "Line7" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line2", "Line3" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line3", "Line4" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line4", "Line5" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line5", "Line6" });

            obj1 = new FeatureRevolve(obj1, true, true, false, false, false, false, 0, 0, 
                6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj2 = new Skeths("Right Plane#PLANE##*Isometric$7");
            obj2.Addcurve(new Lines(0, -0.008, 0, -0.023, true));
            obj2.Addcurve(new Circles(0, -0.0155, 0.003, -0.0155));

            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });

            obj2.Addholdon("sgATMIDDLE", new string[] { "Line1", "Point4#SKETCHPOINT" });

            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "#EDGE#2,69999999999868E-02$-7,89662768915077E-03$-7,32526576619902E-04" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "#EDGE#0,0$-2,30475462485859E-02$-1,13123495976293E-03" });

            obj2 = new FeatureCut(obj2, true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);

            return objpart;
        }
        #endregion
        #region Cylinder Packing
        private Parts ModelCylinderPacking()
        {
            Skeths obj1 = new Skeths("Top Plane#PLANE");
            obj1.Addcurve(new Circles(0, 0, 0.02, 0));
            obj1.Addcurve(new Circles(0, 0, 0.025, 0, true));
            obj1.Addcurve(new Circles(0, 0, 0.032, 0));
            obj1.Addcurve(new Circles(0, 0.025, 0.002, 0.025));
            obj1.Addcurve(new CreateCircularSketchStepAndRepeat(0.025, 4.71238898038472, 4, 
                1.5707963267949, true, "", false, false, true, new string[] { "Arc4" }));

            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc2", "Point8#SKETCHPOINT" });
            obj1.Addholdon("sgCONCENTRIC", new string[] { "Arc1", "Arc2" });
            obj1.Addholdon("sgCONCENTRIC", new string[] { "Arc3", "Point2#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point2#SKETCHPOINT", "Point8#SKETCHPOINT" });
            obj1.Addholdon("sgFIXED", new string[] { "Point15#SKETCHPOINT" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 0, 0, 0.0005, 0.01, false, false, false, false, 
                1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);

            return objpart;
        }
        #endregion
        #region Cylinder
        private Parts ModelCylinder()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE");
            obj1.Addcurve(new Lines(0, 0, 0, 0.06, true));
            obj1.Addcurve(new Lines(0.02, 0, 0.032, 0));
            obj1.Addcurve(new Lines(0.032, 0, 0.032, 0.006));
            obj1.Addcurve(new Lines(0.032, 0.006, 0.0175, 0.006));
            obj1.Addcurve(new Lines(0.0175, 0.006, 0.0175, 0.06));
            obj1.Addcurve(new Lines(0.0175, 0.06, 0.015, 0.06));
            obj1.Addcurve(new Lines(0.015, 0.06, 0.015, 0.0023));
            obj1.Addcurve(new Lines(0.015, 0.0023, 0.02, 0.0023));
            obj1.Addcurve(new Lines(0.02, 0.0023, 0.02, 0));

            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj1.Addholdon("sgPARALLEL", new string[] { "Line1", "Line7" });

            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line6", "Point2#SKETCHPOINT" });            
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point1#SKETCHPOINT" });

            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line2", "Line3" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line3", "Line4" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line4", "Line5" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line5", "Line6" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line6", "Line7" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line7", "Line8" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line8", "Line9" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line9", "Line2" });

            obj1 = new FeatureRevolve(obj1, true, true, false, false, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj2 = new Skeths("Top Plane#PLANE");
            obj2.Addcurve(new Circles(0, 0, 0, 0.025, true));
            obj2.Addcurve(new Circles(0, 0.025, 0.002, 0.025));
            obj2.Addcurve(new CreateCircularSketchStepAndRepeat(0.025, 4.71238898038472, 4,
                1.5707963267949, true, "", false, false, true, new string[] { "Arc2" }));

            obj2.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point4#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1@Origin#EXTSKETCHPOINT", "Point2#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point4#SKETCHPOINT" });
            obj2.Addholdon("sgFIXED", new string[] { "Point11#SKETCHPOINT##*Isometric$7" });

            obj2 = new FeatureCut(obj2, true, false, true, 2, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            InsertFeatureChamfer obj3 = new InsertFeatureChamfer(4, 1, 0.0005, 0.78539816339745, 0, 0, 0, 0,
                new string[] {  "#EDGE#-2,57822365080642E-02$5,99833197134103E-03$1,77950597560539E-03",
                                "#EDGE#1,59589845441133E-03$6,0945489100277E-03$2,58104639701173E-02",
                                "#EDGE#2,68339304474807E-02$5,8817753735525E-03$4,68932891067197E-04",
                                "#EDGE#1,79826225547686E-03$6,01440953158772E-03$-2,51245981290253E-02",
                                "#EDGE#2,42059206336762E-02$5,8566315291273E-03$2,10852075772436E-02",
                                "#EDGE#1,28300741149587E-02$5,97820367376585E-02$1,21267666465883E-02" });
                        
            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);

            return objpart;
        }
        #endregion
        #region Flywheel shaft
        private Parts ModelFlywheelShaft()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE");
            obj1.Addcurve(new Lines(0, 0, 0, 0.0005, true));
            obj1.Addcurve(new Circles(0, -0.002, 0.0, 0.0005));

            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "Arc1" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point4#SKETCHPOINT", "Line1" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 0, 0, 0.052, 0.01, false, false, false, false, 
                1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            InsertFeatureChamfer obj2 = new InsertFeatureChamfer(4, 1, 0.0005, 0.78539816339745, 0, 0, 0, 0,
                new string[] {  "#EDGE#-3,31054853234036E-04$4,29791055921669E-04$5,20400139284334E-02",
                                "#EDGE#4,99547018307567E-04$5,3626508065463E-04$-1,01502014388188E-04"});

            Skeths obj3 = new Skeths("Top Plane#PLANE");
            obj3.Addcurve(new Lines(-0.0025, 0, 0.0025, 0));
            obj3.Addcurve(new Lines(-0.0025, -0.01, 0.0025, -0.01));
            obj3.Addcurve(new Lines(-0.0025, 0, -0.0025, -0.01));
            obj3.Addcurve(new Lines(0.0025, 0, 0.0025, -0.01));

            obj3.Addholdon("sgATMIDDLE", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });
            obj3.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line2" });
            obj3.Addholdon("sgVERTICAL2D", new string[] { "Line3", "Line4" });

            obj3 = new FeatureCut(obj3, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            
            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);

            return objpart;
        }
        #endregion
        #region Flywheel
        private Parts ModelFlywheel()
        {
            Skeths obj1 = new Skeths("Right Plane#PLANE##*Isometric$7");
            obj1.Addcurve(new Lines(0, 0, 0, 0.01, true));
            obj1.Addcurve(new Lines(-0.0095, 0, 0.0055, 0, true));
            
            obj1.Addcurve(new Lines(-0.0095, 0.0025, 0.0055, 0.0025));
            obj1.Addcurve(new Lines(0.0055, 0.0025, 0.0055, 0.0095));
            obj1.Addcurve(new Lines(0.005, 0.01, -0.005, 0.01));
            obj1.Addcurve(new Lines(-0.0055, 0.0105, -0.0055, 0.0395));
            obj1.Addcurve(new Lines(-0.005, 0.04, -0.003, 0.04));

            obj1.Addcurve(new Lines(-0.0025, 0.0405, -0.0025, 0.0545));
            obj1.Addcurve(new Lines(-0.003, 0.055, -0.014, 0.055));
            obj1.Addcurve(new Lines(-0.0145, 0.0545, -0.0145, 0.0405));
            obj1.Addcurve(new Lines(-0.014, 0.04, -0.01, 0.04));
            obj1.Addcurve(new Lines(-0.0095, 0.0395, -0.0095, 0.0025));

            obj1.Addcurve(new Arcs(0.005, 0.0095, 0.005, 0.01, 0.0055, 0.0095, -1));
            obj1.Addcurve(new Arcs(-0.005, 0.0105, -0.005, 0.01, -0.0055, 0.0105, -1));
            obj1.Addcurve(new Arcs(-0.005, 0.0395, -0.0055, 0.0395, -0.005, 0.04, -1));
            obj1.Addcurve(new Arcs(-0.003, 0.0405, -0.003, 0.04, -0.0025, 0.0405, 1));
            obj1.Addcurve(new Arcs(-0.003, 0.0545, -0.0025, 0.0545, -0.003, 0.055, 1));

            obj1.Addcurve(new Arcs(-0.014, 0.0545, -0.014, 0.055, -0.0145, 0.0545, 1));
            obj1.Addcurve(new Arcs(-0.014, 0.0405, -0.0145, 0.0405, -0.014, 0.04, 1));
            obj1.Addcurve(new Arcs(-0.01, 0.0395, -0.01, 0.04, -0.0095, 0.0395, -1));

            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line2" });

            obj1.Addholdon("sgATMIDDLE", new string[] { "Line5", "Point2#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line12", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line4", "Point4#SKETCHPOINT" });

            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line1", "Line2" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line3", "Line4" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line4", "Line5" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line5", "Line6" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line6", "Line7" });

            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line7", "Line8" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line8", "Line9" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line9", "Line10" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line10", "Line11" });
            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line11", "Line12" });

            obj1.Addholdon("sgPERPENDICULAR", new string[] { "Line12", "Line3" });

            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line4" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line5" });            
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line5" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line6" });            
            obj1.Addholdon("sgTANGENT", new string[] { "Arc3", "Line6" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc3", "Line7" });

            obj1.Addholdon("sgTANGENT", new string[] { "Arc4", "Line7" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc4", "Line8" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc5", "Line8" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc5", "Line9" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc6", "Line9" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc6", "Line10" });

            obj1.Addholdon("sgTANGENT", new string[] { "Arc7", "Line10" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc7", "Line11" });            
            obj1.Addholdon("sgTANGENT", new string[] { "Arc8", "Line11" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc8", "Line12" });

            obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc1", "Arc2", "Arc3", "Arc4", "Arc5", "Arc6", "Arc7", "Arc8" });
            obj1.Addholdon("sgCOLINEAR", new string[] { "Line7", "Line11" });

            obj1 = new FeatureRevolve(obj1, true, true, false, false, false, false, 0, 0,
                6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true,
                new string[] { "Sketch1#SKETCH", "Line2@Sketch1#EXTSKETCHSEGMENT#-2,86775168177655E-03$0$0#*Isometric$7#16" });

            Skeths obj2 = new Skeths("Front Plane#PLANE##*Back$2");
            obj2.Addcurve(new Lines(0, 0.01, 0, 0.04, true));
            obj2.Addcurve(new Circles(0, 0, 0, 0.025, true));
            obj2.Addcurve(new Circles(0, 0.025, 0.0075, 0.025));
            
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "#EDGE#-5,29631691328997E-03$8,52805725651058E-03$4,99999999999545E-03" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "#EDGE#-2,22390593108858E-03$3,99758616927443E-02$2,9999999999859E-03" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });
            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point4#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj2.Addholdon("sgATMIDDLE", new string[] { "Line1", "Point6#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point6#SKETCHPOINT" });

            obj2 = new FeatureCut(obj2, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj3 = new Skeths("Top Plane#PLANE##*Isometric$7");
            obj3.Addcurve(new Circles(0, 0, 0, 0.0015));

            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });

            obj3 = new FeatureCut(obj3, true, false, true, 2, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            FeatureFillet obj4 = new FeatureFillet(195, 0.0015, 0, 0, null, null, null,
                new string[] {  "#EDGE#-5,71508892562633E-04$1,74699814189694E-02$9,55569824924396E-03", 
                                "#EDGE#-1,73722428820611E-03$1,76389675108908E-02$5,57637928272925E-03" });

            InsertAxis obj5 = new InsertAxis(new string[] { "Top Plane#PLANE", "Right Plane#PLANE" });

            FeatureCircularPattern obj6 = new FeatureCircularPattern(8, 6.2831853071796, false, "NULL", false, true, false,
                new string[] { "Axis1#AXIS###1", "Fillet1#BODYFEATURE###4", "Cut-Extrude1#BODYFEATURE###4" });
            
            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);
            objpart.AddItem(obj5);
            objpart.AddItem(obj6);

            return objpart;
        }
        #endregion
        #region Exchange Cylinder
        private Parts ModelExchangeCylinder()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE##*Isometric$7");
            obj1.Addcurve(new Lines(0.009, 0, -0.11875, 0, true));            

            obj1.Addcurve(new Lines(-0.11875, 0, -0.118, 0));
            obj1.Addcurve(new Lines(0.005, 0.01825, 0.005, 0.0225));
            obj1.Addcurve(new Lines(0.005, 0.0225, 0.009, 0.0225));
            obj1.Addcurve(new Lines(0.009, 0.0225, 0.009, 0.0375));
            obj1.Addcurve(new Lines(0.009, 0.0375, 0.007, 0.0375));

            obj1.Addcurve(new Lines(0.007, 0.0375, 0.007, 0.0325));
            obj1.Addcurve(new Lines(0.007, 0.0325, 0.002, 0.0325));
            obj1.Addcurve(new Lines(0.002, 0.0325, 0.002, 0.0375));
            obj1.Addcurve(new Lines(0.002, 0.0375, 0, 0.0375));
            obj1.Addcurve(new Lines(0, 0.0375, 0, 0.019));

            obj1.Addcurve(new Lines(0, 0.019, -0.005, 0.019));
            obj1.Addcurve(new Lines(-0.005, 0.019, -0.005, 0.0375));
            obj1.Addcurve(new Lines(-0.005, 0.0375, -0.007, 0.0375));
            obj1.Addcurve(new Lines(-0.007, 0.0375, -0.007, 0.019));
            obj1.Addcurve(new Lines(-0.007, 0.019, -0.012, 0.019));

            obj1.Addcurve(new Lines(-0.012, 0.019, -0.012, 0.0375));
            obj1.Addcurve(new Lines(-0.012, 0.0375, -0.014, 0.0375));
            obj1.Addcurve(new Lines(-0.014, 0.0375, -0.014, 0.019));
            obj1.Addcurve(new Lines(-0.014, 0.019, -0.019, 0.019));
            obj1.Addcurve(new Lines(-0.019, 0.019, -0.019, 0.0375));

            obj1.Addcurve(new Lines(-0.019, 0.0375, -0.021, 0.0375));
            obj1.Addcurve(new Lines(-0.021, 0.0375, -0.021, 0.019));
            obj1.Addcurve(new Lines(-0.021, 0.019, -0.026, 0.019));
            obj1.Addcurve(new Lines(-0.026, 0.019, -0.026, 0.0375));
            obj1.Addcurve(new Lines(-0.026, 0.0375, -0.028, 0.0375));

            obj1.Addcurve(new Lines(-0.028, 0.0375, -0.028, 0.019));
            obj1.Addcurve(new Lines(-0.028, 0.019, -0.033, 0.019));
            obj1.Addcurve(new Lines(-0.033, 0.019, -0.033, 0.0375));
            obj1.Addcurve(new Lines(-0.033, 0.0375, -0.035, 0.0375));
            obj1.Addcurve(new Lines(-0.035, 0.0375, -0.035, 0.019));

            obj1.Addcurve(new Lines(-0.035, 0.019, -0.04, 0.019));
            obj1.Addcurve(new Lines(-0.04, 0.019, -0.04, 0.0375));
            obj1.Addcurve(new Lines(-0.04, 0.0375, -0.042, 0.0375));
            obj1.Addcurve(new Lines(-0.042, 0.0375, -0.042, 0.019));
            obj1.Addcurve(new Lines(-0.042, 0.019, -0.047, 0.019));

            obj1.Addcurve(new Lines(-0.047, 0.019, -0.047, 0.01855));
            obj1.Addcurve(new Lines(-0.047, 0.01855, -0.082625, 0.01855));
            obj1.Addcurve(new Lines(-0.082625, 0.01855, -0.082625, 0.019));
            obj1.Addcurve(new Lines(-0.082625, 0.019, -0.11825, 0.019));
            obj1.Addcurve(new Lines(-0.11875, 0.0185, -0.11875, 0));

            obj1.Addcurve(new Lines(-0.118, 0, -0.118, 0.01775));
            obj1.Addcurve(new Lines(-0.1175, 0.01825, 0.005, 0.01825));

            obj1.Addcurve(new Arcs(-0.1175, 0.01775, -0.118, 0.01775, -0.1175, 0.01825, -1));
            obj1.Addcurve(new Arcs(-0.11825, 0.0185, -0.11875, 0.0185, -0.11825, 0.019, -1));

            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line3", "Line5", "Line7", "Line9", "Line11", "Line13", "Line15", "Line17", "Line19", "Line21", 
                "Line23", "Line25", "Line27", "Line29", "Line31", "Line33", "Line35", "Line37", "Line39", "Line41", "Line42" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line2", "Line4", "Line6", "Line8", "Line10", "Line12", "Line14", "Line16", 
                "Line18", "Line20", "Line22", "Line24", "Line26", "Line28", "Line30", "Line32", "Line34", "Line36", "Line38", "Line40", "Line43" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line8", "Line12", "Line16", "Line20", "Line24", "Line28", "Line32", "Line36" });
            obj1.Addholdon("sgCOLINEAR", new string[] { "Line12", "Line16", "Line20", "Line24", "Line28", "Line32", "Line36" });
            obj1.Addholdon("sgCOLINEAR", new string[] { "Line12", "Line16", "Line20", "Line24", "Line28", "Line32", "Line36", "Line40" });
            obj1.Addholdon("sgCOLINEAR", new string[] { "Line6", "Line10", "Line14", "Line18", "Line22", "Line26", "Line30", "Line34" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line6", "Line10", "Line14", "Line18", "Line22", "Line26", "Line30", "Line34" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line5", "Point1#SKETCHPOINT" });                        
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line40" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line41" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line42" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line43" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc1", "Arc2" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line38", "Line40" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line11", "Point1@Origin#EXTSKETCHPOINT" });

            obj1 = new FeatureRevolve(obj1, true, true, false, false, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj2 = new Skeths("Right Plane#PLANE##*Isometric$7");
            obj2.Addcurve(new Lines(0, 0, 0, 0.036, true));
            obj2.Addcurve(new Lines(0, 0, -0.019445, 0.019445, true));
            obj2.Addcurve(new Circles(-0.019445, 0.019445, -0.019445, 0.022695));

            obj2.Addholdon("sgFIXED", new string[] { "Point1#SKETCHPOINT" });
            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point1#SKETCHPOINT", "Point3#SKETCHPOINT" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point6#SKETCHPOINT" });
            obj2.Addholdon("sgFIXED", new string[] { "Point4#SKETCHPOINT" });

            obj2 = new FeatureCut(obj2, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            InsertAxis obj3 = new InsertAxis(new string[] { "Top Plane#PLANE", "Front Plane#PLANE" });

            FeatureCircularPattern obj4 = new FeatureCircularPattern(4, 6.2831853071796, false, "NULL", false, true, false,
                new string[] { "Cut-Extrude1#BODYFEATURE###4", "Axis1#AXIS###1"  });
            
            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);

            return objpart;
        }
        #endregion
        #region Heat Exchange Piston
        private Parts ModelHeatExchangePiston()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE##*Isometric$7");
            obj1.Addcurve(new Lines(0.006, 0, -0.084, 0, true));
            obj1.Addcurve(new Lines(0.006, 0.0025, 0.006, 0.017));
            obj1.Addcurve(new Lines(0.0055, 0.0175, -0.0835, 0.0175));
            obj1.Addcurve(new Lines(-0.0815, 0.017, 0.0035, 0.017));
            obj1.Addcurve(new Lines(0.004, 0.0165, 0.004, 0.0095));
            obj1.Addcurve(new Lines(-0.082, 0, -0.082, 0.0165));
            obj1.Addcurve(new Lines(0.004, 0.0095, 0, 0.0095));
            obj1.Addcurve(new Lines(0, 0.0095, 0, 0.004));
            obj1.Addcurve(new Lines(0, 0.004, -0.009, 0.004));
            obj1.Addcurve(new Lines(-0.009, 0.004, -0.009, 0.0025));
            obj1.Addcurve(new Lines(-0.009, 0.0025, 0.006, 0.0025));
            obj1.Addcurve(new Lines(-0.084, 0.017, -0.084, 0));
            obj1.Addcurve(new Lines(-0.084, 0, -0.082, 0));
            obj1.Addcurve(new Arcs(0.0035, 0.0165, 0.004, 0.0165, 0.0035, 0.017, 1));
            obj1.Addcurve(new Arcs(0.0055, 0.017, 0.0055, 0.0175, 0.006, 0.017, -1));
            obj1.Addcurve(new Arcs(-0.0815, 0.0165, -0.0815, 0.017, -0.082, 0.0165, 1));
            obj1.Addcurve(new Arcs(-0.0835, 0.017, -0.0835, 0.0175, -0.084, 0.017, 1));

            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point24#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point11#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line8", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line1", "Line3", "Line4", "Line7", "Line9", "Line11" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line2", "Line5", "Line6", "Line8", "Line10", "Line12" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line4" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc1", "Line5" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line2" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc2", "Line3" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc3", "Line4" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc3", "Line6" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc4", "Line3" });
            obj1.Addholdon("sgTANGENT", new string[] { "Arc4", "Line12" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc1", "Arc2", "Arc3", "Arc4" });

            obj1 = new FeatureRevolve(obj1, true, true, false, false, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj2 = new Skeths("Right Plane#PLANE##*Isometric$7");
            obj2.Addcurve(new Lines(0, 0, 0, 0.00675, true));
            obj2.Addcurve(new Circles(0, 0.00675, 0.00125, 0.00675));

            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point4#SKETCHPOINT" });
            obj2.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });

            obj2 = new FeatureCut(obj2, true, false, true, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);

            return objpart;
        }
        #endregion
        #region Piston
        private Parts ModelPiston()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE##*Isometric$7");
            obj1.Addcurve(new Lines(0, 0, 0, 0.028, true));
            obj1.Addcurve(new Lines(0, 0, 0, 0.001));
            obj1.Addcurve(new Lines(0, 0, 0.015, 0));
            obj1.Addcurve(new Lines(0.015, 0, 0.015, 0.0275));
            obj1.Addcurve(new Lines(0.015, 0.0275, 0.0145, 0.028));
            obj1.Addcurve(new Lines(0.0145, 0.028, 0.0115, 0.028));
            obj1.Addcurve(new Lines(0.0115, 0.028, 0.011, 0.0275));
            obj1.Addcurve(new Lines(0.011, 0.0275, 0.011, 0.016));
            obj1.Addcurve(new Lines(0.011, 0.016, 0.01, 0.016));
            obj1.Addcurve(new Lines(0.01, 0.016, 0.01, 0.001));
            obj1.Addcurve(new Lines(0.01, 0.001, 0, 0.001));

            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point1#SKETCHPOINT", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point4#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line4", "Line8", "Line10" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line3", "Line6", "Line9", "Line11" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line6", "Point2#SKETCHPOINT" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line5", "Line7" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point8#SKETCHPOINT", "Point14#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point3#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });

            obj1 = new FeatureRevolve(obj1, true, true, false, false, false, false, 0, 0, 
                6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj2 = new Skeths("Right Plane#PLANE##*Isometric$7");
            obj2.Addcurve(new Lines(0, 0.028, 0, 0.012, true));
            obj2.Addcurve(new Circles(0, 0.012, 0.0025, 0.012));

            obj2.Addholdon("sgATMIDDLE", new string[] { "Point1#SKETCHPOINT", "#EDGE#-1,13084351679618E-02$0,028173156283878$-2,09028563898921E-03" });
            obj2.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj2.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point4#SKETCHPOINT" });

            obj2 = new FeatureCut(obj2, false, false, false, 1, 1, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02,
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            
            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);

            return objpart;
        }
        #endregion
        #region Slide
        private Parts ModelSlide()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE##*Isometric$7");
            obj1.Addcurve(new Lines(-0.009, 0.005, 0.009, -0.005, true));
            obj1.Addcurve(new Lines(0.009, 0.005, -0.009, -0.005, true));
            obj1.Addcurve(new Lines(0.009, -0.004, 0.009, 0.004));
            obj1.Addcurve(new Lines(0.009, 0.004, 0.008, 0.005));
            obj1.Addcurve(new Lines(0.008, 0.005, -0.008, 0.005));
            obj1.Addcurve(new Lines(-0.008, 0.005, -0.009, 0.004));
            obj1.Addcurve(new Lines(-0.009, 0.004, -0.009, -0.004));
            obj1.Addcurve(new Lines(-0.009, -0.004, -0.008, -0.005));
            obj1.Addcurve(new Lines(-0.008, -0.005, 0.008, -0.005));
            obj1.Addcurve(new Lines(0.008, -0.005, 0.009, -0.004));            
            obj1.Addcurve(new Circles(0, 0, 0.0025, 0));

            obj1.Addholdon("sgATMIDDLE", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgATMIDDLE", new string[] { "Line2", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgATINTERSECT", new string[] { "Line5", "Line7", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgATINTERSECT", new string[] { "Line3", "Line5", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgATINTERSECT", new string[] { "Line3", "Line9", "Point2#SKETCHPOINT" });
            obj1.Addholdon("sgATINTERSECT", new string[] { "Line7", "Line9", "Point4#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Point22#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line4", "Line6", "Line8", "Line10" });

            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line5", "Line9" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line3", "Line7" });

            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point10#SKETCHPOINT", "Point16#SKETCHPOINT" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point5#SKETCHPOINT", "Point14#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point8#SKETCHPOINT", "Point18#SKETCHPOINT" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 6, 0, 0.0072, 0.01, false, false, false, false, 
                1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);

            return objpart;
        }
        #endregion
        #region Standard
        private Parts ModelStandard()
        {
            Skeths obj1 = new Skeths("Right Plane#PLANE##*Isometric$7");
            obj1.Addcurve(new Lines(0, 0, 0, 0.09, true));
            obj1.Addcurve(new Lines(-0.01944543648263, 0.10944543648263, 0, 0.09, true));
            obj1.Addcurve(new Lines(0.03, 0.12, 0.03, 0));
            obj1.Addcurve(new Lines(0.02, 0.13, 0.03, 0.12));
            obj1.Addcurve(new Lines(-0.02, 0.13, 0.02, 0.13));
            obj1.Addcurve(new Lines(-0.03, 0.12, -0.02, 0.13));
            obj1.Addcurve(new Lines(-0.03, 0, -0.03, 0.12));
            obj1.Addcurve(new Lines(0.03, 0, -0.03, 0));
            obj1.Addcurve(new Circles(0, 0.09, 0.02629838078898, 0.09804022187988, true));

            obj1.Addcurve(new Circles(-0.01944543648263, 0.10944543648263, -0.01633744602575, 0.11039564452298));
            obj1.Addcurve(new Circles(0.01944543648263, 0.10944543648263, 0.02255342693951, 0.11039564452298));
            obj1.Addcurve(new Circles(0.01944543648263, 0.07055456351737, 0.02255342693951, 0.07150477155772));
            obj1.Addcurve(new Circles(-0.01944543648263, 0.07055456351737, -0.01633744602575, 0.07150477155772));
            obj1.Addcurve(new Circles(0, 0.09, 0.0076504380477, 0.09233897363778));

            obj1.Addcurve(new Lines(-0.01944543648263, 0.10944543648263, 0.01944543648263, 0.10944543648263, true));
            obj1.Addcurve(new Lines(0.01944543648263, 0.10944543648263, 0.01944543648263, 0.07055456351737, true));
            obj1.Addcurve(new Lines(0.01944543648263, 0.07055456351737, -0.01944543648263, 0.07055456351737, true));
            obj1.Addcurve(new Lines(-0.01944543648263, 0.07055456351737, -0.01944543648263, 0.10944543648263, true));

            obj1.Addholdon("sgATMIDDLE", new string[] { "Line8", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgATMIDDLE", new string[] { "Line8", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line5", "Line8", "Line9", "Line11" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1", "Line3", "Line7", "Line10", "Line12" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point4#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point18#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point28#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point3#SKETCHPOINT", "Point20#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point22#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point24#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc1", "Point26#SKETCHPOINT" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc2", "Arc3", "Arc4", "Arc5" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line4", "Line6" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point5#SKETCHPOINT", "Point11#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point24#SKETCHPOINT" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line9", "Line10", "Line11", "Line12" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point3#SKETCHPOINT", "Point29#SKETCHPOINT", "Point36#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point3#SKETCHPOINT", "Point29#SKETCHPOINT", "Point36#SKETCHPOINT" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point22#SKETCHPOINT", "Point30#SKETCHPOINT", "Point31#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point22#SKETCHPOINT", "Point30#SKETCHPOINT", "Point31#SKETCHPOINT" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point26#SKETCHPOINT", "Point34#SKETCHPOINT", "Point35#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point26#SKETCHPOINT", "Point34#SKETCHPOINT", "Point35#SKETCHPOINT" });
            obj1.Addholdon("sgHORIZONTALPOINTS2D", new string[] { "Point24#SKETCHPOINT", "Point32#SKETCHPOINT", "Point33#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point24#SKETCHPOINT", "Point32#SKETCHPOINT", "Point33#SKETCHPOINT" });

            obj1 = new FeatureExtrusion(obj1, true, false, false, 6, 0, 0.012, 0.01, false, false, false, false, 
                1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            FeatureFillet obj2 = new FeatureFillet(195, 0.01, 3, 0, null, null, null,
                new string[] {  "#FACE#-5,99999999997181E-03$4,72471385190377E-02$1,42022891847698E-03#*Left$3#2", 
                                "#FACE#2,73120945860961E-03$0,129999999999995$-4,04218999874266E-03#*Top$5#512", 
                                "#FACE#5,99999999997181E-03$4,27497469438605E-02$-4,02398193568482E-03#*Right$4#4" });

            Skeths obj3 = new Skeths("Top Plane#PLANE##*Isometric$7");
            obj3.Addcurve(new Lines(0, 0, 0, 0.02, true));
            obj3.Addcurve(new Lines(0, 0, 0.006, 0, true));
            obj3.Addcurve(new Circles(0, 0.02, 0.00325, 0.02));
            obj3.Addcurve(new Circles(0, 0.01, 0.0025, 0.01));
            obj3.Addcurve(new Circles(0, -0.02, 0.00325, -0.02));
            obj3.Addcurve(new Circles(0, -0.01, 0.0025, -0.01));

            obj3.Addholdon("sgCOINCIDENT", new string[] { "Point3#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj3.Addholdon("sgHORIZONTAL2D", new string[] { "Line2" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point3#SKETCHPOINT" });
            obj3.Addholdon("sgVERTICAL2D", new string[] { "Line1" });
            obj3.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point8#SKETCHPOINT" });
            obj3.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point6#SKETCHPOINT" });
            obj3.Addholdon("sgSYMMETRIC", new string[] { "Line2", "Point8#SKETCHPOINT", "Point12#SKETCHPOINT" });
            obj3.Addholdon("sgSYMMETRIC", new string[] { "Line2", "Point2#SKETCHPOINT", "Point10#SKETCHPOINT" });
            obj3.Addholdon("sgSAMELENGTH", new string[] { "Arc1", "Arc3" });
            obj3.Addholdon("sgSAMELENGTH", new string[] { "Arc2", "Arc4" });
            obj3.Addholdon("sgATMIDDLE", new string[] { "Point4#SKETCHPOINT", "#EDGE#6,07085247439997E-03$0,124000000000024$-4,43764841777516E-03" });

            obj3 = new FeatureCut(obj3, true, false, true, 0, 0, 0.02, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj4 = new Skeths("Right Plane#PLANE");
            obj4.Addcurve(new Lines(0, 0, 0, 0.0745, true));
            obj4.Addcurve(new Lines(0, 0, 0.003, 0));
            obj4.Addcurve(new Lines(0.003, 0, 0.003, 0.0745));
            obj4.Addcurve(new Lines(0, 0, 0, 0.0775));
            obj4.Addcurve(new Arcs(0, 0.0745, 0.003, 0.0745, 0, 0.0775, 1));

            obj4.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj4.Addholdon("sgCOINCIDENT", new string[] { "Point3#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj4.Addholdon("sgMERGEPOINTS", new string[] { "Point2#SKETCHPOINT", "Point11#SKETCHPOINT" });
            obj4.Addholdon("sgVERTICAL2D", new string[] { "Line1", "Line3", "Line4" });
            obj4.Addholdon("sgHORIZONTAL2D", new string[] { "Line2" });
            obj4.Addholdon("sgCOINCIDENT", new string[] { "Line4", "Point2#SKETCHPOINT" });
            obj4.Addholdon("sgTANGENT", new string[] { "Arc1", "Line3" });

            obj4 = new FeatureRevolve(obj4, true, true, false, true, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true);

            Skeths obj5 = new Skeths("Right Plane#PLANE");
            obj5.Addcurve(new Lines(0, 0, 0, 0.0745, true));
            obj5.Addcurve(new Circles(0, 0.0745, 0.003, 0.0745));

            obj5.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "Point1@Origin#EXTSKETCHPOINT" });
            obj5.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "Point3#SKETCHPOINT" });
            obj5.Addholdon("sgVERTICAL2D", new string[] { "Line1" });

            obj5 = new FeatureCut(obj5, true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj6 = new Skeths("#FACE#-9,46819278984656E-04$9,36412831892862E-02$-2,99999999999727E-02#*Back$2");
            obj6.Addcurve(new Lines(-0.006, 0.09, 0.006, 0.09, true));
            obj6.Addcurve(new Lines(0, 0.09, 0, 0.102, true));
            obj6.Addcurve(new Circles(0, 0.102, 0.003, 0.102));
            obj6.Addcurve(new Circles(0, 0.078, 0.003, 0.078));

            obj6.Addholdon("sgHORIZONTAL2D", new string[] { "Line1" });
            obj6.Addholdon("sgVERTICAL2D", new string[] { "Line2" });
            obj6.Addholdon("sgATMIDDLE", new string[] { "Line1", "Point3#SKETCHPOINT" });
            obj6.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point6#SKETCHPOINT" });
            obj6.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "#EDGE#6,07345530261463E-03$9,39553775831008E-02$-2,99999999999727E-02" });
            obj6.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "#EDGE#-5,97080676490076E-03$9,20323441437496E-02$-2,99999999999727E-02" });
            obj6.Addholdon("sgSYMMETRIC", new string[] { "Arc1", "Arc2", "Line1" });

            obj6 = new FeatureCut(obj6, true, false, false, 0, 0, 0.02, 0.01, false, false, false, false, 1.74532925199433E-02, 
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            Skeths obj7 = new Skeths("#FACE#-9,46819278984656E-04$9,36412831892862E-02$-2,99999999999727E-02#*Back$2");
            obj7.Addcurve(new Lines(-0.006, 0.09, 0.006, 0.09, true));
            obj7.Addcurve(new Lines(0, 0.09, 0, 0.095, true));
            obj7.Addcurve(new Circles(0, 0.095, 0.0015, 0.095));
            obj7.Addcurve(new Circles(0, 0.085, 0.0015, 0.085));

            obj7.Addholdon("sgHORIZONTAL2D", new string[] { "Line1" });
            obj7.Addholdon("sgVERTICAL2D", new string[] { "Line2" });
            obj7.Addholdon("sgATMIDDLE", new string[] { "Line1", "Point3#SKETCHPOINT" });
            obj7.Addholdon("sgMERGEPOINTS", new string[] { "Point4#SKETCHPOINT", "Point6#SKETCHPOINT" });
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point1#SKETCHPOINT", "#EDGE#6,07345530261463E-03$9,39553775831008E-02$-2,99999999999727E-02" });
            obj7.Addholdon("sgCOINCIDENT", new string[] { "Point2#SKETCHPOINT", "#EDGE#-5,97080676490076E-03$9,20323441437496E-02$-2,99999999999727E-02" });
            obj7.Addholdon("sgSYMMETRIC", new string[] { "Arc1", "Arc2", "Line1###*Isometric$7" });

            obj7 = new FeatureCut(obj7, true, false, false, 0, 0, 0.012, 0.01, false, false, false, false, 1.74532925199433E-02,
                1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            
            Parts objpart = new Parts();
            objpart.AddItem(obj1);
            objpart.AddItem(obj2);
            objpart.AddItem(obj3);
            objpart.AddItem(obj4);
            objpart.AddItem(obj5);
            objpart.AddItem(obj6);
            objpart.AddItem(obj7);

            return objpart;
        }
        #endregion
        #region Support
        private Parts ModelSupport()
        {
            Skeths obj1 = new Skeths("Front Plane#PLANE");
            obj1.Addcurve(new Lines(0, 0.018, 0, -0.018, true));
            obj1.Addcurve(new Lines(-0.006, 0, 0.075, 0, true));
            obj1.Addcurve(new Lines(-0.006, 0.016, -0.004, 0.018));
            obj1.Addcurve(new Lines(-0.004, -0.018, -0.006, -0.016));
            obj1.Addcurve(new Lines(-0.006, -0.016, -0.006, 0.016));
            obj1.Addcurve(new Lines(0.057, -0.018, -0.004, -0.018));
            obj1.Addcurve(new Lines(-0.004, 0.018, 0.057, 0.018));
            obj1.Addcurve(new Circles(0.057, 0, 0.0646504380477, 0.00233897363778));
            obj1.Addcurve(new Arcs(0.057, 0, 0.057, 0.018, 0.057, -0.018, -1));
            obj1.Addcurve(new Circles(0.044, 0, 0.04615168570092, 0.00065783633563));
            obj1.Addcurve(new Circles(0.07, 0, 0.07215168570092, 0.00065783633563));
            obj1.Addcurve(new Circles(0.057, -0.013, 0.05915168570092, -0.01234216366437));
            obj1.Addcurve(new Circles(0.057, 0.013, 0.05915168570092, 0.01365783633563));
            obj1.Addcurve(new Circles(0.057, 0, 0.06943196182752, 0.0038008321614, true));
            obj1.Addcurve(new Circles(0, 0.012, 0.00310799045688, 0.01295020804035));
            obj1.Addcurve(new Circles(0, 0.005, 0.00143445713394, 0.00543855755708));
            obj1.Addcurve(new Circles(0, -0.005, 0.00143445713394, -0.00456144244292));
            obj1.Addcurve(new Circles(0, -0.012, 0.00310799045688, -0.01104979195965));

            obj1.Addholdon("sgHORIZONTAL2D", new string[] { "Line2", "Line6", "Line7" });
            obj1.Addholdon("sgVERTICAL2D", new string[] { "Line1", "Line5" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgATMIDDLE", new string[] { "Line1", "Point1@Origin#EXTSKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line6", "Point2#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line7", "Point1#SKETCHPOINT" });
            obj1.Addholdon("sgATMIDDLE", new string[] { "Line5", "Point3#SKETCHPOINT" });
            obj1.Addholdon("sgATMIDDLE", new string[] { "Arc2", "Point4#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line2", "Point16#SKETCHPOINT" });
            obj1.Addholdon("sgATINTERSECT", new string[] { "Line2", "Arc7", "Point21#SKETCHPOINT" });
            obj1.Addholdon("sgATINTERSECT", new string[] { "Line2", "Arc7", "Point23#SKETCHPOINT" });
            obj1.Addholdon("sgVERTICALPOINTS2D", new string[] { "Point16#SKETCHPOINT", "Point25#SKETCHPOINT", "Point27#SKETCHPOINT" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Line3", "Line4" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point31#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Line1", "Point33#SKETCHPOINT" });
            obj1.Addholdon("sgSYMMETRIC", new string[] { "Line2", "Arc8", "Arc11" });
            obj1.Addholdon("sgSYMMETRIC", new string[] { "Line2", "Arc9", "Arc10" });
            obj1.Addholdon("sgATINTERSECT", new string[] { "Line2", "Arc7", "Point23#SKETCHPOINT" });
            obj1.Addholdon("sgSAMELENGTH", new string[] { "Arc3", "Arc4", "Arc5", "Arc6" });
            obj1.Addholdon("sgTANGENT", new string[] { "Line6", "Arc2" });
            obj1.Addholdon("sgTANGENT", new string[] { "Line7", "Arc2" });
            obj1.Addholdon("sgMERGEPOINTS", new string[] { "Point16#SKETCHPOINT", "Point29#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc7", "Point25#SKETCHPOINT" });
            obj1.Addholdon("sgCOINCIDENT", new string[] { "Arc7", "Point27#SKETCHPOINT" });

            obj1 = new FeatureExtrusion(obj1, true, false, true, 0, 0, 0.008, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            Parts objpart = new Parts();
            objpart.AddItem(obj1);

            return objpart;
        }
        #endregion

        public void SetPicture(String ways)
        {
            //@"C:\Users\Руслан\Desktop\GreenArrow\GreenArrow\Images\2017-03-27_073846.jpg"
            Bitmap image = new Bitmap(ways);
            //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
            this.pictureBox1.Size = image.Size;
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
        }

        protected ModelDoc2 swModel;

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                checkedListBox1.SetItemChecked(ix, false);
        }

        public Parts obj;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            switch (checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString())
            { 
                case "Base":
                    obj = ModelMainDisk();
                    SetPicture("./imeg/2017-03-27_073846.jpg");
                    break;
                case "Bearing support":
                    obj = ModelBearingSupport();
                    break;
                case "Counter weight":
                    obj = ModelCounterWeight(true);
                    break;
                case "Crank rod":
                    obj = ModelCrankRod();
                    break;
                case "Crank shaft":
                    obj = ModelCrankShaft();
                    break;
                case "Cross head":
                    obj = ModelCrossHead();
                    break;
                case "Cylinder":
                    obj = ModelCylinder();
                    break;
                case "Cylinder cover":
                    obj = ModelCylinderCover();
                    break;
                case "Cylinder packing":
                    obj = ModelCylinderPacking();
                    break;
                case "Exchange cylinder":
                    obj = ModelExchangeCylinder();
                    break;
                case "Flywheel":
                    obj = ModelFlywheel();
                    break;
                case "Flywheel shaft":
                    obj = ModelFlywheelShaft();
                    break;
                case "Heat exchange piston":
                    obj = ModelHeatExchangePiston();
                    break;
                case "Piston":
                    obj = ModelPiston();
                    break;
                case "Slide":
                    obj = ModelSlide();
                    break;
                case "Standard":
                    obj = ModelStandard();
                    break;
                case "Support":
                    obj = ModelSupport();
                    break;
            }
            obj.getNameDimention(comboBox1);
            textBox1.Text = obj.getCountDimention(comboBox1.Text).ToString("N");
            swModel = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = obj.getCountDimention(comboBox1.Text).ToString("N"); //.Resizedimention(comboBox2, textBox1);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                double number;
                if (Double.TryParse(textBox1.Text, out number))
                    obj.setCountDimention(comboBox1.Text, number);
                else
                    MessageBox.Show("Введіть число!");
                textBox1.Clear();
                textBox1.Text = obj.getCountDimention(comboBox1.Text).ToString("N");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (swModel == null)
                swModel = SmartTools.WorkSolid();
            obj.Bild(swModel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (swModel == null)
            {
                swModel = SmartTools.WorkSolid();
                obj.Bild(swModel);
            }else
                obj.setDimensions(swModel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (swModel != null)
            {
                PartDoc myswModel = (PartDoc)swModel;
                myswModel.SetMaterialPropertyName2("Default", "C:/PROGRA~1/SOLIDW~1/SOLIDW~1/lang/english/sldmaterials/SolidWorks Materials.sldmat", comboBox2.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (swModel != null)
            {
                swModel.Extension.SelectByID2("Boss-Extrude1", "BODYFEATURE", 0, 0, 0, false, 0, null, 0); ;
                swModel.ToolsMassProps();
            }
        }
    }
}
