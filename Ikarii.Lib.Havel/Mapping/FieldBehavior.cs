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
	/// Represents the behavior of an object member.
	/// </summary>
	public enum FieldBehavior
   {
      /// <summary>
      /// Specifies the member should be inherited and used in Havel operations by subclasses.  This is the default behavior of a member.
      /// </summary>
      Inherit,
      /// <summary>
      /// Specifies that a member should be excluded when performing Havel operations on a subclass that inherits this member.
      /// </summary>
      Exclude,
      /// <summary>
      /// Specifies that the member should only be retrieved from the storage device and never persisted.
      /// </summary>
      ReadOnly
   }
}
