public class SuperTrunfoGame : Game<SuperTrunfoCard>
{
    private IPlayer<SuperTrunfoCard> _currentWinner;
    private bool _gameOver;

    public SuperTrunfoGame(IList<IPlayer<SuperTrunfoCard>> players, IDeck<SuperTrunfoCard> deck) : base(players, deck)
    {
    }

    public override void StartGame()
    {
        Deck.Shuffle();

        int cardsPerPlayer = Deck.CardsRemaining / Players.Count;
        int remainder = Deck.CardsRemaining % Players.Count;
        
        for (int i = 0; i < cardsPerPlayer; i++)
        {
            foreach (var player in Players)
                player.ReceiveCard(Deck.Draw());
        }
        
        // Descarta as cartas restantes (ou poderia ser usado como prêmio)
        for (int i = 0; i < remainder; i++)
            Deck.Draw();

        _gameOver = false;
        _currentWinner = null;
    }

    public override void NextRound()
    {
        if (_gameOver)
            throw new InvalidOperationException("O jogo já terminou.");

        string chosenAttribute;
        if (_currentWinner == null)
        {

            chosenAttribute = "População";
        }
        else
        {

            chosenAttribute = EscolherAtributo(_currentWinner);
        }

        var round = new SuperTrunfoRound(chosenAttribute);
        round.PlayRound(Players);

        _currentWinner = round.Winner;

        foreach (var player in Players)
        {
            if (player.Hand.Count == 0)
            {
                _gameOver = true;
                Console.WriteLine($"Jogador {player.Name} ficou sem cartas e foi eliminado!");
            }
        }

        int playersWithCards = Players.Count(p => p.Hand.Count > 0);
        if (playersWithCards <= 1)
        {
            _gameOver = true;
            var winner = Players.FirstOrDefault(p => p.Hand.Count > 0);
            Console.WriteLine(winner != null ? $"Vencedor final: {winner.Name}!" : "Empate final!");
        }
    }

    private string EscolherAtributo(IPlayer<SuperTrunfoCard> player)
    {

        return "População";
    }

    public bool IsGameOver => _gameOver;
}
