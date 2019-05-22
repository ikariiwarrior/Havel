using Ikarii.Lib.Havel.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ikarii.Lib.Havel.Tests
{
   [TestClass]
   public class MappingTests
   {
      private readonly IConfigurationRoot _config;
      private readonly Ikarii.Lib.Havel.Configuration.Settings _default_settings;
      private readonly Ikarii.Lib.Havel.Configuration.Settings _custom_settings;

      public MappingTests()
      {
         var collection = new ServiceCollection();
         collection.AddOptions();

         this._config = new ConfigurationBuilder()
            .SetBasePath( System.IO.Directory.GetCurrentDirectory() )
             .AddJsonFile( "appSettings.json", optional: false )
             .AddEnvironmentVariables()
             .Build();
         this._default_settings = Ikarii.Lib.Havel.Configuration.Settings.Default;

         collection.Configure<Ikarii.Lib.Havel.Configuration.Settings>( settings => _config.GetSection( "HavelSettings" ).Bind( settings ) );

         var services = collection.BuildServiceProvider();

         var options = services.GetService<IOptions<Ikarii.Lib.Havel.Configuration.Settings>>();
         this._custom_settings = options.Value;

      }



   }
}
