using RandomHaikuGenerator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static RandomHaikuGenerator.Delegates;
using static RandomHaikuGenerator.Delegates.StudentCreator;

namespace RandomHaikuGenerator
{
    internal class Program
    {
        public async void TransactionViewModelTests()
        {
            //Arrange
            var transactionViewModel = new WalletTransaction(new StubWallet());
            //Act
            await transactionViewModel.GetTransactions();
            //Assert
            Console.WriteLine($"{transactionViewModel.Transactions.Count}");
        }

        static void Main(string[] args)
        {
            //Prototype Design
            StudentManager studentManager = new StudentManager();
            studentManager["Rickon"] = new Student(13, "13A", "Stark");
            studentManager["Joyffrey"] = new Student(13, "13A", "Lannister");
            studentManager["Walder"] = new Student(13, "13A", "Frey");
            studentManager["Arya"] = new Student(13, "13A", "Stark");
            var newStark = studentManager["Rickon"].Clone();
            var newStark2 = studentManager["Rickon"].Clone();
            var newLanniester = studentManager["Joyffrey"].Clone();

            MealType mm = new MealType("Lunch");
            MenuFactory.GetMenuFromMealType(mm);


            BlogPost p = new BlogPost();


            Computer n = new Computer();
            n.PressPowerButton();
            n.PressPowerButton();
            n.PressPowerButton();


            var blogPostBuilder = new BlogFluent();

            var blogPost = blogPostBuilder
                .WithTitle("My First Blog Post")
                .WithContent("This is my first blog post")
                .WithAuthor("John Doe")
                .WithDate(DateTime.Now)
                .WithCategories(new List<string>() { "blog", "software" })
                .WithTags(new List<string>() { "blog", "software" })
                .WithMetaDescription("This is my first blog post")
                .WithMetaTitle("Read why my first blog post is super important")
                .Build();

            Console.WriteLine($"{blogPost.Author},{blogPost.Date},{blogPost.Title},{blogPost.Content},{blogPost.MetadataTitle}");

            Program pa = new Program();
            pa.TransactionViewModelTests();


            Delegates.someDelegateAction();
            Delegates.someDelegateFunc();
            Delegates d = new Delegates();
            d.arrowFunction();
            Console.WriteLine("Second!!!");
            d.secondArrowFunction();


            StudentCreator s = new StudentCreator();
            Console.WriteLine("Students!!!");
            s.orderStudents();
            Console.WriteLine("Enumerator!!!");
            List<string> listToEnumerate= new List<string>() {"Hello", "My","Cool", "Friend", "Hello"};
            IEnumerator coolList = s.Enumerate(listToEnumerate);

            while(coolList.MoveNext())
            {
                string nsw = (string)coolList.Current;
                listToEnumerate.Add(coolList.Current.ToString());

            }
            var showOff = listToEnumerate.Where(x => x == "Helloxxx");
            foreach (string ns in showOff)
            {
                Console.WriteLine("HELLO FOUNT" +ns);
            }

            RunForTrap r = new RunForTrap();
            r.useAction();


            Weather w = new Weather();
            w.requestWeatherAsync();

            MockTimer mt = new MockTimer();
            TimerCook tc = new TimerCook(mt);
            tc.TimeToCookMock(mt);
            mt.Tick();
            mt.Tick();
            mt.Tick();



            Temperature temp = new Temperature();
            temp.writesSentence();
            temp.writesHaxadecimal();
            temp.showTemp();


            Matrix m = new Matrix();
            m.multiplyMatrix();
            Console.ReadKey();
        }

        public interface IStudentPrototype
        {
            IStudentPrototype Clone();
        }
        public class Student : IStudentPrototype
        {
            public Student(int age, string classroom, string housegroup)
            {
                this.Age = age;
                this.Classroom = classroom;
                this.HouseGroup = housegroup;
            }
            public int Age { get; set; }
            public string Classroom { get; set; }
            public string HouseGroup { get; set; }

            public IStudentPrototype Clone()
            {
                Console.WriteLine($"Closing Alpha Student of the House{HouseGroup}. " + $"Beloging to Classroom {Classroom}. {Age} years of age.");
                return (IStudentPrototype)this.MemberwiseClone();
            }
        }
        public class StudentManager
        {
            private Dictionary<string, IStudentPrototype> students = new Dictionary<string, IStudentPrototype>();
            public IStudentPrototype this[string key]
            {
                get { return students[key]; }
                set { students.Add(key, value); }
            }

        }

    }
}