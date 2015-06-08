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
    class Parser
    {


        Hashtable hashtable = new Hashtable();
        /// <summary>
        /// constructor
        /// </summary>
        public Parser()
        {

        }

        /// <summary>
        ///the method reads JSON file and parse it to matched class attributes
        /// </summary>
        /// <param name="file"> the path of the f chosen file</param>
        public List<RootObject> parseText(string json)
        {
           // create list of var objects according to the json file

            //string extention = Path.GetExtension(json);
            //if (!extention.Equals(".json"))
            //    MessageBox.Show("not JSON file");

            var h = JsonConvert.DeserializeObject<List<RootObject>>(json);
       
            //initialize rootList class
            ListRoot listroot = new ListRoot();
            // initialize functions list of rootObjects from rootList class
          listroot.functions = new List<RootObject>();

            //add all functions to functionlist
           foreach (var f in h)
           {
               listroot.functions.Add(f);
              // createHashTable(listroot.functions);

               //foreach (RootObject root in listroot.functions)
               //{
                   
               //    Debug.Write(" " + root.functionName + " " + root.description);
               //    foreach (Parameter param in root.parameters)
               //    {


               //        if (param.type.Equals(Type.String_Range))
               //        {
               //            string options = "";
               //            options = returnStringOptions(param);
               //            Debug.Write(" " + param.Name + " " + options + " " + param.type + " " + param.Default + " " + param.Description + " " + param.Current_Value + "\n");
               //        }

               //        if(param.type.Equals(Type.Double_Range))
               //            Debug.Write(" " + param.Name + " " + "min: " + param.DoubleRange.Min + " max: " +  param.DoubleRange.Max  + " " + param.type + " " + param.Default + " " + param.Description + " " + param.Current_Value + "\n");

               //        if (param.type.Equals(Type.Int_Range))
               //            Debug.Write(" " + param.Name + " " + "min: " + param.IntRange.Max + " max: " +param.IntRange.Min +  " " + param.type + " " + param.Default + " " + param.Description + " " + param.Current_Value + "\n");
               //    }

               //}
              
           }
         
           return listroot.functions;       
        }

        public string returnStringOptions(Parameter param)
        {
            string options = "";
            foreach (string option in param.StringRange)
                 options += " " + option ;
            return options;
        }


        public Hashtable createHashTable(List<RootObject> functions)
        {
            foreach (RootObject root in functions)
            {
                hashtable.Add(root.functionName,root);
            }
            return hashtable;
        }

        public string removeFilePathExtentions(string selectedImagePath)
        {
            string imageName = "";
            int startIndex = selectedImagePath.LastIndexOf('\\') + 1;
            if (-1 != startIndex)
            { 
                //MessageBox.Show("last index of" + '\\' + "is: " + startIndex.ToString());
                imageName = selectedImagePath.Substring(startIndex);
                MessageBox.Show(imageName);
            }
          
            return imageName;
            //C:\Users\StellaMel\Documents\Visual Studio 2010\Projects\Image Processing Operation Pool\Image Processing Operation Pool\bin\Debug\cahce\image1.jpeg
        }

        public string addMatlabExtantion(string imageName)
        {
            string matlabImage = "";
            string ImageExtantion = ""; 
            int indexOfExtantion = imageName.IndexOf(".") + 1;

            if(-1 != indexOfExtantion)
            {
                ImageExtantion = imageName.Substring(indexOfExtantion) ;
                matlabImage = imageName.Replace(ImageExtantion,"m");
                MessageBox.Show(matlabImage);
            }

            return matlabImage;
        }

    }     
}
