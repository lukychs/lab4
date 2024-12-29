using System.Linq.Expressions;

class MyMatrix
{
    private int n, m;
    private int[,] matrix;

    public MyMatrix(int n, int m, int a, int b)
    {
        this.n = n;
        this.m = m;
        matrix = new int[n, m];
        

        for (int i = 0;  i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Random rand = new Random();
                matrix[i, j] = rand.Next(a, b);
            }
        }
    }

    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || j < 0 || i >= n || j >= m)
            {
                throw new IndexOutOfRangeException();
            }


            else
            {
                return matrix[i, j];
            }
        }

        set
        {
            if (i < 0 || j < 0 || i >= n || j >= m)
            {
                throw new IndexOutOfRangeException();
            }

            else
            {
                matrix[i, j] = value;
            }
        }
    }

    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.n == matrix2.n && matrix1.m == matrix2.m) {
            MyMatrix matrix3 = new MyMatrix(matrix1.n, matrix1.m, 0, 0);
            
            for (int i = 0; i < matrix3.n; i++)
            {
                for (int j = 0; j < matrix3.m; j++)
                    matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
            }

            return matrix3;
        }

        else
        {
            throw new ArgumentException("Размеры матриц не равны");
        }
    }

    public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.n == matrix2.n && matrix1.m == matrix2.m)
        {
            MyMatrix matrix3 = new MyMatrix(matrix1.n, matrix1.m, 0, 0);

            for (int i = 0; i < matrix3.n; i++)
            {
                for (int j = 0; j < matrix3.m; j++)
                    matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
            }

            return matrix3;
        }

        else
        {
            throw new ArgumentException("Размеры матриц не равны");
        }
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.m == matrix2.n)
        {
            MyMatrix matrix3 = new MyMatrix(matrix1.n, matrix2.m, 0, 0);

            for (int i = 0; i < matrix3.n; i++)
            {
                for (int j = 0; j < matrix3.m; j++)
                {
                    for (int k = 0; k < matrix3.n; k++)
                        matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }

            return matrix3;
        }

        else
        {
            throw new ArgumentException("Количество столбцов в первой матрице не равно количеству строк во второй матрице");
        }
    }

    

    public static MyMatrix operator *(MyMatrix matrix, int c)
    {
        MyMatrix matrix1 = new MyMatrix(matrix.n, matrix.m, 0, 0);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
                matrix1[i, j] = matrix[i, j] * c;
        }

        return matrix1;
    }

    public static MyMatrix operator *(int c, MyMatrix matrix)
    {
        return matrix * c;
    }

    public static MyMatrix operator /(MyMatrix matrix, int c)
    {
        MyMatrix matrix1 = new MyMatrix(matrix.n, matrix.m, 0, 0);

        if (c != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                    matrix1[i, j] = matrix[i, j] / c;
            }

            return matrix1;
        }

        else
        {
            throw new DivideByZeroException();
        }
    }

    public void print(string message)
    {
        Console.WriteLine($"{message}:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        MyMatrix matrix1 = new MyMatrix(2, 2, 2, 5);
        MyMatrix matrix2 = new MyMatrix(2, 3, 1, 4);

        MyMatrix matrix3 = matrix1 * matrix2;
        MyMatrix matrix4 = matrix1 * 5;
        MyMatrix matrix5 = matrix2 / 2;

        matrix1.print("Матрица 1");
        matrix2.print("Матрица 2");
        matrix3.print("Произведение матрицы 1 на матрицу 2");
        matrix4.print("Умножение матрицы 1 на число 5");
        matrix5.print("Деление матрицы 2 на число 2");
    }
}