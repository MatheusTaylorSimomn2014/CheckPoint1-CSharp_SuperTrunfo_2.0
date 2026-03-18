public class SuperTrunfoCard : Card, IAttributeCard<int>
{
    public IReadOnlyDictionary<string, int> Attributes { get; private set; }

    public SuperTrunfoCard(string name, Dictionary<string, int> attributes) : base(name)
    {
        Attributes = new Dictionary<string, int>(attributes);
    }

    public int GetAttribute(string attributeName)
    {
        return Attributes.TryGetValue(attributeName, out var value) ? value : throw new ArgumentException("Atributo não encontrado");
    }
}