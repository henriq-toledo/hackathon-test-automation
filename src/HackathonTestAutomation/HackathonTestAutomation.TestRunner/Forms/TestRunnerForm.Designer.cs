using System;
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxPriority = new System.Windows.Forms.ComboBox();
            this.cbxSeverity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRunTestCase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grpTestCases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCases)).BeginInit();
            this.grpFilters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTestCases
            // 
            this.grpTestCases.Controls.Add(this.dgvTestCases);
            this.grpTestCases.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpTestCases.Location = new System.Drawing.Point(0, 94);
            this.grpTestCases.Margin = new System.Windows.Forms.Padding(2);
            this.grpTestCases.Name = "grpTestCases";
            this.grpTestCases.Padding = new System.Windows.Forms.Padding(2);
            this.grpTestCases.Size = new System.Drawing.Size(1011, 515);
            this.grpTestCases.TabIndex = 0;
            this.grpTestCases.TabStop = false;
            this.grpTestCases.Text = "Test Cases";
            // 
            // dgvTestCases
            // 
            this.dgvTestCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestCases.Location = new System.Drawing.Point(2, 15);
            this.dgvTestCases.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTestCases.Name = "dgvTestCases";
            this.dgvTestCases.RowHeadersVisible = false;
            this.dgvTestCases.RowTemplate.Height = 24;
            this.dgvTestCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestCases.Size = new System.Drawing.Size(1007, 498);
            this.dgvTestCases.TabIndex = 0;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.btnReset);
            this.grpFilters.Controls.Add(this.btnSearch);
            this.grpFilters.Controls.Add(this.cbxPriority);
            this.grpFilters.Controls.Add(this.cbxSeverity);
            this.grpFilters.Controls.Add(this.label4);
            this.grpFilters.Controls.Add(this.lblPriority);
            this.grpFilters.Controls.Add(this.lblName);
            this.grpFilters.Controls.Add(this.txtName);
            this.grpFilters.Location = new System.Drawing.Point(2, 10);
            this.grpFilters.Margin = new System.Windows.Forms.Padding(2);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Padding = new System.Windows.Forms.Padding(2);
            this.grpFilters.Size = new System.Drawing.Size(755, 80);
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(676, 20);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(676, 47);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxPriority
            // 
            this.cbxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPriority.FormattingEnabled = true;
            this.cbxPriority.Location = new System.Drawing.Point(59, 41);
            this.cbxPriority.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPriority.Name = "cbxPriority";
            this.cbxPriority.Size = new System.Drawing.Size(279, 21);
            this.cbxPriority.TabIndex = 9;
            // 
            // cbxSeverity
            // 
            this.cbxSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSeverity.FormattingEnabled = true;
            this.cbxSeverity.Location = new System.Drawing.Point(394, 41);
            this.cbxSeverity.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSeverity.Name = "cbxSeverity";
            this.cbxSeverity.Size = new System.Drawing.Size(278, 21);
            this.cbxSeverity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Severity:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(9, 44);
            this.lblPriority.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(41, 13);
            this.lblPriority.TabIndex = 5;
            this.lblPriority.Text = "Priority:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 20);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(59, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(613, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(82, 20);
            this.btnCheckAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAll.TabIndex = 15;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(4, 20);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 14;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRunTestCase
            // 
            this.btnRunTestCase.Location = new System.Drawing.Point(4, 19);
            this.btnRunTestCase.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunTestCase.Name = "btnRunTestCase";
            this.btnRunTestCase.Size = new System.Drawing.Size(75, 23);
            this.btnRunTestCase.TabIndex = 13;
            this.btnRunTestCase.Text = "Run";
            this.btnRunTestCase.UseVisualStyleBackColor = true;
            this.btnRunTestCase.Click += new System.EventHandler(this.btnRunTestCase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUncheckAll);
            this.groupBox1.Controls.Add(this.btnCheckAll);
            this.groupBox1.Controls.Add(this.btnRunTestCase);
            this.groupBox1.Location = new System.Drawing.Point(761, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(161, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Location = new System.Drawing.Point(82, 47);
            this.btnUncheckAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnUncheckAll.TabIndex = 15;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Location = new System.Drawing.Point(926, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(83, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reports";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 47);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Test Result";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // TestRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.grpTestCases);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1027, 597);
            this.Name = "TestRunnerForm";
            this.Text = "Test Runner";
            this.grpTestCases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestCases)).EndInit();
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }        

        #endregion

        private System.Windows.Forms.GroupBox grpTestCases;
        private System.Windows.Forms.DataGridView dgvTestCases;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbxSeverity;
        private System.Windows.Forms.ComboBox cbxPriority;
        private System.Windows.Forms.Button btnSearch;
        private Button btnRunTestCase;
        private Button btnExcel;
        private Button btnCheckAll;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnReset;
        private Button btnUncheckAll;
        private Button button1;
    }
}

