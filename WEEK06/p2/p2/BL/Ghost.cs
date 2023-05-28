using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2.BL
{
    class Ghost
    {
        int X;
        int Y;
        string ghostDiraction;
        char ghostCharacter;
        float speed;
        char previousItem;
        float deltaChange;
        GRID mazeGrid;
        public Ghost(int x, int y, char ghostcharacter, string ghostdirection, float Speed, char PreviousItem, GRID mazegrid)
        {
            mazeGrid = mazegrid;
            X = x;
            Y = y;
            ghostCharacter = ghostcharacter;
            ghostDiraction = ghostdirection;
            speed = Speed;
            previousItem = PreviousItem;


        }


        public void setDirection(string ghostdireacton)
        {
            ghostDiraction = ghostdireacton;
        }
        public string getDirection()
        {
            return ghostDiraction;
        }
        public void remove()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
        public void drew()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(ghostCharacter);
        }
        public char getCharacter()
        {
            return ghostCharacter;
        }
        public void changeDelta()
        {
            deltaChange = speed + deltaChange;
        }
        public float getDelta()
        {

            return deltaChange;
        }
        /*        public float setDelta()
                {

                }
        */
        public void setDeltaZero()
        {
            deltaChange = 0;

        }
        public void move()
        {
         /*   changeDelta();
            if ((Math.Floor(getDelta())) == 1)
            {
         */       if (ghostCharacter == 'H')
                {
                                      moveHorizontal(mazeGrid);
                }
                setDeltaZero();
            
        }
        public void moveHorizontal(GRID mazeGrid)
        {
            Cell current = mazeGrid.maze[Y, X];
            Cell left = mazeGrid.getLeftCell(current);
            Cell right = mazeGrid.getRightCell(current);
            if (ghostDiraction == "left")
            {
                if (left.Value== ' ')
                {
                    X--;

                }
                else
                {
                   setDirection("right");

                    Console.WriteLine(ghostDiraction);
                    Console.ReadLine();
                }
            }
            else if(ghostDiraction=="right")
            {
                if(right.Value==' ')
                {
                    X++;

                }
                else
                {
                  
                    setDirection("left");
                     
                }
            }
        }
        public void moveVeritcale()
        {

        }

        /*    public int generateRandom()
            {

            }*/
        public void moveRandom()
        {

        }
        public void moveSmart()
        {

        }
        /*public double calculateDistance(Cell current, Cell pacmanLocation)
        {

        }*/
    }
}
