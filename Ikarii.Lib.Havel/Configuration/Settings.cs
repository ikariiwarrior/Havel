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

namespace Ikarii.Lib.Havel.Configuration
{
   using System;
   using System.Reflection;

   using Microsoft.Extensions.Configuration;

   /// <summary>   A settings. This class cannot be inherited. </summary>
   ///
   /// <remarks>   Shawn, 7/12/2017. </remarks>
   public sealed class Settings
   {

      /// <summary>
      /// Default <see cref="T:Ikarii.Lib.Havel.Configuration.Convention"/> to use when generating field and table names that are not explicitly annotated.
      /// </summary>
      public Type NamingConventionType { get; set; } = typeof( Convention );

      /// <summary>
      /// Gets an instance of <see cref="P:Ikarii.Lib.Havel.Configuration.Settings.ConventionType"/>.
      /// </summary>
      /// <value>The naming convention.</value>
      public Convention NamingConvention
      {
         get { return ( Activator.CreateInstance( NamingConventionType ) as Convention ); }
      }

      /// <summary>
      /// Delimiter to use when creating SQL statements.  Default is <see cref="Ikarii.Lib.Havel.Mapping.DelimiterFormat.Quoted"/>
      /// </summary>
      public Mapping.IdentifierFormat Delimiter { get; set; } = Mapping.IdentifierFormat.Quoted;









      public static Settings Default
      {
         get { return ( new Settings() ); }
      }
   }


}
