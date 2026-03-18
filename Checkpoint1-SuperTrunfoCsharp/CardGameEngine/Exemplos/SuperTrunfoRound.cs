public class SuperTrunfoRound : Round<SuperTrunfoCard>
{
    private string _chosenAttribute;

    public SuperTrunfoRound(string chosenAttribute)
    {
        _chosenAttribute = chosenAttribute;
    }

    public override void PlayRound(IList<IPlayer<SuperTrunfoCard>> players)
    {
        
        var card0 = players[0].Hand[0];
        var card1 = players[1].Hand[0];

        if (card0.GetAttribute(_chosenAttribute) > card1.GetAttribute(_chosenAttribute))
            Winner = players[0];
        else if (card0.GetAttribute(_chosenAttribute) < card1.GetAttribute(_chosenAttribute))
            Winner = players[1];
        else
            Winner = null; 

    }
}