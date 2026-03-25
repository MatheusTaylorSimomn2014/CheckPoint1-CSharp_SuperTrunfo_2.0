using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            var cards = new List<SuperTrunfoCard>
            {
                new SuperTrunfoCard("Brasil", new Dictionary<string, int> { { "População", 213_000_000 }, { "Área", 8_515_767 } }),
                new SuperTrunfoCard("EUA", new Dictionary<string, int> { { "População", 331_000_000 }, { "Área", 9_833_517 } }),
                new SuperTrunfoCard("Canadá", new Dictionary<string, int> { { "População", 38_000_000 }, { "Área", 9_984_670 } }),
                new SuperTrunfoCard("Argentina", new Dictionary<string, int> { { "População", 45_000_000 }, { "Área", 2_780_400 } }),
                new SuperTrunfoCard("Alemanha", new Dictionary<string, int> { { "População", 83_000_000 }, { "Área", 357_582 } }),
                new SuperTrunfoCard("França", new Dictionary<string, int> { { "População", 67_000_000 }, { "Área", 643_801 } })
            };

            var deck = new Deck<SuperTrunfoCard>(cards);

            var players = new List<IPlayer<SuperTrunfoCard>>
            {
                new Player<SuperTrunfoCard>("João"),
                new Player<SuperTrunfoCard>("Maria")
            };

            var game = new SuperTrunfoGame(players, deck);
            game.StartGame();

            Console.WriteLine("Jogo iniciado!");
            int roundNumber = 1;

            while (!game.IsGameOver)
            {
                Console.WriteLine($"\n--- Rodada {roundNumber} ---");
                game.NextRound();

                foreach (var player in players)
                {
                    Console.WriteLine($"{player.Name} tem {player.Hand.Count} carta(s).");
                }

                roundNumber++;
            }

            Console.WriteLine("\nJogo encerrado!");
        }
    }
}
