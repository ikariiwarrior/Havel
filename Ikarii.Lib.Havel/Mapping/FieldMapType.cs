using System;
using System.Collections.Generic;
using System.Text;

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
	/// Represents the type of field marked up in an object.  This enumeration is generally used by the <see cref="FieldAttribute">FieldAttribute</see> class.
	/// </summary>
	public enum FieldMapType
   {
      /// <summary>
      /// Use PrimaryKey when persist should delegate the creation of identity values to the RDBMS.
      /// </summary>
      /// <remarks>Not all PersistenceProviders support this method of primary key management.  Please read the documenation
      /// for the specific provider you intend on using.</remarks>
      PrimaryKey,

      /// <summary>
      /// Defines a field as a foreign key type.  This will typically be an integer or guid value and reference a parent object in the <see cref="FieldAttribute">FieldAttribute</see>.
      /// </summary>
      ForeignKey,

      /// <summary>
      /// PrimaryForeignKey field types are unique in that they define a field which should be used as a PrimaryKey and a ForeignKey simultaneously.  
      /// This type should only be used when a child persistent object shares the same identity value as it's parent object.  In this case, Persist expects
      /// that the identity value of the object using this type is not auto generated.
      /// </summary>
      PrimaryForeignKey,

      /// <summary>
      /// Defines a field as a reference type.  This field type persists to the storage device only if it does not already exist.
      /// </summary>
      Reference,

      /// <summary>
      /// Defines a field as a value type.  This field type can be any common type that derives from <see cref="System.Object">System.Object</see> or <see cref="System.Xml.XmlDocument">System.Xml.XmlDocument</see>.
      /// Value can also refer to a One to One relationship with any other object marked with the <see cref="PersistentAttribute">PersistentAttribute</see>.
      /// <remarks>Value is the default FieldType for the <see cref="FieldAttribute">FieldAttribute</see>.</remarks>
      /// </summary>
      Value,

      /// <summary>
      /// Use ManagedPrimaryKey when persist should be creating and issuing identitiy values for the primary key.  
      /// </summary>
      /// <remarks>Not all PersistenceProviders support this method of primary key management.  Please read the documenation
      /// for the specific provider you intend on using.</remarks>
      ManagedPrimaryKey
   }
}
