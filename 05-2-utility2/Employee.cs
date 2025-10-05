namespace _18_utility2
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}";
        }
    }
}
