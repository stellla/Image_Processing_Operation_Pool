using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using Telerik.WinControls;
using MetroFramework.Forms;
using System.Security.Cryptography;





namespace Image_Processing_Operation_Pool
{

    public partial class Form1 :MetroForm//DevExpress.XtraEditors.XtraForm
    {

        List<string> _funcNames = new List<string>();
        ListRoot _listroot = new ListRoot();
        Parser parser = new Parser();
        ScriptCreator scriptCreator = new ScriptCreator();
        Hashtable _hashtable = new Hashtable();
        Dictionary<System.Windows.Forms.Button, System.Windows.Forms.ComboBox> _EditComboBoxDict;
        string _selectedImagePath = "";
        string _imageName = "";
        string _filePath = @"C:\Users\StellaMel\Documents\Visual Studio 2010\Projects\Image Processing Operation Pool\Image Processing Operation Pool\bin\Debug\cahce";

        public Form1()
        {
            InitializeComponent();   
            _EditComboBoxDict = new Dictionary<System.Windows.Forms.Button, System.Windows.Forms.ComboBox>();
            iTalk_Buttton_AddTooltip();
            iTalk_Button_RemoveTooltip();
            iTalk_Button_CreateTooltip();
        }

        /// <summary>
        /// create description controller toolip for AddScript button
        /// On hover on the button gives the description of the button
        /// </summary>
        public void iTalk_Buttton_AddTooltip()
        {
            ToolTip iTalk_Buttton_AddScriptDescription = new ToolTip();

            iTalk_Buttton_AddScriptDescription.ToolTipIcon = ToolTipIcon.None;
            iTalk_Buttton_AddScriptDescription.IsBalloon = true;
            iTalk_Buttton_AddScriptDescription.ShowAlways = true;
            iTalk_Buttton_AddScriptDescription.SetToolTip(iTalk_Buttton_AddScript, "Add function to script");
        }

        /// <summary>
        /// create description controller toolip for Remove button
        /// On hover on the button gives the description of the button
        /// </summary>
        public void iTalk_Button_RemoveTooltip()
        {
            ToolTip iTalk_Button_RemoveDescription = new ToolTip();
            iTalk_Button_RemoveDescription.ToolTipIcon = ToolTipIcon.None;
            iTalk_Button_RemoveDescription.IsBalloon = true;
            iTalk_Button_RemoveDescription.ShowAlways = true;
            iTalk_Button_RemoveDescription.SetToolTip(iTalk_Button_Remove, "Remove function from script");
        }

        /// <summary>
        /// create description controller toolip for Create button
        /// On hover on the button gives the description of the button
        /// </summary>
        public void iTalk_Button_CreateTooltip()
        {
            ToolTip iTalk_Button_EngineDescription = new ToolTip();
            iTalk_Button_EngineDescription.ToolTipIcon = ToolTipIcon.None;
            iTalk_Button_EngineDescription.IsBalloon = true;
            iTalk_Button_EngineDescription.ShowAlways = true;
            iTalk_Button_EngineDescription.SetToolTip(iTalk_Button_Create, "Create script");
        }


        /// <summary>
        /// on selected value (function name) presents the parameters for the function
        /// enables to change the values of the params and saves the selected 
        /// values to be the current values of the params
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbScript_SelectedValueChanged(object sender, EventArgs e)
        {
            if (null != lbScript.SelectedItem)
            {
                //usr the createFormByFunc function to create parameters form
                ((RootObject)lbScript.SelectedItem).createFormByFunc(gbFuncParamEdit);
            }
            
           // r.createForm(r.functionName, _hashtable)
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iTalk_Buttton_AddScript_Click(object sender, EventArgs e)
        {
            if (null != lbFuncToolBox.SelectedItem)
            {
                int funNum = 0;
                foreach (var item in lbScript.Items)
                {
                    if (((RootObject)item).functionName == ((RootObject)lbFuncToolBox.SelectedItem).functionName)
                    {
                        funNum++;
                    }
                }
                lbScript.Items.Add(((RootObject)lbFuncToolBox.SelectedItem).Clone());
            }
        }

        /// <summary>
        /// on click removes selected item from listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iTalk_Button_Remove_Click(object sender, EventArgs e)
        {
            if (null != lbScript.SelectedItem)
            {
                lbScript.Items.Remove(lbScript.SelectedItem);
            }
        }

        /// <summary>
        /// on click moves the selected function up on the listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iTalk_Button_Up_Click(object sender, EventArgs e)
        {
            if (null != lbScript.SelectedItem)
            {
                if (0 != lbScript.SelectedIndex)
                {
                    var temp = lbScript.Items[lbScript.SelectedIndex - 1];
                    lbScript.Items[lbScript.SelectedIndex - 1] = lbScript.Items[lbScript.SelectedIndex];
                    lbScript.Items[lbScript.SelectedIndex] = temp;
                    lbScript.SelectedIndex = lbScript.SelectedIndex - 1;
                }
            }
        }
        /// <summary>
        /// on click moves the selected function down on the listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iTalk_Button_Down_Click(object sender, EventArgs e)
        {
            if (null != lbScript.SelectedItem)
            {
                if (lbScript.Items.Count - 1 != lbScript.SelectedIndex)
                {
                    var temp = lbScript.Items[lbScript.SelectedIndex + 1];
                    lbScript.Items[lbScript.SelectedIndex + 1] = lbScript.Items[lbScript.SelectedIndex];
                    lbScript.Items[lbScript.SelectedIndex] = temp;
                    lbScript.SelectedIndex = lbScript.SelectedIndex + 1;
                }
            }
        }


        /// <summary>
        /// On click on "coose json" the the user chooses the json file and the file 
        /// is loaded to the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {

                // initialize functions list of rootObjects from rootList class
                _listroot.functions = new List<RootObject>();
                string file = openFileDialog1.FileName;
                try
                {
                    //int count = 0;
                    string json = File.ReadAllText(Environment.CurrentDirectory + @"\JSON.txt");

                    // parse json file and return list of functions as objects
                    _listroot.functions = parser.parseText(json);
                    _hashtable = parser.createHashTable(_listroot.functions);
                    lbFuncToolBox.DisplayMember = "functionName";
                    lbScript.DisplayMember = "functionName";

                    foreach (RootObject r in _listroot.functions)
                    {
                        _funcNames.Add(r.functionName);// create list of names to fill next comboBoxes
                        foreach (var param in r.parameters)
                        {
                            param.Current_Value = param.Default;
                        }
                        lbFuncToolBox.Items.Add(r);
                        //tcFuncTab.Controls.Add( r.createForm(r.functionName, _hashtable));                   
                    }
                    //*******************TEST*******************************************************************
                    //foreach (RootObject root in listroot.functions)
                    //{
                    //    //count.count++;
                    //    Debug.Write(" " + root.functionName + " " + root.description);
                    //    foreach (Parameter param in root.parameters)
                    //    {
                    //        Debug.Write(" " + param.Name + " " + param.valueType + " " + param.type + " " + param.Default + " " + param.Description + " " + param.Current_Value + "\n");
                    //    }

                    //}
                    //Debug.Write("how many functions:" + count);
                    //******************************************************************************************
                }
                catch (IOException)
                {
                    MessageBox.Show("Could not open file");
                }
            }
        }

        private void chooseImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string mFileName = "";
            OpenFileDialog imageFile = new OpenFileDialog();
            if (imageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _selectedImagePath = imageFile.FileName;
                     //MessageBox.Show(_selectedImagePath);
                     //string imageName = parser.removeFilePathExtentions(_selectedImagePath);
                     //mFileName = parser.addMatlabExtantion(imageName);
                }
                catch (IOException)
                {
                    MessageBox.Show("Could not open file");
                }
            }

        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iTalk_Button_Create_Click(object sender, EventArgs e)
        {
            createScript();
            backgroundWorker1.RunWorkerAsync(_selectedImagePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();
            //MessageBox.Show(filePath);


            // move all the belllow to a function : scriptCreator.generateScript(,_listroot);

            // read parts of the file to here
            byte[] buffer;
            //will be updated with the amount of bytes we read every time through the loop that 
            //will go over the file the file
            int bytesRead;
            // holds the size of the file to hash
            long size;
            //holds the count of the total amount of bytes that were read so far
            long totalBytesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                using (HashAlgorithm hasher = MD5.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = file.Read(buffer, 0, buffer.Length);//returns an integer of how many bytes are read 

                        totalBytesRead += bytesRead;

                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);

                        //update the progress bar
                        backgroundWorker1.ReportProgress((int)((double)totalBytesRead / size * 100));

                    }
                    while (0!= bytesRead);

                    hasher.TransformFinalBlock(buffer, 0, 0);
                    e.Result = makeHashString(hasher.Hash);
                }
            }
        }

        /// <summary> 
        /// convert hash bytes array to string  
        /// </summary>
        /// <param name="hashBytes"></param>
        /// <returns></returns>
        private static string makeHashString(byte[] hashBytes)
        {
            //32 is the initail capacity 
            //md5 hash is 32 charecters long
            StringBuilder hash = new StringBuilder(32);
            foreach (byte b in hashBytes)
            {
                hash.Append(b.ToString("x2").ToLower());
            }

            return hash.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _imageName = e.Result.ToString();
            MessageBox.Show("image name is: " +_imageName);
            MessageBox.Show(e.Result.ToString());
            progressBar1.Value = 0;
        }

        public void createScript()
        {
            //FileStream fs = File.Create(@"C:\Users\StellaMel\Documents\Visual Studio 2010\Projects\Image Processing Operation Pool\Image Processing Operation Pool\bin\Debug\cahce\script7.m");

            string fileNme = "cahce\\";
            string scriptName = "script.m";
            StreamWriter file = new System.IO.StreamWriter(fileNme + scriptName);
            file.WriteLine("my script:");
            foreach (RootObject r in lbScript.Items)
            {
                file.WriteLine("function " + r.functionName + ":");
                foreach (var param in r.parameters)
                {
                    file.Write(param.type.ToString() + ": " + param.Current_Value + ", ");

                }
                file.WriteLine("");

            }

            file.Close();

        }





        //StreamWriter file = new System.IO.StreamWriter("script.m");
        //file.WriteLine("my script:");
        //foreach (RootObject r in lbScript.Items)
        //{
        //    file.WriteLine("function " + r.functionName + ":");
        //    foreach (var param in r.parameters)
        //    {
        //        file.Write(param.type.ToString() + ": " + param.Current_Value + ", ");

        //    }
        //    file.WriteLine("");

        //}

        //file.Close();  

    }
}
