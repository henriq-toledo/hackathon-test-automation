using System.Drawing;
using System.Windows.Forms;

namespace HackathonTestAutomation.TestRunner.Forms
{
    partial class TestRunnerForm
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
            this.grpTestCases = new System.Windows.Forms.GroupBox();
            this.dgvTestCases = new System.Windows.Forms.DataGridView();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.btnExportResults = new System.Windows.Forms.Button();
            this.btnRunTestCase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxPriority = new System.Windows.Forms.ComboBox();
            this.cbxSeverity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.grpTestCases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCases)).BeginInit();
            this.grpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTestCases
            // 
            this.grpTestCases.Controls.Add(this.dgvTestCases);
            this.grpTestCases.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpTestCases.Location = new System.Drawing.Point(0, 215);
            this.grpTestCases.Name = "grpTestCases";
            this.grpTestCases.Size = new System.Drawing.Size(1900, 538);
            this.grpTestCases.TabIndex = 0;
            this.grpTestCases.TabStop = false;
            this.grpTestCases.Text = "Test Cases";
            // 
            // dgvTestCases
            // 
            this.dgvTestCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestCases.Location = new System.Drawing.Point(3, 18);
            this.dgvTestCases.Name = "dgvTestCases";
            this.dgvTestCases.RowHeadersVisible = false;
            this.dgvTestCases.RowTemplate.Height = 24;
            this.dgvTestCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestCases.Size = new System.Drawing.Size(1894, 517);
            this.dgvTestCases.TabIndex = 0;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.btnCheckAll);
            this.grpFilters.Controls.Add(this.btnExportResults);
            this.grpFilters.Controls.Add(this.btnRunTestCase);
            this.grpFilters.Controls.Add(this.label1);
            this.grpFilters.Controls.Add(this.txtClass);
            this.grpFilters.Controls.Add(this.btnSearch);
            this.grpFilters.Controls.Add(this.cbxPriority);
            this.grpFilters.Controls.Add(this.cbxSeverity);
            this.grpFilters.Controls.Add(this.label4);
            this.grpFilters.Controls.Add(this.lblPriority);
            this.grpFilters.Controls.Add(this.lblMethod);
            this.grpFilters.Controls.Add(this.txtMethod);
            this.grpFilters.Location = new System.Drawing.Point(3, 12);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(1531, 182);
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            // 
            // btnExportResults
            // 
            this.btnExportResults.Location = new System.Drawing.Point(607, 127);
            this.btnExportResults.Name = "btnExportResults";
            this.btnExportResults.Size = new System.Drawing.Size(75, 49);
            this.btnExportResults.TabIndex = 14;
            this.btnExportResults.Text = "Export Results";
            this.btnExportResults.UseVisualStyleBackColor = true;
            this.btnExportResults.Click += new System.EventHandler(this.btnExportResults_Click);
            // 
            // btnRunTestCase
            // 
            this.btnRunTestCase.Location = new System.Drawing.Point(607, 33);
            this.btnRunTestCase.Name = "btnRunTestCase";
            this.btnRunTestCase.Size = new System.Drawing.Size(75, 74);
            this.btnRunTestCase.TabIndex = 13;
            this.btnRunTestCase.Text = "Run";
            this.btnRunTestCase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Class:";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(95, 80);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(135, 22);
            this.txtClass.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(182, 127);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(176, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cbxPriority
            // 
            this.cbxPriority.FormattingEnabled = true;
            this.cbxPriority.Location = new System.Drawing.Point(322, 33);
            this.cbxPriority.Name = "cbxPriority";
            this.cbxPriority.Size = new System.Drawing.Size(121, 24);
            this.cbxPriority.TabIndex = 9;
            // 
            // cbxSeverity
            // 
            this.cbxSeverity.FormattingEnabled = true;
            this.cbxSeverity.Location = new System.Drawing.Point(317, 80);
            this.cbxSeverity.Name = "cbxSeverity";
            this.cbxSeverity.Size = new System.Drawing.Size(121, 24);
            this.cbxSeverity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Severity:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(259, 35);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(52, 17);
            this.lblPriority.TabIndex = 5;
            this.lblPriority.Text = "Priority";
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(26, 40);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(59, 17);
            this.lblMethod.TabIndex = 4;
            this.lblMethod.Text = "Method:";
            // 
            // txtMethod
            // 
            this.txtMethod.Location = new System.Drawing.Point(95, 35);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(135, 22);
            this.txtMethod.TabIndex = 0;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(472, 40);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(88, 46);
            this.btnCheckAll.TabIndex = 15;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // TestRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 753);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.grpTestCases);
            this.MinimumSize = new System.Drawing.Size(1918, 800);
            this.Name = "TestRunnerForm";
            this.Text = "Form1";
            this.grpTestCases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCases)).EndInit();
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTestCases;
        private System.Windows.Forms.DataGridView dgvTestCases;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.ComboBox cbxSeverity;
        private System.Windows.Forms.ComboBox cbxPriority;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClass;
        private Button btnRunTestCase;
        private Button btnExportResults;
        private Button btnCheckAll;
    }
}

