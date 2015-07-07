using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Image_Processing_Operation_Pool
{
    [Serializable]
    public class Var : ICloneable
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }

        public string varName { get; set; }

        public object Clone()
        {
            Var newVar = new Var();

             newVar.Name = Name;
             newVar.Type = Type;
             newVar.varName = varName;
             newVar.Description = Description;
            return newVar;
        }
    }
}
