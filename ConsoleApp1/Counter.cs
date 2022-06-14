
namespace ConsoleApp1
{
    public class Counter
    {
        public Counter(int number, int minValue, int maxValue, int countPlus, int countMinus) => (Number, MinValue, MaxValue, CountPlus, CountMinus) = (number, minValue, maxValue, countPlus, countMinus);
        public int Number { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int CountPlus { get; private set; }
        public int CountMinus { get; private set; }
        
        public void Plus()
        {
            if (Number < MaxValue)
            {
                Number++;
                CountPlus++;
            }
            else { Console.WriteLine("Неможливо виконати, бо  число вийде за межі діапазону."); }
        }
        public void Minus()
        {
            if (Number > MinValue)
            {
                Number--;
                CountMinus++;
            }
            else { Console.WriteLine("Неможливо виконати, бо  число вийде за межі діапазону."); }
        }
        public override string ToString()
        {
            return string.Format($"Число - {Number} знаходиться в дiапазонi вiд {MinValue} до {MaxValue}.\nКiлькiсть збiльшень на одиницю - {CountPlus}\nКiлькiсть зменшень на одиницю - {CountMinus}.");
        
        }
    }
}
