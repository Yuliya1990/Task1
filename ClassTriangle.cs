using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle1
{
    public class Triangle
    {
        protected double[] Side = new double[3];

        public Triangle(double side0, double side1, double side2)
        {
            if (IsTriangleExist(side0, side1, side2))
            {
                Side[0] = side0; Side[1] = side1; Side[2] = side2;
            }
            else throw new Exception("Triangle doesn`t exist");
        }
      
        private bool IsTriangleExist(double side0, double side1, double side2)
        {
            if (side0>0 && side1>0 && side2>0)
            {
                if (side0 + side1 > side2 && side0 + side2 > side1 && side1 + side2 > side0)
                    return true;
            }
            return false;
        }
        public double Perimetr()
        {
            double perimetr = 0;
            for (int i = 0; i < 2; i++)
            {
                perimetr += Side[i];
            }
            return perimetr;
        }

        public bool ChangeSide(int IndexOfSideToChange, double newSide)
        {
            double[] temporary = new double[3];
            Side.CopyTo(temporary, 0);
            temporary[IndexOfSideToChange] = newSide;
            if (IsTriangleExist(temporary[0], temporary[1], temporary[2]))
            {
                Side[IndexOfSideToChange] = newSide;
                return true;
            }
            return false;
        }
        public virtual double[] GetAngles()
        {
             double[] angles = new double[3];
             angles[0] = Math.Acos((Math.Pow(Side[0], 2) + Math.Pow(Side[2], 2) - Math.Pow(Side[1], 2))
                 / (2 * Side[0] * Side[2])) * 180 / Math.PI;
             //angle between sides 0 and 2
             angles[1] = Math.Acos((Math.Pow(Side[0], 2) + Math.Pow(Side[1], 2) - Math.Pow(Side[2], 2))
                 / (2 * Side[0] * Side[1])) * 180 / Math.PI;
             //angle between sides 0 and 1
             angles[2] = 180 - angles[0] - angles[1];
             return angles;
        }
    }


    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double side) : base(side, side, side) {}
        public bool ChangeSide(double newSide)
        {
            for (int i=0; i<2; i++)
            {
                Side[i] = newSide;
            }
            return true;
        }
        public override double[] GetAngles()
        {
            return new double[] { 60, 60, 60 };
        }
        public double GetSquare()
        {
            return (Math.Sqrt(3) / 4) * Side[0];
        }

    }
}

