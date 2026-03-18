using System.Collections.Generic;

namespace CardGameEngine
{
    public interface IGame<T> where T : ICard
    {
        IList<IPlayer<T>> Players { get; }
        IDeck<T> Deck { get; }
        void StartGame();
        void NextRound();
    }

    public abstract class Game<T> : IGame<T> where T : ICard
    {
        public IList<IPlayer<T>> Players { get; protected set; }
        public IDeck<T> Deck { get; protected set; }

        protected Game(IList<IPlayer<T>> players, IDeck<T> deck)
        {
            Players = players;
            Deck = deck;
        }

        public abstract void StartGame();
        public abstract void NextRound();
    }
}