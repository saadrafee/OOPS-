using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.BL;
namespace game.Functions
{
    static public class anymousFunction
    {

        static public void eraseThech(char[,] erase, int Xaxis, int Yaxis)
        {

            int y = Yaxis;
            for (int row = 0; row < 3; row++)
            {
                Console.SetCursorPosition(Xaxis, y);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(erase[row, col]);
                }
                y++;
            }
        }
        static public void printplayer(char[,] player, int playerX, int playerY)
        {

            int y = playerY;
            for (int row = 0; row < 3; row++)
            {
                Console.SetCursorPosition(playerX, y);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(player[row, col]);
                }
                y++;
            }
        }
        static public void makeBulletInactive(int x, List<bool> isBulletActive)
        {
            isBulletActive[x] = false;
        }
        static public void erasebullet(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static public void createbullet(List<int> bulletplayerx, List<int> bulletplayery, List<bool> isBulletActive, char[,] maze, int playerX, int playerY,int x)
        {

            char next;
            
            next = maze[playerY - 1+x, playerX];
            if (next ==' ' )
            {
                bulletplayerx.Add(playerX + 1);
                bulletplayery.Add(playerY - 1+x);
                isBulletActive.Add(true);
                Console.SetCursorPosition(bulletplayerx[bulletplayerx.Count - 1],
                       bulletplayery[bulletplayery.Count - 1]);
                Console.Write(".");

            }
        }
        static public void printbullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(".");
        }
        static public void bulletCollisionwithEnemy(Player pl, enemy1 en)
        {
            for (int idx = 0; idx < pl.bulletplayerx.Count; idx++)
            {
                if (pl.isBulletActive[idx] == true)
                {
                    if (pl.bulletplayery[idx] - 1 == en.enemyY + 2 && (pl.bulletplayerx[idx] == en.enemyX || pl.bulletplayerx[idx] == en.enemyX + 1 || pl.bulletplayerx[idx] == en.enemyX + 2))
                    {
                        pl.addScore();
                        en.addenemydamage();
                    }
                }
            }
        }
        static public void printdamage(int damage,int x,int y,string name)
        {
            Console.SetCursorPosition(x, y);
            Console.Write( name+ damage);
        }
        static public string random()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 3);
            string direction="";

            if (randomNumber == 0)
            {
                direction = "up";
            }

            if (randomNumber == 1)
            {
                direction = "down";
            }

            if (randomNumber == 2)
            {
                direction = "right";
            }

            if (randomNumber == 3)
            {
                direction = "left";
            }
            return direction;
        }
    }
}
