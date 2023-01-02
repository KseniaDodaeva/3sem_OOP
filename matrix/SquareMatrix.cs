namespace practika_matr;

public class SquareMatrix : Matrix
{
    public SquareMatrix(int n = 0, bool zero = false)
    {
        this.n = n;
        this.m = n;
        double[,] matr = new double[n, n];
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

    /*public static double determinant(SquareMartix A)
    {
        SquareMartix buf = new SquareMartix(A.n);
        MatrixCopy(A.matr, buf.matr, A.n, A.n);
        if (A.n == 1)
        {
            return buf.matr[0, 0];
        }
        else if (A.n == 2)
        {
            return ((buf.matr[0, 0] * buf.matr[1, 1]) - (buf.matr[0, 1] * buf.matr[1, 0]));
        }
        else if (A.n == 3)
        {
            return ((buf.matr[0, 0] * buf.matr[1, 1] * buf.matr[2, 2]) + (buf.matr[0, 1] * buf.matr[1, 2] * buf.matr[2, 0]) + (buf.matr[0, 2] * buf.matr[1, 0] * buf.matr[2, 1]) -
                    (buf.matr[0, 2] * buf.matr[1, 1] * buf.matr[2, 0]) - (buf.matr[0, 0] * buf.matr[1, 2] * buf.matr[2, 1]) - (buf.matr[0, 1] * buf.matr[1, 0] * buf.matr[2, 2]));
        }
        else
        {
            double res = 1;
            for (int i = 0; i < A.n; i++)
            {
                res *= Math.Pow(-1, (i + 0));
            }
            return res;
        }
    }*/
    
    public static void rowSwap(SquareMatrix A, int r1, int r2)
    {
        double[] rowBuf = new double[A.n];
        for (int c = 0; c < A.n; c++)
        {
            rowBuf[c] = A.matr[r2, c];
            A.matr[r2, c] = A.matr[r1, c];
            A.matr[r1, c] = rowBuf[c];

        }
    }
    
    public static double determinant(SquareMatrix A)
    {
        int countOfSwap = 0;
        SquareMatrix buf = new SquareMatrix(A.n);
        MatrixCopy(A.matr, buf.matr, A.n, A.n);
        int row_step = 0; 
        for (int col = 0; col < buf.n - 1; col++) 
        {
            for (int row = row_step + 1; row < buf.n; row++)
            {
                if (buf.matr[row_step,col] == 0 && buf.matr[row, col] != 0)
                {
                    rowSwap(buf, row_step, row);
                    countOfSwap++;
                }
                double c = buf.matr[row, col] / buf.matr[row_step, col];

                for (int col_step = col; col_step < buf.n; col_step++)
                {
                    buf.matr[row, col_step] = buf.matr[row, col_step] - c * buf.matr[row_step, col_step];
                }
            }
            row_step++;
        }
        double res = 1;
        for (int i = 0; i < A.n; i++)
        {
            res *= buf.matr[i, i];
        }
        return res * Math.Pow(-1,countOfSwap);
    }
    
    public static double determinant(double[,] A, int n)
    {

        double[,] buf = new double[n, n];
        MatrixCopy(A, buf, n, n);
        int row_step = 0;
        for (int col = 0; col < n - 1; col++)
        {
            for (int row = row_step + 1; row < n; row++)
            {
                double x = buf[row, col] / buf[row_step, col];

                for (int col_step = col; col_step < n; col_step++)
                {
                    buf[row, col_step] = buf[row, col_step] - x * buf[row_step, col_step];
                }
            }
            row_step++;

        }
        double result = 1;
        for (int i = 0; i < n; i++)
        {
            result *= buf[i, i];
        }
        return result;
    }
    public static bool massZero(double[] mass)
    {
        int flag = 0;
        for (int i = 0; i < mass.Length; i++)
        {
                if (mass[i] != 0)
                {
                    flag = 1;
                    break;
                }
        }
            if (flag == 0) { return true; }
            else { return false; }
        }
    public static bool linearity(double[] mass1, double[] mass2)
        {
            int index_subtraction = 0;
            double coef_subtraction = 0;
            if (massZero(mass1) == true || massZero(mass2) == true)
            { /*Если присутствует хотя бы 1 нулевая строка, то две строки являются линейными*/ return true;}
            else
            { 
                for (int i = 0; i < mass1.Length; i++)
                {
                    if (mass1[i] != 0)
                    {
                        index_subtraction = i;
                    }
                }
                coef_subtraction = mass2[index_subtraction] / mass1[index_subtraction];
                int flag = 0;
                for (int index = 0; index < mass1.Length; index++)
                {
                    if (mass2[index] - mass1[index] * coef_subtraction != 0)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                { return true; }
                else { return false; }
            }
        }
        public static double[] createMass(SquareMatrix A, int row)
        {
            double[] mass = new double[A.n];
            for (int i = 0; i < A.n; i++)
            {
                mass[i] = A.matr[row,i];
            }
            return mass;
        }
        public static double[] createMass(double[,] A, int size, int row)
        {
            double[] mass = new double[size];
            for (int i = 0; i < size; i++)
            {
                mass[i] = A[row, i];
            }
            return mass;
        }
        
        public static SquareMatrix lines(SquareMatrix A)
        {
            double[] mass1 = createMass(A, 0);
            if (massZero(mass1) == true)
            {
                A.matr[0, 0] += 1;
            }
            double p = 2;
            for (int row = 0; row < A.n - 1; row++)
            {
                mass1 = createMass(A, row);
                for (int row_second = row + 1; row_second < A.n; row_second++)
                {
                    double[] mass2 = createMass(A, row_second);
                    if (linearity(mass1, mass2) == true)
                    {
                        A.matr[row_second, 0] = Math.Round(A.matr[row_second, 0] + p);
                        p += 1;
                    }
                }
            }
            return A;
        }
        
        public static double[,] lines(double[,] A, int size)
        {
            double[] mass1 = createMass(A, size, 0);
            if (massZero(mass1) == true)
            {
                A[0, 0] += 1;
            }
            double p = 2;
            for (int row = 0; row < size - 1; row++)
            {
                mass1 = createMass(A, size, row);
                for (int row_second = row + 1; row_second < size; row_second++)
                {
                    double[] mass2 = createMass(A, size, row_second);
                    if (linearity(mass1, mass2) == true)
                    {
                        A[row_second, 0] = Math.Round(A[row_second, 0] + p);
                        p += 1;
                    }
                }
            }
            return A;
        }
}