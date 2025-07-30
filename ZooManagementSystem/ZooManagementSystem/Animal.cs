namespace ZooManagementSystem
{
    public class Animal
    {
        public string Name { get; set; }

        public virtual string MakeSound()
        {
            return $" *Some sort of random noise*";
        }

        public Animal(string name)
        {
            Name = name;
        }
        public Animal()
        {
        }

        public override string ToString()
        {
            string typeName = this.GetType().Name;
            return $"{this.Name}({typeName}):";
        }
    }
}
