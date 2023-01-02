namespace practika_matr;

public class ReverseMatrix : SquareMatrix
{
    
        public ReverseMatrix(int n = 0, bool Zero = false)
        {
            this.n = n;
            this.m = n;

            double[,] matr = new double[n, n];

            Random r = new Random();
            Random d = new Random();

            if (Zero)
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
                        matr[i, j] = Convert.ToInt64(d.NextDouble() * 10000) / 100.0;
                    }
                }
            }

            if (SquareMatrix.determinant(matr,n) == 0)
            {
                matr = SquareMatrix.lines(matr, n);
            }

            this.matr = matr;
        }

        public static double getMinor(double[,] A, int size, int row_curr, int col_curr)
        {
            double[,] matrTemp = new double[size-1, size-1];
            double minor = 0;


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == row_curr || j == col_curr)
                    {
                        continue;
                    }

                    else if (i < row_curr && j < col_curr)
                    {
                        matrTemp[i, j] = A[i, j];
                    }

                    else if (i > row_curr && j > col_curr)
                    {
                        matrTemp[i-1, j-1] = A[i, j];
                    }

                    else if (i > row_curr && j < col_curr)
                    {
                        matrTemp[i-1,j] = A[i, j];
                    }

                    else if (i < row_curr && j > col_curr)
                    {
                        matrTemp[i, j - 1] = A[i, j];
                    }
                }
            }
            minor = SquareMatrix.determinant(matrTemp, size - 1);
            return (Math.Pow(-1, row_curr + col_curr) * minor);

        }

        public static ReverseMatrix Inverse(ReverseMatrix A)
        {

            ReverseMatrix buf = new ReverseMatrix(A.n);

            MatrixCopy(A.matr, buf.matr, A.n, A.n);

            double determinante = SquareMatrix.determinant(buf);
            double[,] attachedMatr = new double[buf.n, buf.n];

            for (int i = 0; i < buf.n; i++)
            {
                for (int j = 0; j < buf.n; j++)
                {
                    attachedMatr[i, j] = getMinor(buf.matr, buf.n, i, j);
                }
            }

            MatrixCopy(attachedMatr, buf.matr, buf.n, buf.n);

            buf.matr = matrix_transposition(buf).matr;
            double coef = 1 / determinante;
            Console.WriteLine();
            buf.matr = Matrix.multiplication_by_a_constant(buf.matr, A.n, A.n, coef);

            return buf;
        }

        public static ReverseMatrix CheckInverse(ReverseMatrix A, ReverseMatrix AInverse)
        {
            ReverseMatrix Result = new ReverseMatrix(A.n);
            Result.matr = matrix_multiplication(A, AInverse).matr;

            return Result;

        }
}