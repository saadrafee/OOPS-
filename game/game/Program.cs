using System;
using EZInput;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game.BL;
using game.Functions;
namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            int timer = 10;
            int move = 0;
            Player pl = new Player();
            enemy1 en1 = new enemy1();
            enemy2 en2 = new enemy2();
            char[,] Maze = new char[30, 75];
            char[,] player = new char[3, 3];
            char[,] erase = {
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '}
                    }; 
            load(Maze, pl,en1,en2);

            printmaze(Maze);
            bool runing = true;
            while (runing)
            {
                if (move == timer)
                {
                    if (en1.damage < 40)
                    {
                        en1.enemy1move(Maze, erase);
                        anymousFunction.createbullet(en1.bulletenemyx, en1.bulletenemyy, en1.makebulletenemyactive, Maze, en1.enemyX, en1.enemyY,4);
                    
                    }
                    if (en1.damage >= 40)
                    {
                        anymousFunction.eraseThech(erase, en1.enemyX, en1.enemyY);
                    }
                    if (en2.damage < 40)
                    {
                        en2.enemymove(Maze, erase);
                        anymousFunction.createbullet(en2.bulletenemyx, en2.bulletenemyy, en2.makebulletenemyactive, Maze, en2.enemyX, en2.enemyY, 4);

                    }
                    if (en2.damage >= 40)
                    {
                        anymousFunction.eraseThech(erase, en2.enemyX, en2.enemyY);

                    }
                    move = 0;
                }
                int rando = 0;
                if (rando == 50)
                {
                    en2.direction = anymousFunction.random();
                    rando = 0;
                }
                rando++;
                move++;
                Thread.Sleep(150);
                pl.movebullet(Maze);
                anymousFuctionForenemy1.movebulletEnemy(en1.bulletenemyx, en1.bulletenemyy, en1.makebulletenemyactive, Maze);
                anymousFuctionForenemy1.movebulletEnemy(en2.bulletenemyx, en2.bulletenemyy, en2.makebulletenemyactive, Maze);
                anymousFunction.bulletCollisionwithEnemy(pl, en1);
                anymousFuctionForenemy1.bulletCollisionwithplayer(en1.bulletenemyx, en1.bulletenemyy, en1.makebulletenemyactive, pl);
                anymousFunction.printdamage(en1.damage, 75, 8, "Enemy 1 Damage : ");
                anymousFunction.printdamage(pl.damage, 75, 7, "Player Damage : ");
                if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    pl.moveplayerleft(erase, Maze);

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    pl.moveplayerright(erase, Maze);

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    pl.moveplayerUp(erase, Maze);

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    pl.moveplayerDown(erase, Maze);

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.Escape))
                {
                    runing = false;

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.Space))
                {

                    anymousFunction.createbullet(pl.bulletplayerx, pl.bulletplayery, pl.isBulletActive, Maze, pl.playerX, pl.playerY,0);
                }

            }
        }
        static void load(char[,] printmaze,Player pl,enemy1 en,enemy2 en2)
        {
            string line;
            string path = "D:\\CS\\semester 2\\PD\\game\\maze.txt";
            StreamReader file = new StreamReader(path);
            int row = 0;
            while (!(file.EndOfStream))
            {
                line = file.ReadLine();
                string[] word = line.Split(',');

                for (int col = 0; col < 75; col++)
                {
                    printmaze[row, col] = Convert.ToChar(int.Parse(word[col]));

                }

                row++;

            }
            file.Close();
             path = "D:\\CS\\semester 2\\PD\\game\\player.txt";
             file = new StreamReader(path);
             row = 0;
            while (!(file.EndOfStream))
            {
                line = file.ReadLine();
                string[] word = line.Split(',');

                for (int col = 0; col < 3; col++)
                {
                    en2.player[row, col] = Convert.ToChar(int.Parse(word[col]));
                    en.player[row, col] = Convert.ToChar(int.Parse(word[col]));
                    pl.player[row, col] = Convert.ToChar(int.Parse(word[col]));

                }

                row++;

            }
            file.Close();


        }
        static void printmaze(char[,] Maze)
        {
            
            for (int idx = 0; idx < 28; idx++)
            {
                
                for (int idx2 = 0; idx2 < 75; idx2++)
                {
                    Console.Write( Maze[idx,idx2]);
                }
                Console.WriteLine();
            }
        }
      
        }

    }

