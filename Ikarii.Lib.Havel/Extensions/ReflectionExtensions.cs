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

namespace Ikarii.Lib.Havel.Extensions
{
   using Ikarii.Lib.Havel.Mapping;
   using System;
   using System.Linq.Expressions;
   using System.Reflection;

   public static class ReflectionExtensions
   {
      internal static bool ImplementsInterface<T>( this Type type ) where T : class
      {
         return ( ImplementsInterface( type, typeof( T ) ) );
      }

      internal static bool ImplementsInterface( this Type type, Type interfaceType )
      {
         if( !interfaceType.IsInterface ) return ( false );
         if( interfaceType.IsAssignableFrom( type ) || type?.GetInterface( interfaceType.Name ) == interfaceType )
            if( !interfaceType.IsAssignableFrom( type )
               && type?.GetInterface( interfaceType.Name ) == null
               && !type.IsInterface
               && !type.Equals( interfaceType ) )

               if( type?.GetInterface( interfaceType.Name ) == null && !type.IsInterface && !type.Equals( interfaceType ) )
               {
                  return ( false );
               }
         return ( true );
      }

      /*
      internal static object GetCustomFieldAttribute( this PropertyInfo property, Type attributeType )
      {
         return ( property.GetCustomAttribute( attributeType, false ) );
      }

      internal static T GetCustomFieldAttribute<T>( this PropertyInfo property ) where T : IFieldAttribute
      {
         return ( property.GetCustomAttribute<T>( false ) );
      }

      internal static object GetCustomObjectAttribute( this Type obj, Type attributeType )
      {
         return ( obj.GetCustomAttribute( attributeType, false ) );
      }

      internal static T GetCustomObjectAttribute<T>( this Type obj )
      {
         return ( obj.GetCustomAttribute<T>( false ) );
      }
      */

      internal static IdentityFormat GetIdentityFormat( this Type identityType )
      {
         IdentityFormat result = IdentityFormat.Integer;
         if( identityType.Equals( typeof( System.Int32 ) ) || identityType.Equals( typeof( System.Int64 ) ) )
         {
            result = IdentityFormat.Integer;
         }
         else if( identityType.Equals( typeof( System.Guid ) ) )
         {
            result = IdentityFormat.Guid;
         }
         else if( identityType.Equals( typeof( System.String ) ) )
         {
            result = IdentityFormat.String;
         }
         else
         {
            /*
            throw new PersistMappingException(
               String.Format( System.Globalization.CultureInfo.InvariantCulture,
               "Primary Key is an unknown datatype.  Primary Keys must be integers, guids or strings." ) );
            */
         }
         return ( result );
      }

      internal static object GetDefaultUnsavedValue( this Type identityType )
      {
         if( identityType.Equals( typeof( System.Int32 ) ) ) return ( Constants.UNSAVED_INTEGER_VALUE );
         if( identityType.Equals( typeof( System.Int64 ) ) ) return ( Constants.UNSAVED_LONG_VALUE );
         if( identityType.Equals( typeof( System.Guid ) ) ) return ( Constants.UNSAVED_GUID_VALUE );
         return ( Constants.UNSAVED_STRING_VALUE );
      }

      internal static PropertyInfo GetProperty<TYPE>( Expression<Func<TYPE, object>> expression )
      {
         return ( ( PropertyInfo )GetMemberExpression( expression ).Member );
      }

      internal static MemberExpression GetMemberExpression<TYPE, MAP>( Expression<Func<TYPE, MAP>> expression )
      {
         MemberExpression memberExpression = null;
         if( expression.Body.NodeType == ExpressionType.Convert )
         {
            var body = ( UnaryExpression )expression.Body;
            memberExpression = body.Operand as MemberExpression;
         }
         else if( expression.Body.NodeType == ExpressionType.MemberAccess )
         {
            memberExpression = expression.Body as MemberExpression;
         }

         if( memberExpression == null )
         {
            throw new ArgumentException( "Not a member access", "member" );
         }

         return memberExpression;
      }

      public static bool IsElemental( this Type type )
      {
         return ( type.IsValueType ||
            type.Namespace.Equals( "System.Xml" ) ||
            type.Namespace.Equals( "System.Drawing" ) ||
            type.Equals( typeof( Byte[] ) ) ||
            type.Equals( typeof( String ) ) );
      }

   }
}
