namespace practika_FourPoint;

public class Point
{
    private double ox;
    private double oy;
    private double oz;

    public double oX { get => ox; set { ox = value; } }
    public double oY { get => oy; set { oy = value; } }
    public double oZ { get => oz; set { oz = value; } }

    public Point()
    {
        this.ox = 0;
        this.oy = 0;
        this.oz = 0;
    }
    public Point(double oX, double oY, double oZ)
    {
        this.ox = oX;
        this.oy = oY;
        this.oz = oZ;
    }

    public static Point operator+(Point A, Point B)
    {
        return new(A.ox + B.ox, A.oy + B.oy, A.oz + B.oz);
    }
    
    public static Point operator-(Point A, Point B)
    {
        return new(A.ox - B.ox, A.oy - B.oy, A.oz - B.oz);
    }

    public static double operator *(Point A, Point B)
    {
        return A.ox * B.ox + A.oy * B.oy + A.oz * B.oz;
    }

    public static bool operator/(Point A, Point B)
    {
        return A.ox / B.ox >= 0 && A.oy / B.oy >= 0;
    }

    public void showPoint(Point z)
    {
        Console.WriteLine("({0},{1},{2})", z.oX, z.oY, z.oZ);
    }
    
    public static double distance(Point z1, Point z2)
    {
        return Math.Sqrt(Math.Pow((z2.oX - z1.oX), 2) + Math.Pow((z2.oY - z1.oY), 2) + Math.Pow((z2.oZ - z1.oZ), 2));
    }
    
    public void distance_from_point_to_origin(Point z1)
    {
        Console.WriteLine("Расстояние между z1 и (0,0,0) = {0}", 
            Math.Sqrt(Math.Pow((z1.oX), 2) + Math.Pow((z1.oY), 2) + Math.Pow((z1.oZ), 2)));
    }

    public void equation_of_line_two_point(Point z1, Point z2)
    {
        Console.WriteLine("x-{0}/{1} = y-{2}/{3} = z-{4}/{5}", 
            z1.oX, z2.oX - z1.oX, z1.oY, z2.oY - z1.oY, z1.oZ, z2.oZ - z1.oZ);
    }
    
    public static double convert_radians(int x)
    {
        return (x * Math.PI) / 180;
    }

    public static double convert_degrees(double x)
    {
        return (x * 180) / Math.PI;
    }

    public static double[] nonconvex_coef(Point A, Point B)
    {
        double[] res = new double[3];
        res[0] = B.oy - A.oy;
        res[1] = (B.ox - A.ox) * (-1);
        res[2] = A.oy * B.ox - B.oy * A.ox;
        return res;
    }

    public static bool intersection_one_in_two(double[] l1, double[] l2)
    {
        if (l1[0] / l2[0] == l1[1] / l2[1]) { return false; }
        if (l1[0] * l2[1] - l2[0] * l1[1] == 0 && l2[2] * l1[1] - l1[2] * l2[1] == 0) { return false; }
        return true;
    }

    public static double intersection(double[] l1, double[] l2)
    { 
        double resoX = (l1[2]*l2[1] - l2[2]*l1[1]) / (l2[0]*l1[1] - l1[0]*l2[1]);
        return resoX;
    }

    public static bool intersection_parts(Point A1, Point A2, Point B1, Point B2)
    {
        double[] l1 = nonconvex_coef(A1, A2);
        double[] l2 = nonconvex_coef(B1, B2);
        if (intersection_one_in_two(l1, l2) == true)
        {
            double intoX = intersection(l1, l2);
            if (((intoX < A2.ox && intoX > A1.ox) || (intoX < A1.ox && intoX > A2.ox)) &&
                ((intoX < B2.ox && intoX > B1.ox) || (intoX < B1.ox && intoX > B2.ox)))
            {
                return true;
            }
            return false;
        }
        return false;
    }

    public static void plot(Point z1, Point z2, Point z3)
    {
        Console.WriteLine("{1}*x+{3}*y+{5}*z+((-1)*({0}*{1}+{2}*{3}+{4}*{5}))=0", 
            z1.oX, (z2.oY - z1.oY) * (z3.oZ - z1.oZ) - (z2.oZ - z1.oZ) * (z3.oY - z1.oY),
            z1.oY, (-1) * (z2.oX - z1.oX) * (z3.oZ - z1.oZ) - (z2.oZ - z1.oZ) * (z3.oX - z1.oX),
            z1.oZ, (z2.oX - z1.oX) * (z2.oY - z1.oY) - (z3.oZ - z1.oZ) * (z3.oX - z1.oX));
    }
    
    public Point addition_vectors(Point z1, Point z2)
    {
        Point z3 = new Point();
        z3.oX = z1.oX + z2.oX;
        z3.oY = z1.oY + z2.oY;
        z3.oZ = z1.oZ + z2.oZ;
        return z3;
    }
    
    public double scalar_product(Point z1, Point z2)
    {
        return z1.oX * z2.oX + z1.oY * z2.oY + z1.oZ * z2.oZ;
    }

    public void vector_product(Point z1, Point z2)
    {
        Console.WriteLine("z1 x z2 = {0}*i - {1}*j + {2}*k", 
            z1.oY * z2.oZ - z2.oY * z1.oZ,
            z1.oY * z2.oZ - z2.oX * z1.oZ,
            z1.oX * z2.oY - z2.oX * z1.oY); 
    }
    
    public static Point vector(Point A, Point B)
    {
        Point vec = new Point();
        vec.oX = B.oX - A.oX;
        vec.oY = B.oY - A.oY;
        vec.oZ = B.oZ - A.oZ;
        return vec;
    }

    public static double angle_two_point(Point A, Point B)
    {
        double a = A.ox * B.ox + A.oy * B.oy + A.oz * B.oz;
        double b = Math.Sqrt(Math.Pow(A.ox, 2) + Math.Pow(A.oy, 2) + Math.Pow(A.oz, 2)) * Math.Sqrt(Math.Pow(B.ox, 2) 
            + Math.Pow(B.oy, 2) + Math.Pow(B.oz, 2));
        return Math.Acos(a / b);
    }

    public static double vectorM(Point A, Point B)
    {
        return A.ox * B.oy - B.ox * A.oy;
    }
    
    public static bool equation_four_point(Point A, Point B, Point C, Point D)
    {
        return ((D.ox - A.ox) * ((B.oy - A.oy) * (C.oz - A.oz) - (C.oy - A.oy) * (B.oz - A.oz))
            - (D.oy - A.oy) * ((B.ox - A.ox) * (C.oz - A.oz) - (B.oz - A.oz) * (C.ox - A.ox))
            + (D.oz - A.oz) * ((B.ox - A.ox) * (C.oy - A.oy) - (B.oy - A.oy) * (C.ox - A.ox)) == 0);
    }
}