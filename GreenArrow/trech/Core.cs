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

namespace GreenArrow
{
    interface IBildmode
    {
        void Bild3d();
        void SetParameter(DataGridView Dg);
    }

    class BildModel
    {
        protected SldWorks SwApp;
        protected ModelDoc2 swModel;

        public BildModel()
        {
            startSolid();
        }

        private void startSolid()
        {
            //#region Start SolidWorks
            //очищення процесів
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

            //створення моделі
            SwApp.NewDocument(@"C:\ProgramData\SolidWorks\SolidWorks 2013\templates\gost-part.prtdot", 0, 0, 0);
            //SwApp.NewPart();
            swModel = SwApp.IActiveDoc2;
            //#endregion
        }

        public void SetMaterial(ComboBox CBox)
        {
            PartDoc myPart = (PartDoc)swModel;
            myPart.SetMaterialPropertyName2("Default", "C:/PROGRA~1/SOLIDW~1/SOLIDW~1/lang/english/sldmaterials/SolidWorks Materials.sldmat", CBox.Text);
            swModel.ViewZoomtofit2();
        }

        public virtual void ShowMasseVolume(TextBox Masse, TextBox Volume)
        {
            ModelDoc2 swDoc = ((ModelDoc2)(SwApp.ActiveDoc));
            swDoc.Extension.SelectByID2("Boss-Extrude1", "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
            Masse.Text = "" + swDoc.Extension.CreateMassProperty().Mass;
            Volume.Text = "" + swDoc.Extension.CreateMassProperty().Volume;
        }

        protected double InputmmWithEdit(TextBox text)
        {
            return Convert.ToDouble(text.Text) / 1000.0;
        }
    }
}
