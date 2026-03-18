using System.Collections.Generic;

namespace CardGameEngine
{
    public interface IDeck<T> where T : ICard
    {
        int CardsRemaining { get; }
        void Shuffle();
        T Draw();
        void AddCard(T card);
    }

    public class Deck<T> : IDeck<T> where T : ICard
    {
        private List<T> _cards;
        private Random _random = new Random();

        public Deck(IEnumerable<T> initialCards)
        {
            _cards = new List<T>(initialCards);
        }

        public int CardsRemaining => _cards.Count;

        public void Shuffle()
        {
            _cards = _cards.OrderBy(c => _random.Next()).ToList();
        }

        public T Draw()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Deck is empty");
            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public void AddCard(T card)
        {
            _cards.Add(card);
        }
    }
}