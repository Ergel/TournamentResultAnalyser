using System;
using System.Linq;
using System.Windows.Forms;
using RpDoc.TournamentResultsAnalyser.Lib;

namespace RpDoc.TournamentResultsAnalyser.UI
{
    public partial class Form1 : Form
    {
        private string soccerResultsFilePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            using (var selectFileDialog = new OpenFileDialog())
            {
                selectFileDialog.Filter = "Text|*.txt";
                selectFileDialog.DefaultExt = "txt";
                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    soccerResultsFilePath = selectFileDialog.FileName;
                    labelSelectedFilePath.Text = soccerResultsFilePath;
                    buttonAnalyseFile.Enabled = true;
                }
            }
        }

        private void buttonAnalyseFile_Click(object sender, EventArgs e)
        {
            var analyseResult = TournamentResultAnalyser.Process(soccerResultsFilePath);

            if (analyseResult.ErrorsList.Any())
            {
                var errorMessage = string.Join(System.Environment.NewLine, analyseResult.ErrorsList);
                MessageBox.Show(this, errorMessage, "Selected File has not valid content.");
                return;
            }

            dataGridResult.DataSource = analyseResult.TeamScores;

            buttonOpenXMLFile.Enabled = true;
            labelXMLFilePath.Text = analyseResult.XMLFilePath;
        }

        private void buttonOpenXMLFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(labelXMLFilePath.Text);
        }
    }
}
