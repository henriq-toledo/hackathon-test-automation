using HackathonTestAutomation.Common.Enums;
using HackathonTestAutomation.TestRunner.Classes;
using HackathonTestAutomation.TestRunner.Classes.Entities;
using HackathonTestAutomation.TestRunner.Classes.Extensions;
using HackathonTestAutomation.TestRunner.Classes.Reports;
using HackathonTestAutomation.TestRunner.Classes.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            SetCbxDatasources();
            HandleEvents();
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
            // TODO grbTestMethods.Text = string.Format($"Test methods ({this.TestMethodRows.Count})");
        }

        private void HandleEvents()
        {
            btnSearch.Click += BtnSearch_Click;            
            btnRunTestCase.Click += BtnRunTestCase_Click;
        }

        private void BtnRunTestCase_Click(object sender, EventArgs e)
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
   
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // TODO filter
        }

        private void SetCbxDatasources()
        {
            List<string> priorityList = new List<string>();
            List<string> severityList = new List<string>();

            priorityList.Add("");
            severityList.Add("");

            foreach (PriorityEnum item in Enum.GetValues(typeof(PriorityEnum)))
            {
                priorityList.Add(item.GetDescription());
            }

            foreach (SeverityEnum item in Enum.GetValues(typeof(SeverityEnum)))
            {
                severityList.Add(item.GetDescription());
            }

            cbxPriority.SelectedIndex = -1;
            cbxSeverity.SelectedIndex = -1;

            cbxSeverity.SelectedItem = 0;

            cbxPriority.DataSource = priorityList;
            cbxSeverity.DataSource = severityList;
        }

        private IEnumerable<TestCase> GetTestCasesToRun()
        {
            var testCasesToRun = dgvTestCases.Rows;
            var testCases = new List<TestCase>();
            
            foreach (DataGridViewRow tc in testCasesToRun)
            {
                var testCase = (TestCase)tc.DataBoundItem;

                if (testCase.Execute == true)
                {
                    testCases.Add(testCase);
                }
            }

            return testCases;
        }

        private void btnExportResults_Click(object sender, EventArgs e)
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
            DataGridViewRowCollection rows = dgvTestCases.Rows;

            if (btnCheckAll.Text.Equals("Check All"))
            {
                foreach (DataGridViewRow row in rows)
                {
                    row.Cells[0].Value = true;
                }

                btnCheckAll.Text = "Uncheck All";
            }
            else
            {
                foreach (DataGridViewRow row in rows)
                {
                    row.Cells[0].Value = false;
                }

                btnCheckAll.Text = "Check All";
            }
        }
    }
}
