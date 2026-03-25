using System;
using System.Collections.Generic;

namespace CardGameEngine
{
    
    public class PlayerData
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int TotalMatches { get; set; }

        public PlayerData(string name)
        {
            Name = name;
            Wins = 0;
            Losses = 0;
            TotalMatches = 0;
        }

        public void RecordWin()
        {
            Wins++;
            TotalMatches++;
        }

        public void RecordLoss()
        {
            Losses++;
            TotalMatches++;
        }
    }

 
    public class RoundRecord
    {
        public int RoundNumber { get; set; }
        public string AttributeUsed { get; set; }
        public Dictionary<string, string> CardsPlayed { get; set; } 
        public string Winner { get; set; } 
        public DateTime Timestamp { get; set; }

        public RoundRecord()
        {
            CardsPlayed = new Dictionary<string, string>();
            Timestamp = DateTime.Now;
        }
    }

    public class Match
    {
        public string Id { get; set; } 
        public List<string> PlayerNames { get; set; } 
        public string Winner { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<RoundRecord> Rounds { get; set; }

        public Match()
        {
            Id = Guid.NewGuid().ToString();
            PlayerNames = new List<string>();
            Rounds = new List<RoundRecord>();
            StartTime = DateTime.Now;
        }
    }

    public class GameHistory
    {
        private const string HistoryFile = "history.json";
        private List<Match> _matches;

        public GameHistory()
        {
            Load();
        }

        public void AddMatch(Match match)
        {
            match.EndTime = DateTime.Now;
            _matches.Add(match);
            Save();
        }

        public List<Match> GetAllMatches()
        {
            return _matches;
        }

        private void Load()
        {
            if (File.Exists(HistoryFile))
            {
                string json = File.ReadAllText(HistoryFile);
                _matches = JsonSerializer.Deserialize<List<Match>>(json) ?? new List<Match>();
            }
            else
            {
                _matches = new List<Match>();
            }
        }

        private void Save()
        {
            string json = JsonSerializer.Serialize(_matches, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(HistoryFile, json);
        }
    }
}