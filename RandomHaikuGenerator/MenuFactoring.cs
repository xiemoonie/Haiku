using System;
using System.Collections.Generic;
using System.Text;

namespace RandomHaikuGenerator
{
  
    public interface IMenu
    {
        string GetMenuName();
        int CreateOrder();
        int CreateInvoice();
    }

    public class BreakfastMenu : IMenu
    {
        public string GetMenuName()
        {
            return "breakfast";
        }

        public int CreateOrder()
        {
            return 3;
        }
        public int CreateInvoice()
        {
            return 3;
        }
    }
    public class LunchMenu : IMenu
    {
        public string GetMenuName()
        {
            return "lunch";
        }

        public int CreateOrder()
        {
            return 1;
        }
        public int CreateInvoice()
        {
            return 1;
        }
    }
    public class DinnerMenu : IMenu
    {
        public string GetMenuName()
        {
            return "dinner";
        }

        public int CreateOrder()
        {
            return 2;
        }
        public int CreateInvoice()
        {
            return 2;
        }
    }


        public class MealType{
            protected string foodName;
            public MealType(string name)
            {
                this.foodName = name;
            }
        public string GetFoodName()
        {
            return foodName; 
        }
        }
        public static class MenuFactory
        {
       
        public static IMenu GetMenuFromMealType(MealType mealType)
        {
            IMenu menuType = null;
            switch (mealType.GetFoodName())
            {
                case "Dinner":
                    menuType = new DinnerMenu();
                
                    break;
                case "Breakfast":
                    menuType = new BreakfastMenu();
                 
                    break; 
                case "Lunch":
                    menuType = new LunchMenu();
             
                    break;  
            }

            return menuType;
          }
            
        }
}

