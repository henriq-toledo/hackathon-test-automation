using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HackathonTestAutomation.TestRunner.Classes.Extensions
{
    /// <summary>
    /// The <c>XContainerExtension</c> class has the extension methods of the <c>XContainer</c> class
    /// </summary>
    internal static class XContainerExtension
    {
        /// <summary>
        /// Retrieves the descendants by local name
        /// </summary>
        /// <param name="xContainer">The <c>XContainer</c> object</param>
        /// <param name="localName">The local name</param>
        /// <param name="parentLocalName">The parent local name</param>
        /// <returns>The descendants</returns>
        public static IEnumerable<XElement> DescendantsByLocalName(
            this XContainer xContainer, string localName, string parentLocalName)
        {
            return xContainer
                .Descendants()
                .Where(d => d.Parent != null
                    && d.Parent.Name.LocalName == parentLocalName
                    && d.Name.LocalName == localName);
        }

        /// <summary>
        /// Retrieves the descendants by local name
        /// </summary>
        /// <param name="xContainer">The <c>XContainer</c> object</param>
        /// <param name="localName">The local name</param>
        /// <returns>The descendants</returns>
        public static IEnumerable<XElement> DescendantsByLocalName(
            this XContainer xContainer, string localName)
        {
            return xContainer
                .Descendants()
                .Where(d => d.Name.LocalName == localName);
        }
    }
}
