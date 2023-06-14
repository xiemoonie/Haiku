using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomHaikuGenerator
{
    public class Delegates
    {
        public static void someDelegateAction()
        {
            Action<int, int> sumNumbers = new Action<int, int>(sum);
            sumNumbers(3, 4);



        }
        public static void sum(int n, int m)
        {
            Console.WriteLine("" + (n + m));

        }
        public static void someDelegateFunc()
        {
            Func<int, int, bool> findGreater = new Func<int, int, bool>(IsGreater);
            Console.WriteLine("" + findGreater(5, 3));


        }

        public static bool IsGreater(int n, int m)
        {
            if (n > m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void arrowFunction()
        {
            int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
           
            foreach (int n in numbers.Where(x =>
            {
                if (x % 2 == 0)
                    return true;
                return false;
            }))
            {
                Console.WriteLine(n);
            }
        }

        public void secondArrowFunction()
        {
            List<string> names = new List<string> { "lucas", "juan", "pedro" };
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var division = numbers.Select(x => x / 2);

            foreach (int d in division)
            {
                Console.WriteLine("" + d);
            }

        }

        public class Student
        {
            public string name { set; get; }
            public string subject { set; get; }

        }

        public class StudentCreator
        {
            List<Student> students = new List<Student>()
            {
               new Student{name = "Carlos", subject = "Math"},
               new Student{name = "Pepe", subject = "Logic"},
               new Student{name = "Anna", subject = "Math"},
               new Student{name = "Zack", subject = "Biology"}
            };

            public void orderStudents()
            {
                var orderStudent = students.OrderBy(x => x.subject);
                foreach (Student s in orderStudent)
                {
                    Console.WriteLine("" +s.name);
                }

                var b = () => Console.WriteLine("hello cuchik");
                b();

            }


            public IEnumerator Enumerate(IEnumerable enumerable)
            {
                // List implements IEnumerable, but could be any collection.
                List<string> list = new List<string>();

                foreach (string value in enumerable)
                {
                    list.Add(value + "xxx");
                }
                return list.GetEnumerator();
            }

            public class RunForTrap
            {
                List<Student> studentList = new List<Student>() {
                new Student{name = "sofi", subject = "math" },
                new Student{name = "carlos", subject = "literature"}
                };


                List<Action> act = new List<Action>();

                public void useAction()
                {
                    Student[] pr = studentList.ToArray();
                    for (int i = 0; i <= pr.Length; i++)
                    {
                        var val = i;
                        act.Add(() => Console.WriteLine($"Hey The Value is {val}"));

                    }
                    foreach (Action a in act)
                    {
                        a();
                    }     
                }
                
            }
        }
      


    }
}
