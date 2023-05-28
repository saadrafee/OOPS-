using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task01.BL;
namespace task01
{
    class Program
    {
        static void Main(string[] args)
        { int op = 0;
            List<Ship> sh = new List<Ship>();
            do {
                Console.Clear();
                viewMenu();
                op=int.Parse(Console.ReadLine());
                if(op==1)
                {
                    sh.Add(shipinput());
                }
                if (op == 2)
                {
                    showShipPosition( sh);
                }
                if (op == 3)
                {
                    showShipSerialNumber(sh);
                }
                if (op == 4)
                {
                    changeDirection(sh);
                }
            }
            while (op != 5);
        }
        static void viewMenu()
        {
            Console.WriteLine("1.Add Ship");
            Console.WriteLine("2.View Ship Position");
            Console.WriteLine("3.View Ship Serial Number");
            Console.WriteLine("4.Change Ship Position");
            Console.WriteLine("5.Exit");
        }
        static Ship shipinput()
        {
            Console.Clear();
            List<Angle> latitude = new List<Angle>();
            List<Angle> longitude = new List<Angle>();
            Console.Write("Enter Ship Serial Number :");
            string serialNUmber = Console.ReadLine();
                latitude.Add(takeInputAngle("Latitude"));
            longitude.Add(takeInputAngle("Longitude"));
            Ship sh = new Ship(serialNUmber, latitude, longitude);
            return sh;

        }
        static Angle takeInputAngle(string diractions)
        {
           
            Console.Write("Enter {0}'s Degree :", diractions);
            int degree = int.Parse(Console.ReadLine());
            Console.Write("Enter {0}'s Minutes :", diractions);
            float minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter {0}'s Diraction :",diractions );
            char diraction = char.Parse(Console.ReadLine());
            Angle an = new Angle(degree, minutes, diraction);
            return an;
           
        }
        static void showShipPosition(List<Ship> sh)
        {
            Console.Clear();
            int index;
            List<Angle> an = new List<Angle>();
            Console.Write("Enter Serial Number :");
            string serial = Console.ReadLine();
            bool flag = checkPresence(sh, serial);
            if(flag==true)
            {
                index =findIndexNumber(sh, serial);
                
                an = sh[index].showLatitude();
                printDirection(an,"Latitude");
                an = sh[index].showLongitude();
                printDirection(an, "Longitude");

            }
            else
            {
                Console.Write("No Ship Found");
            }
            Console.WriteLine("Press Any Key to Continue.......");
            Console.ReadKey();
        }
        static void printDirection(List<Angle> angles,string directions)
        {
            Console.WriteLine("Latitude  " + angles[0].degree + "\u00b0" + angles[0].degree + "'" + angles[0].diraction + "''");

        }
        static int findIndexNumber(List<Ship> sh,string serial)
        {
            int index = 0;
            for (int i = 0; i < sh.Count; i++)
            {
                if (serial == sh[i].getSerialNumber())
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

static bool checkPresence(List<Ship> sh , string serial)
        {
            bool flag = false;
            for(int i =0; i<sh.Count;i++)
            {
                if (serial == sh[i].getSerialNumber())
                {
                    flag = true;
                }
            }
            return flag;
        }
         static void  showShipSerialNumber(List <Ship> sh)
        {
            int index=0;
            List<Angle> cj = new List<Angle>();
            List<Angle> lat = new List<Angle>();
            lat.Add(takeInputAngle("Latitude"));
            List<Angle> lon= new List<Angle>();
            lon.Add(takeInputAngle("Longitude"));
            Console.WriteLine(lat[0].degree);
            bool check = checkAngel(lat, lon, sh,ref index);
            Console.WriteLine(index);
            if(check == true)
            {
                printDirection(sh,index);
            }
            else
            {
                Console.WriteLine("Ship Not Found!!");
            }
            
            Console.WriteLine("Press Any Key to Continue.......");
            Console.ReadKey();
        }
        static void printDirection(List<Ship> sh,int index)
        { 
            Console.WriteLine("Serial Number is " + sh[index].getSerialNumber());
        }
        static bool checkAngel(List<Angle> lat,List<Angle> lon, List<Ship> sh,ref int i)
        {
            bool flag = false;

            for(int index  = 0; index<sh.Count();index++)
            {
                if (sh[index].showLatitude() == lat && sh[index].showLongitude() == lon)
                    {
                    flag = true;
                    i = index;
                    break;
                }

            }
            return flag;
        }

        static void changeDirection(List<Ship> sh)
        {
            List<Angle> latitude = new List<Angle>();
            List<Angle> longitude = new List<Angle>();
            Console.Write("Enter Serial ");
            string ser = Console.ReadLine();
            bool check =checkPresence(sh, ser);
            if(check==true)
            {
                int index = findIndexNumber(sh, ser);
            latitude.Add(takeInputAngle("New Latitude"));
                longitude.Add(takeInputAngle("New Longitude"));
                sh[index].changedirection(latitude, longitude);
            }
           if(check==false)
            {
                Console.WriteLine("Wrong Entry");
            }
            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();
        }
    }
}
