namespace Pigpot
{
    public class Catalog : ICatalog
    {
        public Catalog(string name)
        {
            Name = name;
        }

        public virtual string Name { get; }
    }
}
