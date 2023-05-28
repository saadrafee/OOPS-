using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussnies_application.BL
{
    public class Passangers
    {
        public string name;
        public string id;
        public string destination;
        public Passangers(string name,string id,string destination)
        {
            this.name = name;
            this.id = id;
            this.destination = destination;
        }
    }
}
