namespace practika_matr;

public class Matrix
{
    public int n;
    public int m;
    public double[,] matr;
    
    public Matrix()
    {
        this.n = 0;
        this.m = 0;
        this.matr = new double[0, 0];
    }
    
    public Matrix(string filename = "")
    {
        this.n = 0;
        this.m = 0;
        this.matr = new double[0, 0]; 
    }

    public Matrix(int n = 0, int m = 0, bool zero = false)
    {
        this.n = n;
        this.m = m;
        double[,] matr = new double[n, m];
        Random r = new Random();
        Random d = new Random();
        if (zero)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matr[i, j] = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matr[i, j] = Convert.ToDouble(Convert.ToInt64(d.NextDouble() * 10000)) / 100.0;
                }
            }
        }
        this.matr = matr;
    }

    public void show()
    {
        for (int i = 0; i < this.n; i++)
        {
            for (int j = 0; j < this.m; j++)
            {
                Console.Write("{0}\t", this.matr[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void show(Matrix A)
    {
        for (int i = 0; i < this.n; i++)
        {
            for (int j = 0; j < this.m; j++)
            {
                Console.Write("{0} ", this.matr[i, j]);
            }
            Console.WriteLine();
        }
    }

    public static Matrix addition_matrix(Matrix A, Matrix B)
    {
        Matrix res = new Matrix(A.n, A.m);
        for (int i = 0; i < A.n; i++)
        {
            for (int j = 0; j < A.m; j++)
            {
                res.matr[i, j] = A.matr[i, j] + B.matr[i, j];
            }
        }
        return res;
    }

    public static Matrix operator+(Matrix A, Matrix B)
    {
        return Matrix.addition_matrix(A, B);
    }
    public static Matrix subtraction_matrix(Matrix A, Matrix B)
    {
        Matrix res = new Matrix(A.n, A.m);
        for (int i = 0; i < A.n; i++)
        {
            for (int j = 0; j < A.m; j++)
            {
                res.matr[i, j] = A.matr[i, j] - B.matr[i, j];
            }
        }

        return res;
    }

    public static Matrix operator -(Matrix A, Matrix B)
    {
        return Matrix.subtraction_matrix(A, B);
    }
    public static Matrix multiplication_by_a_constant(Matrix A, double c)
    {
        Matrix res = new Matrix(A.n, A.m);
        for (int i = 0; i < A.n; i++)
        {
            for (int j = 0; j < A.m; j++)
            {
                res.matr[i, j] = A.matr[i, j] * c;
            }
        }
        return res;
    }

    public static double[,] multiplication_by_a_constant(double[,] A, int row, int col, double c)
    {
        double[,] res = new double[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                res[i, j] = A[i, j] * c;
            }
        }
        return res;
    }

    public static Matrix matrix_multiplication(Matrix A, Matrix B)
    {
        if (A.m != B.n)
        {
            Console.WriteLine("Проверьте размерность матриц!");
            Matrix res = new Matrix(A.n, A.m, true);
            return res;
        }
        else
        {
            Matrix res = new Matrix(A.n, B.m);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < B.m; j++)
                {
                    double buf = 0;

                    for (int r = 0; r < A.m; r++)
                    {
                        buf += A.matr[i, r] * B.matr[r, j];
                    }
                    res.matr[i, j] = buf;
                }
            }
            return res;
        }
    }

    public static Matrix operator*(Matrix A, Matrix B)
    {
        return Matrix.matrix_multiplication(A, B);
    }

    public static Matrix operator*(Matrix A, double c)
    {
        return Matrix.multiplication_by_a_constant(A, c);
    }
    
    public static Matrix division_by_constant(Matrix A, double c)
    {
        try
        {
            Matrix res = new Matrix(A.n, A.m);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    res.matr[i, j] = A.matr[i, j] / c;
                }
            }
            return res;
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Делить на ноль нельзя");
        }
        return null;
    }

    public static Matrix operator /(Matrix A, double c)
    {
        return Matrix.division_by_constant(A, c);
    }
    
    public static Matrix matrix_transposition(Matrix A)
    {
        Matrix transp = new Matrix(A.m, A.n);
        for (int i = 0; i < A.m; i++)
        {
            for (int j = 0; j < A.n; j++)
            {
                transp.matr[i, j] = A.matr[j, i];
            }
        }
        return transp;
    }

    public static double take_elem(Matrix A, int indexN, int indexM)
    {
        return A.matr[indexN, indexM];
    }
    
    public static void MatrixCopy(double[,] from, double[,] where, int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                where[i,j] = from[i,j];
            }
        }
    }
}