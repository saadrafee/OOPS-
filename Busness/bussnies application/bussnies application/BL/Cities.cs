using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussnies_application.BL
{
    public class Cities
    {
        public string CitiesName;
        public float rent;
        public int tikectSold;
        public Cities()
        {
        }
        public Cities(string CitiesName,float rent,int tikectSold)
        {
            
            this.CitiesName = CitiesName;
            this.rent = rent;
            this.tikectSold = tikectSold;
        }
        public void ticketBooked()
        {
            tikectSold++;
        }
        public void ticketCancel()
        {
            tikectSold--;
        }
        public void changePrice(int rent)
        {
            this.rent = rent;
        }
        public bool checkPrecense(string name)
        {
            bool flag = false;
            if(name==CitiesName)
            {
                flag = true;
            }
            return flag;
        }

    }
}
