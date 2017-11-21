using System.Collections.Generic;

namespace RpDoc.TournamentResultsAnalyser.Lib
{
    internal class FileParseResult
    {
        public IReadOnlyCollection<MatchResult> MatchResults { get; set; }
        public List<string> Errors { get; set; }

        public FileParseResult()
        {
            Errors = new List<string>();
        }
    }
}