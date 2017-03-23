using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
//using System.Xml;
//using System.Xml.XPath;

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
            //openFileDialog1.ShowDialog();
             openFileDialog1.FileName = "S:\\Visual Studio 2015\\Projects\\My-Training\\forAzot\\XMLApplication\\testXML\\out-OPS$14010-17-03-10-31.xml";
            textBox1.Text = openFileDialog1.FileName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  openFileDialog2.ShowDialog();
            openFileDialog2.FileName = "S:\\Visual Studio 2015\\Projects\\My-Training\\forAzot\\XMLApplication\\testXML\\out-OPS$14010-17-03-10-31.xml";
            textBox2.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(openFileDialog1.FileName);
                int bufferLength = 10000;

                string pattern = @"\s+";
                string target = " ";
                Regex regex = new Regex(pattern);
                             
                StringBuilder buffer = new StringBuilder(bufferLength);
                buffer.Clear();
                string currentString = reader.ReadLine();
                var prevString = "";
                currentString = regex.Replace(currentString, target);
                buffer.Append(currentString + "\n");
                while (currentString != null)
                {
                    prevString = currentString;
                    prevString = regex.Replace(prevString, target);
                    currentString = reader.ReadLine();
                   
                    if (prevString == "<NDS_v3_reestr_t001>")
                    {
                        buffer.Append("Fuck!" + "\n");
                    }
                    else buffer.Append(currentString + "\n");
                    
                }
                richTextBox1.Text = buffer.ToString();
                buffer.Clear();
             }
            catch (IOException ee)
            {
                // Console.WriteLine("Error reading. {0}", ee.Message);
                label1.Text = ee.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
            /*
            XmlDocument docAzot = new XmlDocument();
            docAzot.Load(openFileDialog1.FileName);
            XPathNavigator navigatorAzot = docAzot.CreateNavigator();
            */
            // XmlNamespaceManager managerAzot = new XmlNamespaceManager(navigatorAzot.NameTable);
            // managerAzot.AddNamespace("bk", "");
            //richTextBox1.Text = navigatorAzot.OuterXml.ToString();



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
