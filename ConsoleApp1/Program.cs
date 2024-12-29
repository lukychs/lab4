using System.Collections;

class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string Name, int ProductionYear, int MaxSpeed)
    {
        this.Name = Name;
        this.ProductionYear = ProductionYear;
        this.MaxSpeed = MaxSpeed;
    }

    public override string ToString()
    {
        return $"Название: {Name}, год выпуска: {ProductionYear}, максимальная скорость: {MaxSpeed}";
    }
}


class CarCatalog:IEnumerable<Car>
{
    public Car[] carMas;

    public CarCatalog(params Car[] carMas)
    {
        this.carMas = carMas;  
    }

    public IEnumerator<Car> GetEnumerator()
    {
        Console.WriteLine("Прямой проход по элементам:");
        for (int i = 0; i < carMas.Length; i++)
            yield return carMas[i];
        Console.WriteLine();
    }

    public IEnumerable<Car> GetReverse()
    {
        Console.WriteLine("Обратный проход по элементам:");
        for (int i = carMas.Length - 1; i >= 0; i--)
            yield return carMas[i];
        Console.WriteLine();
    }

    public IEnumerable<Car> GetProductionYear(int Year)
    {
        Console.WriteLine($"Проход по элементам с фильтром по году выпуска ({Year}):");
        for (int i = 0; i < carMas.Length; i++)
            if (carMas[i].ProductionYear == Year)
                yield return carMas[i];
        Console.WriteLine();
    }

    public IEnumerable<Car> GetMaxSpeed(int Speed)
    {
        Console.WriteLine($"Проход по элементам с фильтром по максимальной скорости ({Speed}):");
        for (int i = 0; i < carMas.Length; i++)
            if (carMas[i].MaxSpeed == Speed)
                yield return carMas[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Nissan", 2015, 150);
        Car car2 = new Car("Chevrolet", 2002, 200);
        CarCatalog catalog = new CarCatalog(car1, car2);

        foreach (Car car in catalog)
        {
            Console.WriteLine(car);
        }
        
        foreach (Car car in catalog.GetReverse())
        {
            Console.WriteLine(car);
        }
        
        foreach (Car car in catalog.GetProductionYear(2002))
        {
            Console.WriteLine(car);
        }

        foreach (Car car in catalog.GetMaxSpeed(150))
        {
            Console.WriteLine(car);
        }

    }
}