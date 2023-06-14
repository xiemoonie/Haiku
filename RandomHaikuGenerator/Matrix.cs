using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomHaikuGenerator
{

    public class Matrix
    {
        int[,] students = { { 1, 4, 2 }, { 2, 5, 1 } };
        int[,] gradeStudents = { { 3, 4, 2 }, { 3, 5, 7 }, { 1, 2, 1 } };

        public void multiplyMatrix()
        {
            int[,] results = new int[2, 3];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    results[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        results[i, j] += students[i, k] * gradeStudents[k, j];
                    }
                }
            }


            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("result matrix" + results[i, j]);
                }

            }

        }

        public void AddToMatrix(int[,] matrix)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] += 2;
                    Console.WriteLine("addition" + matrix[i, j]);
                }
            }


        }

        public void Add(int m)
        {
            m = m + 2;
         }


        }
    


}