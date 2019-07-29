using HackathonTestAutomation.Common.Classes.Helpers;
using HackathonTestAutomation.Common.Enums;
using HackathonTestAutomation.TestRunner.Classes;
using HackathonTestAutomation.TestRunner.Classes.Entities;
using HackathonTestAutomation.TestRunner.Classes.Extensions;
using HackathonTestAutomation.TestRunner.Classes.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HackathonTestAutomation.TestRunner.Forms
{
    public partial class TestRunnerForm : Form
    {
        private List<TestCase> TestCases { get; set; }

        private List<TestCase> TestCasesRows
        {
            get
            {
                var dataSource = (List<TestCase>)dgvTestCases.DataSource;

                if (dataSource == null)
                {
                    dataSource = new List<TestCase>();
                }

                return dataSource;
            }
            set
            {
                dgvTestCases.DataSource = null;
                dgvTestCases.DataSource = value;
                this.UpdateRowsColor();
                dgvTestCases.Columns["Execute"].Frozen = true;

                this.UpdateTestMethodsCount();
            }
        }

        public TestRunnerForm()
        {
            InitializeComponent();
            InitializeFilterValues();
            InitializeGrid();
        }

        /// <summary>
        /// Initializes the grid data
        /// </summary>
        private void InitializeGrid()
        {
            var testDiscoverer = new TestDiscoverer();
            this.TestCases = testDiscoverer.GetTests();

            this.TestCases = this.TestCases.OrderBy(t => t.Priority).ThenBy(p => p.Severity).ToList();
            this.TestCasesRows = this.TestCases;
        }

        /// <summary>
        /// Updates the rows color according the test method status
        /// </summary>
        private void UpdateRowsColor()
        {
            foreach (DataGridViewRow row in dgvTestCases.Rows)
            {
                var testCase = row.GetDataBoundItem();

                foreach (DataGridViewCell rowCell in row.Cells)
                {
                    rowCell.Style.BackColor = testCase.StatusColor;
                }
            }
        }

        /// <summary>
        /// Updates the test method count
        /// </summary>
        private void UpdateTestMethodsCount()
        {
            grpTestCases.Text = string.Format($"Test cases ({this.TestCasesRows.Count}/{this.TestCases.Count})");
        }

        private void btnRunTestCase_Click(object sender, EventArgs e)
        {
            var testMethods = this.TestCasesRows;
            var testMethodsToBeExecuted = testMethods.Where(t => t.Execute).ToArray();

            if (testMethodsToBeExecuted.Count() == 0)
            {
                MessageBox.Show("Please select a test to be executed.", this.Text, MessageBoxButtons.OK);

                return;
            }

            var testRunner = new TestRunnerClass();
            testRunner.Run(testMethodsToBeExecuted);

            this.TestCasesRows = testMethods;

            this.ShowFinishExecutionMessageBox(testMethodsToBeExecuted);
        }

        private void InitializeFilterValues()
        {
            cbxPriority.Initialize<PriorityEnum>();
            cbxSeverity.Initialize<SeverityEnum>();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var excelReport = new ExcelReport();
            excelReport.Run(dgvTestCases);
        }

        /// <summary>
        /// Shows the data from the test execution
        /// </summary>
        /// <param name="testMethodsExecuted">Test methods executed</param>
        private void ShowFinishExecutionMessageBox(TestCase[] testMethodsExecuted)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{testMethodsExecuted.Count()} test(s) executed.");
            stringBuilder.AppendLine();

            testMethodsExecuted
                .GroupBy(t => t.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList()
                .ForEach(status =>
                {
                    stringBuilder.AppendLine($"{status.Status}: {status.Count}");
                    stringBuilder.AppendLine();
                });

            MessageBox.Show(stringBuilder.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTestCases.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTestCases.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            cbxPriority.ResetText();
            cbxSeverity.ResetText();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = this.TestCases.AsEnumerable();

            if (txtName.Text == string.Empty == false)
            {
                query = query.Where(testCase => testCase.Name.ToLower().Contains(txtName.Text.ToLower()));
            }

            if (cbxPriority.Text == string.Empty == false)
            {
                query = query.Where(testCase => testCase.Priority == cbxPriority.Text);
            }

            if (cbxSeverity.Text == string.Empty == false)
            {
                query = query.Where(testCase => testCase.Severity == cbxSeverity.Text);
            }

            this.TestCasesRows = query.ToList();
        }
    }
}
