
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using p2.BL;
namespace p2
{
    class Program
    {
        static void Main(string[] args)
        {
             string path = "E:\\OOP\\Week6\\Maze\\DATA\\maz.txt";

            GRID mazeGrid = new GRID(10, 10, path);
            mazeGrid.drew();
            Pacman Player = new Pacman(3, 3, mazeGrid);
            List<Ghost> enemies = new List<Ghost>();
            /*Ghost ghot1 = new Ghost(15, 39, 'H', "left", 0.1f, ' ', mazeGrid);
            Ghost ghot2 = new Ghost(20, 57, 'V', "up", 0.2f, ' ', mazeGrid);
            Ghost ghot3 = new Ghost(19, 26, 'R', "up", 1f, ' ', mazeGrid);
            Ghost ghot4 = new Ghost(18, 21, 'C', "up", 0.5f, ' ', mazeGrid);
            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghot1);
            enemies.Add(ghot2);
            enemies.Add(ghot3);
            enemies.Add(ghot4);
            mazeGrid.draw();
            */
            Ghost ghot1 = new Ghost(7, 2, 'H', "left", 0.1f, ' ', mazeGrid);

            enemies.Add(ghot1); bool gameRunnin = true;
            while (gameRunnin)
            {
                Thread.Sleep(90);
                Player.printScore();
                //    Player.remove();
                Player.move();
                 Player.drawPlayer();
                foreach (Ghost g in enemies)
                {
                    g.remove();
                    g.move();
                    g.drew();
                }
/*                if (mazeGrid.isStopingCondition())
                {
                    gameRunnin = false;
                }
*/

            }
        }
        }
}
