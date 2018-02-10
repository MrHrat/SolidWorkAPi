using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace GreenArrow
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public class Circle
        {
            public double Radius;

            public Circle()
            {
                Radius = 0.0;
            }

            public Circle(double radius)
            {
                Radius = radius;
            }
        }

        public class Bilds
        {
            public BindingList<Circle> sketh;

            public Bilds()
            {
                sketh = new BindingList<Circle>();
            }

            public void AddCircle(double putradius)
            {
                sketh.Add(new Circle(putradius));
            }

            public void OpenDialog()
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = openFileDialog1.OpenFile()) != null)
                        {
                            using (myStream)
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Circle>));
                                sketh = (BindingList<Circle>)serializer.Deserialize(myStream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }

            public void SaveDialog()
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();

                saveFile1.DefaultExt = "*.xml";
                saveFile1.Filter = "xml files (*.xml)|*.xml";

                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                   saveFile1.FileName.Length > 0)
                {
                    using (Stream writer = new FileStream("temple.xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(sketh.GetType());
                        serializer.Serialize(writer, sketh);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
