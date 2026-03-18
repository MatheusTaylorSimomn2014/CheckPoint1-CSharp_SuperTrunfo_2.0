namespace CardGameEngine
{
    public interface ICard
    {
        string Name { get; }
    }

    public abstract class Card : ICard
    {
        public string Name { get; protected set; }

        protected Card(string name)
        {
            Name = name;
        }
    }
}