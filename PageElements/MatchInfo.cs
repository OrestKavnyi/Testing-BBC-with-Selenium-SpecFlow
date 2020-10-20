using System;

namespace UnitTestProject.PageElements
{
    public sealed class MatchInfo
    {
        public Teams GetTeams { get; }
        public Score GetScore { get; }

        public MatchInfo(Teams teams, int score1, int score2)
        {
            GetTeams = teams;
            GetScore = new Score(score1, score2);
        }
        public MatchInfo(string team1, string team2, int score1, int score2)
        {
            GetTeams = new Teams(team1, team2);
            GetScore = new Score(score1, score2);
        }
        public sealed class Score
        {
            public int Score1 { get; }
            public int Score2 { get; }
            public Score(int score1, int score2)
            {
                Score1 = score1;
                Score2 = score2;
            }

            public override bool Equals(object obj)
            {
                return (obj is Score other) && Score1 == other.Score1 && Score2 == other.Score2;
            }

            public override int GetHashCode()
            {
                return Score1.GetHashCode() ^ Score2.GetHashCode();
            }
        }
        public sealed class Teams
        {
            public string Team1 { get; }
            public string Team2 { get; }
            public Teams(string team1, string team2)
            {
                Team1 = team1;
                Team2 = team2;
            }

            public override bool Equals(object obj)
            {
                return (obj is Teams other) && Team1 == other.Team1 && Team2 == other.Team2;
            }
            public override int GetHashCode()
            {
                return Team1.GetHashCode() ^ Team2.GetHashCode();
            }
        }
        public override bool Equals(object obj)
        {
            return (obj is MatchInfo other) && GetTeams.Equals(other.GetTeams) && GetScore.Equals(other.GetScore);
        }
        public override int GetHashCode()
        {
            return GetTeams.GetHashCode() ^ GetScore.GetHashCode();
        }
    }
}