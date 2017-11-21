namespace RpDoc.TournamentResultsAnalyser.UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridResult = new System.Windows.Forms.DataGridView();
            this.teamScoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonAnalyseFile = new System.Windows.Forms.Button();
            this.labelSelectedFilePath = new System.Windows.Forms.Label();
            this.buttonOpenXMLFile = new System.Windows.Forms.Button();
            this.labelXMLFilePath = new System.Windows.Forms.Label();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamScoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridResult
            // 
            this.dataGridResult.AllowUserToAddRows = false;
            this.dataGridResult.AllowUserToDeleteRows = false;
            this.dataGridResult.AutoGenerateColumns = false;
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.positionDataGridViewTextBoxColumn,
            this.teamNameDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn,
            this.goalRateDataGridViewTextBoxColumn});
            this.dataGridResult.DataSource = this.teamScoreBindingSource;
            this.dataGridResult.Location = new System.Drawing.Point(3, 157);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.ReadOnly = true;
            this.dataGridResult.Size = new System.Drawing.Size(726, 187);
            this.dataGridResult.TabIndex = 0;
            // 
            // teamScoreBindingSource
            // 
            this.teamScoreBindingSource.DataSource = typeof(RpDoc.TournamentResultsAnalyser.Lib.TeamScore);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(24, 36);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(111, 23);
            this.buttonSelectFile.TabIndex = 2;
            this.buttonSelectFile.Text = "Select File";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonAnalyseFile
            // 
            this.buttonAnalyseFile.Enabled = false;
            this.buttonAnalyseFile.Location = new System.Drawing.Point(24, 76);
            this.buttonAnalyseFile.Name = "buttonAnalyseFile";
            this.buttonAnalyseFile.Size = new System.Drawing.Size(111, 23);
            this.buttonAnalyseFile.TabIndex = 3;
            this.buttonAnalyseFile.Text = "Analyse  the File";
            this.buttonAnalyseFile.UseVisualStyleBackColor = true;
            this.buttonAnalyseFile.Click += new System.EventHandler(this.buttonAnalyseFile_Click);
            // 
            // labelSelectedFilePath
            // 
            this.labelSelectedFilePath.AutoSize = true;
            this.labelSelectedFilePath.Location = new System.Drawing.Point(153, 41);
            this.labelSelectedFilePath.Name = "labelSelectedFilePath";
            this.labelSelectedFilePath.Size = new System.Drawing.Size(0, 13);
            this.labelSelectedFilePath.TabIndex = 4;
            // 
            // buttonOpenXMLFile
            // 
            this.buttonOpenXMLFile.Enabled = false;
            this.buttonOpenXMLFile.Location = new System.Drawing.Point(24, 114);
            this.buttonOpenXMLFile.Name = "buttonOpenXMLFile";
            this.buttonOpenXMLFile.Size = new System.Drawing.Size(111, 23);
            this.buttonOpenXMLFile.TabIndex = 5;
            this.buttonOpenXMLFile.Text = "Open XML File";
            this.buttonOpenXMLFile.UseVisualStyleBackColor = true;
            this.buttonOpenXMLFile.Click += new System.EventHandler(this.buttonOpenXMLFile_Click);
            // 
            // labelXMLFilePath
            // 
            this.labelXMLFilePath.AutoSize = true;
            this.labelXMLFilePath.Location = new System.Drawing.Point(153, 119);
            this.labelXMLFilePath.Name = "labelXMLFilePath";
            this.labelXMLFilePath.Size = new System.Drawing.Size(0, 13);
            this.labelXMLFilePath.TabIndex = 6;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // teamNameDataGridViewTextBoxColumn
            // 
            this.teamNameDataGridViewTextBoxColumn.DataPropertyName = "Team";
            this.teamNameDataGridViewTextBoxColumn.HeaderText = "Team";
            this.teamNameDataGridViewTextBoxColumn.Name = "teamNameDataGridViewTextBoxColumn";
            this.teamNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Points";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // goalRateDataGridViewTextBoxColumn
            // 
            this.goalRateDataGridViewTextBoxColumn.DataPropertyName = "GoalRate";
            this.goalRateDataGridViewTextBoxColumn.HeaderText = "Goal Rate";
            this.goalRateDataGridViewTextBoxColumn.Name = "goalRateDataGridViewTextBoxColumn";
            this.goalRateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 342);
            this.Controls.Add(this.labelXMLFilePath);
            this.Controls.Add(this.buttonOpenXMLFile);
            this.Controls.Add(this.labelSelectedFilePath);
            this.Controls.Add(this.buttonAnalyseFile);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.dataGridResult);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamScoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridResult;
        private System.Windows.Forms.BindingSource teamScoreBindingSource;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonAnalyseFile;
        private System.Windows.Forms.Label labelSelectedFilePath;
        private System.Windows.Forms.Button buttonOpenXMLFile;
        private System.Windows.Forms.Label labelXMLFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalRateDataGridViewTextBoxColumn;
    }
}

