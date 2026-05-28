using System;
using System.Collections.Generic;
using System.Linq;

namespace AutosalonLab6
{
    // =========================
    // Завдання №1
    // Абстрактний клас Vehicle
    // =========================
    public interface Refuelable
    {
        void Refill();
    }

    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public int Speed { get; set; }

        protected Vehicle(string brand, int speed)
        {
            Brand = brand;
            Speed = speed;
        }

        public abstract void Move();

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Марка: {Brand}, швидкість: {Speed} км/год");
        }
    }

    public class Car : Vehicle, Refuelable
    {
        public string FuelType { get; set; }

        public Car(string brand, int speed, string fuelType) : base(brand, speed)
        {
            FuelType = fuelType;
        }

        public override void Move()
        {
            Console.WriteLine($"Автомобіль {Brand} їде дорогою зі швидкістю {Speed} км/год.");
        }

        public void Refill()
        {
            Console.WriteLine($"Автомобіль {Brand} заправлено паливом типу {FuelType}.");
        }
    }

    public class Bicycle : Vehicle
    {
        public Bicycle(string brand, int speed) : base(brand, speed)
        {
        }

        public override void Move()
        {
            Console.WriteLine($"Велосипед {Brand} рухається завдяки силі людини зі швидкістю {Speed} км/год.");
        }
    }

    public class Airplane : Vehicle, Refuelable
    {
        public int Altitude { get; set; }

        public Airplane(string brand, int speed, int altitude) : base(brand, speed)
        {
            Altitude = altitude;
        }

        public override void Move()
        {
            Console.WriteLine($"Літак {Brand} летить на висоті {Altitude} м зі швидкістю {Speed} км/год.");
        }

        public void Refill()
        {
            Console.WriteLine($"Літак {Brand} заправлено авіаційним паливом.");
        }
    }

    // =========================
    // Завдання №2
    // Індивідуальне: Транспорт у місті
    // PublicTransport -> Bus, Tram, Metro
    // =========================
    public interface IRouteInfo
    {
        void PrintStops();
    }

    public abstract class PublicTransport
    {
        public string Name { get; set; }
        public string RouteNumber { get; set; }
        public int PassengerCapacity { get; set; }

        protected PublicTransport(string name, string routeNumber, int passengerCapacity)
        {
            Name = name;
            RouteNumber = routeNumber;
            PassengerCapacity = passengerCapacity;
        }

        public abstract void DescribeRoute();

        public virtual void ShowGeneralInfo()
        {
            Console.WriteLine($"{Name}: маршрут №{RouteNumber}, місткість: {PassengerCapacity} пасажирів.");
        }
    }

    public class Bus : PublicTransport, IRouteInfo
    {
        public Bus(string routeNumber, int passengerCapacity)
            : base("Автобус", routeNumber, passengerCapacity)
        {
        }

        public override void DescribeRoute()
        {
            Console.WriteLine("Автобус рухається міськими дорогами та зупиняється на наземних зупинках.");
        }

        public void PrintStops()
        {
            Console.WriteLine("Зупинки: Автовокзал -> Центр -> Школа -> Лікарня -> Парк.");
        }
    }

    public class Tram : PublicTransport, IRouteInfo
    {
        public Tram(string routeNumber, int passengerCapacity)
            : base("Трамвай", routeNumber, passengerCapacity)
        {
        }

        public override void DescribeRoute()
        {
            Console.WriteLine("Трамвай рухається рейками та підходить для перевезення великої кількості пасажирів.");
        }

        public void PrintStops()
        {
            Console.WriteLine("Зупинки: Депо -> Площа -> Університет -> Ринок -> Вокзал.");
        }
    }

    public class Metro : PublicTransport, IRouteInfo
    {
        public Metro(string routeNumber, int passengerCapacity)
            : base("Метро", routeNumber, passengerCapacity)
        {
        }

        public override void DescribeRoute()
        {
            Console.WriteLine("Метро рухається підземними лініями та має найвищу швидкість перевезення.");
        }

        public void PrintStops()
        {
            Console.WriteLine("Станції: Центральна -> Університет -> Південна -> Заводська -> Кінцева.");
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Лабораторна робота №6 — Наслідування та Поліморфізм";

            bool running = true;

            while (running)
            {
                Console.Clear();
                PrintHeader("ЛАБОРАТОРНА РОБОТА №6");
                Console.WriteLine("1. Виконати завдання №1: Vehicle, Car, Bicycle, Airplane");
                Console.WriteLine("2. Виконати завдання №2: PublicTransport, Bus, Tram, Metro");
                Console.WriteLine("3. Пояснення використаних принципів ООП");
                Console.WriteLine("0. Вихід");
                Console.Write("\nОберіть пункт меню: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        RunTask1();
                        Pause();
                        break;
                    case "2":
                        RunTask2();
                        Pause();
                        break;
                    case "3":
                        ShowTheory();
                        Pause();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Помилка: такого пункту меню немає.");
                        Console.ResetColor();
                        Pause();
                        break;
                }
            }
        }

        static void RunTask1()
        {
            Console.Clear();
            PrintHeader("ЗАВДАННЯ №1 — VEHICLE");

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Toyota", 120, "бензин"),
                new Bicycle("Giant", 25),
                new Airplane("Boeing", 850, 10000)
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Демонстрація поліморфізму: один список Vehicle, різна поведінка move().\n");
            Console.ResetColor();

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.ShowInfo();
                vehicle.Move();

                if (vehicle is Refuelable refuelable)
                {
                    refuelable.Refill();
                }
                else
                {
                    Console.WriteLine("Цей транспортний засіб не потребує заправки паливом.");
                }

                Console.WriteLine(new string('-', 60));
            }
        }

        static void RunTask2()
        {
            Console.Clear();
            PrintHeader("ЗАВДАННЯ №2 — ТРАНСПОРТ У МІСТІ");

            List<PublicTransport> transports = new List<PublicTransport>
            {
                new Bus("12А", 80),
                new Tram("4", 120),
                new Metro("M1", 900)
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Демонстрація наслідування та поліморфізму на прикладі міського транспорту.\n");
            Console.ResetColor();

            foreach (PublicTransport transport in transports)
            {
                transport.ShowGeneralInfo();
                transport.DescribeRoute();

                if (transport is IRouteInfo route)
                {
                    route.PrintStops();
                }

                Console.WriteLine(new string('-', 60));
            }
        }

        static void ShowTheory()
        {
            Console.Clear();
            PrintHeader("ПОЯСНЕННЯ ООП");

            Console.WriteLine("1. Наслідування:");
            Console.WriteLine("   Класи Car, Bicycle, Airplane успадковують базовий клас Vehicle.");
            Console.WriteLine("   Класи Bus, Tram, Metro успадковують базовий клас PublicTransport.\n");

            Console.WriteLine("2. Поліморфізм:");
            Console.WriteLine("   У списках Vehicle та PublicTransport зберігаються різні об'єкти.");
            Console.WriteLine("   Під час виклику move() або DescribeRoute() виконується метод конкретного класу.\n");

            Console.WriteLine("3. Абстрактні класи:");
            Console.WriteLine("   Vehicle та PublicTransport містять спільні поля і абстрактні методи.\n");

            Console.WriteLine("4. Інтерфейси:");
            Console.WriteLine("   Refuelable реалізують тільки Car і Airplane.");
            Console.WriteLine("   IRouteInfo реалізують Bus, Tram і Metro.");
        }

        static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================================");
            Console.WriteLine(title);
            Console.WriteLine("============================================================");
            Console.ResetColor();
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
            Console.ReadLine();
        }
    }
}
