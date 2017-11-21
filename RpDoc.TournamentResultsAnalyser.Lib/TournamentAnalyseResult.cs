using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace RpDoc.TournamentResultsAnalyser.Lib
{
    [Serializable]
    [XmlInclude(typeof(TeamScore))]
    public class TournamentAnalyseResult
    {
        [XmlIgnore]
        public List<string> ErrorsList { get; private set; }

        [System.Xml.Serialization.XmlArray]
        public List<TeamScore> TeamScores { get; }

        public TournamentAnalyseResult(List<TeamScore> list)
            : this(new List<string>())
        {
            TeamScores = list;
        }

        public TournamentAnalyseResult(List<string> errorsList)
        {
            ErrorsList = errorsList;
        }

        public TournamentAnalyseResult()
        {
            TeamScores = new List<TeamScore>();
        }

        public string XMLFilePath { get; set; }

        public int Count => TeamScores.Count;
    }
}