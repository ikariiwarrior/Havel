using System;
using System.Collections.Generic;
using System.Text;

namespace Ikarii.Lib.Havel.Mapping
{
    /// <summary>
	/// Describes the formatting for delimited identifiers, used to escape table and column names.
	/// </summary>
    public enum DelimiterFormat
    {
        /// <summary>
        /// Quoted delimiter, pads name in quotes.
        /// </summary>
        Quoted,

        /// <summary>
        /// Bracketed delimiter, pads name in brackets. Not supported by some providers.
        /// </summary>
        Bracketed,

        /// <summary>
        /// No delimeter, does not pad name.  Reserved and non-standard words will generate SQL errors
        /// without a delimiter.
        /// </summary>
        None
    }
}
