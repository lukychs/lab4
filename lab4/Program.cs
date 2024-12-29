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

class CarComparer: IComparer<Car>
{
    private string key;

    public CarComparer(string key)
    {
        this.key = key;
    }

    public int Compare(Car car1, Car car2)
    {
        if (car1 == null || car2 == null)
            throw new ArgumentNullException("Некорректное значение параметра");
        else
        {
            switch (key)
            {
                case "Name":
                    return car1.Name.CompareTo(car2.Name);
                    break;
                case "Production Year":
                    return car1.ProductionYear.CompareTo(car2.ProductionYear);
                    break;
                case "Max Speed":
                    return car1.MaxSpeed - car2.MaxSpeed;
                    break;
                default:
                    throw new ArgumentException("Неверный параметр сортировки");
                    break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Nissan", 2002, 200);
        Car car2 = new Car("Subaru", 1980, 150);
        Car car3 = new Car("Audi", 1999, 250);

        Car[] masCar = { car1, car2, car3 };
        Array.Sort(masCar, new CarComparer("Production Year"));

        foreach (Car car in masCar)
            Console.WriteLine(car);
    }
}