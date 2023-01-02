using practika_point;
Point point = new Point();

Point z1 = new Point(1, 4, 8);
Point z2 = new Point(5, 7, 9);
Point z3 = new Point(2,8, 4);
Point z4 = new Point();

Console.WriteLine("Расстояние между точками");
point.distance_between_points(z1, z2);

Console.WriteLine("Уравнение прямой по двум точкам");
point.equation_of_line_two_point(z1, z2);

Console.WriteLine("Уравнение прямой по трем точкам");
point.equation_of_line_three_point(z1, z2, z3);

Console.WriteLine("Расстояние от точки до начала координат");
point.distance_from_point_to_origin(z1);

Console.WriteLine("Сложение векторов");
z4 = point.addition_vectors(z1,z2);
point.show_Point(z4);

Console.WriteLine("Векторное произведение"); 
double vp = point.scalar_product(z1, z2);
Console.WriteLine(vp);

Console.WriteLine("Скалярное произведение векторов");
point.vector_product(z1,z2);