public class Program
{
    public static void Main()
    {

        var cards = new List<SuperTrunfoCard>
        {
            new SuperTrunfoCard("Brasil", new Dictionary<string, int> { { "População", 213_000_000 }, { "Área", 8_515_767 } }),
            new SuperTrunfoCard("EUA", new Dictionary<string, int> { { "População", 331_000_000 }, { "Área", 9_833_517 } }),
            new SuperTrunfoCard("Canadá", new Dictionary<string, int> { { "População", 38_000_000 }, { "Área", 9_984_670 } }),

        };

        var deck = new Deck<SuperTrunfoCard>(cards);

        var players = new List<IPlayer<SuperTrunfoCard>>
        {
            new Player<SuperTrunfoCard>("João"),
            new Player<SuperTrunfoCard>("Maria")
        };

        var game = new SuperTrunfoGame(players, deck);
        game.StartGame();

        while (!game.IsGameOver)
        {
            game.NextRound();
        }
    }
}