using System.Collections.Generic;

namespace RpDoc.TournamentResultsAnalyser.Lib
{
    internal class TeamScoreComparer : Comparer<TeamScore>
    {
        public override int Compare(TeamScore teamScoreOfTeamA, TeamScore teamScoreOfTeamB)
        {
            if (teamScoreOfTeamA.Points > teamScoreOfTeamB.Points)
            {
                return -1;
            }

            if (teamScoreOfTeamA.Points < teamScoreOfTeamB.Points)
            {
                return 1;
            }

            if (teamScoreOfTeamA.GoalRate > teamScoreOfTeamB.GoalRate)
            {
                return -1;
            }

            if (teamScoreOfTeamA.GoalRate < teamScoreOfTeamB.GoalRate)
            {
                return 1;
            }

            return 0;
        }
    }
}