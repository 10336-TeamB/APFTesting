using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface which exposes fields for address
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// Street number, street name, or name of the pilot candidate
        /// </summary>
        string Address1 { get; }
        /// <summary>
        /// Unit or Suite number of the pilot candidate
        /// </summary>
        string Address2 { get; }
        /// <summary>
        /// Suburb and city of the pilot candidate
        /// </summary>
        string Suburb { get; }
        /// <summary>
        /// State of the pilot candidate
        /// </summary>
        string State { get; }
        /// <summary>
        /// Post code of the pilot candidate
        /// </summary>
        string Postcode { get; }

        /// <summary>
        /// Creates address as html
        /// </summary>
        /// <returns>HTML addess as string</returns>
        string ToHtmlString();
    }
}
