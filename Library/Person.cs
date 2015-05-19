namespace Library
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void Greet()
        {
            System.Console.WriteLine("Hello! I'm {0} and {1} years old.", this.Name, this.Age);
        }

        public void Plus(int age)
        {
            this.Age += age;
        }
    }
}
