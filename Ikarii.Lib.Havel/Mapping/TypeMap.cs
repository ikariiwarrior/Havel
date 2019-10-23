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
   using Ikarii.Lib.Havel.Configuration;
   using System;
   using System.Collections.Generic;
   using System.Collections.ObjectModel;


   /// <summary>
   /// A <see cref="T:TypeMap" /> represents a relationship map between a class <see cref="T:Type" /> and the database.  The <see cref="T:TypeMap" />
   /// creates a "map" of the defined <see cref="T:Type" /> and is used by Havel to describe the object in database operations. 
   /// </summary>
   public class TypeMap
   {
      /// <summary>
      /// Gets the <see cref="T:Type" /> of object the <see cref="T:TypeMap" /> is mapping.
      /// </summary>
      public Type Type { get; set; }

      /// <summary>
      /// Gets or sets the name of the database table for the mapped <see cref="T:Type" />.  If empty, the
      /// TypeMap's <see cref="T:Convention">Naming Convention</see> will be used to generate a table name.
      /// </summary>
      public string Table { get; set; }

      /// <summary>
      /// Gets the <see cref="T:IdentityFormat" /> for the primary key of the mapped <see cref="T:Type" />.
      /// Persist supports primary keys in the form of <see langword="int" />, <see cref="T:Guid"/>, or <see langword="string" />.
      /// </summary>
      public IdentityFormat IdentityFormat { get { return ( this.PrimaryKey.Format ); } }

      /// <summary>
      /// Gets the <see cref="T:IdentityMethod" /> for the primary key of the mapped <see cref="T:Type" />.
      /// </summary>
      public IdentityIncrement IdentityMethod { get { return ( this.PrimaryKey.Increment ); } }

      /// <summary>
      /// Gets or sets the <see cref="T:FieldMap" /> representing the primary key of the mapped <see cref="T:Type" />.
      /// </summary>
      public IdentityFieldMap PrimaryKey { get; private set; }

      private List<FieldMap> m_fields;
	  /// <summary>
	  /// Gets a list of <see cref="T:FieldMap" /> of mapped fields.
	  /// </summary>
	  public ReadOnlyCollection<FieldMap> Fields => ( this.m_fields.AsReadOnly() );

	  private List<RelationalFieldMap> m_children;
	  /// <summary>
	  /// Gets a list of <see cref="T:FieldMap" /> of mapped children.
	  /// </summary>
	  public ReadOnlyCollection<RelationalFieldMap> Children => ( this.m_children.AsReadOnly() );

	  private List<FieldMap> m_referenced;
	  /// <summary>
	  /// Gets a list of <see cref="T:FieldMap" /> of mapped references.
	  /// </summary>
	  public ReadOnlyCollection<FieldMap> ReferencedFields => ( this.m_referenced.AsReadOnly() );

	  private List<FieldMap> m_foreignkeys;
	  /// <summary>
	  /// Gets a list of <see cref="T:FieldMap" /> of mapped foreign keys.
	  /// </summary>
	  public ReadOnlyCollection<FieldMap> ForeignKeys => ( this.m_foreignkeys.AsReadOnly() );

	  /// <summary>
	  /// Gets a list of Persist mapping warings.
	  /// </summary>
	  public List<String> Warnings { get; protected set; }

      /// <summary>
      /// Gets the <see cref="Ikarii.Lib.Havel.Configuration.Convention" /> used for the <see cref="T:Type" /> mapped.
      /// </summary>
      public Convention NamingConvention { get; protected set; }

      /// <summary>
      /// Instantiates TypeMap with only its lists initialized and the current NamingConvention.  This constructor is used by <see cref="T:TypeMap{T}" />.
      /// </summary>
	  /// <remarks>
	  /// Note: ConventionTable uses the Singleton pattern
	  /// </remarks>
      protected TypeMap()
      {
         this.m_fields = new List<FieldMap>();
         this.m_children = new List<RelationalFieldMap>();
         this.m_referenced = new List<FieldMap>();
         this.m_foreignkeys = new List<FieldMap>();
         this.Warnings = new List<String>();
         this.NamingConvention = ConventionTable.Instance.NamingConvention;
      }

      /// <summary>
      /// Creates a new <see cref="Ikarii.Lib.Havel.Mapping.TypeMap" /> for the specified <paramref name="type"/>.
      /// </summary>
      /// <param name="type"><see cref="System.Type" /> to be mapped.</param>
      public TypeMap( Type t ) : this() => this.Type = t;

      /// <summary>
      /// Creates a new <see cref="Ikarii.Lib.Havel.Mapping.TypeMap" /> for the specified <paramref name="type"/> and <paramref name="convention"/>.
      /// </summary>
      /// <param name="type"><see cref="System.Type" /> to be mapped.</param>
      /// <param name="convention"<see cref="Ikarii.Lib.Havel.Configuration.Convention"/> to use when mapping to a database.</param>
      public TypeMap( Type type, Convention convention ) : this( type ) => this.NamingConvention = convention;
   }
}
