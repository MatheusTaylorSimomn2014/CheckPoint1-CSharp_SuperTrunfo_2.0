using System.Collections.Generic;

namespace CardGameEngine
{
    public interface IAttributeCard<TValue> : ICard where TValue : IComparable<TValue>
    {
        IReadOnlyDictionary<string, TValue> Attributes { get; }
        TValue GetAttribute(string attributeName);
    }
}