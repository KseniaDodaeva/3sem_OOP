using practika_FourPoint;

Point A = new Point(0,0,0);
Point B = new Point(3, -1, 0);
Point C = new Point(3, 2, 0);
Point D = new Point(0, 2, 0);

FourPoint f = new FourPoint(A, B, C, D);

Console.WriteLine("Площадь: {0}", FourPoint.square(f));
Console.WriteLine("Периметр: {0}", FourPoint.perimeter(f));
Console.WriteLine("Длины диагоналей: {0}, {1}", FourPoint.diagonal_length(f)[0], FourPoint.diagonal_length(f)[1]);
Console.WriteLine(String.Concat("Данный четырехугольник ", (FourPoint.convexity(f) == true) ? "выпуклый" : "невыпуклый"));
Console.WriteLine(String.Concat("Данный четырехугольник ", (FourPoint.isSquare(f) == true) ? "квадрат" : "не квадрат"));
Console.WriteLine(String.Concat("Данный четырехугольник ", (FourPoint.isRectangle(f) == true) ? "треугольник" : "не треугольник"));
Console.WriteLine(String.Concat("Данный четырехугольник ", (FourPoint.isParallelogram(f) == true) ? "параллелограмм" : "не параллелограмм"));
Console.WriteLine(String.Concat("Данный четырехугольник ", (FourPoint.isRomb(f) == true) ? "ромб" : "не ромб"));
Console.WriteLine(String.Concat("Данный четырехугольник ", (FourPoint.isTrapeze(f) == true) ? "трапеция" : "не трапеция"));

Point A1 = new Point(2,4,0);
Point B1 = new Point(4,6,0);
Point C1 = new Point(8,6,0);
Point D1 = new Point(8,2,0);
/*Point A2 = new Point(3, 4, 0); 
Point B2 = new Point(4, 5, 0);
Point C2 = new Point(7, 5, 0);
Point D2 = new Point(7, 3, 0);*/

Point A2 = new Point(2,-3,0);
Point B2 = new Point(4,1,0);
Point C2 = new Point(7,3,0); 
Point D2 = new Point(7,-2,0);

FourPoint f1 = new FourPoint(A1, B1, C1, D1);
FourPoint f2 = new FourPoint(A2, B2, C2, D2);

Console.WriteLine(String.Concat("Четырехугольники ", (FourPoint.intersection(f1, f2)) ? "пересекаются" : "не пересекаются"));
Console.WriteLine(String.Concat("Четырехугольник ", (FourPoint.one_inside_the_other(f1, f2) == true) ? "лежит внутри другого" : "не лежит внутри другого"));
