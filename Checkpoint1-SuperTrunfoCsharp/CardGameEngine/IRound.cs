using System.Collections.Generic;

namespace CardGameEngine
{
    public interface IRound<T> where T : ICard
    {
        IPlayer<T> Winner { get; }
        void PlayRound(IList<IPlayer<T>> players);
    }

    public abstract class Round<T> : IRound<T> where T : ICard
    {
        public IPlayer<T> Winner { get; protected set; }

        public abstract void PlayRound(IList<IPlayer<T>> players);
    }
}