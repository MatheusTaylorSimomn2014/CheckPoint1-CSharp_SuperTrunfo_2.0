public class SuperTrunfoGame : Game<SuperTrunfoCard>
{
    private IPlayer<SuperTrunfoCard> _currentWinner;
    private bool _gameOver;
    private int _roundNumber;
    private Match _currentMatch;          
    private GameHistory _history;         

    public SuperTrunfoGame(IList<IPlayer<SuperTrunfoCard>> players, IDeck<SuperTrunfoCard> deck)
        : base(players, deck)
    {
        _currentMatch = new Match();
        _currentMatch.PlayerNames.AddRange(players.Select(p => p.Name));
        _history = new GameHistory();
    }

    public override void StartGame()
    {

        _gameOver = false;
        _currentWinner = null;
        _roundNumber = 0;
        _currentMatch.StartTime = DateTime.Now;
    }

    public override void NextRound()
    {
        if (_gameOver) throw new InvalidOperationException("O jogo já terminou.");

        string chosenAttribute;
        if (_currentWinner == null)
            chosenAttribute = "População";
        else
            chosenAttribute = EscolherAtributo(_currentWinner);

        var round = new SuperTrunfoRound(chosenAttribute);
        round.PlayRound(Players);  
        
        _currentWinner = round.Winner;

       
        var roundRecord = new RoundRecord
        {
            RoundNumber = ++_roundNumber,
            AttributeUsed = chosenAttribute,
            Winner = round.Winner?.Name ?? "Empate"
        };

        foreach (var kvp in round.CardsPlayed)
        {
            roundRecord.CardsPlayed[kvp.Key.Name] = kvp.Value.Name;
        }
        _currentMatch.Rounds.Add(roundRecord);

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
            _currentMatch.Winner = winner?.Name ?? "Ninguém";
            _history.AddMatch(_currentMatch);
            Console.WriteLine(winner != null ? $"Vencedor final: {winner.Name}!" : "Empate final!");
        }
    }

    private string EscolherAtributo(IPlayer<SuperTrunfoCard> player)
    {

        return "População";
    }

    public bool IsGameOver => _gameOver;
}
