using System;

class MatrixOperations
{
    // Create random matrix
    public static int[,] CreateMatrix(int rows, int cols)
    {
        Random rand = new Random();
        int[,] mat = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                mat[i, j] = rand.Next(1, 10);
        return mat;
    }

    // Display matrix
    public static void DisplayMatrix(int[,] mat)
    {
        int rows = mat.GetLength(0);
        int cols = mat.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(mat[i, j] + "\t");
            Console.WriteLine();
        }
    }

    // Addition
    public static int[,] AddMatrices(int[,] a, int[,] b)
    {
        int rows = a.GetLength(0), cols = a.GetLength(1);
        int[,] sum = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                sum[i, j] = a[i, j] + b[i, j];
        return sum;
    }

    // Subtraction
    public static int[,] SubtractMatrices(int[,] a, int[,] b)
    {
        int rows = a.GetLength(0), cols = a.GetLength(1);
        int[,] diff = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                diff[i, j] = a[i, j] - b[i, j];
        return diff;
    }

    // Multiplication
    public static int[,] MultiplyMatrices(int[,] a, int[,] b)
    {
        int r1 = a.GetLength(0), c1 = a.GetLength(1);
        int r2 = b.GetLength(0), c2 = b.GetLength(1);
        if (c1 != r2) throw new Exception("Cannot multiply matrices.");

        int[,] product = new int[r1, c2];
        for (int i = 0; i < r1; i++)
            for (int j = 0; j < c2; j++)
                for (int k = 0; k < c1; k++)
                    product[i, j] += a[i, k] * b[k, j];
        return product;
    }

    // Transpose
    public static int[,] Transpose(int[,] mat)
    {
        int rows = mat.GetLength(0), cols = mat.GetLength(1);
        int[,] trans = new int[cols, rows];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                trans[j, i] = mat[i, j];
        return trans;
    }

    // Determinant of 2x2
    public static int Determinant2x2(int[,] mat)
    {
        return mat[0,0]*mat[1,1] - mat[0,1]*mat[1,0];
    }

    // Determinant of 3x3
    public static int Determinant3x3(int[,] m)
    {
        return m[0,0]*(m[1,1]*m[2,2]-m[1,2]*m[2,1])
             - m[0,1]*(m[1,0]*m[2,2]-m[1,2]*m[2,0])
             + m[0,2]*(m[1,0]*m[2,1]-m[1,1]*m[2,0]);
    }

    // Inverse of 2x2
    public static double[,] Inverse2x2(int[,] m)
    {
        double det = Determinant2x2(m);
        if (det == 0) throw new Exception("No inverse exists.");
        double[,] inv = new double[2,2];
        inv[0,0] = m[1,1]/det;
        inv[0,1] = -m[0,1]/det;
        inv[1,0] = -m[1,0]/det;
        inv[1,1] = m[0,0]/det;
        return inv;
    }

    static void Main(string[] args)
    {
        int[,] mat1 = CreateMatrix(2,2);
        int[,] mat2 = CreateMatrix(2,2);

        Console.WriteLine("Matrix 1:");
        DisplayMatrix(mat1);
        Console.WriteLine("Matrix 2:");
        DisplayMatrix(mat2);

        Console.WriteLine("Sum:");
        DisplayMatrix(AddMatrices(mat1, mat2));

        Console.WriteLine("Difference:");
        DisplayMatrix(SubtractMatrices(mat1, mat2));

        Console.WriteLine("Product:");
        DisplayMatrix(MultiplyMatrices(mat1, mat2));

        Console.WriteLine("Transpose of Matrix 1:");
        DisplayMatrix(Transpose(mat1));

        Console.WriteLine($"Determinant of Matrix 1 (2x2): {Determinant2x2(mat1)}");

        Console.WriteLine("Inverse of Matrix 1 (2x2):");
        double[,] inv = Inverse2x2(mat1);
        for (int i=0; i<2; i++)
        {
            for(int j=0; j<2; j++) Console.Write($"{inv[i,j]:F2}\t");
            Console.WriteLine();
        }
    }
}
