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
   using System;
   using System.Reflection;

   using Ikarii.Lib.Havel.Extensions;

   /// <summary>
	/// Represents a <see cref="T:PersistentAttribute">persistent</see> field in a <see cref="T:TypeMap"/> where
	/// the field represents another mapped object or collection of mapped objects.
	/// </summary>
   public sealed class RelationalFieldMap : BaseFieldMap, IFieldMap
   {

      private string m_childname;
      /// <summary>
      /// Gets or Sets the table name for children in this field.
      /// </summary>
      public string ChildName
      {
         get { return ( String.IsNullOrEmpty( this.m_childname ) ? this.Map.NamingConvention.TableName( this.ChildReturnType ) : this.m_childname ); }
         set { this.m_childname = value; }
      }

      private string m_linkname;
      /// <summary>
      /// Gets or Sets the linking table name for the children in this field.
      /// </summary>
      public string LinkName
      {
         get { return ( String.IsNullOrEmpty( this.m_linkname ) ? this.Map.NamingConvention.ManyToManyTableName( this.Map.Type, this.ChildReturnType ) : this.m_linkname ); }
         set { this.m_linkname = value; }
      }

      private string m_linkleft;
      /// <summary>
      /// Gets or Sets the field name for the parent column in the linking table.
      /// </summary>
      /// <remarks>If this property is blank Persist will assume that the column is named like [table]_[id]
      /// where table is the name of the parent table and id is the name of the parent primary key.</remarks>
      public string LinkLeft
      {
         get { return ( String.IsNullOrEmpty( this.m_linkleft ) ? this.Map.NamingConvention.ManyToManyLeftKey( this.Map.Type ) : this.m_linkleft ); }
         set { this.m_linkleft = value; }
      }

      private string m_linkright;
      /// <summary>
      /// Gets or Sets the field name for the child column in the linking table.
      /// </summary>
      /// <remarks>If this property is blank Persist will assume that the column is named like [table]_[id]
      /// where table is the name of the child table and id is the name of the child primary key.</remarks>
      public string LinkRight
      {
         get { return ( String.IsNullOrEmpty( this.m_linkright ) ? this.Map.NamingConvention.ManyToManyRightKey( this.ChildReturnType ) : this.m_linkright ); }
         set { this.m_linkright = value; }
      }

      /// <summary>
      /// Gets or Sets the <see cref="T:Type"/> for the children in this field.
      /// </summary>
      public Type ChildReturnType { get; set; }

      /// <summary>
      /// Gets the <see cref="T:Type"/> of the field.  If this field is a collection it will return the collection type NOT the <see cref="T:Type"/> of items in the collection.
      /// If you need the <see cref="T:Type"/> of items the collection is made up of use <see cref="FieldArrayInfo.ChildReturnType" />.
      /// </summary>
      public Type FieldReturnType { get { return ( this.Field.PropertyType ); } }


      /// <summary>
      /// Gets or sets whether this field is linked to it's parent through a linking table indicating a many to many relationship.
      /// </summary>
      public bool Linked { get; set; }


      /// <summary>
      /// Gets whether this field is a collection.
      /// </summary>
      public bool IsArray { get { return ( this.FieldReturnType.ImplementsInterface(  typeof( System.Collections.ICollection ) ) ); } }

   }
}
