using System.Data;
using System.Diagnostics.SymbolStore;
using practika_matr;

int n = Convert.ToInt32(Console.ReadLine());
int m = Convert.ToInt32(Console.ReadLine());

Matrix a = new Matrix(n,m);
Matrix b = new Matrix(n,m);


int ind1 = Convert.ToInt32(Console.ReadLine()); //index for mult
int ind2 = Convert.ToInt32(Console.ReadLine());
Matrix c = new Matrix(ind1, ind2);

Console.WriteLine("Матрица А");
a.show();
Console.WriteLine("Матрица B");
b.show();
Console.WriteLine("Матрица C");
c.show();
Console.Write("\n");


Console.WriteLine("Сложение матриц А и В");
a = a + b;
a.show();
Console.Write("\n");

Console.WriteLine("Вычитание матриц A и B");
a = a - b;
a.show();
Console.Write("\n");

Console.WriteLine("Умножение матрицы A на константу");
double consta = 3;
a = a * consta;
a.show();
Console.Write("\n");

Console.WriteLine("Деление матрицы А на константу");
a = a / consta;
a.show();
Console.Write("\n");

Console.WriteLine("Умножение матриц А и C");
a = a * c;
a.show();
Console.Write("\n");

Console.WriteLine("Транспонирование матрицы С");
c = Matrix.matrix_transposition(c);
c.show();

SquareMatrix sa = new SquareMatrix(n);
SquareMatrix sb = new SquareMatrix(n);

Console.WriteLine("Квадратная матрица sa");
sa.show();
Console.Write("\n");

Console.WriteLine("Квадратная матрица sb");
sb.show();
Console.Write("\n");

Console.WriteLine("Определитель матрицы sa");
Console.WriteLine(SquareMatrix.determinant(sa));
Console.Write("\n");

Console.WriteLine("Удаление линейно-зависимых строк или столбцов - когда det = 0 в матрице sb");
SquareMatrix.lines(sb).show();
Console.Write("\n");

ReverseMatrix ia = new ReverseMatrix(n);
ReverseMatrix ib = new ReverseMatrix(n);

ia.matr[0,0] = 3;
ia.matr[0,1] = 4;
ia.matr[0,2] = 1;

ia.matr[1,0] = 7;
ia.matr[1,1] = 3;
ia.matr[1,2] = 7;

ia.matr[2,0] = 7;
ia.matr[2,1] = 8;
ia.matr[2,2] = 4;

Console.WriteLine("Квадратная обратимая матрица ia");
ia.show();
Console.Write("\n");

Console.WriteLine("Определитель ia");
Console.WriteLine(SquareMatrix.determinant(ia));
Console.Write("\n");

Console.WriteLine("Обратная матрица к ia");
ReverseMatrix iai = ReverseMatrix.Inverse(ia);
iai.show();
Console.Write("\n");
