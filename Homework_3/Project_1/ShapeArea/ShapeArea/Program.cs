using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeArea
{
    interface Shape
    {
        double Area();
        //int Height { get; set; }
        //int Width { get; set; }
        bool IfLegal();
    }
    class Rectangle : Shape
    {
        int Height { get; set; }
        int Width { get; set; }
        public Rectangle(int height,int width)
        {
            Height = height;
            Width = width;
        }

        public double Area()
        {
            if (this.IfLegal())
            {
                return this.Height * this.Width;
            }
            else
                Console.WriteLine("不是合法类型");
            return 0;
        }
        public bool IfLegal()
        {
            return Height > 0 && Width > 0;
        }
    }
    class Triangle : Shape
    {
        int SideA { get; set; }
        int SideB { get; set; }
        int SideC { get; set; }
        public Triangle(int sideA,int sideB,int sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }
        public double Area()
        {
            if (this.IfLegal())
            {
                int underSqrt = (SideA + SideB + SideC) * (SideA + SideB - SideC) *
                    (SideA + SideC - SideB) * (SideB + SideC - SideA);

                return 1.0 / 4 * Math.Sqrt(underSqrt);
            }
            else
                Console.WriteLine("不是合法三角形");
            return 0;
        }
        public bool IfLegal()
        {
            return (SideA + SideB > SideC && SideB + SideC > SideA && SideA + SideC > SideB
                 && SideA > 0 && SideB > 0 && SideC > 0);
               
        }

    }
    class Square:Rectangle
    {
        public Square(int side) : base(side, side) { }
       
    }
    class Factory
    {
        public Shape creatShape(int shapeName)
        {
            Shape shape;
            Random rand = new Random();
            switch (shapeName)
            {
                case 0:
                    shape = new Rectangle(rand.Next(3, 10), rand.Next(3, 10));
                    if(shape.IfLegal())
                        return shape;
                    break;
                case 1:
                    shape =
                        new Triangle(rand.Next(3, 10), rand.Next(3, 10), rand.Next(3, 10));
                    if (shape.IfLegal())
                        return shape;
                    break;
                case 2:
                    shape = new Square(rand.Next(3,10));
                    if (shape.IfLegal())
                        return shape;
                    break;
                default:
                    Console.WriteLine("这不是合理形状");
                    break;
 
            }
            return null;
        }
    }

    class Program
    {
        static double AreaAll;
        static Shape[] shapes = new Shape[9];
        static void Main(string[] args)
        {
            for (int num = 0; num < shapes.Length; num++)
            {
                Random random = new Random();
                Factory fac = new Factory();
                //Shape sha = fac.creatShape(1);
                Shape sha = fac.creatShape(random.Next(0, 2));
                if (sha != null)
                {
                    shapes[num] = sha;
                    continue;
                }
                else
                    num--;



            }
            for(int num = 0; num < shapes.Length; num++)
            {
                double i = shapes[num].Area();
                AreaAll = AreaAll + i;
            }
            Console.WriteLine(AreaAll);
        }
    }
}
