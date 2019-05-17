/****************************************************************************
MIT License

https://github.com/ikariiwarrior/Havel 
Copyright(c) 2019 Shawn Hall

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*****************************************************************************/

namespace Ikarii.Lib.Havel.Mapping
{
   /// <summary>
   /// Describes the formatting for delimited identifiers, used to escape table and column names. Most
   /// </summary>
   public enum IdentifierFormat
   {
      /// <summary>
      /// Quoted delimiter, pads name in quotes.
      /// </summary>
      /// <example>Havel will use quote marks to delimit columns and tables in SQL queries.
      /// <code>
      /// SELECT "column" FROM "table"
      /// </code>
      /// </example>
      Quoted,

      /// <summary>
      /// Bracketed delimiter, pads name in brackets. Not supported by some providers.
      /// <example>Havel will use quote marks to delimit columns and tables in SQL queries.
      /// <code>
      /// SELECT [column] FROM [table]
      /// </code>
      /// </summary>
      Bracketed,

      /// <summary>
      /// Backtick delimiter, pads name in backticks. Not supported by some providers.
      /// <example>Havel will use quote marks to delimit columns and tables in SQL queries.
      /// <code>
      /// SELECT `column` FROM `table`
      /// </code>
      /// </summary>
      Backtick,

      /// <summary>
      /// No delimeter, does not pad name.  Reserved and non-standard words will generate SQL errors
      /// <example>Havel will use quote marks to delimit columns and tables in SQL queries.
      /// <code>
      /// SELECT column FROM table
      /// </code>
      /// without a delimiter.
      /// </summary>
      None
   }
}
