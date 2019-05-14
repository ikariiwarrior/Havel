/***********************************************************************
<copyright file="Settings.cs" company="Ikarii">
    Copyright © Ikarii, LLC. 2017 All rights reserved.
    Author: Shawn Hall
</copyright>
***********************************************************************/


namespace Ikarii.Lib.Havel.Configuration
{
    using System;
    using System.Reflection;

   using Microsoft.Extensions.Configuration;

   /// <summary>   A settings. This class cannot be inherited. </summary>
   ///
   /// <remarks>   Shawn, 7/12/2017. </remarks>
   public sealed class Settings
    {

        /// <summary>
        /// Default <see cref="T:Ikarii.Lib.Havel.Configuration.Convention"/> to use when generating field and table names that are not explicitly annotated.
        /// </summary>
        public Type NamingConventionType { get; set; } = typeof( Convention );

        /// <summary>
        /// Gets an instance of <see cref="P:Ikarii.Lib.Havel.Configuration.Settings.ConventionType"/>.
        /// </summary>
        /// <value>The naming convention.</value>
        public Convention NamingConvention
        {
            get { return ( Activator.CreateInstance( NamingConventionType ) as Convention ); }
        }

        /// <summary>
		/// Delimiter to use when creating SQL statements.  Default is <see cref="Ikarii.Lib.Havel.Mapping.DelimiterFormat.Quoted"/>
		/// </summary>
        public Mapping.DelimiterFormat Delimiter { get; set; } = Mapping.DelimiterFormat.Quoted;








        
        public static Settings Default
        {
            get { return ( new Settings() ); }
        }
    }


}
