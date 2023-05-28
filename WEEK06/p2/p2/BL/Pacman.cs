using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
namespace p2.BL
{
    class Pacman
    {
        public int X;
        public int Y;
        public int score;
        public GRID mazeGrid;

        public Pacman(int X, int Y, GRID mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.mazeGrid = mazeGrid;
        
        }


        public void drawPlayer()
        {
            Console.SetCursorPosition(X, Y);

            Console.Write("P");
        
        }
        public void printScore()
        {
            // Console.SetCursorPosition(20, 6);
            //  Console.Write("Score"+score);
        }
        public void move()
        {
                 Cell current = mazeGrid.maze[Y, X];
   
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Console.WriteLine("Wao");
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {

                Cell next = mazeGrid.getLeftCell(current);
                
                moveLeft(current, next);

            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                Cell next = mazeGrid.getRightCell(current);
                
                moveRight(current, next);


              

            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                Cell next = mazeGrid.getUpCell(current);

                moveUp(current,next);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                Cell next = mazeGrid.getDownCell(current);

                moveDown(current,next);
            }

        }
        public void erasePlayer()

        {
            Console.SetCursorPosition(X,Y);
            Console.Write("  ");
        }
        public void moveLeft(Cell current, Cell next)
        {
            
            erasePlayer();
            X--;
            drawPlayer();


            /*if (next.Value == ' ')
            {
                if (!next.isGhostPresent('V'))
                {
                   
                    erasePlayer();
                    Console.SetCursorPosition(next.X,next.Y);
                    drawPlayer();
                }
            }*/
        }
        public void moveRight(Cell current,Cell next)
        {

            erasePlayer();
            X++;
            drawPlayer();


        }
        public void moveUp(Cell current,Cell next)
        {
            erasePlayer();
            Y--;
         
            drawPlayer();

        }
        public void moveDown(Cell current,Cell next)

        {
            
            erasePlayer();
            Y++;
            
            drawPlayer();
        }


    }
}
