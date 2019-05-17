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

   public sealed class IdentityFieldMap : FieldMap
   {
      /// <summary>
      /// Gets or sets the <see cref="T:IdentityFormat"/> of the identity.
      /// </summary>
      public IdentityFormat Format { get; set; }

      /// <summary>
      /// Gets or sets the <see cref="T:IdentityIncrement"/> of the identity.
      /// </summary>
      public IdentityIncrement Increment { get; set; }

      /// <summary>
      /// Gets or sets the unsaved value of this identity.
      /// </summary>
      /// <remarks>Note that persist will not actually set the value of this identity to the one specified.
      /// It only uses this value to determine whether or not to perform an update or insert.</remarks>
      public object UnsavedValue { get; set; }
      
      /// <summary>
      /// Initializes a new instance of IdentityMap.
      /// </summary>
      /// <param name="format"><see cref="T:IdentityFormat"/> of the identity.</param>
      /// <param name="increment"><see cref="T:IdentityIncrement"/> of the identity.</param>
      public IdentityFieldMap( IdentityFormat format, IdentityIncrement increment )
      {
         this.Format = format;
         this.Increment = increment;
         if( this.Format == IdentityFormat.Guid ) { this.UnsavedValue = new Guid(); }
         else if( this.Format == IdentityFormat.Integer ) { this.UnsavedValue = 0; }
         else if( this.Format == IdentityFormat.String ) { this.UnsavedValue = String.Empty; }
      }

   }
}
