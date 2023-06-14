using System;
using System.Collections.Generic;
using System.Text;
//Factory Method Design Patter
namespace RandomHaikuGenerator
{
    public interface ICar
    {

        int GetYear();
        string GetModel();
        string GetName();
    }
    public class HondaCar : ICar
    {
        public int GetYear()
        {
            return 1994;
        }
        public string GetModel()
        {
            return "Max";
        }
        public string GetName()
        {
            return "Honda";
        }
    }
    public class AudiCar : ICar
    {
        public int GetYear()
        {
            return 1994;
        }
        public string GetModel()
        {
            return "Max";
        }
        public string GetName()
        {
            return "Audi";
        }
    }

    public abstract class CarFactory{
        public abstract ICar FactoryMethod(string type);
}

    public class Factory : CarFactory
    {
        public override ICar FactoryMethod(string type)
        {
            switch (type)
            {
                case "Honda": return new HondaCar(); 
                case "Audi": return new AudiCar(); 
                default: return null;
            }
        }
    }




}
