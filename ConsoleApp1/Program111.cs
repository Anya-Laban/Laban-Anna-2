
using System.Text.Json;
//Описати клас, який реалізує десятковий лічильник, який може збільшувати або зменшувати своє значення на одиницю в заданому діапазоні.
//Передбачити ініціалізацію лічильника значеннями за замовчуванням і довільними значеннями.
//Лічильник має два методи: збільшення і зменшення, - і властивість, що дозволяє отримати його поточний стан.
//Написати програму, яка демонструвала б всі можливості класу.


namespace ConsoleApp1
{
    internal class Program
    {
        private const string _pathToFileJson = "C:\\Users\\Anna\\Desktop\\Навчання КПІ\\Програмування\\Лабораторна 1.2\\Counters.json";
        public static void Serialize(Counter counter)
        {
            using (FileStream fs = new FileStream(_pathToFileJson, FileMode.OpenOrCreate))
            {
               JsonSerializer.Serialize(fs, counter);
            }
            Console.WriteLine($"Збережено у файл json.");
        }
        public static void Deseriale()
        {
            string jsonString;
            using (StreamReader sr = new StreamReader(_pathToFileJson))
            {
                jsonString = sr.ReadToEnd(); 
            }
            Counter counter = JsonSerializer.Deserialize<Counter>(jsonString);
            Console.WriteLine(counter);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
                string st; int minValue, maxValue, number;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Натиснiть: \n1, щоб самостiйно вибрати число.\nБудь що iнше, щоб вибрати рандомно");
                    st = Console.ReadLine();
                } while (st == null);

                if (st == "1")
                {
                    Console.Write("Введiть початок дiапазону:");
                    minValue = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введiть кiнець дiапазону:");
                    maxValue = Convert.ToInt32(Console.ReadLine());
                    if (minValue > maxValue)
                    {
                        int c = minValue;
                        minValue = maxValue;
                        maxValue = c;
                    }
                    do
                    {
                        Console.Write("Введiть число в заданому дiапазонi:");
                        st = Console.ReadLine();
                        int.TryParse(st, out number);
                    } while (st == null || number < minValue || number > maxValue);

                }
                else 
                {
                    Random random = new Random();
                    number = random.Next(10,100);
                    minValue = 10; maxValue = 100;
                }
                Counter counter = new Counter(number, minValue, maxValue,0,0);
                Console.Clear();

                bool v = true;
                while (v)
                {
                    Console.WriteLine("Для збiльшення на 1 натиснiть -> \"+\".\nДля зменшення на 1 натиснiть -> \"-\".\nДля виведення iнформацiї на екран натиснiть -> \"0\"\nДля збереження i виходу з програми натисніть будь що інше");
                    st = Console.ReadLine();
                    if (st == "+") counter.Plus();
                    else if (st == "-") counter.Minus();
                    else if (st == "0")
                    {
                        Console.WriteLine(counter);
                        Console.ReadKey();
                    }
                    else
                    {
                    Serialize(counter);
                    Deseriale();
                    v = false;
                    }
                    Console.Clear();
                }


        }
    } 
}
