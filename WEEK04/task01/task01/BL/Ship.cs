using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task01.BL
{
    public class Ship
    {
        public string serialNUmber;
        List<Angle> latitude = new List<Angle>();
        List <Angle> longitude = new List<Angle>();
        public Ship(string serialNUmber,List<Angle> latitude,List<Angle> longitude)
        {
            this.serialNUmber = serialNUmber;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public void changedirection(List<Angle> latitude, List<Angle> longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public List<Angle> showLatitude()
        {
            return latitude;
        }
        public List<Angle> showLongitude()
        {
            return longitude;
        }
        public string getSerialNumber()
        {
            return serialNUmber;
        }
    }
}
