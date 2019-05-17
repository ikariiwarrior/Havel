using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ikarii.Lib.Havel.Tests
{
   [TestClass]
   public class ConventionTests
   {
      private readonly IConfigurationRoot _config;
      private readonly Ikarii.Lib.Havel.Configuration.Settings _default_settings;
      private readonly Ikarii.Lib.Havel.Configuration.Settings _custom_settings;

      public ConventionTests()
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


      [TestMethod]
      public void DefaultSettingsConventionTypeNotNull()
      {
         Assert.IsTrue( this._default_settings?.NamingConventionType != null, "NamingConventionType should not be null" );
      }

      [TestMethod]
      public void DefaultSettingsNamingConventionNotNull()
      {
         Assert.IsTrue( this._default_settings?.NamingConvention != null, "NamingConvention should not be null" );
      }

      [TestMethod]
      public void DefaultSettingsDelimiterSetToQuoted()
      {
         Assert.IsTrue( this._default_settings.Delimiter == Ikarii.Lib.Havel.Mapping.IdentifierFormat.Quoted, 
            $"Default delimiter should be: '{Ikarii.Lib.Havel.Mapping.IdentifierFormat.Quoted}'" );
      }


      [TestMethod]
      public void DefaultMappingProviderIsSet()
      {
         Assert.IsTrue( this._default_settings.NamingConvention != null, $"{_default_settings} should not be null" );

         var inflector = Ikarii.Lib.Havel.Configuration.Inflector.Underscore( typeof( DummyTable ).Name ).ToLower();
         var control = "dummy_table";
         var convention = this._default_settings.NamingConvention.TableName( typeof( DummyTable ) );

         
         Assert.IsTrue( convention == control && convention == inflector, 
            $"The value generated from the Convention.TableName function: '{_default_settings.NamingConvention.TableName( typeof( DummyTable ) )}' should be the same as the control: '{control}' and Inflector.Underscore: '{inflector}'" );

      }


      [TestMethod]
      public void ConfiguredMappingProviderIsSet()
      {
         Assert.IsTrue( this._custom_settings != null, "Custom settings should not be null" );
      }

      [TestMethod]
      public void TestRuntimeConventionChanges()
      {
         var control = "Banana";
         Ikarii.Lib.Havel.Configuration.ConventionTable.Instance.NamingConvention.TableName = ( t ) => control;
         var result = Ikarii.Lib.Havel.Configuration.ConventionTable.Instance.NamingConvention.TableName( typeof( DummyTable ) );

         Assert.IsTrue( result == control, $"Convention.TableName was overriden. Outcome should be 'Banana'. Actual value: '{result}'" );
      }


      public class DummyTable
      {

      }

   }
}
