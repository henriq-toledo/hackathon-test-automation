using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HackathonTestAutomation.TestRunner.Classes.Extensions
{
    /// <summary>
    /// The <c>XElementExtension</c> class has the extension methods of the <c>XElement</c> class
    /// </summary>
    internal static class XElementExtension
    {
        /// <summary>
        /// Get the value by the local name
        /// </summary>
        /// <param name="xElement">The <c>XElement</c> object</param>
        /// <param name="localName">The local name</param>
        /// <returns>The value stored in the local name</returns>
        public static string GetValue(this XElement xElement, string localName)
        {
            return xElement.GetValue(localName: localName, parentLocalName: xElement.Name.LocalName);
        }

        /// <summary>
        /// Get the value by the local name and parent local name
        /// </summary>
        /// <param name="xElement">The <c>XElement</c> object</param>
        /// <param name="localName">The local name</param>
        /// <param name="parentLocalName">The parent local name</param>
        /// <returns>The value stored in the local name</returns>
        public static string GetValue(this XElement xElement, string localName, string parentLocalName)
        {
            return xElement
                .DescendantsByLocalName(localName: localName, parentLocalName: parentLocalName)
                .Select(d => d.Value)
                .FirstOrDefault();
        }
    }
}
