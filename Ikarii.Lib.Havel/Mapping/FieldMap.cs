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

   /// <summary>
	/// Represents a mapped elemental database column in a <see cref="T:TypeMap"/>. 
	/// </summary>
   /// <remarks>A FieldMap is generally a one-to-one mapping, such as a string to varchar or int to int. Excpetions
   /// include reference or static reference fields, where the FieldMap represents a foriegn key.</remarks>
   public class FieldMap : BaseFieldMap, IFieldMap
   {
      /// <summary>
		/// Gets or Sets the static nature of this field. Static fields are excluded from insert, update and delete operations.
		/// </summary>
		public bool Static { get; set; }

      /// <summary>
      /// Gets or Sets the default value of this field. If the value of the field is default() or null during insert operations, 
      /// the value of DefaultValue will be used.
      /// </summary>
      public object DefaultValue { get; set; }

      /// <summary>
      /// Gets or sets the name of the column this field is coupled with.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets the <see cref="T:FieldMapType"/> of this field.
      /// </summary>
      public FieldMapType MapType { get; set; }

      /// <summary>
      /// Gets or Sets the parent <see cref="T:Type"/> of this field.
      /// </summary>
      public Type Parent { get; set; }

      /// <summary>
      /// Determines if field can be null for saving operations.
      /// </summary>
      public bool AllowNull { get; set; }

      /// <summary>
      /// Is field a primary key
      /// </summary>
      public bool IsPrimaryKey
      {
         get { return ( this.MapType == FieldMapType.PrimaryKey || this.MapType == FieldMapType.PrimaryForeignKey ); }
      }

      /// <summary>
      /// Is field a foreign key
      /// </summary>
      public bool IsForeignKey
      {
         get { return ( this.MapType == FieldMapType.ForeignKey || this.MapType == FieldMapType.PrimaryForeignKey ); }
      }


      public bool IsIdentity { get { return ( this is IdentityFieldMap ); } }

      public bool IsEncrypted { get { return ( this is EncryptedFieldMap ); } }
      /// <summary>
      /// Gets or sets a <see cref="T:Boolean"/> value indicating whether or not this field should us encryption.
      /// </summary>
      //      public bool UseEncryption { get; set; }

      /// <summary>
      /// Gets or sets the <see cref="T:EncryptionMap"/> for this field. This is used only by fields that are encrypted.
      /// </summary>
      //      public EncryptionMap Encryption { get; set; }


   }
}
