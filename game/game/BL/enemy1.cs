using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.Functions;
namespace game.BL
{
    public class enemy1
    {
       
        public int enemyX = 2;
        public int enemyY = 3;
       public string direction = "right";
        public int damage = 0;
        public char[,] player = new char[3, 3];
        public List<int> bulletenemyx = new List<int>();
        public List<int> bulletenemyy = new List<int>();
        public List<bool> makebulletenemyactive = new List<bool>();
        public void enemy1move(char[,] maze,char[,] erase)
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
                   anymousFuctionForenemy1.printenemy1(enemyX,enemyY,player);
                }
                else
                {
                    direction = "left";
                }
            }
            if (direction == "left")
            {
                next = maze[enemyY, enemyX - 1];
                if (next == ' ' || next == '.')
                {
                    anymousFunction.eraseThech(erase, enemyX, enemyY);
                    enemyX--;
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
