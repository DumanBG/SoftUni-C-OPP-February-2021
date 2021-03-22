using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
 public   class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get => this.width; private set => this.width = value; }
        public int Height { get =>this.height; private set =>this.height = value; }

        public void Draw()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
