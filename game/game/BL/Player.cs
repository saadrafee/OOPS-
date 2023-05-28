using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.Functions;
namespace game.BL
{
    public class Player
    {

        public int playerX = 22;
        public int playerY = 19;
        public char[,] player = new char[3, 3];
        public int score = 0;
        public int damage = 0;
        public List<bool> isBulletActive = new List<bool>();
        public List<int> bulletplayerx = new List<int>();
        public List<int> bulletplayery = new List<int>();
        public void moveplayerright(char[,] erase, char[,] maze)
        {
            char next = maze[playerY, playerX + 3];
            if (next == ' ')
            {
                anymousFunction.eraseThech(erase, playerX, playerY);
                playerX++;
                anymousFunction.printplayer(player, playerX, playerY);
            }
        }
        public void moveplayerleft(char[,] erase, char[,] maze)
        {
            char next = maze[playerY, playerX - 1];
            if (next == ' ')
            {
                anymousFunction.eraseThech(erase, playerX, playerY);
                playerX--;
                anymousFunction.printplayer(player, playerX, playerY);
            }

        }
        public void moveplayerUp(char[,] erase, char[,] maze)
        {
            char next = maze[playerY - 1, playerX];
            if (next == ' ')
            {
                anymousFunction.eraseThech(erase, playerX, playerY);
                playerY--;
                anymousFunction.printplayer(player, playerX, playerY);
            }

        }
        public void moveplayerDown(char[,] erase, char[,] maze)
        {
            char next = maze[playerY + 3, playerX];
            if (next == ' ')
            {
                anymousFunction.eraseThech(erase, playerX, playerY);
                playerY++;
                anymousFunction.printplayer(player, playerX, playerY);
            }

        }
        public void movebullet( char[,] maze)
        {

            for (int idx = 0; idx < bulletplayery.Count; idx++)
            {
                if (isBulletActive[idx] == true)
                {
                    char next = maze[bulletplayery[idx] - 1, bulletplayerx[idx]];

                    if (next != ' ')
                    {
                        anymousFunction.erasebullet(bulletplayerx[idx], bulletplayery[idx]);
                       anymousFunction.makeBulletInactive(idx, isBulletActive);
                
                    }
                    else
                    {
                        anymousFunction. erasebullet(bulletplayerx[idx], bulletplayery[idx]);
                        bulletplayery[idx] = bulletplayery[idx] - 1;
                        anymousFunction. printbullet(bulletplayerx[idx], bulletplayery[idx]);
                    }
                }
            }

        }
        public void addScore()
            {
            score++;
        }
        public void adddamage()
        {
            damage++;
        }
    }
}
 