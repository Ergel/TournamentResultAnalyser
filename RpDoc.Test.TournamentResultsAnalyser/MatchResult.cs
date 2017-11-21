namespace RpDoc.Test.TournamentResultsAnalyser
{
    public class MatchResult
    {
        public MatchResult(string nameofTeamA, string nameOfTeamB, int numberOfGoalsA, int numberOfGoalsB)
        {
            NameOfTeamA = nameofTeamA;
            NameOfTeamB = nameOfTeamB;
            NumberOfGoalsA = numberOfGoalsA;
            NumberOfGoalsB = numberOfGoalsB;

            SetResult();
        }

        private void SetResult()
        {
            if (NumberOfGoalsA > NumberOfGoalsB)
            {
                NameOfWinner = NameOfTeamA;
            }
            else if (NumberOfGoalsA < NumberOfGoalsB)
            {
                NameOfWinner = NameOfTeamB;
            }
            else
            {
                NameOfWinner = null;
            }
        }

        public string NameOfTeamA { get; }
        public string NameOfTeamB { get; }
        public int NumberOfGoalsA { get; }
        public int NumberOfGoalsB { get; }

        public string NameOfWinner { get; private set; }

    }
}