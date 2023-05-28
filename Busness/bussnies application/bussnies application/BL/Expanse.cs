using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussnies_application.BL
{
    public class Expanse
    {
        public string title;
        public float price;
       
        public Expanse (string title,float price)
        {
            this.title = title;
            this.price = price;
        }
    }
}
