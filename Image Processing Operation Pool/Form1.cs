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

    public partial class Form1 : MetroForm//DevExpress.XtraEditors.XtraForm
    {

        List<string> _funcNames = new List<string>();
        ListRoot _listroot = new ListRoot();

        
        string _selectedImagePath = "";
        string _imageHash = "";
        public const string SCRIPT_PATH = "cache\\";
        Size _originalSize;   //**
        Point _originalLoc;   //**
        int _resize = 0;

        
        public Form1()
        {
            InitializeComponent();   
          //  _EditComboBoxDict = new Dictionary<System.Windows.Forms.Button, System.Windows.Forms.ComboBox>();
            iTalk_Buttton_AddTooltip();
            iTalk_Button_RemoveTooltip();
            iTalk_Button_CreateTooltip();
            iTalk_Buttton_SortA2Z_Tooltip();
            Directory.CreateDirectory(SCRIPT_PATH);
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

        public void ShowDwscription()
        {
            ToolTip iTalk_Button_EngineDescription = new ToolTip();
            iTalk_Button_EngineDescription.ToolTipIcon = ToolTipIcon.None;
            iTalk_Button_EngineDescription.IsBalloon = true;
            iTalk_Button_EngineDescription.ShowAlways = true;
            iTalk_Button_EngineDescription.SetToolTip(iTalk_Button_Create, "Create script");
        }

        public void iTalk_Buttton_SortA2Z_Tooltip()
        {
            ToolTip iTalk_Buttton_SortA2ZDescription = new ToolTip();

            iTalk_Buttton_SortA2ZDescription.ToolTipIcon = ToolTipIcon.None;
            iTalk_Buttton_SortA2ZDescription.IsBalloon = true;
            iTalk_Buttton_SortA2ZDescription.ShowAlways = true;
            iTalk_Buttton_SortA2ZDescription.SetToolTip(iTalk_Button_SortA2Z, "Sort List");
        }


        //public void iTalk_Buttton_Up_tooltip()
        //{
        //    ToolTip iTalk_Buttton_UptDescription = new ToolTip();

        //    iTalk_Buttton_UptDescription.ToolTipIcon = ToolTipIcon.None;
        //    iTalk_Buttton_UptDescription.IsBalloon = true;
        //    iTalk_Buttton_UptDescription.ShowAlways = true;
        //    iTalk_Buttton_UptDescription.SetToolTip(iTalk_Buttton_AddScript, "Add function to script");
        //}
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
                ((RootObject)lbScript.SelectedItem).createFormByFunc(ControlsPanel);
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
                if (lbScript.Items.Count == 0)
                {
                    ControlsPanel.Controls.Clear();
                }
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
        private void LoadJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {

                string file = openFileDialog1.FileName;               
                string extension = Path.GetExtension(file);
                if (!extension.Equals(".json"))
                {
                    MessageBox.Show("Can Load Only .json File Format","Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    this.Refresh();
                }
                else
                {
                    try
                    {
                        lbFuncToolBox.Items.Clear();
                        // initialize functions list of rootObjects from rootList class
                        _listroot.functions = new List<RootObject>();
                        string json = File.ReadAllText(openFileDialog1.InitialDirectory + openFileDialog1.FileName);

                        // parse json file and return list of functions as objects
                        _listroot.functions = Parser.parseText(json);
                        lbFuncToolBox.DisplayMember = "functionName";
                        lbScript.DisplayMember = "functionName";

                        foreach (RootObject r in _listroot.functions)
                        {
                            _funcNames.Add(r.functionName);// create list of names to fill the  function Box
                            foreach (var param in r.parameters)
                            {
                                param.Current_Value = param.Current_Value;
                            }
                            lbFuncToolBox.Items.Add(r);
                            //tcFuncTab.Controls.Add( r.createForm(r.functionName, _hashtable));                   
                        }

                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Could not open file");
                    }
                }
            }
        }


        private void chooseImageToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            OpenFileDialog imageFile = new OpenFileDialog();
            if (imageFile.ShowDialog() == DialogResult.OK)
            {                
                    try
                    {
                        _selectedImagePath = imageFile.FileName;

                        if (File.Exists(_selectedImagePath + ".script"))
                        {
                            string json = File.ReadAllText(_selectedImagePath + ".script");

                            // parse json file and return list of functions as objects
                            var scriptsJson = Parser.parseText(json);

                            lbScript.DisplayMember = "functionName";
                            lbScript.Items.Clear();
                            foreach (RootObject r in scriptsJson)
                            {
                                lbScript.Items.Add(r);
                                //tcFuncTab.Controls.Add( r.createForm(r.functionName, _hashtable));                   
                            }
                        }
                        //MessageBox.Show(_selectedImagePath);
                        pictureBox1.ImageLocation = _selectedImagePath;
                       // pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize; 
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Could not load image");
                        this.Refresh();
                    }              
            }

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox2.BringToFront();
            pictureBox2.ImageLocation = _selectedImagePath;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox2.SendToBack();
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iTalk_Button_Create_Click(object sender, EventArgs e)
        {
            if (lbScript.Items.Count == 0)
            {                
                MessageBox.Show("Minimum number of functions needed in order to operate is one", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                this.Refresh();
            }
            else
            {
                int valid = createImageHash();
                if (valid == -1)
                {
                    this.Refresh();
                }
                else
                {
                    string scriptName = createScript();
                    //createJsonFile(scriptName);
                }
              
            }
            
           
        }
        
        public int createImageHash()
        {

            string filePath = _selectedImagePath;
            if ("" != filePath)
            {

                string fileName = Path.GetFileNameWithoutExtension(_selectedImagePath);
                if (65 == fileName.Length && '_' == fileName[32])
                {
                    _imageHash = fileName.Substring(0, 32);
                }
                else
                {
                    string result = "";
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
                            }
                            while (0 != bytesRead);

                            hasher.TransformFinalBlock(buffer, 0, 0);
                            result = makeHashString(hasher.Hash);
                            _imageHash = result;
                        }
                    }
                }           
            }
            else
            {
                MessageBox.Show("Please choose an image", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return -1;
            }
            return 0;
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


        public string createScript()
        {
            List<string> hashes = new List<string>();
            string stringObject = "";
            string listOfObjecs = "";


            
  
            for (int i = 0; i < lbScript.Items.Count; i++)
            {               
                RootObject rootObject = (RootObject)lbScript.Items[i];              
                stringObject = rootObject.GenerateObjectHashCode();
                listOfObjecs += " " + stringObject;
                string ObjectHash = CalculateMD5HashFromString(listOfObjecs);
                string Hash = _imageHash + "_" + ObjectHash + ".bmp";
                hashes.Add(Hash);
            }

            string startIm = _selectedImagePath;
            int hashIndex = 0;
            while (hashIndex < hashes.Count)            
            {
                if (File.Exists("cache\\" + hashes[hashIndex]))
                {
                    startIm = hashes[hashIndex];
                }
                else
                {                    
                    break;
                }

                hashIndex++;
            }
           // MessageBox.Show(startIm);


            string hashName = "";
            string scriptData = "im = imread('" + startIm + "');\n";

            for (int i = hashIndex; i < lbScript.Items.Count; i++ )
            {
                //scriptData += ((RootObject)lbScript.Items[i]).buildRetVal() + " = ";
                scriptData += ((RootObject) lbScript.Items[i]).calcMatlabScript( "cache\\" +  hashes[i]) + "\n";
               
                
                //create json file
                ListRoot listroot2 = new ListRoot();
                listroot2.functions = new List<RootObject>();
                for (int j = 0; j <= i; j++)
                {
                    listroot2.functions.Add((RootObject)lbScript.Items[j]);
                }

                var output = JsonConvert.SerializeObject(listroot2.functions);
                string fileNme = "cache\\";
                string scriptName = hashes[i] + ".script";
                StreamWriter file = new System.IO.StreamWriter(fileNme + scriptName);
                file.WriteLine(output);
                file.Close();
            }
            StreamWriter scriptFile = new System.IO.StreamWriter(SCRIPT_PATH + "MyScript.m" + hashName);
            scriptFile.Write(scriptData);
            scriptFile.Close();
            string strCmdMatlab = "/C matlab.exe -nodisplay -nosplash -nodesktop -r \"run('" +Path.GetFullPath( SCRIPT_PATH + "MyScript.m" + hashName )+ "');exit;\"";
            Debug.Print(strCmdMatlab);
            //System.Diagnostics.Process.Start("CMD.exe", strCmdMatlab);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = strCmdMatlab;
            process.StartInfo = startInfo;
            process.Start();

            return hashName;    
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CalculateMD5HashFromString(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptHashName"></param>
        public void createJsonFile(string scriptHashName)
        {
            ListRoot listroot2 = new ListRoot();
            listroot2.functions = new List<RootObject>();
            foreach (RootObject r in lbScript.Items)
            {
                listroot2.functions.Add(r);
            }
            var output = JsonConvert.SerializeObject(listroot2.functions);
            string fileNme = @"C:\Users\StellaMel\Documents\Visual Studio 2010\Projects\Operation_Pool\Image Processing Operation Pool\bin\Debug\cache";
            string scriptName = scriptHashName + ".script";
            StreamWriter file = new System.IO.StreamWriter(fileNme + scriptName);
            file.WriteLine(output);
            file.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                int i = file.IndexOf('.');
                string extension = file.Substring(i);
                MessageBox.Show(extension);

                if ((extension.Equals(".bmp")) || (extension.Equals(".bmp.script")))
                {
                    try
                    {
                        lbFuncToolBox.Items.Clear();
                        lbScript.Items.Clear();
                        // initialize functions list of rootObjects from rootList class
                        _listroot.functions = new List<RootObject>();
                        string json = File.ReadAllText(openFileDialog1.InitialDirectory + openFileDialog1.FileName);
                        // parse json file and return list of functions as objects
                        var scriptsJson = Parser.parseText(json);

                        lbScript.DisplayMember = "functionName";
                        foreach (RootObject r in scriptsJson)
                        {
                            lbScript.Items.Add(r);
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Could not open file");
                    }
                }
                else
                {
                    MessageBox.Show("Can Load Only .bmp.script File Format OR .bmp File Format", "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button1);
                    this.Refresh();
                }

                    
               
            }
        }

        private void iTalk_Button_SortA2Z_Click(object sender, EventArgs e)
        {
            lbFuncToolBox.Sorted = true;
        }

        /// <summary>
        /// show function description for every function in Functions box window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFuncToolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolTip FunctionDexcription = new ToolTip();

            FunctionDexcription.ToolTipIcon = ToolTipIcon.None;
            FunctionDexcription.IsBalloon = true;
            FunctionDexcription.ShowAlways = true;
            int index = 0;
            RootObject root = new RootObject();
                if (index >= 0 && index < lbFuncToolBox.Items.Count)
                {
                   root.description = ((RootObject)lbFuncToolBox.SelectedItem).description;
                   FunctionDexcription.SetToolTip(this.lbFuncToolBox, root.description);
                }
            
        }

        private void createJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {

                string file = openFileDialog1.FileName;
                Parser.path2Json(file);
            }
            else
            {

            }
        }

   

    


  




    }
}
