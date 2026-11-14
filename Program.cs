using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Alphabet : IEnumerable<char>, IEnumerator<char>
{
    private char[] letters = new char[26];
    private int position = -1;

    public Alphabet()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = (char)('A' + i);
        }
    }

    public int Count => letters.Length;

    public char Current => letters[position];

    object IEnumerator.Current => letters[position];

    public bool MoveNext()
    {
        if (position < letters.Length - 1)
        {
            position++;
            return true;
        }
        Reset();
        return false;
    }

    public void Reset()
    {
        position = -1;
    }

    public void Dispose()
    {
    }

    public IEnumerator<char> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this;
    }
}

class Apartment : IEnumerable<string>
{
    private List<string> residents = new List<string>();

    public int Number { get; set; }
    public int Rooms { get; set; }

    public Apartment(int number, int rooms)
    {
        Number = number;
        Rooms = rooms;
    }

    public int Count => residents.Count;

    public void AddResident(string name)
    {
        residents.Add(name);
    }

    public IEnumerator<string> GetEnumerator()
    {
        foreach (string resident in residents)
        {
            yield return resident;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return $"Квартира №{Number}, кімнат: {Rooms}, мешканців: {Count}";
    }
}

class House : IEnumerable<Apartment>
{
    private List<Apartment> apartments = new List<Apartment>();

    public string Address { get; set; }

    public House(string address)
    {
        Address = address;
    }

    public void AddApartment(Apartment apartment)
    {
        apartments.Add(apartment);
    }

    public IEnumerator<Apartment> GetEnumerator()
    {
        foreach (Apartment apartment in apartments)
        {
            yield return apartment;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Number { get; set; }

    public Car(string brand, string model, int year, string number)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Number = number;
    }

    public override string ToString()
    {
        return $"{Brand} {Model}, {Year} р., номер {Number}";
    }
}

class Garage : IEnumerable<Car>
{
    private List<Car> cars = new List<Car>();

    public string Name { get; set; }

    public Garage(string name)
    {
        Name = name;
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public IEnumerator<Car> GetEnumerator()
    {
        foreach (Car car in cars)
        {
            yield return car;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Завдання 1. Алфавіт");
        Alphabet alphabet = new Alphabet();
        foreach (char letter in alphabet)
        {
            Console.Write($"{letter} ");
        }
        Console.WriteLine();
        foreach (char letter in alphabet)
        {
            Console.Write($"{char.ToLower(letter)} ");
        }
        Console.WriteLine($"\nВсього літер: {alphabet.Count}");

        Console.WriteLine("\nЗавдання 2. Будинок і квартири");
        Apartment first = new Apartment(1, 2);
        first.AddResident("Іван Петренко");
        first.AddResident("Олена Петренко");

        Apartment second = new Apartment(2, 1);
        second.AddResident("Андрій Коваль");

        Apartment third = new Apartment(3, 3);
        third.AddResident("Марія Бондар");
        third.AddResident("Олег Бондар");
        third.AddResident("Софія Бондар");

        House house = new House("вул. Шевченка, 15");
        house.AddApartment(first);
        house.AddApartment(second);
        house.AddApartment(third);

        Console.WriteLine($"Будинок: {house.Address}");
        foreach (Apartment apartment in house)
        {
            Console.WriteLine(apartment);
            foreach (string resident in apartment)
            {
                Console.WriteLine($"   - {resident}");
            }
        }

        Console.WriteLine("\nЗавдання 3. Гараж");
        Garage garage = new Garage("Гараж на Лісовій");
        garage.AddCar(new Car("Toyota", "Camry", 2019, "AA1234BC"));
        garage.AddCar(new Car("Volkswagen", "Golf", 2015, "KA5678IO"));
        garage.AddCar(new Car("Tesla", "Model 3", 2022, "BC0001EE"));

        Console.WriteLine(garage.Name);
        foreach (Car car in garage)
        {
            Console.WriteLine(car);
        }
    }
}
