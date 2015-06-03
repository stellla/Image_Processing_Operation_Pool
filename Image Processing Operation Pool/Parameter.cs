using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Drawing;


namespace Image_Processing_Operation_Pool
{
    public class Parameter : ICloneable
    {
        public string Name { get; set; }
        public Type type { get; set; }
        public DoubleRange DoubleRange { get; set; }
        public string Default { get; set; }
        public string Description { get; set; }
        public string Current_Value { get; set; }
        public List<string> StringRange { get; set; }
        public IntRange IntRange { get; set; }
        public string Array { get; set; }

        public object Clone()
        {
            Parameter clone = new Parameter();

            clone.Name = Name;
            clone.type = type;
            clone.DoubleRange = DoubleRange;
            clone.Default = Default;
            clone.Description = Description;
            clone.Current_Value = Current_Value;

            if (null != StringRange)
            {
                clone.StringRange = new List<string>();
                foreach (var str in StringRange)
                {
                    clone.StringRange.Add(str);
                }
            }
            else
            {
                clone.StringRange = null;
            }

            clone.StringRange = StringRange;
            clone.IntRange = IntRange;
            clone.Array = Array;

            return clone;
        }
    }
}
