using System;
using NAudio.Wave;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;

namespace Compiler
{
    public partial class Form1 : Form
    {
        string an;
        string str;
        int listbox1length, listbox2length = 0;
        public Form1()
        {
           
            InitializeComponent();

           
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            editor.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
        }

        private void Save_Click(object sender, EventArgs e)
        {
        }
        private void waveOut_PlaybackStopped(object sender,StoppedEventArgs e)
        {
          
        }

        private void convertspeech_Click(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            listbox1length = 0;
            listbox2length = 0;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listView1.Clear();
            string reg = @"\w";
            string floatingpointPattern =@"^\d *\.?\d *$";
            string StringLiteralPattern= "\".*\"";
            string Identifierpattern = @"^[A-Z|a-z]+[0-9]*[A-Z]*[a-z]*";
            Regex reg2 = new Regex(Identifierpattern);
            Regex floatingpoint = new Regex(floatingpointPattern);
            Regex regstring = new Regex(StringLiteralPattern);
            Regex spacenot = new Regex(reg);
            int total = 0;
            string[] previous = new string[1000];
            string[] tokentype = new string[10000];
            string text = editor.Text.ToString();
            string[] final = text.Split(' ');
            int number;
            bool find = false;
            for (int i = 0; i < final.Length; i++)
            {
                 find = false;
                dictionary dictionary = new dictionary();
               
                foreach (var input in dictionary.dictionary1)
                {
                  
                    if (input.Key == final[i])
                    {
                        tokentype[i] = input.Value;
                        total++;
                        find = true;
                      
                        listBox1.Items.Add("Token < "+final[i] +" , "+ input.Value + " >" );
                        listbox1length++;


                    }
                }
                
                if (find != false)
                { continue; }
                if (int.TryParse(final[i], out number))
                {
                    
                    tokentype[i] = "number";
                    total++;
                    listBox1.Items.Add("Token < " + final[i] + " , " + "number" + " >");
                    listbox1length++;

                }
                
                else if (regstring.IsMatch(final[i]))
                {
                    
                    tokentype[i] = "String Literal";
                    total++;
                    listBox1.Items.Add("Token < " + final[i] + " , " + "String Literal" + " >");
                    listbox1length++;
                }
                else if (floatingpoint.IsMatch(final[i]))
                {
                   
                    tokentype[i] = "floating point";
                    total++;
                    listBox1.Items.Add("Token < " + final[i] + " , " + "float" + " >");
                    listbox1length++;

                }
                else if (reg2.IsMatch(final[i]))
                {
                   
                    tokentype[i] = "identifier";
                    total++;
                    listBox1.Items.Add("Token < " + final[i] + " , " + "identifier" + " >");
                    listbox1length++;
                }
               
                else if(spacenot.IsMatch(final[i]))
                {
                    listBox2.Items.Add("Lexical Error unrecognize token "+final[i]);
                }
               

            }
            listView1.Items.Add("Compiled Successfully... !");
            syntaxAnalyzer();
            ErrorRead();



            void ErrorRead()
            {
                SpeechSynthesizer reader3 = new SpeechSynthesizer();
                
                if(radioButton1.Checked == true)
                {
                    str = "";
                    for (int j = 0; j < listbox2length; j++)
                    {
                        listBox2.SelectedIndex = j;
                        str += listBox2.SelectedItem.ToString();

                    }
                    reader3.Dispose();
                    reader3 = new SpeechSynthesizer();
                    reader3.SpeakAsync(str);
                }
                else if(radioButton2.Checked == true)
                {
                    reader3.Dispose();
                }
            }
            void syntaxAnalyzer()
            {
                string[] forloop ={ "keyword","opening round bracket","INT","identifier","Equal","number","semi colon", "identifier", "Lessthan","number","semi colon","identifier",
                "Increment","closing round bracket" };
                bool ErrorCommand = false;
                bool SementicError = false;
                int i = 0;
                int exist = 0;
                if (tokentype[i] == "INT" || tokentype[i] == "STRING" || tokentype[i] == "FLOAT" || tokentype[i] == "CHAR")
                {
                    ErrorCommand = true;
                    SementicError = true;
                    for (i = 0; i < tokentype.Length; i++)
                    {
                        if (tokentype[i] == "INT" || tokentype[i] == "STRING" || tokentype[i] == "FLOAT" || tokentype[i] == "CHAR")
                        {
                        newvar:
                            i++;

                            if (tokentype[i] == "identifier")
                            {
                                i++;

                                if (tokentype[i] == "Equal")
                                {
                                    i++;

                                    if (tokentype[i] == "number" || tokentype[i] == "String Literal" || tokentype[i] == "floating point")
                                    {

                                        if (tokentype[0] == "INT" && tokentype[i] == "number" || tokentype[0] == "STRING" && tokentype[i] == "String Literal" || tokentype[0] == "FLOAT" && tokentype[i] == "floating point")
                                        {
                                            SementicError = false;
                                        }
                                        i++;

                                        if (tokentype[i] == "comma")
                                        {
                                            goto newvar;
                                        }


                                        if (tokentype[i] == "semi colon")
                                        {
                                            ErrorCommand = false;
                                            listBox2.Items.Add("Syntax is correct");

                                            listbox2length++;
                                            break;
                                        }
                                    }

                                }
                                if (tokentype[i] == "semi colon")
                                {
                                    ErrorCommand = false;
                                    listBox2.Items.Add("Syntax is correct");
                                    listbox2length++;
                                    break;
                                }
                            }

                            if (tokentype[i] == "semi colon")
                            {
                                ErrorCommand = false;
                                listBox2.Items.Add("Syntax is correct");
                                listbox2length++;
                                break;
                            }
                        }

                    }
                    if (ErrorCommand == true)
                    {
                        listBox2.Items.Add("Syntax Error");
                        listbox2length++;

                    }
                    if (SementicError == true)
                    {
                        listBox2.Items.Add("Sementic Error check datatype");
                        listbox2length++;
                    }
                }
            forloop:
                if (tokentype[0] == forloop[0])
                {
                    for (i = 0; i < forloop.Length; i++)
                    {
                        exist = 0;
                        foreach (string x in tokentype)
                        {
                            if (forloop[i] == x)
                            {
                                exist = 1;
                            }
                        }
                        if (exist == 0)
                        {
                            listBox2.Items.Add("missing " + forloop[i]);
                            listbox2length++;
                        }
                        if (tokentype[i] != forloop[i])
                        {
                            ErrorCommand = true;
                        }

                    }
                    if (ErrorCommand == true)
                    {
                        listBox2.Items.Add("Syntax Error");
                        listbox2length++;
                    }
                }
            ifcheck:
                int k = 0;
                if (tokentype[0] == "if keyword")
                {
                    ErrorCommand = true;
                    SementicError = true;

                    try { 
                    for (k = 0; k < tokentype.Length; k++)
                    {
                        if (tokentype[k] == "if keyword")
                        {

                            k++;
                            if (tokentype[k] == "opening round bracket")
                            {
                            new2:
                                k++;

                                if (tokentype[k] == "identifier")
                                {
                                    k++;
                                    if (tokentype[k] == "Equal" || tokentype[k] == "EqualTo" || tokentype[k] == "Lessthan" || tokentype[k] == "Not equal to" || tokentype[k] == "Greaterthan" || tokentype[k] == "Lessequal" || tokentype[k] == "Greaterequal")
                                    {
                                        k++;

                                        if (tokentype[k] == "number" || tokentype[k] == "String Literal" || tokentype[k] == "identifier" || tokentype[k] == "floating point")
                                        {

                                            k++;

                                            if (tokentype[k] == "AND" || tokentype[k] == "OR")
                                            {
                                                goto new2;
                                            }

                                            else if (tokentype[k] == "closing round bracket")
                                            {
                                                k++;
                                                if (tokentype[k] == "opening curly bracket")
                                                {
                                                previous:
                                                    k++;
                                                    if (tokentype[k] == "closing curly bracket")
                                                    {
                                                        ErrorCommand = false;
                                                        listBox2.Items.Add("Syntax is correct");
                                                        listbox2length++;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        goto previous;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    }
                    catch { }
                    if (ErrorCommand == true)
                    {
                        listBox2.Items.Add("if Syntax Error");
                        listbox2length++;
                    }
                }
     }
  }
        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void button2_Click(object sender, EventArgs e)
        {
            if(editor.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(editor.Text);
            }
            
        }
        SpeechSynthesizer reader2 = new SpeechSynthesizer();
        private void button3_Click(object sender, EventArgs e)
        {
            an = "";
            for (int j = 0; j < listbox1length; j++)
            {
                listBox1.SelectedIndex = j;
                an += listBox1.SelectedItem.ToString();
                
            }
            reader2.Dispose();
            reader2 = new SpeechSynthesizer();
            reader2.SpeakAsync(an);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (reader2 != null)
            {
                reader2.Dispose();
            }
        }
    }
}
