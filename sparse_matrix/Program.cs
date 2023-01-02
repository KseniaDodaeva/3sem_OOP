using System.Collections;
using practika_sparse_matrices;

Sparce_matrix<int> matr = new Sparce_matrix<int>(4, 5);

matr[2, 2] = 4;
matr[0, 2] = 5;
matr[0, 3] = 6;
matr[3, 4] = 7;
matr[1, 2] = 8;
matr[0, 0] = 9;

matr.show();
Console.WriteLine();
matr.sm(0, 4).show();