namespace Task1
{
    public abstract class Item //: IHasName, IHasWeight
    {
        public string Name { get; protected set; }
        public double Weight { get; protected set; }

        public Item(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

    }
}