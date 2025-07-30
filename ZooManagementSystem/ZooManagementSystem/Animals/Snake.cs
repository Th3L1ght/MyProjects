namespace ZooManagementSystem.Animals
{
    public class Snake : Animal
    {
        public Snake()
        {
        }

        public Snake(string name) : base(name)
        {
        }

        public override string MakeSound()
        {
            return $" Hiss";
        }
    }
}
