namespace RpDoc.TournamentResultsAnalyser.Lib
{
    public class TeamScore
    {
        public TeamScore(string team)
        {
            Team = team;
        }

        public TeamScore()
        {
        }

        public int Position { get; set; }

        public string Team { get; set; }

        public int Points { get; set; }

        public int GoalRate { get; set; }


        public void AddPoints(int newPoints)
        {
            Points = Points + newPoints;
        }

        public void AddGoalRate(int newGoals)
        {
            GoalRate = GoalRate + newGoals;
        }
    }
}