using System.Diagnostics.Contracts;

namespace practika_FourPoint;

public class FourPoint : Point
{
    private Point A;
    private Point B;
    private Point C;
    private Point D;

    public FourPoint(Point A, Point B, Point C, Point D)
    {
        if (Point.equation_four_point(A, B, C, D))
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }
        else
        {
            Console.WriteLine("Точки не лежат в одной плоскости!");
            this.A = new Point(0, 0, 0);
            this.B = new Point(0, 0, 0);
            this.C = new Point(0, 0, 0);
            this.D = new Point(0, 0, 0);
        }
    }

    public static double perimeter(FourPoint pr)
    {
        double pm = distance(pr.A, pr.B) + distance(pr.B, pr.C) + distance(pr.C, pr.D) + distance(pr.D, pr.A);
        return pm;
    }
    
    public static double square(FourPoint sq)
    {
        double a = distance(sq.A, sq.B);
        double b = distance(sq.B, sq.C);
        double c = distance(sq.C, sq.D);
        double d = distance(sq.D, sq.A);
        double angle1 = angle_two_point(vector(sq.A, sq.B), vector(sq.B, sq.C));
        double angle2 = angle_two_point(vector(sq.C, sq.D), vector(sq.A, sq.D));
        double p = (a + b + c + d) / 2;
        double pp = (p - a) * (p - b) * (p - c) * (p - d);
        double square = Math.Sqrt(pp - a * b * c * d * Math.Pow(Math.Cos((angle1 + angle2) / 2), 2));
        return square;
    }

    public static double[] diagonal_length(FourPoint dl)
    {
        double dg1 = distance(dl.A, dl.C);
        double dg2 = distance(dl.B, dl.D);
        double[] dg = new double[2] { dg1, dg2 };
        return dg;
    }
    
    public static bool convexity(FourPoint cx)
    {
        if (Math.Sign(vectorM(cx.A - cx.B, cx.D - cx.B) / vectorM(cx.D - cx.B, cx.C - cx.B)) ==
            Math.Sign(vectorM(cx.B - cx.A, cx.C - cx.A) / vectorM(cx.C - cx.A, cx.D - cx.A)))
        { return true; } 
        return false;
    }

    public static bool convexity_v2(FourPoint cx)
    {
        if (!((cx.A - cx.B) / (cx.A - cx.C))) { return false; }
        if (!((cx.B - cx.C) / (cx.B - cx.D))) { return false; }
        if (!((cx.C - cx.D) / (cx.C - cx.A))) { return false; }
        return true;
    }

    public static bool intersection(FourPoint ins1, FourPoint ins2)
    {
        if (Point.intersection_parts(ins1.A, ins1.B, ins2.A, ins2.B) == true ||
            Point.intersection_parts(ins1.A, ins1.B, ins2.B, ins2.C) == true ||
            Point.intersection_parts(ins1.A, ins1.B, ins2.C, ins2.D) == true ||
            Point.intersection_parts(ins1.A, ins1.B, ins2.D, ins2.A) == true)
        { return true; }
        if (Point.intersection_parts(ins1.B, ins1.C, ins2.A, ins2.B) == true ||
            Point.intersection_parts(ins1.B, ins1.C, ins2.B, ins2.C) == true ||
            Point.intersection_parts(ins1.B, ins1.C, ins2.C, ins2.D) == true ||
            Point.intersection_parts(ins1.B, ins1.C, ins2.D, ins2.A) == true)
        { return true; }
        if (Point.intersection_parts(ins1.C, ins1.D, ins2.A, ins2.B) == true ||
            Point.intersection_parts(ins1.C, ins1.D, ins2.B, ins2.C) == true ||
            Point.intersection_parts(ins1.C, ins1.D, ins2.C, ins2.D) == true ||
            Point.intersection_parts(ins1.C, ins1.D, ins2.D, ins2.A) == true)
        { return true; }
        if (Point.intersection_parts(ins1.D, ins1.A, ins2.A, ins2.B) == true ||
            Point.intersection_parts(ins1.D, ins1.A, ins2.B, ins2.C) == true ||
            Point.intersection_parts(ins1.D, ins1.A, ins2.C, ins2.D) == true ||
            Point.intersection_parts(ins1.D, ins1.A, ins2.D, ins2.A) == true)
        { return true; }
        return false;
    }

    public static bool one_inside_the_other(FourPoint f1, FourPoint f2)
    {
        double[] ox1 = new double[4] { f1.A.oX, f1.B.oX, f1.C.oX, f1.D.oX };
        double[] ox2 = new double[4] { f2.A.oX, f2.B.oX, f2.C.oX, f2.D.oX };
        double[] oy1 = new double[4] { f1.A.oY, f1.B.oY, f1.C.oY, f1.D.oY };
        double[] oy2 = new double[4] { f2.A.oY, f2.B.oY, f2.C.oY, f2.D.oY };
        
        double minoX1 = ox1.Min();
        double minoX2 = ox2.Min();
        double maxoX1 = ox1.Max();
        double maxoX2 = ox2.Max(); 
        double maxoY1 = oy1.Max();
        double maxoY2 = oy2.Max();
        double minoY1 = oy1.Min();
        double minoY2 = oy2.Min();
        
        if((((minoX1 > minoX2 && minoX1 < maxoX2) && (maxoX1 > minoX2 && maxoX1 < maxoX2)) &&
            ((minoY1 > minoY2 && minoY1 < maxoY2) && (maxoY1 > minoY2 && maxoY1 < maxoY2))) ||
           (((minoX2 > minoX1 && minoX2 < maxoX1) && (maxoX2 > minoX1 && maxoX2 < maxoX1)) &&
            ((minoY2 > minoY1 && minoY2 < maxoY1) && (maxoY2 > minoY1 && maxoY2 < maxoY1))) && intersection(f1, f2) == false)
        { return true; }
        return false;
    }

    public static bool isSquare(FourPoint f)
    {
        if (distance(f.A, f.B) == distance(f.B, f.C) && (distance(f.C, f.D) == distance(f.D, f.A)) &&
            (distance(f.B, f.C) == distance(f.D, f.C))
            && convert_degrees(angle_two_point(vector(f.A, f.B), vector(f.A, f.D))) == 90
            && convert_degrees(angle_two_point(vector(f.C, f.D), vector(f.A, f.D))) == 90)
        { return true; }
        return false;
    }

    public static bool isParallelogram(FourPoint f)
    {
        if (distance(f.A, f.B) == distance(f.D, f.C) && distance(f.B, f.C) == distance(f.A, f.D) &&
            distance(f.A, f.B) != distance(f.A, f.D) )
        {
            Point ab = vector(f.A, f.B);
            Point cd = vector(f.D, f.C);
            if (ab.oY * cd.oZ - ab.oZ * cd.oY == 0 && ab.oZ * cd.oX - ab.oX * cd.oZ == 0 && ab.oX * cd.oY - ab.oY * cd.oX == 0)
            { return true; }
            return false;
        }
        return false;
    }

    public static bool isRomb(FourPoint f)
    {
        if (distance(f.A, f.B) == distance(f.B, f.C) && (distance(f.C, f.D) == distance(f.D, f.A)) && (distance(f.B, f.C) == distance(f.D, f.C)))
        {
            Point ab = vector(f.A, f.B);
            Point cd = vector(f.D, f.C);
            if (ab.oY * cd.oZ - ab.oZ * cd.oY == 0 && ab.oZ * cd.oX - ab.oX * cd.oZ == 0 && ab.oX * cd.oY - ab.oY * cd.oX == 0)
            { return true; }
            return false;
        }
        return false;
    }
    public static bool isRectangle(FourPoint f)
    {
        if (distance(f.A, f.B) == distance(f.D,f.C) && distance(f.B, f.C) == distance(f.A, f.D) &&
            distance(f.A,f.B) != distance(f.A,f.D) &&
            convert_degrees(angle_two_point(vector(f.A, f.B), vector(f.A, f.D))) == 90 &&
            convert_degrees(angle_two_point(vector(f.C, f.D), vector(f.A, f.D))) == 90)
        { return true; }
        return false;
    }

    public static bool isTrapeze(FourPoint f)
    {
        Point ab = vector(f.A, f.B);
        Point cd = vector(f.D, f.C);
        Point bc = vector(f.B, f.C);
        Point ad = vector(f.A, f.D);

        if (ab.oY * cd.oZ - ab.oZ * cd.oY == 0 && ab.oZ * cd.oX - ab.oX * cd.oZ == 0 &&
            ab.oX * cd.oY - ab.oY * cd.oX == 0)
        {
            if (bc.oY * ad.oZ - bc.oZ * ad.oY != 0 || bc.oZ * ad.oX - bc.oX * ad.oZ != 0 ||
                bc.oX * ad.oY - bc.oY * ad.oX != 0)
            { return true; }
            return false;
        }
        else
        {
            if (bc.oY * ad.oZ - bc.oZ * ad.oY == 0 && bc.oZ * ad.oX - bc.oX * ad.oZ == 0 && bc.oX * ad.oY - bc.oY * ad.oX == 0)
            {
                if (ab.oY * cd.oZ - ab.oZ * cd.oY != 0 || ab.oZ * cd.oX - ab.oX * cd.oZ != 0 || ab.oX * cd.oY - ab.oY * cd.oX != 0)
                { return true; }
                return false;
            }
        }
        return false;
    }
}