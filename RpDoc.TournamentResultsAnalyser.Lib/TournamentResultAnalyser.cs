using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RpDoc.TournamentResultsAnalyser.Lib
{
    //todo: Service Schnittstelle
    public static class TournamentResultAnalyser
    {
        public static TournamentAnalyseResult Process(string testFilePath)
        {
            var fileParseResults = ParseTheASCIIFile(testFilePath);
            if (fileParseResults.Errors.Any())
            {
                return new TournamentAnalyseResult(fileParseResults.Errors);
            }

            var teamScores = AnalyseMatchResults(fileParseResults.MatchResults);

            var analyseResult = new TournamentAnalyseResult(teamScores);
            var xmlFilePath = WriteTournamentResultToXMLFile(analyseResult);

            analyseResult.XMLFilePath = xmlFilePath;
            return analyseResult;
        }

        private static string WriteTournamentResultToXMLFile(TournamentAnalyseResult tournamentResult)
        {
            //todo: XML File Path from AppSettings
            var xmlFileName = System.IO.Path.GetTempFileName().Replace(".tmp", ".xml");
            var serializer = new XmlSerializer(typeof(TournamentAnalyseResult));
            using (var stream = File.OpenWrite(xmlFileName))
            {
                serializer.Serialize(stream, tournamentResult);
            }

            return xmlFileName;
        }

        private static List<TeamScore> AnalyseMatchResults(IReadOnlyCollection<MatchResult> matchResults)
        {
            var listeVonTeamScores = new List<TeamScore>(); ;

            foreach (var matchResult in matchResults)
            {
                var scoreFuerTeamA = listeVonTeamScores.SingleOrDefault(itm => itm.Team == matchResult.NameOfTeamA);
                if (scoreFuerTeamA == null)
                {
                    scoreFuerTeamA = new TeamScore(matchResult.NameOfTeamA);
                    listeVonTeamScores.Add(scoreFuerTeamA);
                }

                var scoreFuerTeamB = listeVonTeamScores.SingleOrDefault(itm => itm.Team == matchResult.NameOfTeamB);
                if (scoreFuerTeamB == null)
                {
                    scoreFuerTeamB = new TeamScore(matchResult.NameOfTeamB);
                    listeVonTeamScores.Add(scoreFuerTeamB);
                }

                if (matchResult.NameOfWinner == matchResult.NameOfTeamA)
                {
                    scoreFuerTeamA.AddPoints(2);
                }
                else if (matchResult.NameOfWinner == matchResult.NameOfTeamB)
                {
                    scoreFuerTeamB.AddPoints(2);
                }
                else
                {
                    scoreFuerTeamA.AddPoints(1);
                    scoreFuerTeamB.AddPoints(1);
                }

                scoreFuerTeamA.AddGoalRate(matchResult.NumberOfGoalsA);
                scoreFuerTeamB.AddGoalRate(matchResult.NumberOfGoalsB);
            }

            //Sort the TeamScores and set the Positions
            var teamScoreComparer = new TeamScoreComparer();
            listeVonTeamScores.Sort(teamScoreComparer);

            listeVonTeamScores.ForEach(ts => ts.Position = listeVonTeamScores.IndexOf(ts) + 1);

            return listeVonTeamScores;
        }

        private static FileParseResult ParseTheASCIIFile(string testFilePath)
        {
            var parseResult = new FileParseResult();

            var matchResults = new List<MatchResult>();
            using (var dateiReader = new StreamReader(testFilePath, Encoding.ASCII))
            {
                var fileRow = string.Empty;
                while ((fileRow = dateiReader.ReadLine()) != null)
                {
                    var infosInRow = fileRow.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var numberOfGoalsA = ushort.Parse(infosInRow[2]);
                    var numberOfGoalsB = ushort.Parse(infosInRow[3]);
                    var matchResult = new MatchResult(infosInRow[0], infosInRow[1], numberOfGoalsA, numberOfGoalsB);

                    var validationResult = ValidateMatchResult(matchResult);
                    if (validationResult.Any())
                    {
                        //todo: Think about it : is it better, to validate all results before exiting?? 
                        parseResult.Errors = validationResult.ToList();
                        return parseResult;
                    }

                    matchResults.Add(matchResult);
                }
            }

            if (matchResults.Count < 2 || matchResults.Count > 10)
            {
                var errors = new List<string> { "There should be at least 2 Teams and at most 10 Teams in a Tornument." };
                parseResult.Errors = errors;
                return parseResult;
            }

            parseResult.MatchResults = matchResults;
            return parseResult;
        }

        //todo: Use FluentValidation and move validation logic from here, make a validator that can be reused.
        private static IEnumerable<string> ValidateMatchResult(MatchResult matchResult)
        {
            if (matchResult.NameOfTeamA.Length > 50
                || matchResult.NameOfTeamB.Length > 50)
            {
                yield return "Team Name should not contain more than 50 characters.";
            }

            if (matchResult.NameOfTeamA.Any(chr => char.IsLower(chr) || char.IsLetter(chr) == false)
                || matchResult.NameOfTeamB.Any(chr => char.IsLower(chr) || char.IsLetter(chr) == false))
            {
                yield return "Each team name should contain only uppercase letters";
            }

            if (matchResult.NumberOfGoalsA < 0 || matchResult.NumberOfGoalsA > 20
                || matchResult.NumberOfGoalsB < 0 || matchResult.NumberOfGoalsB > 20)
            {
                yield return "The goals should be integer and between 0 and 20";
            }
        }
    }
}