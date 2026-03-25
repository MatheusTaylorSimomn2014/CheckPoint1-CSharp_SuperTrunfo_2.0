public class SuperTrunfoRound : Round<SuperTrunfoCard>
{
    private string _chosenAttribute;
    public Dictionary<IPlayer<SuperTrunfoCard>, SuperTrunfoCard> CardsPlayed { get; private set; }

    public SuperTrunfoRound(string chosenAttribute)
    {
        _chosenAttribute = chosenAttribute;
        CardsPlayed = new Dictionary<IPlayer<SuperTrunfoCard>, SuperTrunfoCard>();
    }

    public override void PlayRound(IList<IPlayer<SuperTrunfoCard>> players)
    {

        foreach (var player in players)
        {
            var card = player.PlayCard(0);
            CardsPlayed[player] = card;
        }

    }
}
