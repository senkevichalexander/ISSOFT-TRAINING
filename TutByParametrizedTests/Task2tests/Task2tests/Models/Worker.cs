namespace Task2tests.Pages.SeleniumeasyPages
{
    public class Worker
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public string Office { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

        public Worker(string name, string position, string office, int age, decimal salary)
        {
            Name = name;
            Position = position;
            Office = office;
            Age = age;
            Salary = salary;
        }
    }
}
