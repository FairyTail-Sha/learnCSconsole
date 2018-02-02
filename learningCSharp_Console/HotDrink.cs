using System;

namespace learningCSharp_Console
{
    abstract class  HotDrink
    {
        protected double Milk;
        protected double Suger;
        public abstract void Drink();
        public abstract void AddMilk(double block);
        public abstract void AddSuger(double spoon);
    }
}

namespace learningCSharp_Console
{
    class CupOfCoffee : HotDrink,ICup
    {

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Refill()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Wash()
        {
            throw new NotImplementedException();
        }

        public override void AddMilk(double block)
        {
            throw new NotImplementedException();
        }

        public override void AddSuger(double spoon)
        {
            throw new NotImplementedException();
        }

        public override void Drink()
        {
            throw new NotImplementedException();
        }
    }
    class CupOfTea : HotDrink
    {

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Refill()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Wash()
        {
            throw new NotImplementedException();
        }

        public override void AddMilk(double block)
        {
            throw new NotImplementedException();
        }

        public override void AddSuger(double spoon)
        {
            throw new NotImplementedException();
        }

        public override void Drink()
        {
            throw new NotImplementedException();
        }
    }
}

namespace learningCSharp_Console
{
    class Pro
    {

        public void Drink(HotDrink myDrink)
        {
            myDrink.AddMilk(4);
            myDrink.Drink();
            //myDrink.Wash();HotDrink不支持ICup接口，所以要进行转化
            //方法一 显示转换
            //ICup cupInteface = (ICup)myDrink;
            //cupInteface.Wash();
            ////更安全的办法
            if (myDrink is ICup)
            {
                ((ICup)myDrink).Wash();
            }
            else
            {
                Console.WriteLine($"不支持ICup接口");
            }
            //Console.WriteLine(myDrink.ToString());
            //Console.ReadKey();
        }
    }
}
