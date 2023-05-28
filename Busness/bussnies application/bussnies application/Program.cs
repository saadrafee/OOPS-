using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bussnies_application.BL;

namespace bussnies_application
{
    class Program
    {
        static void Main(string[] args)
        {
            //list
            List<Cities> cit = new List<Cities>();
            List<Passangers> pass = new List<Passangers>();
            List<UsersData> user = new List<UsersData>();
            List<Expanse> exp = new List<Expanse>();
            string ascessPassword = "saad1234";
            header();
            loaddatafromfiles(cit, pass,user,exp);
            int op = 0;
            do
            {
                op = printmain();
                if(op== 1)
                {
                    signIn(cit, pass, user, exp,ref ascessPassword);
                }
                if (op == 2)
                {
                    bool check=checkAscess(ascessPassword);
                    if (check == true) {
                        header();
                        user.Add(signUp());
                        Console.WriteLine("Sign Up ScessFully");
                    }
                    if(check == false)
                    {
                        Console.SetCursorPosition(12, 24);
                        Console.WriteLine("Wrong Acess Password");
                    }
                    Console.WriteLine("Press Any Key Continue....");
                    Console.ReadKey();
                }
                if (op == 3)
                {
                    passangermenu(cit, pass);
                }
            }
            while (op != 4);
            
            Console.ReadKey();
        }
        static void signIn(List<Cities> cit,List<Passangers> pass,List<UsersData> user,List<Expanse> exp,ref string accesPassword)
        {
            header();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(10, 24);
            Console.Write("Enter User Name :");
            string name = Console.ReadLine();
            Console.SetCursorPosition(10, 25);
            Console.Write("Enter User Password :");
            string password = Console.ReadLine();
            string role="";
            bool check = processSignIn(user,  name,password,ref role);
            if(check==true)
            {
                if(role=="admin")
                {
                    admin(cit, pass, user, exp,ref accesPassword);
                }
                if (role == "employ")
                {
                    employ( cit, pass,  user,  exp);
                }
            }
            else
            {
                Console.SetCursorPosition(10, 26);
                Console.WriteLine("Wrong Entry");
                Console.SetCursorPosition(10, 27);
                Console.WriteLine("Press Any Continue...");
                Console.ReadKey();
            }
        }
        static void  admin(List<Cities> cit,List<Passangers> pass,List<UsersData> user,List<Expanse> exp,ref string acessPassword) 
        {
            int op = 0;
            do
            {
                 op = adminMenu();
                if (op == 1)
                {
                    ticketSale(cit);
                }
                if (op == 2)
                {
                    seeAllPassanger(pass);
                }
                if (op == 3)
                {
                    changPrice(cit);
                }
                if (op == 4)
                {
                    addOrRemove(user);
                }
                if (op == 5)
                {
                    seeExpanse(exp);
                }
                if (op == 6)
                {
                    seeProfit(exp, cit);
                }
                if (op == 7)
                {
                    seeEmpolyDetail(user);
                }
                if (op == 8)
                {
                    addOrRemoveCity(cit);
                }
                if (op == 9)
                {
                    changeAscessPassword(ref acessPassword);
                }
            }
            while (op != 0);
        }
        static void changeAscessPassword(ref string acessPassword)
        {
            header();
            
            
            bool flag = checkAscess(acessPassword);
            if(flag==true)
            {
                header();
                Console.SetCursorPosition(10, 25);
                Console.Write("Enter You New AcessPassWors :");
                string pass = Console.ReadLine();
                acessPassword = pass;
                Console.SetCursorPosition(10, 26);
                Console.WriteLine("PassWord Change SucessFully");
            }
            else
            {
                header();
                Console.SetCursorPosition(10, 25);
                Console.Write("Wrong Entry..");
                
            }
            Console.SetCursorPosition(10, 27);
            Console.Write("Press Any Key To Continue.....");
            Console.ReadKey();

            
        }
        static void addOrRemoveCity(List<Cities> cit)
        {
            int op = addOrRemoveCityMenu();
            if(op==1)
            {
                cit.Add(addCity(cit));
            }
            if (op == 2)
            {
                removeCity(cit);
            }
        }
        static void removeCity(List<Cities> cit)
        {
            header();
            int index=0;
            bool flag = false;
            Console.SetCursorPosition(10, 25);
            Console.Write("Enter City to Remove :");
            string cityName = Console.ReadLine();
            flag=checkCity(cit, cityName, ref index);
            if(flag==true)
            {
                cit.RemoveAt(index);
                storeCities(cit);
                Console.SetCursorPosition(10, 26);
                Console.Write("Remove SuccessFully");
            }
            else
            {
                Console.SetCursorPosition(10, 26);
                Console.Write("Wrong Entry");
            }
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
        static Cities addCity(List<Cities> cit)
        {
            header();
            Console.SetCursorPosition(10, 25);
            Console.Write("Enter City Name :");
            string cityName = Console.ReadLine();
            Console.SetCursorPosition(10, 26);
            Console.Write("Enter Rent :");
            float rent =float.Parse( Console.ReadLine());
            Console.SetCursorPosition(10, 27);
            Cities city = new Cities(cityName, rent, 0);
            appBuses(city);
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            return city;
           
        }
        static int  addOrRemoveCityMenu()
        {
            header();
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("Press 1 for Add destination");
            Console.SetCursorPosition(10, 26);
            Console.WriteLine("Press 2 for Remove destination");
            Console.SetCursorPosition(10, 27);
            int op = int.Parse(Console.ReadLine());
            return op;
        }
        static void seeEmpolyDetail(List<UsersData> users)
        {
            header();
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("{0,-15}{1,-15}{2,-15}", "Name", "PassWords", "Role");
            int y = 27;
            foreach(var i in users)
            {
                Console.SetCursorPosition(10, y);
                Console.WriteLine("{0,-15}{1,-15}{2,-15}", i.name, i.password, i.role);
                y++;
            }
            Console.SetCursorPosition(10, y);
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        static void  seeProfit(List<Expanse> exp,List<Cities> cit)
        {
            float expan = calculateExp(exp);
            float sale = calculateSale(cit);
            header();
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("{0,-15}{1,-15}", "Total Expanse ", expan);
            Console.SetCursorPosition(10, 26);
            Console.WriteLine("{0,-15}{1,-15}", "Total Sale ", sale);
            Console.SetCursorPosition(10, 27);
            Console.WriteLine("___________________________________");
            if(sale<expan)
            {
                Console.SetCursorPosition(10, 28);
                Console.WriteLine("{0,-15}{1,-15}", "Loss  ", (expan-sale));
            }
            else
            {
                Console.SetCursorPosition(10, 28);
                Console.WriteLine("{0,-15}{1,-15}", "Profit  ", ( sale-expan));
            }
            Console.SetCursorPosition(10, 29);
            Console.WriteLine("___________________________________");
        }
        static float calculateExp(List<Expanse> exp)
        {
            float  sum = 0f;
            foreach(var i in exp)
            {
                sum += i.price;
            }
            return sum;
        }
        static float calculateSale(List<Cities> cit)
        {
            float sum = 0f;
            foreach (var i in cit)
            {
                sum += (i.rent * i.tikectSold);
            }
            return sum;
        }
        static void seeExpanse(List<Expanse> exp)
        {
            header();
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("{0,-10}{1,-10}", "Title", "Expanse");
            int y = 27;
            float sum = 0;
            foreach(var i in exp)
            {
                Console.SetCursorPosition(10, y);
                Console.WriteLine("{0,-10}{1,-10}", i.title, i.price);
                sum += i.price;
                y++;
            }
            Console.SetCursorPosition(10, y);
            Console.WriteLine("_________________________________");
            y++;
            Console.SetCursorPosition(10, y);
            Console.WriteLine("{0,-10}{1,-10}","Total Sum ",sum);
            y++;
            Console.SetCursorPosition(10, y);
            Console.WriteLine("_________________________________");
            Console.SetCursorPosition(10, y+1);
            Console.WriteLine("Press any key To continue.....");
            Console.ReadKey();
        }
        static void addOrRemove(List<UsersData> user)
        {
            int op = menuadd();
            if(op==1)
            {
                user.Add(signUp());
            }
            if(op==2)
            {
                removeUser(user);
            }
        }
        static void removeUser(List<UsersData> users)
        {
            int index = 0;
            header();
            Console.SetCursorPosition(10, 25);
            Console.Write("Enter Name of employ you want to remove :");
            string name = Console.ReadLine();
            Console.SetCursorPosition(10, 26);
            Console.Write("Enter His/Her Role :");
            string role = Console.ReadLine();
            bool flag = checkUser(name, role, ref index,users);
            if(flag==true)
            {
                users.RemoveAt(index);
                Console.SetCursorPosition(10, 27);
                Console.WriteLine("Remove SuccesFully");
            }
            if (flag == false)
            {
                
                Console.SetCursorPosition(10, 27);
                Console.WriteLine("Entry Does Not Exsit");
            }
        }
        static bool checkUser(string nam,string  rol, ref int index,List<UsersData> users)
        {
            bool flag = false;
            for(int i =0;i<users.Count;i++)
            {
                if(users[i].name==nam&&users[i].role==rol)
                {
                    flag = true;
                    index = i;
                }
            }
            return flag;
        }
        static int menuadd()
        {
            header();
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("Press 1 for add Empoly/Admin");
            Console.SetCursorPosition(10, 26);
            Console.WriteLine("Press 2 for remove Empoly/Admin");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
        static void changPrice(List<Cities> cit)
        {
            int op = menuChangePrice();
            if(op==1)
            {
                changePriceOfOne(cit);
            }
            if(op==2)
            {
                changePriceOfAll(cit);
            }
            storeCities(cit);

        }
        static void changePriceOfAll(List<Cities> cit)
        {
            header();
            Console.SetCursorPosition(10, 25);
            int y = 27;
            Console.WriteLine("{0,-10}{1,-10}{2,-10}", "City", "Old Rent", "New Rent");
            foreach(var i in cit)
            {
                Console.SetCursorPosition(10, y);
                Console.Write("{0,-10}{1,-10}", i.CitiesName, i.rent );
                Console.WriteLine("{0,30}", i.rent = (int.Parse(Console.ReadLine())));
                y++;
            }
        }
        static void changePriceOfOne(List<Cities> cit)
        {
            header();
            Console.SetCursorPosition(10, 24);
            Console.Write("Enter  City Name :");
            string citname = Console.ReadLine();
            bool flag = false;
            int index = 0;
            flag = checkCity(cit, citname, ref index);
            if(flag==true)
            {
                Console.SetCursorPosition(10, 25);
                Console.Write("Old Price is {0} Enter New Price :",cit[index].rent);
                Console.SetCursorPosition(42, 25);
                int pp = int.Parse(Console.ReadLine());
                cit[index].changePrice(pp);
            }
            else
            {
                Console.Write("Wrong Entry ");
            }
        }
        static bool checkCity(List<Cities> cit,string citiy,ref int index)
            {
            bool flag = false;
            for (int i  =0; i<cit.Count;i++)
            {
                flag = cit[i].checkPrecense(citiy);
                if(flag==true)
                {
                    index = i;
                    break;
                }
            }
            return flag;
        }
        static int menuChangePrice()
        {
            header();
            Console.SetCursorPosition(10, 24);
            Console.WriteLine("Press 1 For Change Specific City Rent ");
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("Press 2 For Change All City Rent ");
            Console.SetCursorPosition(10, 26);
            int op = int.Parse(Console.ReadLine());
            return op;

        }
        static void ticketSale(List<Cities> cit)
        {
            string name = "Cities Name ";
            string sold = "Sold Ticket";
            string inco = "Total Sales";
            header();
            Console.SetCursorPosition(10, 24);
            int y = 25;
            Console.WriteLine("{0,-15}{1,-15}{2,-15}",name,sold,inco);
            foreach(var i in cit)
            {
                Console.SetCursorPosition(10, y);
                Console.WriteLine("{0,-15}{1,-15}{2,-15}", i.CitiesName, i.tikectSold, (i.tikectSold * i.rent));
                y++;
            }
        }   
    static void employ(List<Cities> cit, List<Passangers> pass, List<UsersData> user, List<Expanse> exp)
        {
            int op = 0;
            do
            {
                op = employMenu();
                if(op==1)
                {
                    booking(cit,pass);
                }
                if (op == 2)
                {
                    cancelTicket( pass,cit);
                }
                if (op == 3)
                {
                    seeAllPassanger(pass);
                }
                if (op == 4)
                {
                   exp.Add( addExpanse());
                }

            }
            while (op != 5);
        }
        static Expanse addExpanse( )
        {
            Console.Write("Enter Title of Expanse ");
            string ti = Console.ReadLine();
            Console.Write("Enter Price ");
            float pr =float.Parse( Console.ReadLine());
            Expanse exp = new Expanse(ti,pr);
            return exp;
        }
        static int employMenu()
        {
            header();
            Console.SetCursorPosition(10, 24);
            Console.WriteLine( "press 1 Book ticket " );
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("press 2 cancel ticket " );
            Console.SetCursorPosition(10, 26);
            Console.WriteLine( "press 3 see passengers  " );
            Console.SetCursorPosition(10, 27);
            Console.WriteLine("press 4 for add expenses " );
            Console.SetCursorPosition(10, 28);
            Console.WriteLine("press 5 for exit " );
            Console.SetCursorPosition(10, 29);
            int op = int.Parse(Console.ReadLine());
            return op;
        }
        static int adminMenu()
        {
            header();
            Console.SetCursorPosition(10, 24);
            Console.WriteLine("press 1 for see ticket sales ");
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("press 2 for passanger detials ");
            Console.SetCursorPosition(10, 26);
            Console.WriteLine("press 3 for change price   ");
            Console.SetCursorPosition(10, 27);
            Console.WriteLine("press 4 for Add or remove (employ/admin) ");
            Console.SetCursorPosition(10, 28);
            Console.WriteLine("press 5 for see expences ");
            Console.SetCursorPosition(10, 29);
            Console.WriteLine("press 6 for net profit ");
            Console.SetCursorPosition(10, 30);
            Console.WriteLine("press 7 for see employe detail ");
            Console.SetCursorPosition(10, 31);
            Console.WriteLine("press 8 for add/remove new destination ");
            Console.SetCursorPosition(10, 32);
            Console.WriteLine("press 9 for change the access password  ");
            Console.SetCursorPosition(10, 33);
            Console.WriteLine("press 0 for exit ");
            Console.SetCursorPosition(10, 34);
            int op = int.Parse(Console.ReadLine());
            return op;
        }
        static bool processSignIn( List<UsersData> user,string nam,string passwor, ref string role)
        {
            bool flag = false;
            foreach(var i in user)
            {
                if(i.name==nam&&i.password==passwor&&(i.role=="admin" || i.role=="employ"))
                {
                    role = i.role;
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        static UsersData signUp()
        {
            string pass = "NUll";
            Console.Write("Enter New user Name :");
            string name = Console.ReadLine();
            Console.Write("Enter New user Role :");
            string role = Console.ReadLine();
            if(role=="admin"||role=="empoly")
            {
                Console.Write("Enter New user Password :");
                pass = Console.ReadLine();
            }
            UsersData us = new UsersData(name,role,pass);
            appUser(us);
            return us;
        }
        static void appUser(UsersData us)
        {
            string path = "D:\\CS\\semester 2\\PD\\Busness\\usersdata.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(us.name + ',' + us.password + ',' + us.role);
            file.Flush();
            file.Close();

        }
        static bool checkAscess(string ascessPassword)
        {
            bool flag = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(10, 24);
            Console.Write("Enter Acess Password :");
            string pass = Console.ReadLine();
            if(pass==ascessPassword)
            {
                flag = true;
            }
            return flag;
        }
        static int printmain()
        {
            header();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(10, 24);
            int option;
             Console.WriteLine("1.sign in");
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("2.sign up");
            Console.SetCursorPosition(10, 26);
            Console.WriteLine("3.Passanger");
            Console.SetCursorPosition(10, 27);
            Console.WriteLine("4.Exist");
                Console.SetCursorPosition(10, 28);
            Console.WriteLine("enter the option: ");
            Console.SetCursorPosition(10, 29);
            option = int.Parse(Console.ReadLine());
            return option;
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
        static void passangermenu( List<Cities> cit,List<Passangers> pass)
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
                    booking(cit,pass);
                }
               if (op == 2)
                {
                    cancelTicket(pass,   cit);
                }
                 if (op == 3)
                {
                    seeYourdetails( pass);
                }
                if (op == 4)
                {
                    runing = false;
                }
            
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void booking(List<Cities> cit, List<Passangers> pass)
        {
            header();
            int city;
            int confirm;
            int y = 25;
           
            Console.SetCursorPosition(10, y);
            Console.WriteLine( "Select destination " );
            for (int idx = 0; idx < cit.Count; idx++)
            {
                y++;
                Console.SetCursorPosition(10, y);
                Console.WriteLine( "Press " + (idx + 1) + " for " + cit[idx].CitiesName +"     Rent is "+ cit[idx].rent );
            }
            city = int.Parse(Console.ReadLine());
            header();
            Console.SetCursorPosition(10, 25);
            Console.WriteLine( "Ticket price is " + cit[city - 1].rent);
            Console.SetCursorPosition(10, 26);
            Console.WriteLine( "press 1 for book the ticket " );
            Console.SetCursorPosition(10, 27);
            Console.WriteLine( "press 0 for cancel the process " );
            Console.SetCursorPosition(10, 28);
            Console.SetCursorPosition(10, 28);
            confirm = int.Parse(Console.ReadLine());
            if (confirm == 1)
            {
                
                bookingConfirm(city, pass, cit);
                
            }
            if (confirm == 0)
            {
                Console.SetCursorPosition(10, 28);
                Console.WriteLine( "press any key to continue.....");
                Console.ReadKey();
            }
        }
        static void bookingConfirm(int city,List<Passangers> pass,List<Cities> cit)
        {
            header();
            string pname;
            string pid;
            
            Console.SetCursorPosition(10, 25);
            
            Console.Write( "Enter Passanger name ");
            pname = Console.ReadLine();
            Console.SetCursorPosition(10, 26);
                Console.SetCursorPosition(10, 27);
                Console.Write( "Enter ID No ");
                 pid=Console.ReadLine();
                Console.SetCursorPosition(10, 28);
            Passangers passa = new Passangers(pname, pid, cit[city - 1].CitiesName);
            pass.Add(passa);
            
            cit[city - 1].ticketBooked();
            storeCities(cit);
                Console.WriteLine( "Ticket is booked " );
            Passangers p1 = new Passangers(pname, pid, cit[city - 1].CitiesName);
            appassanger(p1);
                /*appassanger(pname, pid, cit[city - 1].CitiesName)*/;

            Console.ReadKey();
        }
       /* static void appassanger(string name, string id, string destination)
        {
            string path = "D:\\CS\\semester 2\\PD\\Busness\\passanger.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + ',' + id + ',' + destination);
            file.Flush();
            file.Close();

        }*/
        static void appassanger(Passangers p1)
        {
            string path = "D:\\CS\\semester 2\\PD\\Busness\\passanger.txt";
            StreamWriter file=new StreamWriter(path,true);
            file.WriteLine(p1.name + ',' + p1.id + ',' + p1.destination);
            file.Flush();
            file.Close();
            
        }
        static void appBuses(Cities cit)
        {
            string path = "D:\\CS\\semester 2\\PD\\Busness\\buses.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(cit.CitiesName + ',' + cit.rent + ',' + cit.tikectSold);
            file.Flush();
            file.Close();

        }
        static void loaddatafromfiles(List<Cities> cit,List<Passangers> pass,List<UsersData> users,List<Expanse> exp)
        {
            string line;
            string path = "D:\\CS\\semester 2\\PD\\Busness\\buses.txt";
            
            StreamReader file=new StreamReader(path);
            while (!(file.EndOfStream))
            {
                line = file.ReadLine();
                string[] word = line.Split(',');
               
                Cities citi = new Cities(word[0],float.Parse(word[1]),int.Parse(word[2]));
                cit.Add(citi);
  
            }
            file.Close();
             path = "D:\\CS\\semester 2\\PD\\Busness\\passanger.txt";
            StreamReader file2 = new StreamReader(path);
            while (!(file2.EndOfStream))
            { 
                line = file2.ReadLine();
                string[] word = line.Split(',');
                Passangers paasa = new Passangers(word[0], word[1], word[2]);
                pass.Add(paasa);
                
            }
            file2.Close();
            path = "D:\\CS\\semester 2\\PD\\Busness\\expenses.txt";
            file2 = new StreamReader(path);
            while (!(file2.EndOfStream))
            {            

                line = file2.ReadLine();
                string[] word = line.Split(',');
                Expanse expa = new Expanse(word[0], float.Parse(word[1]));
                exp.Add(expa);
             

            }
            file2.Close();
            path = "D:\\CS\\semester 2\\PD\\Busness\\usersdata.txt";
            file2 = new StreamReader(path);
            while (!(file2.EndOfStream))
            {
                line = file2.ReadLine();
                string[] word = line.Split(',');
                UsersData use = new UsersData(word[0], word[1], word[2]);
                users.Add(use);
                
            }
            file2.Close();
        }
        static void cancelTicket(List<Passangers> pass, List<Cities> citi)
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
            cancelTicketProcess( pass, citi,name,idcancel);
        }
        static void cancelTicketProcess( List<Passangers> pass ,  List<Cities> citi,string name,string idcancel)
        {   header();
            int i = 0;
            bool check = false;
            for (int idx = 0; idx < pass.Count; idx++)
            {

                if (name == pass[idx].name && idcancel == pass[idx].id)
                {
                    for (int ii = 0; ii < citi.Count; ii++)
                    {
                        if(pass[idx].destination ==citi[ii].CitiesName)
                        {
                            citi[ii].ticketCancel();
                            storeCities(citi);
                        }
                            }
                    check = true;
                    pass.RemoveAt(idx);
                   
                    
                }
            }

            if (check == true)
            {
                 Console.SetCursorPosition(10, 27);
                Console.WriteLine( "booking cancel successfully ");
                
                
                
                storepassanger(pass);
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
        static void storepassanger(List<Passangers> pass)
        {
            string path = "D:\\CS\\semester 2\\PD\\Busness\\passanger.txt";
            StreamWriter file = new StreamWriter(path);
            for (int idx = 0; idx < pass.Count; idx++)
            {
                file.WriteLine(pass[idx].name+ ',' + pass[idx].id + ',' + pass[idx].destination );
            }
            file.Flush();
            file.Close();
        }
       
        static void storeCities(List<Cities> cit)
        {
            string path = "D:\\CS\\semester 2\\PD\\Busness\\buses.txt";
            StreamWriter file = new StreamWriter(path);
            foreach(var i in cit)
            {
                file.WriteLine(i.CitiesName + ',' + i.rent + ',' + i.tikectSold);
            }
            file.Flush();
            file.Close();
        }
        static void seeYourdetails(List<Passangers> pass)
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
            for (int idx = 0; idx < pass.Count; idx++)
            {
                if (pass[idx].name == name && idcheck == pass[idx].id)
                {
                    check = true;
                }
            }
            if (check == true)
            {

                ViewseeYourdetails(name, idcheck, pass);
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
        static void seeAllPassanger(List<Passangers> pass)
        {
            header();
            int y = 24;
            Console.SetCursorPosition(10, y);
            string n1 = "Name";
            string n2 = "id";
            string n3 = "Destination";

            Console.WriteLine("{0,-10}{1,-10}{2,-10}", n1, n2, n3);
            y++;
            Console.SetCursorPosition(10, y);
            for (int idx = 0; idx < pass.Count; idx++)
            {
                y++;
                Console.SetCursorPosition(10, y);
                Console.WriteLine("{0,-10}{1,-10}{2,-10}", pass[idx].name, pass[idx].id, pass[idx].destination);
            }
            y++;
            Console.SetCursorPosition(10, y);
            Console.WriteLine("press any key to continue....");
            Console.ReadKey();
        }
            static void ViewseeYourdetails(string name, string idcheck,List<Passangers> pass)
        {
            header();
            int y = 24;
            Console.SetCursorPosition(10, y);
            string n1 = "Name";
            string n2 = "id";
            string n3 = "Destination";
            
            Console.WriteLine( "{0,-10}{1,-10}{2,-10}",n1,n2,n3  );
            y++;
            Console.SetCursorPosition(10, y);
            for (int idx = 0; idx < pass.Count; idx++)
            {
                if (pass[idx].name == name && idcheck == pass[idx].id)
                {
                    y++;
                    Console.SetCursorPosition(10, y);
                    Console.WriteLine("{0,-10}{1,-10}{2,-10}",pass[idx].name , pass[idx].id,pass[idx].destination );
                }
            }
            y++;
            Console.SetCursorPosition(10, y);
            Console.WriteLine( "press any key to continue....");
            Console.ReadKey();
        }

    }
    }

