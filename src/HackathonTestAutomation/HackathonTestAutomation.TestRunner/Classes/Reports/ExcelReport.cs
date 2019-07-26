using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HackathonTestAutomation.TestRunner.Classes.Extensions;
using HackathonTestAutomation.TestRunner;

namespace HackathonTestAutomation.TestRunner.Classes.Reports
{
    internal class ExcelReport
    {
        private const string _applicationName = "Test Runner";
        /// <summary>
        /// Runs the report
        /// </summary>
        /// <param name="dataGridView">The data grid view to generate the report</param>
        internal void Run(DataGridView dataGridView)
        {
            var excelFileName = this.CreateFileName();

            this.CreateReport(excelFileName, dataGridView);

            this.OpenReport(excelFileName);
        }

        private void OpenReport(string excelFileName)
        {
            if (MessageBox.Show($"The excel file '{excelFileName}' was created, do you would like open it?",
                _applicationName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(excelFileName);
            }
        }

        private string CreateFileName()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss");

            var excelFileName = string.Format($@"{desktopPath}\{_applicationName} {dateTime}.xlsx");

            return excelFileName;
        }

        private void CreateReport(string excelFileName, DataGridView dataGridView)
        {
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add(_applicationName);
                var lineNumber = 1;

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    var columnIndex = dataGridView.Columns.IndexOf(column) + 1;

                    var cell = worksheet.Cells[lineNumber, columnIndex];
                    cell.Value = column.HeaderText;
                    cell.Style.Font.Bold = true;
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    lineNumber++;

                    var testMethod = row.GetDataBoundItem();

                    foreach (DataGridViewCell rowCell in row.Cells)
                    {
                        var columnIndex = row.Cells.IndexOf(rowCell) + 1;

                        var cell = worksheet.Cells[lineNumber, columnIndex];
                        cell.Value = string.Format($"{rowCell.Value}");

                       /* if (testMethod.IsStatusEmpty() == false)
                        {
                            cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(testMethod.StatusColor);
                        }*/
                    }
                }

                excelPackage.SaveAs(new FileInfo(excelFileName));
            }
        }
    }
}
