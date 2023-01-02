namespace practika_point;

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

    public void show_Point(Point z)
    {
        Console.WriteLine("({0}, {1}, {2})", z.oX, z.oY, z.oZ);
    }

    public void distance_between_points(Point z1, Point z2)
    {
        Console.WriteLine("{0}", 
            Math.Sqrt(Math.Pow((z2.oX - z1.oX), 2) + Math.Pow((z2.oY - z1.oY), 2) + Math.Pow((z2.oZ - z1.oZ), 2)));
    }

    public void equation_of_line_two_point(Point z1, Point z2)
    {
        Console.WriteLine("x-{0}/{1} = y-{2}/{3} = z-{4}/{5}", 
            z1.oX, z2.oX - z1.oX, z1.oY, z2.oY - z1.oY, z1.oZ, z2.oZ - z1.oZ);
    }

    public void equation_of_line_three_point(Point z1, Point z2, Point z3)
    {
        Console.WriteLine("{1}*x+{3}*y+{5}*z+((-1)*({0}*{1}+{2}*{3}+{4}*{5}))=0", 
            z1.oX, (z2.oY - z1.oY) * (z3.oZ - z1.oZ) - (z2.oZ - z1.oZ) * (z3.oY - z1.oY),
            z1.oY, (-1) * (z2.oX - z1.oX) * (z3.oZ - z1.oZ) - (z2.oZ - z1.oZ) * (z3.oX - z1.oX),
            z1.oZ, (z2.oX - z1.oX) * (z2.oY - z1.oY) - (z3.oZ - z1.oZ) * (z3.oX - z1.oX));
    }

    public void distance_from_point_to_origin(Point z1)
    {
        Console.WriteLine("{0}", 
            Math.Sqrt(Math.Pow((z1.oX), 2) + Math.Pow((z1.oY), 2) + Math.Pow((z1.oZ), 2)));
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

   
}