using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussnies_application
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runing = true;
            int op;
            string[] passangerNames=new string[150];
            string[] passangerDestination= new string[150];
            string[] id = new string[150];
            int idxForpassangers = 0;
            int destinationIdx=idxForpassangers;
            int[] eachCitySoldticket = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            string[] destination= new string[150];
            int ticketSold = 0;
            //int destinationIdx;
            string[] cities=new string[15];
            int citiesIdx = 0;
            float[] rent=new float[15];
            rent[0] = 1500;
            string[] expanse=new string[10];
            float[] costprice=new float [10];
            int expanseIdx = 0;
            float totalExpance = 0;

            string[] username=new string[15];
            string[] password = new string[15];
            string[] post = new string[15];
            string accesspassword = "saad1234";
            int signidx = 0;

            header();
            loaddatafromfiles(cities, rent, ref citiesIdx, passangerNames, id, passangerDestination, ref idxForpassangers,ref destinationIdx ,eachCitySoldticket,expanse,ref expanseIdx,costprice,ref totalExpance,username,password,ref signidx,post);
            
            while (runing)
            {
                Console.SetCursorPosition(10, 0);
                header();
                option();
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                   /* signUp();*/
                }
                if (op == 2)
                {
                   /* signIn(signidx, username, password,  post);*/
                }
                if (op == 3)
                {
                    /*passangermenu(citiesIdx, rent, passangerNames, ref idxForpassangers, id, passangerDestination, cities, ref ticketSold, destinationIdx, eachCitySoldticket);*/
                }
                if (op == 4)
                {
                    runing = false;
                }
            }
            Console.ReadKey();
        }
        static void printlogo()
        {
            string line;
            string path = "D:\\New folder\\New folder\\buslogo.txt";
            StreamReader file = new StreamReader(path);
            int x = 10;
            int y = 5;
            Console.ForegroundColor = ConsoleColor.Red;
            while ((line=file.ReadLine())!=null)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(line);
                y++;
            }
            file.Close();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void header()
        {

            Console.Clear();
            printlogo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 21);
            Console.WriteLine( "*****************************************************" );
            Console.SetCursorPosition(10, 22);
            Console.WriteLine( "            Bus Reservation system " );
            Console.SetCursorPosition(10, 23);
            Console.WriteLine( "*****************************************************" );
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void passangermenu(int citiesIdx, float[] rent, string[] passangerNames, ref int idxForpassangers, string[] id, string[] passangerDestination, string[] cities,ref int ticketSold, int destinationIdx,int[] eachCitySoldticket)
        {

            bool runing = true;
            int op = 0;

            while (runing)
            {
                header();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(10, 24);
                Console.WriteLine("press 1 for book the ticket  ");
                Console.SetCursorPosition(10, 25);
                Console.WriteLine("press 2 for cancel the ticket ");
                Console.SetCursorPosition(10, 26);
                Console.WriteLine("press 3 for see your ticket details  ");
                Console.SetCursorPosition(10, 27);
                Console.WriteLine("press 4 for exit");
                Console.SetCursorPosition(10, 28);
                Console.SetCursorPosition(10, 28);
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    booking(citiesIdx,  rent,passangerNames, ref  idxForpassangers,  id,  passangerDestination,  cities ,ref ticketSold, destinationIdx,  eachCitySoldticket);
                }
               if (op == 2)
                {
                    cancelTicket(idxForpassangers,  passangerNames,  id, ref citiesIdx, passangerDestination,  eachCitySoldticket,  cities);
                }
                 if (op == 3)
                {
                    seeYourdetails( passangerNames, idxForpassangers,  id,  passangerDestination);
                }
                if (op == 4)
                {
                    runing = false;
                }
            
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void booking(int citiesIdx,float[] rent, string[] passangerNames,ref int idxForpassangers, string[] id, string[] passangerDestination, string[] cities,ref int ticketSold, int destinationIdx,  int[] eachCitySoldticket)
        {
            header();
            int city;
            int confirm;
            int y = 25;
           
            Console.SetCursorPosition(10, y);
            Console.WriteLine( "Select destination " );
            for (int idx = 0; idx < citiesIdx; idx++)
            {
                y++;
                Console.SetCursorPosition(10, y);
                Console.WriteLine( "Press " + (idx + 1) + " for " + cities[idx] +"     Rent is "+ rent[idx] );
            }
            city = int.Parse(Console.ReadLine());
            header();
            Console.SetCursorPosition(10, 23);
            Console.WriteLine( "Ticket price is " + rent[city - 1] );
            Console.SetCursorPosition(10, 24);
            Console.WriteLine( "press 1 for book the ticket " );
            Console.SetCursorPosition(10, 25);
            Console.WriteLine( "press 0 for cancel the process " );
            Console.SetCursorPosition(10, 26);
            Console.SetCursorPosition(10, 26);
            confirm = int.Parse(Console.ReadLine());
            if (confirm == 1)
            {
                bookingConfirm(city, passangerNames,ref idxForpassangers, id, passangerDestination, cities,ref ticketSold,  destinationIdx, citiesIdx,  eachCitySoldticket);
            }
            if (confirm == 0)
            {
                Console.SetCursorPosition(10, 28);
                Console.WriteLine( "press any key to continue.....");
                Console.ReadKey();
            }
        }
        static void bookingConfirm(int city,string[] passangerNames,ref int idxForpassangers,string[] id,string[] passangerDestination,string[] cities,ref int ticketSold,int destinationIdx,int citiesIdx,int[] eachCitySoldticket)
        {
            header();
            string name;
            Console.SetCursorPosition(10, 25);
            
            Console.Write( "Enter Passanger name ");
            name = Console.ReadLine();
            Console.SetCursorPosition(10, 26);
     
          

                passangerNames[idxForpassangers] = name;
                Console.SetCursorPosition(10, 27);
                Console.Write( "Enter ID No ");
                 id[idxForpassangers]=Console.ReadLine();
                Console.SetCursorPosition(10, 28);
                Console.WriteLine( "Ticket is booked " );
                passangerDestination[idxForpassangers] = cities[city - 1];
                appassanger(passangerNames[idxForpassangers], id[idxForpassangers], passangerDestination[idxForpassangers]);
                idxForpassangers++;
            ticketSold++;
            calulationOfTicketSales(destinationIdx, idxForpassangers, citiesIdx,  passangerDestination,  cities,  eachCitySoldticket);
            Console.ReadKey();
        }
        static void appassanger(string name, string id, string destination)
        {
            string path = "D:\\CS\\semester 2\\PD\\WEEK01\\passanger.txt";
            StreamWriter file=new StreamWriter(path,true);
            file.WriteLine(
                  name + ',' + id + ',' + destination);
            file.Flush();
            file.Close();
        }
        static void loaddatafromfiles(string[] cities, float[] rent, ref int citiesIdx, string[] passangerNames, string[] id, string[] passangerDestination,ref int idxForpassangers,ref int destinationIdx,  int[] eachCitySoldticket,string[] expanse,ref int expanseIdx,float[] costprice,ref float totalExpance,string[] username,string[] password,ref int  signidx,string[] post)
        {
            string line;
            string path = "D:\\CS\\semester 2\\PD\\WEEK01\\buses.txt";
            StreamReader file=new StreamReader(path);
            while (!(file.EndOfStream))
            {
                line = file.ReadLine();
                string[] word = line.Split(',');
                cities[citiesIdx] = word[0];
                rent[citiesIdx] = float.Parse(word[1]);
                citiesIdx = citiesIdx + 1;
            }
            file.Close();
             path = "D:\\CS\\semester 2\\PD\\WEEK01\\passanger.txt";
            StreamReader file2 = new StreamReader(path);
            while (!(file2.EndOfStream))
            {
                line = file2.ReadLine();
                string[] word = line.Split(',');
                passangerNames[idxForpassangers] = word[0];
                id[idxForpassangers] = word[1];
                passangerDestination[idxForpassangers] = word[2];
                idxForpassangers++;
            }
            file.Close();
            calulationOfTicketSales(destinationIdx, idxForpassangers, citiesIdx, passangerDestination, cities, eachCitySoldticket);
            path = "D:\\CS\\semester 2\\PD\\WEEK01\\expenses.txt";
    
        file2 = new StreamReader(path);
            while (!(file2.EndOfStream))
            {
                line = file2.ReadLine();
                string[] word = line.Split(',');
                expanse[expanseIdx] = word[0];
                costprice[expanseIdx] = float.Parse(word[1]);
                totalExpance = totalExpance + costprice[expanseIdx];
                expanseIdx++;
            }
            file.Close();
            path = "D:\\CS\\semester 2\\PD\\WEEK01\\usersdata.txt";
            file2 = new StreamReader(path);
            while (!(file2.EndOfStream))
            {
                line = file2.ReadLine();
                string[] word = line.Split(',');
                username[signidx] = word[0];
                password[signidx] = word[1];
                post[signidx] = word[2];
                signidx++;
            }
            file.Close();
        }
        
            static void cancelTicket(int idxForpassangers, string[] passangerNames, string[] id, ref int citiesIdx, string[] passangerDestination, int[] eachCitySoldticket, string[] cities)
        {
            header();
            string name;
            string idcancel;
            
            Console.SetCursorPosition(10, 24);
            Console.Write("Enter passanger name ");
            name = Console.ReadLine();

            Console.SetCursorPosition(10, 25);
            Console.Write("Enter id number of passanger ");
            idcancel = Console.ReadLine();
            Console.SetCursorPosition(10, 26);
            Console.Write("press any key to continue.....");
            Console.ReadKey();
            cancelTicketProcess(idxForpassangers, passangerNames, id, ref citiesIdx, passangerDestination, eachCitySoldticket, cities,name,idcancel);
        }
        static void cancelTicketProcess(int idxForpassangers, string[] passangerNames, string[] id, ref int citiesIdx, string[] passangerDestination, int[] eachCitySoldticket, string[] cities,string name,string idcancel)
        {   header();
            int i = 0;
            bool check = false;
            for (int idx = 0; idx < idxForpassangers; idx++)
            {

                if (name == passangerNames[idx] && idcancel == id[idx])
                {
                    check = true;
                    i = idx;
                    break;
                }
            }

            if (check == true)
            {
                 Console.SetCursorPosition(10, 27);
                Console.WriteLine( "booking cancel successfully ");
                for (int idx = 0; idx < citiesIdx; idx++)
                {
                    if (passangerDestination[i] == cities[idx])
                    {
                        eachCitySoldticket[idx] = eachCitySoldticket[idx] - 1;
                    }
                }
                for (int idx = i; idx < idxForpassangers - 1; idx++)
                {
                    passangerNames[idx] = passangerNames[idx + 1];
                    passangerDestination[idx] = passangerDestination[idx + 1];
                    id[idx] = id[idx + 1];
                }
                idxForpassangers--;
                storepassanger(idxForpassangers,  passangerNames, id,  passangerDestination);
            }
            if (check == false)
            {
                 Console.SetCursorPosition(10, 27);
                Console.WriteLine( "Wrong input ");
            }
             Console.SetCursorPosition(10, 28);
            Console.Write( "Press any key to continue....." );
            Console.ReadKey();
        }
       static void calulationOfTicketSales(int destinationIdx,int idxForpassangers,int citiesIdx,String[] passangerDestination,string[] cities,int[] eachCitySoldticket)
        {
            header();
            for (int idx = destinationIdx; idx < idxForpassangers; idx++)
            {
                for (int idx2 = 0; idx2 < citiesIdx; idx2++)
                {
                    if (passangerDestination[idx] == cities[idx2])
                    {
                        eachCitySoldticket[idx2] = eachCitySoldticket[idx2] + 1;
                    }
                }
            }
        }
        static void storepassanger(int idxForpassangers,string[] passangerNames,string[] id,string[] destination)
        {
            string path = "D:\\CS\\semester 2\\PD\\WEEK01\\passanger.txt";
            StreamWriter file = new StreamWriter(path);
            for (int idx = 0; idx < idxForpassangers; idx++)
            {
                Console.WriteLine(passangerNames[idx]+ ',' + id[idx] + ',' + destination[idx] );
            }
            file.Flush();
            file.Close();
        }
        static void seeYourdetails(string[] passangerNames,int idxForpassangers,string[] id,string[] passangerDestination)
        {
            header();
            string name;
            string idcheck;
            bool check = false;
            Console.SetCursorPosition(10, 24);
            Console.Write("Enter your name :");
            name = Console.ReadLine();
            Console.SetCursorPosition(10, 25);
            Console.Write( "Enter your id number ");
             idcheck=Console.ReadLine();
             Console.ReadKey();
            for (int idx = 0; idx < idxForpassangers; idx++)
            {
                if (passangerNames[idx] == name && idcheck == id[idx])
                {
                    check = true;
                }
            }
            if (check == true)
            {

                ViewseeYourdetails(name, idcheck, passangerNames, id, passangerDestination, idxForpassangers);
            }
            else
            {
                Console.SetCursorPosition(10, 26);
                Console.WriteLine("there is no booked ticked for you ");
                Console.SetCursorPosition(10, 27);
                Console.WriteLine("press any key to continue");
                 Console.ReadKey();
            }
        }
        static void ViewseeYourdetails(string name, string idcheck,string[] passangerNames,string[] id,string[] passangerDestination,int idxForpassangers)
        {
            header();
            int y = 24;
            Console.SetCursorPosition(10, y);
            Console.WriteLine( "       Name              id            Destination"  );
            y++;
            Console.SetCursorPosition(10, y);
            for (int idx = 0; idx < idxForpassangers; idx++)
            {
                if (passangerNames[idx] == name && idcheck == id[idx])
                {
                    y++;
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine( passangerNames[idx] +"          "+ id[idx] +"        "+passangerDestination[idx] );
                }
            }
            y++;
            Console.SetCursorPosition(10, y);
            Console.WriteLine( "press any key to continue....");
            Console.ReadKey();
        }
        static void option()
        {
            
            Console.SetCursorPosition(10, 24);
            Console.WriteLine( "press 1 for sign up " );
            Console.SetCursorPosition(10, 25);
            Console.WriteLine( "press 2 for sign in  " );
            Console.SetCursorPosition(10, 26);
            Console.WriteLine( "press 3 for passanger  " );
            Console.SetCursorPosition(10, 27);
            Console.WriteLine( "press 4 exsit  " );
            Console.SetCursorPosition(10, 28);
            
        }
        
    }
    }

