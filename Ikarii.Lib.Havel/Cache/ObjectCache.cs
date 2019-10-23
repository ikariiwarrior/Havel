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
   using System.Threading;

   using Microsoft.Extensions.Primitives;
   using Microsoft.Extensions.Caching.Memory;

   using Ikarii.Lib.Havel.Mapping;

   internal class ObjectCache
   {
	  private static CancellationTokenSource m_reset_cache_token = new CancellationTokenSource();
	  private static readonly Lazy<ObjectCache> m_instance = new Lazy<ObjectCache>( () => new ObjectCache() );
	  private IMemoryCache m_cache;

	  internal static ObjectCache Instance { get { return m_instance.Value; } }

	  private ObjectCache() => this.m_cache = new MemoryCache( new MemoryCacheOptions() );

	  private string GetCacheKey( Type t, object id ) => ( $"{t.FullName}::{id}" );

	  internal static void AddObject( object id, object o ) => Instance.AddObjectInternal( id, o );
	  private void AddObjectInternal( object id, object o )
	  {
		 var cache_key = this.GetCacheKey( o.GetType(), id );
		 var options = new MemoryCacheEntryOptions()
			.SetSlidingExpiration( TimeSpan.FromMinutes( 60 ) )
			.SetAbsoluteExpiration( DateTimeOffset.UtcNow.AddDays( 1 ) );

		 options.AddExpirationToken( new CancellationChangeToken( m_reset_cache_token.Token ) );

		 this.m_cache.Set( cache_key, o, options );

	  }

	  internal static bool TryGetObject<T>( object id, out T cached_object ) => Instance.InternalTryGetObject<T>( id, out cached_object );
	  private bool InternalTryGetObject<T>( object id, out T cached_object )
	  {
		 var cache_key = this.GetCacheKey( typeof(T), id);
		 var is_cached = this.m_cache.TryGetValue( cache_key, out cached_object );
		 return ( is_cached );
	  }

	  internal static bool TryGetObject( object id, Type type, out object cached_object ) => Instance.InternalTryGetObject( id, type, out cached_object );
	  private bool InternalTryGetObject( object id, Type type, out object cached_object )
	  {
		 var cache_key = this.GetCacheKey( type, id);
		 var is_cached = this.m_cache.TryGetValue( cache_key, out cached_object );
		 return ( is_cached );
	  }

	  internal static void RemoveObject<T>( object id ) => Instance.InternalRemoveObject( id, typeof( T ) );
	  internal static void RemoveObject( object id, Type type ) => Instance.InternalRemoveObject( id, type );
	  private void InternalRemoveObject( object id, Type type )
	  {
		 var cache_key = this.GetCacheKey( type, id);
		 this.m_cache.Remove( cache_key );
	  }

	  public static void Clear() => Instance.InternalClear();
	  private void InternalClear()
	  {
		 if ( ( m_reset_cache_token?.IsCancellationRequested ?? false ) && ( m_reset_cache_token?.Token.CanBeCanceled ?? false ) )
		 {
			m_reset_cache_token.Cancel();
			m_reset_cache_token.Dispose();
		 }
		 m_reset_cache_token = new CancellationTokenSource();
	  }
   }
}
