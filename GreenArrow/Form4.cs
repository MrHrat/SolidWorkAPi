using System;
using System.Diagnostics;
using System.IO; // это для работы с файлами
using System.Windows.Forms;
using System.Xml.Serialization; //это для сохранения классов — что и есть серилизация (стрёмное слово)
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace GreenArrow
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        protected BilderParts obj;

        private void button1_Click(object sender, EventArgs e)
        {
            obj.ChangeDimensions();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            obj = new BilderParts();
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.OpenDialog();
            obj.FillupCombobox(comboBox2);
            obj.Resizedimention(comboBox2, textBox1);
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj.SaveDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.BildModel();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.Resizedimention(comboBox2, textBox1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            obj.BildModel();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                obj.Updatedimention(comboBox2, textBox1);
                textBox1.Clear();
                obj.Resizedimention(comboBox2, textBox1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
        }
    }
}
