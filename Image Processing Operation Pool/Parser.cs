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
    }     
}
