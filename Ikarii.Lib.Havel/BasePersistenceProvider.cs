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

namespace Ikarii.Lib.Havel
{
   using System;
   public abstract class BasePersistenceProvider : IPersistenceProvider
   {
	  /// <summary>
	  /// Occurs immediately before any SQL is executed by Persist.  Should be used only for debuging purposes by a tailing logger.
	  /// </summary>
	  public event EventHandler<PersistentActivityEventArgs> ExecutingSql;

	  /// <summary>
	  /// Occurs immediately before an object is persisted.  Only fires once, even if multiple objects are being persisted due to parent child relationships.
	  /// </summary>
	  public event EventHandler<PersistentActivityEventArgs> Persisting;

	  /// <summary>
	  /// Occurs immediately after an object is persisted.  Only fires once, even if multiple objects are being persisted due to parent child relationships.
	  /// </summary>
	  public event EventHandler<PersistentActivityEventArgs> Persisted;

	  /// <summary>
	  /// Occurs immediately before an object is deleted.  Only fires once, even if multiple objects are being purged due to parent child relationships.
	  /// </summary>
	  public event EventHandler<PersistentActivityEventArgs> Destroying;

	  /// <summary>
	  /// Occurs immediately after an object is deleted.  Only fires once, even if multiple objects are being purged due to parent child relationships.
	  /// </summary>
	  public event EventHandler<PersistentActivityEventArgs> Destroyed;

	  /// <summary>
	  /// Occurs immediately before an object is retrieved from the database.  Fires each time an object is retrieved from the database.
	  /// </summary>
	  public event EventHandler<PersistentActivityEventArgs> Retrieving;

	  /// <summary>
	  /// Occurs immediately after an object is retrieved from the database.  Fires each time an object is retrieved from the database.
	  /// </summary>
	  public event EventHandler<PersistentActivityEventArgs> Retrieved;
   }
}
