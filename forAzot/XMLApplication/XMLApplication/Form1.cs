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
using System.Configuration;

namespace XMLApplication
{
    public partial class Form1 : Form
    {
        private string fileNameIn;

        public Form1()
        {
            fileNameIn = "";
            InitializeComponent();
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
           
        }

        public Form1(string fileName)
        {
            fileNameIn = fileName;
            InitializeComponent();
            if (fileNameIn.Length > 0)
            {
                openFileDialog1.FileName = fileNameIn;
                textBox1.Text = openFileDialog1.FileName;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();  
            textBox1.Text = openFileDialog1.FileName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            openFileDialog2.ShowDialog();
            textBox2.Text = openFileDialog2.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;
            StreamReader reader2 = null;
            try
            {
                reader = File.OpenText(openFileDialog1.FileName);

                int bufferLength = 30000;
                string pattern = @"\s+";
                string target = " ";
                Regex regex = new Regex(pattern);

                var startTag2 = ConfigurationManager.AppSettings["startTag2"];
                var endTag2 = ConfigurationManager.AppSettings["endTag2"];
                var startTag8 = ConfigurationManager.AppSettings["startTag8"];
                var endTag8 = ConfigurationManager.AppSettings["endTag8"];
                var flag2 = false;
                var flag8 = false;


                StringBuilder buffer = new StringBuilder(bufferLength);
                buffer.Clear();
                string currentString = reader.ReadLine().Trim();
                currentString = regex.Replace(currentString, target);
                string currentString2;
                while (currentString != null)
                {
                    if (currentString.Trim() == startTag2) flag2 = true;
                    if (currentString.Trim() == endTag2)   flag2 = false;
                    if (currentString.Trim() == startTag8) flag8 = true;
                    if (currentString.Trim() == endTag8)   flag8 = false;

                    if (flag2)
                    {
                        //buffer.Append("Bingo2!" + "\n");
                        buffer.Append(currentString);
                        try
                        {
                            reader2 = File.OpenText(openFileDialog2.FileName);
                            currentString2 = reader2.ReadLine();
                            currentString2 = regex.Replace(currentString2, target);
                            var flagCur = false;
                            while (currentString2 != null)
                            {
                                if (currentString2.Trim() == startTag2) flagCur = true;
                                if (currentString2.Trim() == endTag2) flagCur = false;

                                if (flagCur)
                                {
                                    buffer.Append(currentString2 + "\n");
                                 
                                }

                                currentString2 = reader2.ReadLine();
                            }
                            flagCur = false;
                            flag2 = false;
                        }
                        catch (IOException ee)
                        {
                            label1.Text = "2 " + ee.Message;
                        }
                        finally
                        {
                            if (reader2 != null)
                                reader2.Dispose();
                        }
                    }
                    else if (flag8)
                    {
                        //buffer.Append("Bingo8!" + "\n");
                        //buffer.Append(currentString);
                        try
                        {
                            reader2 = File.OpenText(openFileDialog2.FileName);
                            currentString2 = reader2.ReadLine();
                            currentString2 = regex.Replace(currentString2, target);
                            var flagCur = false;
                            while (currentString2 != null)
                            {
                                if (currentString2.Trim() == startTag8) flagCur = true;
                                if (currentString2.Trim() == endTag8) flagCur = false;

                                if (flagCur)
                                {
                                    buffer.Append(currentString2 + "\n");
                                 
                                }

                                currentString2 = reader2.ReadLine();
                            }
                            flagCur = false;
                            flag8 = false;
                        }
                        catch (IOException ee)
                        {
                            label1.Text = "8 " + ee.Message;
                        }
                        finally
                        {
                            if (reader2 != null)
                                reader2.Dispose();
                        }
                    }
                    else { buffer.Append(currentString + "\n");
                          
                          }
                    label2.Text = currentString;
                    currentString = reader.ReadLine();
                }
                richTextBox1.Text = buffer.ToString();

                var pathToSave = @ConfigurationManager.AppSettings["pathToSave"];
                if (!Directory.Exists(pathToSave)) { var pathToTemp = @Path.GetTempPath();
                                                         pathToSave = pathToTemp;
                                                   }

                var saveTo = pathToSave + "to-load-" + DateTime.Today.ToShortDateString() + ".xml";
                File.WriteAllText(saveTo, buffer.ToString());
                label2.Text = "Файл сохранён: " + saveTo;
                buffer.Clear();
             }
            catch (IOException ee)
            {
                // Console.WriteLine("Error reading. {0}", ee.Message);
                label1.Text = "Main " + ee.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
