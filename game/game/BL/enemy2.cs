using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.Functions;
namespace game.BL
{
    public class enemy2
    {
       
        public int enemyX = 50;
        public int enemyY = 13;
       public string direction = "right";
        public int damage = 0;
        public char[,] player = new char[3, 3];
       public List<int> bulletenemyx = new List<int>();
        public List<int> bulletenemyy = new List<int>();
         public List<bool> makebulletenemyactive = new List<bool>();
        int enemy1bulletidx = 0;
      
        
        public void enemymove(char[,] maze,char[,] erase)
        {
            char next;
            if (direction == "right")
            {
                next = maze[enemyY, enemyX + 3];
                if (next == ' ' || next == '.')
                {
                    anymousFunction.eraseThech(erase, enemyX, enemyY);
                    enemyX++;
                    Console.SetCursorPosition(enemyX, enemyY);
                    anymousFuctionForenemy1.printenemy1(enemyX, enemyY, player);
                }
            }
            if (direction == "left")
            {
                next = maze[enemyY, enemyX - 1];
                if (next == ' ' )
                {
                    anymousFunction.eraseThech(erase, enemyX, enemyY);
                    enemyX--;
                    Console.SetCursorPosition(enemyX, enemyY);
                    anymousFuctionForenemy1.printenemy1(enemyX, enemyY, player);
                }
             
            }
            if (direction == "Up")
            {
                next = maze[enemyY - 1, enemyX];
                if (next == ' ' )
                {
                    anymousFunction.eraseThech(erase, enemyX, enemyY);
                    enemyY--;
                    Console.SetCursorPosition(enemyX, enemyY);
                    anymousFuctionForenemy1.printenemy1(enemyX, enemyY, player);
                }

            }
            if (direction == "Down")
            {
                next = maze[enemyY + 3, enemyX];
                if (next == ' ')
                {
                    anymousFunction.eraseThech(erase, enemyX, enemyY);
                    enemyY++;
                    Console.SetCursorPosition(enemyX, enemyY);
                    anymousFuctionForenemy1.printenemy1(enemyX, enemyY, player);
                }

            }
        }
        public void addenemydamage()
        {
            damage++;
        }
        

    }
}
