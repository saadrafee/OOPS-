using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace p2.BL
{
    class GRID
    {

        int rowSize;
        int colSize;
        string path;
        public Cell[,] maze = new Cell[24, 71];

        public GRID(int rowSize, int colSize, string path)
        {
            this.path = path;
            this.rowSize = rowSize;
            this.colSize = colSize;
            string line;
            int y = 0;
         

            StreamReader file = new StreamReader(path);
            
            
            while (((line = file.ReadLine()) != null))
            {
                for (int x = 0; x < line.Length; x++)
                {
                   maze[y, x] = new Cell(line[x], x, y);
                }
                y++;
            }
         
        }
        public Cell getLeftCell(Cell c)
        {

            c.X--;
            return c;


        }

        public Cell getRightCell(Cell c)
        {
            c.X++;
            return c;

        }



        public Cell getUpCell(Cell c)
        {
            c.Y--;
            return c;

        }

        public Cell getDownCell(Cell c)
        {
            c.Y++;
            return c;

        }
        /* public Cell findPacman()
         {


         }
         public Cell findGhost()
         {

         }
         public boll isStopingConditon()
         {

         }
        */
        public void drew()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(maze[i, j].Value);
                }
                Console.WriteLine("");
            }
        }

    }
}
