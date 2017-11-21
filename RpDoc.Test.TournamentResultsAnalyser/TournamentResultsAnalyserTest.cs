using System.IO;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RpDoc.TournamentResultsAnalyser.Lib;

namespace RpDoc.Test.TournamentResultsAnalyser
{
    //todo: Negative Tests - Validation-Logic
    //todo: Test content of generated XML File

    [TestFixture]
    public class TournamentResultsAnalyserTest
    {
        [Test]
        public void TestAnalyseTournamentResultsFromSample()
        {
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("A B 3 0");
            contentBuilder.AppendLine("B C 0 0");
            contentBuilder.AppendLine("A C 2 2");

            var testFilePath = ErzeugeTestFileWithMatchResults(contentBuilder.ToString());
            var analyseResult = TournamentResultAnalyser.Process(testFilePath);
            Assert.That(analyseResult.XMLFilePath, Is.Not.Null);
            Assert.That(analyseResult.Count, Is.EqualTo(3));

            var expectedFirstResult = analyseResult.TeamScores[0];
            var expectedSecondResult = analyseResult.TeamScores[1];
            var expectedThirdResult = analyseResult.TeamScores[2];

            Assert.That(expectedFirstResult.Position, Is.EqualTo(1));
            Assert.That(expectedFirstResult.Team, Is.EqualTo("A"));
            Assert.That(expectedFirstResult.Points, Is.EqualTo(3));
            Assert.That(expectedFirstResult.GoalRate, Is.EqualTo(5));

            Assert.That(expectedSecondResult.Position, Is.EqualTo(2));
            Assert.That(expectedSecondResult.Team, Is.EqualTo("C"));
            Assert.That(expectedSecondResult.Points, Is.EqualTo(2));
            Assert.That(expectedSecondResult.GoalRate, Is.EqualTo(2));

            Assert.That(expectedThirdResult.Position, Is.EqualTo(3));
            Assert.That(expectedThirdResult.Team, Is.EqualTo("B"));
            Assert.That(expectedThirdResult.Points, Is.EqualTo(1));
            Assert.That(expectedThirdResult.GoalRate, Is.EqualTo(0));
        }

        [Test]
        public void TestAnalyseTournamentResultsFromSample_1()
        {
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("ITALY USA 1 1");
            contentBuilder.AppendLine("PARAGUAY ITALY 2 2");
            contentBuilder.AppendLine("USA PARAGUAY 1 0");

            var testFilePath = ErzeugeTestFileWithMatchResults(contentBuilder.ToString());
            var analyseResult = TournamentResultAnalyser.Process(testFilePath);
            Assert.That(analyseResult.XMLFilePath, Is.Not.Null);
            Assert.That(analyseResult.Count, Is.EqualTo(3));

            var expectedFirstResult = analyseResult.TeamScores[0];
            var expectedSecondResult = analyseResult.TeamScores[1];
            var expectedThirdResult = analyseResult.TeamScores[2];

            Assert.That(expectedFirstResult.Position, Is.EqualTo(1));
            Assert.That(expectedFirstResult.Team, Is.EqualTo("USA"));
            Assert.That(expectedFirstResult.Points, Is.EqualTo(3));
            Assert.That(expectedFirstResult.GoalRate, Is.EqualTo(2));

            Assert.That(expectedSecondResult.Position, Is.EqualTo(2));
            Assert.That(expectedSecondResult.Team, Is.EqualTo("ITALY"));
            Assert.That(expectedSecondResult.Points, Is.EqualTo(2));
            Assert.That(expectedSecondResult.GoalRate, Is.EqualTo(3));

            Assert.That(expectedThirdResult.Position, Is.EqualTo(3));
            Assert.That(expectedThirdResult.Team, Is.EqualTo("PARAGUAY"));
            Assert.That(expectedThirdResult.Points, Is.EqualTo(1));
            Assert.That(expectedThirdResult.GoalRate, Is.EqualTo(2));
        }

        [Test]
        public void TestAnalyseTournamentResultsFromSample_3()
        {
            var contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("BRASIL CROATIA 0 3");
            contentBuilder.AppendLine("JAPAN AUSTRALIA 1 0");
            contentBuilder.AppendLine("AUSTRALIA BRASIL 0 1");
            contentBuilder.AppendLine("BRASIL JAPAN 2 0");
            contentBuilder.AppendLine("JAPAN CROATIA 0 0");
            contentBuilder.AppendLine("CROATIA AUSTRALIA 0 0");

            var testFilePath = ErzeugeTestFileWithMatchResults(contentBuilder.ToString());
            var analyseResult = TournamentResultAnalyser.Process(testFilePath);
            Assert.That(analyseResult.XMLFilePath, Is.Not.Null);
            Assert.That(analyseResult.Count, Is.EqualTo(4));

            var expectedFirstResult = analyseResult.TeamScores[0];
            var expectedSecondResult = analyseResult.TeamScores[1];
            var expectedThirdResult = analyseResult.TeamScores[2];
            var expectedFourthResult = analyseResult.TeamScores[3];

            Assert.That(expectedFirstResult.Position, Is.EqualTo(1));
            Assert.That(expectedFirstResult.Team, Is.EqualTo("BRASIL"));
            Assert.That(expectedFirstResult.Points, Is.EqualTo(4));
            Assert.That(expectedFirstResult.GoalRate, Is.EqualTo(3));

            Assert.That(expectedSecondResult.Position, Is.EqualTo(2));
            Assert.That(expectedSecondResult.Team, Is.EqualTo("CROATIA"));
            Assert.That(expectedSecondResult.Points, Is.EqualTo(4));
            Assert.That(expectedSecondResult.GoalRate, Is.EqualTo(3));

            Assert.That(expectedThirdResult.Position, Is.EqualTo(3));
            Assert.That(expectedThirdResult.Team, Is.EqualTo("JAPAN"));
            Assert.That(expectedThirdResult.Points, Is.EqualTo(3));
            Assert.That(expectedThirdResult.GoalRate, Is.EqualTo(1));

            Assert.That(expectedFourthResult.Position, Is.EqualTo(4));
            Assert.That(expectedFourthResult.Team, Is.EqualTo("AUSTRALIA"));
            Assert.That(expectedFourthResult.Points, Is.EqualTo(1));
            Assert.That(expectedFourthResult.GoalRate, Is.EqualTo(0));

        }

        private string ErzeugeTestFileWithMatchResults(string fileContent)
        {
            //todo: Read content directly from test file with testdata
            var tempFileName = System.IO.Path.GetTempFileName();
            using (var fileWriter = File.CreateText(tempFileName))
            {
                fileWriter.Write(fileContent);
            }

            return tempFileName;
        }
    }
}
