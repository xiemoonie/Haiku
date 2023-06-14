using NUnit.Framework;
using RandomHaikuGenerator;
using System.Threading.Tasks;

namespace TestingTurorial
{
    public class Tests
    {
        [TestCase("")]
        public void TestMenuCreationsError(string type)
        {
            MealType mm = new MealType(type);
            IMenu mT = MenuFactory.GetMenuFromMealType(mm);
            Assert.IsNull(mT);
        }

        [TestCase("Lunch")]
        public void TestMenuLunch(string type)
        {
            MealType mm = new MealType(type);
            IMenu mT = MenuFactory.GetMenuFromMealType(mm);
            Assert.AreEqual("lunch", mT.GetMenuName());
        }

        [TestCase("Dinner")]
        public void TestMenuDinner(string type)
        {
            MealType mm = new MealType(type);
            IMenu mT = MenuFactory.GetMenuFromMealType(mm);
            Assert.AreEqual("dinner", mT.GetMenuName());

        }
        [TestCase("Breakfast")]
        public void TestMenuBreakfast(string type)
        {
            MealType mm = new MealType(type);
            IMenu mT = MenuFactory.GetMenuFromMealType(mm);
            Assert.AreEqual("breakfast", mT.GetMenuName());
        }

        [TestCase("Breakfast")]
        [TestCase("Lunch")]
        [TestCase("Dinner")]
        public void TestMenuTypeName(string type)
        {
            MealType mm = new MealType(type);
            string s = mm.GetFoodName();
            if (mm.GetFoodName() == "breakfast" || mm.GetFoodName() == "lunch" || mm.GetFoodName() == "dinner")
            {
                Assert.IsNotEmpty(s);
            }


        }
        [TestCase("")]
        public void TestMenuTypeEmptyName(string type)
        {
            MealType mm = new MealType(type);
            string s = mm.GetFoodName();
            Assert.IsEmpty(s);
        }

        [Test]
        public void ReturnValueBreakfast()
        {
            BreakfastMenu b = new BreakfastMenu();
            int n = b.CreateOrder();
            Assert.AreEqual(3, n);
        }
        [Test]
        public void ReturnValueLunch()
        {
            LunchMenu b = new LunchMenu();
            int n = b.CreateOrder();
            Assert.AreEqual(1, n);
        }
        [Test]
        public void ReturnValueDinner()
        {
            DinnerMenu b = new DinnerMenu();
            int n = b.CreateOrder();
            Assert.AreEqual(2, n);
        }

        [TestCase("Honda")]
        [TestCase("Audi")]
        public void ReturnTypeVehicle(string type)
        {
            Factory f = new Factory();
            ICar c = f.FactoryMethod(type);
            Assert.IsNotNull(c);
        
        }

        [TestCase("")]
        public void ReturnTypeVehicleNull(string type)
        {
            Factory f = new Factory();
            ICar c = f.FactoryMethod(type);
            Assert.IsNull(c);
            
        }

        [Test]
        public async Task GetTransactions_populates_Transactions_property()
        {
            //Arrange
            var transactionViewModel = new WalletTransaction(new StubWallet());
            //Act
            await transactionViewModel.GetTransactions();
            //Assert
            //Console.WriteLine($"{transactionViewModel.Transactions.Count}");
            Assert.AreEqual(3, transactionViewModel.Transactions.Count);
            
        }

        [Test]
        public async Task GetTransactions_Transactions_NotEmpty()
        {
            bool c= true;
            //Arrange
            var transactionViewModel = new WalletTransaction(new StubWallet());
            //Act
            await transactionViewModel.GetTransactions();
            //Assert
            foreach (var t in transactionViewModel.Transactions )
            {
                if(t.Id == 0 || t.Amount == 0 || t.Symbol == "")
                {
                  c = false;
                }
            }
            Assert.IsTrue(c);
        }
        [Test]
        public void Notification_SendMail()
        {
            var sender = new EmailSenderMock();
            var notifier = new EmailSender(sender);
            notifier.NotifyItWasSent("2334","iutt");
            Assert.IsTrue(sender.mailSent);
        }

        [Test]
        public void Notification_SendMail_Empty()
        {
            var sender = new EmailSenderMock();
            var notifier = new EmailSender(sender);
            notifier.NotifyItWasSent("2334", "iutt");
            bool r = false;
         
                if (IsNullOrEmptyOrAllSpaces(sender.subject) || IsNullOrEmptyOrAllSpaces(sender.body) || IsNullOrEmptyOrAllSpaces(sender.toAdress))
                {
                    r = true;
                }
           
            Assert.IsFalse(r);
            }

        private bool IsNullOrEmptyOrAllSpaces(string str)
        {
            bool b = false;
            if (string.IsNullOrWhiteSpace(str))
            {
               b = true;
            }
            return b;
            
        }

        [Test]
        public void Notification_FoodRequested()
        {
            var request = new FoodMock();
            var result = new Food(request);
            result.requestPage();
            Assert.IsTrue(request.foodRequested);
        }

    

    }
}