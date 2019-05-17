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

   public interface IFieldMap
   {
      /// <summary>
		/// Gets or Sets the <see cref="T:PropertyInfo"/> for this field.
		/// </summary>
		PropertyInfo Field { get; set; }

      /// <summary>
      /// Gets the <see cref="T:Type"/> of the field.  If this field is a collection it will return the collection type NOT the <see cref="T:Type"/> of items in the collection.
      /// If you need the <see cref="T:Type"/> of items the collection is made up of use <see cref="FieldArrayInfo.ChildReturnType" />.
      /// </summary>
      Type ReturnType { get; }

      /// <summary>
      /// Gets the <see cref="T:FieldBehavior"/> of this field.
      /// </summary>
      FieldBehavior Behavior { get; set; }

      /// <summary>
      /// Gets or Sets whether this field is lazy loaded or not.
      /// </summary>
      bool Lazy { get; set; }

      /// <summary>
      /// Gets or Sets how Update and Delete operations are treated with this child field.
      /// </summary>
      Cascade Cascade { get; set; }

   }
}
