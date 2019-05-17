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

namespace Ikarii.Lib.Havel.Mapping.Providers
{
   using System;
   using Ikarii.Lib.Havel.Extensions;

   /// <summary>
	/// Base class for <see cref="T:IMappingProvider"/> classes providing basic functionality.
	/// </summary>
   public abstract class AbstractMappingProvider : IMappingProvider
   {
      /// <summary>
		/// The <see cref="T:TypeMap"/> being constructed.
		/// </summary>
		public TypeMap Context { get; protected set; }

      /// <summary>
      /// Maps the defined <see cref="T:Type"/> to the supplied <see cref="T:TypeMap"/>.
      /// </summary>
      /// <param name="t"><see cref="T:Type"/> to map.</param>
      /// <param name="otm"><see cref="T:TypeMap"/> instance to populate with mappings.</param>
      abstract public void MapByType( Type t, TypeMap otm );

      /// <summary>
      /// Creates new instance of a <see cref="T:IMappingProvider" /> based on the <see cref="Type" /> passed in.
      /// </summary>
      /// <param name="t"><see cref="T:Type"/> to create.</param>
      /// <returns><see cref="T:IMappingProvider" /></returns>
      /// <exception cref="T:System.Exception" />
      public static IMappingProvider GetInstance( Type t )
      {
         if( !t.ImplementsInterface( typeof( IMappingProvider ) ) )
         {
            throw new Exception( "Type must implement IMappingProvider or extend AbstractMappingProvider to be created." );
         }
         return ( t.Assembly.CreateInstance( t.FullName ) as IMappingProvider );
      }

      /// <summary>
      /// Determines whether the passed in type can be mapped by this provider.
      /// </summary>
      /// <param name="t"><see cref="T:Type"/> to map.</param>
      /// <returns>Value indicating whther <typeparamref name="t"/> can be mapped by this provider.</returns>
      public abstract bool CanMapByType( Type t );
   }
}
