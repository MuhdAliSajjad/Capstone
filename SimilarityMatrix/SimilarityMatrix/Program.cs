using System;
using System.Linq;

class SimilarityMatrix
{
    static void Main()
    {
        // Example data
        double[,] data = { 
            { 3, 4, 3 },
            { 2, 3, 4 },
            { 3, 4, 5 },
            { 1, 2, 3 }
        };

        // Calculate the similarity matrix
        double[,] similarityMatrix = CalculateSimilarityMatrix(data);

        // Print the similarity matrix
        for (int i = 0; i < similarityMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < similarityMatrix.GetLength(1);  j++)
            {
                Console.Write(similarityMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static double[,] CalculateSimilarityMatrix(double[,] data)
    {
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);

        double[] rowMagnitudes = new double[rows];
        for (int i = 0; i < rows; i++)
        {
            double sum = 0;
            for (int j = 0; j < cols; j++)
            {
                sum += data[i, j] * data[i, j];
            }
            rowMagnitudes[i] = Math.Sqrt(sum);
        }

        double[,] similarityMatrix = new double[rows, rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                double dotProduct = 0;
                for (int k = 0; k < cols; k++)
                {
                    dotProduct += data[i, k] * data[j, k];
                }
                similarityMatrix[i, j] = dotProduct / (rowMagnitudes[i] * rowMagnitudes[j]);
            }
        }
        return similarityMatrix;
    }
}
