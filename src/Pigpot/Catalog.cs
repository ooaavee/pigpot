namespace Pigpot
{
    public class Catalog
    {
        public Catalog(string name)
        {
            Name = name;
        }

        public virtual string Name { get; }
    }
}
