using HackathonTestAutomation.TestRunner.Classes.Entities;
using System.Windows.Forms;

namespace HackathonTestAutomation.TestRunner.Classes.Extensions
{
    /// <summary>
    /// The <c>DataGridViewRowExtension</c> class has the extension methods of the <c>DataGridViewRow</c> class
    /// </summary>
    internal static class DataGridViewRowExtension
    {
        /// <summary>
        /// Gets the test method item
        /// </summary>
        /// <param name="dataGridViewRow">The <c>DataGridViewRow</c> object</param>
        /// <returns>The test method entity</returns>
        internal static TestCase GetDataBoundItem(this DataGridViewRow dataGridViewRow)
        {
            return dataGridViewRow.GetDataBoundItem<TestCase>();
        }

        private static T GetDataBoundItem<T>(this DataGridViewRow dataGridViewRow)
        {
            return (T)dataGridViewRow.DataBoundItem;
        }
    }
}
