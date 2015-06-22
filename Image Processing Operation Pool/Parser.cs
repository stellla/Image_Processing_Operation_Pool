using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Windows.Forms;

namespace Image_Processing_Operation_Pool
{
    /// <summary>
    ///  gets a file and inserts all functions to interface
    /// </summary>
    public class Parser
    {
        /// <summary>
        ///the method reads JSON file and parse it to matched class attributes
        /// </summary>
        /// <param name="file"> the path of the f chosen file</param>
        public static List<RootObject> parseText(string json)
        {
           // create list of var objects according to the json file

            //string extention = Path.GetExtension(json);
            //if (!extention.Equals(".json"))
            //    MessageBox.Show("not JSON file");

            var h = JsonConvert.DeserializeObject<List<RootObject>>(json);
       
            //initialize rootList class
            //ListRoot listroot = new ListRoot();
            // initialize functions list of rootObjects from rootList class
            List<RootObject> functions = new List<RootObject>();

            //add all functions to functionlist
           foreach (var f in h)
           {
               functions.Add(f);              
           }

           return functions;       
        }

        public static void path2Json(string path)
        {
            List<String> listOfScript = new List<String>();

            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(path);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {            
                foreach (var script in Directory.GetFiles(path, "*.m"))
                {
                     listOfScript.Add(script);
                }               
            }
            else
            {
                listOfScript.Add(path);
            }

            StreamWriter file = new System.IO.StreamWriter(path + ".json");
            file.WriteLine("[");

            for (int i = 0; i < listOfScript.Count; i++)
            {
                file.WriteLine(script2Json(listOfScript[i]));
                if ((i + 1 )< listOfScript.Count)
                {
                    file.WriteLine(",");
                }
            }

            file.WriteLine("]");
            file.Close();
        }

        public static string script2Json(string path)
        {
            string json ="";

            // check if path exist

            RootObject func = new RootObject();
            func.functionName = "xx";
            func.description = "??";
            func.parameters = null;
            func.RetVal = null;

            var scriptLines = File.ReadAllLines(path);

            for (int i = 0; i < scriptLines.Length; i++)
            {
                //if (scriptLines[i].Contains("description"))
                //{

                //}
                if (scriptLines[i].Contains("function"))
                {
                    var lineParams = scriptLines[i].Split();

                    // function keyword
                    //lineParams[0];

                    // ret value
                    //lineParams[1];

                    // =
                    //lineParams[2];

                    // ret value
                    func.functionName = lineParams[3];
                    int argInedex = scriptLines[i].IndexOf("(");
                    string temp = scriptLines[i].Substring(0, argInedex);
                    var nameList = temp.Split();
                    func.functionName = nameList[nameList.Length - 1];


                    string arglist = scriptLines[i].Substring(scriptLines[i].IndexOf("(") + 1, scriptLines[i].Length - (argInedex + 2 ));
                    var funcArg = arglist.Split(',');
                    if (funcArg.Length > 0)
                    {
                        func.parameters = new List<Parameter>();
                        for (int j = 0; j < funcArg.Length; j++)
                        {
                            Parameter param = new Parameter();
                            param.Name = funcArg[j];
                            
                            func.parameters.Add(param);

                        
                        }
                    }
                    
                 
                }
            }
            

            
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            json = serializer.Serialize(func);
            Debug.Print(json);


            //
            //json += "{";
            //string functionName = "";

            //json += @"""functionName"":""" + functionName + "";
            //json +=  @"""description"":""...""";
            


            //json += "}";


            return json;
            
        }
    }     
}
