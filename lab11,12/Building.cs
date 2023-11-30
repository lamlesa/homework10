using System;

namespace lab11_12
{
    internal class Building
    {
        private static ushort number = CreateBuildingNumber();
        private double height;
        private byte storeys;
        private uint apartments;
        private byte entrances;
        internal Building(double height)
        {
            this.height = height;
        }
        internal Building(double height, byte storeys)
        {
            this.height = height;
            this.storeys = storeys;
        }
        static private ushort CreateBuildingNumber()
        {
            Random n = new Random(0);
            bool flag = false;
            do
            {
                flag = ushort.TryParse(Convert.ToString(n.Next()), out number);
            } while (!flag);
            return (number);
        }
        public void CreateNewBuildingNumber()
        {
            Building.number += 1;
        }
        public ushort Number { get { return number; } }
        public double Height {  get { return height; } }
        public byte Storeys { get { return storeys; } }
        public uint Apartments { get { return apartments; } }
        public byte Entrances { get { return entrances; } }
        public void CalculateTheHeightOfTheStorey(double height, byte storeys)
        {
            double storey_height = height / Convert.ToDouble(storeys);
            Console.WriteLine($"Высота одного этажа: {storey_height}");
        }
        public void CalculateTheNumberOfApartmentsInTheEntrance(uint apartments, byte entrances)
        {
            double entrance_volume = Convert.ToDouble(apartments) / Convert.ToDouble(entrances);
            if (entrance_volume % 1 == 0)
            {
                Console.WriteLine($"Квартир в одном подъезде: {entrance_volume}");
            }
            else
            {
                throw new ArgumentException("Что-то не так с входными данными.");
            }
        }
        public void CalculateTheNumberOfApartmentsPerStorey(uint apartments, byte storeys)
        {
            double storey_volume = Convert.ToDouble(apartments) / Convert.ToDouble(storeys);
            if (storey_volume % 1 == 0)
            {
                Console.WriteLine($"Квартир на одном этаже: {storey_volume}");
            }
            else
            {
                throw new ArgumentException("Что-то не так с входными данными.");
            }
        }
        public void Print()
        {
            Console.WriteLine($"Номер здания: {number}\nВысота: {height}\nКоличество квартир: {apartments}\nПодъездов: {entrances}\nЭтажей: {storeys}");
        }
    }
}