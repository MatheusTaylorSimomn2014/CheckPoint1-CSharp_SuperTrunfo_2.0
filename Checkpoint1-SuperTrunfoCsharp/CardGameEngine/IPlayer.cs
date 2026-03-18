using System.Collections.Generic;

namespace CardGameEngine
{
    public interface IPlayer<T> where T : ICard
    {
        string Name { get; }
        IList<T> Hand { get; }
        void ReceiveCard(T card);
        T PlayCard(int index);
    }

    public class Player<T> : IPlayer<T> where T : ICard
    {
        public string Name { get; private set; }
        public IList<T> Hand { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<T>();
        }

        public void ReceiveCard(T card)
        {
            Hand.Add(card);
        }

        public T PlayCard(int index)
        {
            if (index < 0 || index >= Hand.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            var card = Hand[index];
            Hand.RemoveAt(index);
            return card;
        }
    }
}