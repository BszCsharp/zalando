using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Angebot
    {
        public Int32 Id { get; set; }
        public String Anghebotstext { get; set; }
        public override string ToString()
        {
            return this.Anghebotstext;
        }
    }
}
