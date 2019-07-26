using HackathonTestAutomation.Common.Classes.Attributes;
using HackathonTestAutomation.Common.Enums;
using HackathonTestAutomation.TestRunner.Classes.Entities;
using HackathonTestAutomation.TestRunner.Classes.Reports;
using HackathonTestAutomation.TestRunner.Classes.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace HackathonTestAutomation.TestRunner.Forms
{
    public partial class TestRunnerForm : Form
    {
        private Type currObj { get; set; }

        public TestRunnerForm()
        {
            InitializeComponent();
            SetCbxDatasources();
            HandleEvents();
            PopulateGridView();
        }

        private void HandleEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            //dgvTestCases.CellDoubleClick += DgvTestCases_CellDoubleClick;
            btnRunTestCase.Click += BtnRunTestCase_Click;
        }

        private void BtnRunTestCase_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void Run()
        {
            IEnumerable<TestCase> listTestCase = GetTestCasesToRun();

            foreach (var tc in listTestCase)
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();

                    var command = "\"" + AppSettings.Current.VsTestConsole + "\" " +
                         $"\"{tc.AssemblyPath}\" /UseVsixExtensions:true /logger:trx /Tests:{tc.Name}";

                    process.StandardInput.WriteLine(command);
                    process.StandardInput.Flush();
                    process.StandardInput.Close();
                    process.WaitForExit();

                    var output = process.StandardOutput.ReadToEnd();

                    var resultFile = this.GetResultFileNameFromResultFile(output);
                }
            }
        }

        private string GetResultFileNameFromResultFile(string resultFileText)
        {
            var resultFile = resultFileText
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(line => line.StartsWith("Results File: "));

            //  resultFile = resultFile.Replace("Results File: ", string.Empty);

            return resultFile;
        }

        /*   private void DgvTestCases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
           {

               var selectedTC = dgvTestCases.CurrentRow;

               if (selectedTC != null)
               {

                   var obj = (TestCase) selectedTC.DataBoundItem;


                   //var selectedClass = Assembly.Load(obj.Class).DefinedTypes.Where(a => a.Name.Equals(obj.getClassName())).First();
                   var classNames = obj.getClassName();
                   var selectedClass = Assembly.Load(classNames[0] + "." + classNames[1]);

                  // Type t = selectedClass.GetType(classNames[classNames.Count - 1]);

                   //Activator.CreateInstance();
                   //HackathonTestAutomation.Tests.Classes.Tests.SearchJobTest
                   Type t2 = selectedClass.DefinedTypes.GetType();
                   var t = selectedClass.DefinedTypes.ToList().GetRange(2, 2).First().UnderlyingSystemType;
                   Type t3 = selectedClass.DefinedTypes.Where(a => a.Name.Equals(classNames[classNames.Count - 1]) != null).First().UnderlyingSystemType;

                   //var constructor = selectedClass.GetConstructor(new Type[] {selectedClass.GetType()});

                   var constructor = t3.GetConstructor(new Type[] {t});

                   var instancedObj = Activator.CreateInstance(t3);

                   var method = t3.GetMethod(obj.Method);

                   method.Invoke(instancedObj, null);

                   //var objFromClass = selectedClass.CreateInstance(obj.getClassName());          

                 /*  Type t = objFromClass.GetType();

                   var selectedMethod = t.GetMethod(obj.Method);

                   selectedMethod.Invoke(obj, null);
               *//*}
           }
   */
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void PopulateGridView()
        {/*
            DataTable dt = new DataTable();

            DataColumn dtClass = new DataColumn("Class", typeof(string));
            DataColumn dtMethods = new DataColumn("Methods.Name", typeof(string));
            DataColumn dtDescription = new DataColumn("Description", typeof(string));

            dt.Columns.Add(dtDescription);
            dt.Columns.Add(dtMethods);
            dt.Columns.Add(dtClass);
            */

            //var reflectedTestCases = GetReflectedClasses().Where(a => a.Methods.Where(n => n.Name.Contains(this.txtMethod.Text.Trim()) 
            //                                                                            || n.Name.Contains(this.txtClass.Text.Trim())) != null);

            var reflectedTestCases = GetReflectedClasses().Where(a => a.TestMethod.Contains(this.txtMethod.Text.Trim()) || a.TestClass.Contains(txtClass.Text.Trim()));

            /*               
               foreach (var row in reflectedTestCases)
               {                
                   foreach (var method in row.Methods)
                   {
                       dt.Rows.Add("", method.Name, row.Class.ToString());
                   }
               }
               */

            BindingSource bs = new BindingSource();
            bs.DataSource = reflectedTestCases;

            dgvTestCases.DataSource = bs;
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

        private List<TestCase> GetReflectedClasses()
        {
            var assemblyLocation = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var projectDirectory = assemblyLocation.Directory.Parent.Parent.Parent;
            var assemblyPath = projectDirectory.FullName + @"\HackathonTestAutomation.Tests\bin\Debug\HackathonTestAutomation.Tests.dll";

            var targetAssembly = Assembly.LoadFile(assemblyPath);

            List<TestCase> testCases = new List<TestCase>();

            var types = targetAssembly.GetTypes();

            foreach (var classType in types)
            {
                var classCustomAttrs = classType.CustomAttributes;

                foreach (var attr in classCustomAttrs)
                {
                    if (attr.AttributeType == typeof(TestClassAttribute))
                    {
                        List<MethodInfo> methods = new List<MethodInfo>();

                        var reflectedMethods = classType.GetMethods().Where(a => a.GetCustomAttribute(typeof(TestMethodAttribute)) != null);

                        methods.AddRange(reflectedMethods);

                        foreach (var method in methods)
                        {                            
                            var defectAttribute = (DefectAttribute)method.GetCustomAttribute(typeof(DefectAttribute));
                            TestCase tc = new TestCase()
                            {
                                TestClass = classType.FullName,
                                TestMethod = method.Name,
                                Description = defectAttribute.Description,
                                Priority = defectAttribute.Priority.GetDescription(),
                                Severity = defectAttribute.Severity.GetDescription(),
                                AssemblyPath = assemblyPath
                            };
                            //new TestCase(false, defectAttribute.Description, method.Name, className.Replace(" ", ""));

                            testCases.Add(tc);
                        }
                    }
                }
            }

            return testCases;
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
