using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.BL;
namespace game.Functions
{
    static public class anymousFuctionForenemy1
    {
        static public void printenemy1(int enemyX, int enemyY, char[,] player)
        {

            int y = enemyY;
            for (int row = 2; row >= 0; row--)
            {
                Console.SetCursorPosition(enemyX, y);
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(player[row, col]);
                }
                y++;
            }
        }
        static public void movebulletEnemy(List<int> bulletenemyx, List<int> bulletenemyy, List<bool> makebulletenemyactive, Char[,] maze)
        {
            for (int idx = 0; idx < bulletenemyx.Count; idx++)
            {

                if (makebulletenemyactive[idx] == true)
                {
                    char next = maze[bulletenemyy[idx] + 1, bulletenemyx[idx]];
                    if (next != ' ')
                    {
                        anymousFunction.erasebullet(bulletenemyx[idx], bulletenemyy[idx]);
                        anymousFunction.makeBulletInactive(idx, makebulletenemyactive);
                    }
                    else
                    {
                        anymousFunction.erasebullet(bulletenemyx[idx], bulletenemyy[idx]);
                        bulletenemyy[idx] = bulletenemyy[idx] + 1;
                        anymousFunction.printbullet(bulletenemyx[idx], bulletenemyy[idx]);
                    }
                }
            }
        }
        static public void bulletCollisionwithplayer(List<int> bulletenemyx, List<int> bulletenemyy, List<bool> makebulletenemyactive, Player pl)
        {
            for (int idx = 0; idx < bulletenemyy.Count; idx++)
            {
                if (makebulletenemyactive[idx] == true)
                {
                    if (bulletenemyy[idx] + 1 == pl.playerY && (bulletenemyx[idx] == pl.playerX || bulletenemyx[idx] == pl.playerX + 1 || bulletenemyx[idx] == pl.playerX + 2))
                    {
                        pl.adddamage();
                    }
                }

            }
        }
    }
}
