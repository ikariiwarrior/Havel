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

   public sealed class ConventionTable
   {
      private static readonly Lazy<ConventionTable> m_instance = new Lazy<ConventionTable>( () => new ConventionTable() );
      private Convention m_convention;

      public static ConventionTable Instance { get { return m_instance.Value; } }

      /// <summary>
      /// Gets the current <see cref="T:Convention"/> being used by Persist.B
      /// </summary>
      public Convention NamingConvention
      {
         get { return ( this.m_convention ); }
         set { this.m_convention = value; }
      }

	  private ConventionTable() => this.m_convention = new Convention();

	  /// <summary>
	  /// Registers a <see cref="T:TypeMap"/> with the Type cache.
	  /// </summary>
	  /// <param name="typemap"><see cref="T:TypeMap"/> to register.</param>
	  //public void RegisterTypeMap( TypeMap typemap ) { TypeCache.AddType( typemap.Type, typemap ); }
   }
}

