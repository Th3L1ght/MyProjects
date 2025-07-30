namespace ZooManagementSystem
{
    public class Zoo
    {
        private List<Animal> list = new List<Animal>();

        public List<Animal> GetAnimals()
        {
            return list;
        }

        public void AddAnimal(Animal animal)
        {
            list.Add(animal);
        }

        public bool RemoveAnimal(string name)
        {
            int removedCount = list.RemoveAll(animal => animal.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return removedCount > 0;
        }
    }
}
