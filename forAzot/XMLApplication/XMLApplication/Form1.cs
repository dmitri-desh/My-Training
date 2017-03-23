using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace XMLApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // openFileDialog1.ShowDialog();
            openFileDialog1.FileName = "N:\\MARKET\\ORACLE\\DeclRegister\\xsl-edecl\\3\\out-OPS$14010-17-03-10-31.xml";
            textBox1.Text = openFileDialog1.FileName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  openFileDialog2.ShowDialog();
            openFileDialog2.FileName = "N:\\MARKET\\ORACLE\\DeclRegister\\xsl-edecl\\3\\edeclSNG-201702.xml";
            textBox2.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument docAzot = new XmlDocument();
            docAzot.Load(openFileDialog1.FileName);
            XPathNavigator navigatorAzot = docAzot.CreateNavigator();

           // XmlNamespaceManager managerAzot = new XmlNamespaceManager(navigatorAzot.NameTable);
           // managerAzot.AddNamespace("bk", "");
            richTextBox1.Text = navigatorAzot.OuterXml.ToString();

            /*
            foreach (XPathNavigator navAzot in navigatorAzot.Select("//bk:NDS_v3_part1_t001", managerAzot))
            {
                label1.Text = navAzot.OuterXml;
                Console.WriteLine(navigatorAzot.OuterXml);
                 if (navAzot.Value == "63465184.84")
                 {
                     navAzot.SetValue("12.99");

                
            }
            
            Console.WriteLine(navigatorAzot.OuterXml);
            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
