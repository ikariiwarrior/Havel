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

namespace Ikarii.Lib.Havel.Extensions
{
   using Ikarii.Lib.Havel.Mapping;
   using System;

   public static class StringExtensions
   {
      internal static string PopulateIdentifiers( this string source, IdentifierFormat format )
      {
         ( string left, string right ) parts;
         switch( format )
         {
            case IdentifierFormat.Backtick: parts = ( left: "`", right: "`" ); break;
            case IdentifierFormat.Bracketed: parts = ( left: "[", right: "]" ); break;
            case IdentifierFormat.Quoted: parts = ( left: "\"", right: "\"" ); break;
            default: parts = ( left: String.Empty, right: String.Empty ); break;
         }
         return ( $"{parts.left}{source}{parts.right}" );
      }
   }
}
