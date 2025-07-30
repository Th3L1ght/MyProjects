namespace ZooManagementSystem.Animals
{
    public class Elephant : Animal
    {
        public Elephant()
        {
        }

        public Elephant(string name) : base(name)
        {
        }

        public override string MakeSound()
        {
            return $" Trumpet";
        }
    }
}
