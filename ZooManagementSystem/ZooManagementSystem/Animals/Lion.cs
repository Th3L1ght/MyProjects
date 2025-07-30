namespace ZooManagementSystem.Animals
{
    public class Lion : Animal
    {
        public Lion()
        {
        }

        public Lion(string name) : base(name)
        {
        }

        public override string MakeSound()
        {
            return $" Roar";
        }
    }
}
