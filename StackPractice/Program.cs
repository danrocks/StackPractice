///Based on Michaelis Essential c Sharp

using System;
using System.Collections.Generic;

namespace StackPractice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Program snake = new Program();
            snake.Sketch();
        }
    }

    class Program{
        public void Sketch(){
            Console.Clear();
            Console.Title = "Sketcher";
            Stack<Cell> path;

            path = new Stack<Cell>();

            Cell currentPosition;

            currentPosition = new Cell(Console.WindowWidth / 2, Console.WindowHeight / 2);
            path.Push(currentPosition);
           FillCell(currentPosition);

            ConsoleKeyInfo key;
           
            do
            {

                //key = Move();?
                key = Console.ReadKey(true);
                Console.Clear();
                    switch (key.Key)
                    {
                        case ConsoleKey.Z:
                            if (path.Count >= 1)
                            {
                                //No cast reuired
                                currentPosition = path.Pop();
                                Console.SetCursorPosition(
                                       currentPosition.X, currentPosition.Y
                                );
                                //undo;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.RightArrow:
                            currentPosition = new Cell(Console.CursorLeft, Console.CursorTop);
                            path.Push(currentPosition);
                            Console.SetCursorPosition(currentPosition.X, currentPosition.Y);
                            break;
                        default:
                            if (Console.KeyAvailable)
                                Console.Beep();
                            break;
                    }
            } while (key.Key != ConsoleKey.X);

        }

        private static void FillCell(Cell cell){

            FillCell(cell, ConsoleColor.Red);
        }

        private static void FillCell(Cell cell, ConsoleColor color)
        {
            Console.SetCursorPosition(cell.X,cell.Y);
            Console.BackgroundColor = color;
            Console.Write(' ' );
            Console.SetCursorPosition(cell.X, cell.Y);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    public struct Cell{
        readonly public int X;
        readonly public int Y;
        public Cell(int x, int y){
            X = x;
            Y = y;

        }

    }

}
