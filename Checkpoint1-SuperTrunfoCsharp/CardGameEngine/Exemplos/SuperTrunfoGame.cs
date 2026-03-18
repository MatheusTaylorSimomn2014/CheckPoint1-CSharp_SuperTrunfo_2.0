public class SuperTrunfoGame : Game<SuperTrunfoCard>
{
    public SuperTrunfoGame(IList<IPlayer<SuperTrunfoCard>> players, IDeck<SuperTrunfoCard> deck) : base(players, deck)
    {
    }

    public override void StartGame()
    {
        Deck.Shuffle();
        
        int cardsPerPlayer = Deck.CardsRemaining / Players.Count;
        for (int i = 0; i < cardsPerPlayer; i++)
        {
            foreach (var player in Players)
                player.ReceiveCard(Deck.Draw());
        }
    }

    public override void NextRound()
    {
        var chosenAttribute = "População";
        var round = new SuperTrunfoRound(chosenAttribute);
        round.PlayRound(Players);

        if (round.Winner != null)
        {
            
        }
    }
}