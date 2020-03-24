using System;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Furniture furn = new Furniture(100, "Стол", "Круглый, невысокий");
            Console.WriteLine(furn.ToString());
            furn.Price = 200;
            Console.WriteLine(furn.ToString());
        }
    }
    public class Furniture
    {
       
        private int price;
        private string type;
        private string characteristic;

        // Конструктор с параметрами
        public Furniture( int price, string type, string characteristic)
        {
            this.price = price;
            this.type = type;
            this.characteristic = characteristic;
        }

        // геттеры и сеттеры
        public int Price
        {
            get { return price;}
            set { price = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Characteristic
        {
            get { return characteristic; }
            set { characteristic = value; }
        }
        // методы
        public override string ToString() // перегрузка метода ToString с помощью override 
        {
            return string.Format("Цена: {0}\n Тип: {1}\nОписание: {2}\n",price,type,characteristic);
        }

    }
}

