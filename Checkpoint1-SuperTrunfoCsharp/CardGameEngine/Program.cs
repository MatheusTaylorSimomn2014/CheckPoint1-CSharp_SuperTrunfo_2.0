using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameEngine
{
    class Program
    {
        private static GameHistory _history = new GameHistory();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Super Trunfo 2.0 ===");
                Console.WriteLine("1 - Jogar");
                Console.WriteLine("2 - Histórico");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        MenuJogar();
                        break;
                    case "2":
                        MenuHistorico();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void MenuJogar()
        {
            Console.Clear();
            Console.WriteLine("=== Jogar ===");
            Console.WriteLine("1 - Jogador vs Jogador");
            Console.WriteLine("2 - Jogador vs CPU");
            Console.WriteLine("3 - Voltar");
            Console.Write("Opção: ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    JogadorVsJogador();
                    break;
                case "2":
                    JogadorVsCPU();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        static void JogadorVsJogador()
        {
            Console.Clear();
            Console.Write("Nome do Jogador 1: ");
            string nome1 = Console.ReadLine();
            Console.Write("Nome do Jogador 2: ");
            string nome2 = Console.ReadLine();

            var cards = CriarBaralhoPadrao();
            var deck = new Deck<SuperTrunfoCard>(cards);
            var players = new List<IPlayer<SuperTrunfoCard>>
            {
                new Player<SuperTrunfoCard>(nome1),
                new Player<SuperTrunfoCard>(nome2)
            };

            var game = new SuperTrunfoGame(players, deck);
            game.StartGame();

            Console.WriteLine("Jogo iniciado! Pressione Enter para a próxima rodada...");
            int roundNum = 1;
            while (!game.IsGameOver)
            {
                Console.WriteLine($"\n--- Rodada {roundNum} ---");
                game.NextRound();

                foreach (var p in players)
                    Console.WriteLine($"{p.Name}: {p.Hand.Count} cartas");
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                roundNum++;
            }

            Console.WriteLine("Fim do jogo! Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static void JogadorVsCPU()
        {
            Console.WriteLine("Modo Jogador vs CPU ainda não implementado.");
            Console.ReadKey();
        }

        static void MenuHistorico()
        {
            Console.Clear();
            Console.WriteLine("=== Histórico de Partidas ===");
            var matches = _history.GetAllMatches();
            if (matches.Count == 0)
            {
                Console.WriteLine("Nenhuma partida registrada.");
            }
            else
            {
                foreach (var match in matches.OrderByDescending(m => m.StartTime))
                {
                    Console.WriteLine($"Partida {match.Id.Substring(0,8)} - {match.StartTime:dd/MM/yyyy HH:mm}");
                    Console.WriteLine($"  Jogadores: {string.Join(", ", match.PlayerNames)}");
                    Console.WriteLine($"  Vencedor: {match.Winner}");
                    Console.WriteLine($"  Rodadas: {match.Rounds.Count}");
                    Console.WriteLine($"  Duração: {match.EndTime - match.StartTime:mm\\:ss}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
        }

        static List<SuperTrunfoCard> CriarBaralhoPadrao()
        {

            return new List<SuperTrunfoCard>
            {
                new SuperTrunfoCard("Brasil", new Dictionary<string, int> { { "População", 213_000_000 }, { "Área", 8_515_767 } }),
                new SuperTrunfoCard("EUA", new Dictionary<string, int> { { "População", 331_000_000 }, { "Área", 9_833_517 } }),
                new SuperTrunfoCard("Canadá", new Dictionary<string, int> { { "População", 38_000_000 }, { "Área", 9_984_670 } }),
                new SuperTrunfoCard("Argentina", new Dictionary<string, int> { { "População", 45_000_000 }, { "Área", 2_780_400 } }),
                new SuperTrunfoCard("Alemanha", new Dictionary<string, int> { { "População", 83_000_000 }, { "Área", 357_582 } }),
                new SuperTrunfoCard("França", new Dictionary<string, int> { { "População", 67_000_000 }, { "Área", 643_801 } }),
                new SuperTrunfoCard("Índia", new Dictionary<string, int> { { "População", 1_380_000_000 }, { "Área", 3_287_263 } }),
                new SuperTrunfoCard("China", new Dictionary<string, int> { { "População", 1_400_000_000 }, { "Área", 9_596_961 } })
            };
        }
    }
}
