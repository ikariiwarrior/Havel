using System;
using System.Collections.Generic;
using System.Text;

namespace Ikarii.Lib.Havel.Configuration
{
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

      private ConventionTable()
      {
         this.m_convention = new Convention();
      }

      /// <summary>
      /// Registers a <see cref="T:TypeMap"/> with the Type cache.
      /// </summary>
      /// <param name="typemap"><see cref="T:TypeMap"/> to register.</param>
      //public void RegisterTypeMap( TypeMap typemap ) { TypeCache.AddType( typemap.Type, typemap ); }
   }
}

