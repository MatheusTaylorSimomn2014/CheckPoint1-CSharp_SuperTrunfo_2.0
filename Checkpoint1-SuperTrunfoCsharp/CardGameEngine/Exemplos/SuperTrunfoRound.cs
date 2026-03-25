public class SuperTrunfoRound : Round<SuperTrunfoCard>
{
    private string _chosenAttribute;

    public SuperTrunfoRound(string chosenAttribute)
    {
        _chosenAttribute = chosenAttribute;
    }

    public override void PlayRound(IList<IPlayer<SuperTrunfoCard>> players)
    {
        if (players == null || players.Count < 2)
            throw new ArgumentException("É necessário pelo menos dois jogadores.");

        foreach (var player in players)
        {
            if (player.Hand.Count == 0)
                throw new InvalidOperationException($"Jogador {player.Name} não tem cartas para jogar.");
        }

        // Remove a primeira carta de cada jogador e guarda para comparação
        var cardsPlayed = new Dictionary<IPlayer<SuperTrunfoCard>, SuperTrunfoCard>();
        foreach (var player in players)
        {
            var card = player.PlayCard(0); // Remove e retorna a carta
            cardsPlayed[player] = card;
        }

        IPlayer<SuperTrunfoCard> winner = null;
        int bestValue = int.MinValue;

        foreach (var kvp in cardsPlayed)
        {
            int value = kvp.Value.GetAttribute(_chosenAttribute);
            if (value > bestValue)
            {
                bestValue = value;
                winner = kvp.Key;
            }
            else if (value == bestValue)
            {
            
                winner = null;
            }
        }

        if (winner != null)
        {
            foreach (var card in cardsPlayed.Values)
            {
                winner.ReceiveCard(card);
            }
        }
        
        else
        {
            foreach (var kvp in cardsPlayed)
            {
                kvp.Key.ReceiveCard(kvp.Value);
            }
        }

        Winner = winner;
    }
}
