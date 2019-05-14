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

namespace Ikarii.Lib.Havel.Cache
{
   using System;

   using Microsoft.Extensions.Caching.Memory;

   using Ikarii.Lib.Havel.Mapping;

   public sealed class TypeCache
   {
      private static readonly Lazy<TypeCache> m_instance = new Lazy<TypeCache>( () => new TypeCache() );
      private IMemoryCache m_cache;
      private static readonly MemoryCacheEntryOptions m_entry_options = 
         new MemoryCacheEntryOptions()
         .SetSlidingExpiration( TimeSpan.FromMinutes( 60 ) )
         .SetAbsoluteExpiration( DateTimeOffset.UtcNow.AddDays( 1 ) );

      public static TypeCache Instance { get { return m_instance.Value; } }

      private TypeCache() => this.m_cache = new MemoryCache( new MemoryCacheOptions() );

      public void AddType( Type type, TypeMap map ) => this.m_cache.Set( type.FullName, map, m_entry_options );

      public TypeMap GetType( Type type ) => ( this.m_cache.Get<TypeMap>( type.FullName ) );

   }
}
