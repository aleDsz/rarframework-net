using System;
using System.Collections.Generic;
using System.Reflection;

using Necql.Database.Interfaces;

namespace Necql.Database.Factories {
  /// <summary>
  /// Database provider constructor
  /// </summary>
  public static class Provider {
    private static Dictionary<string, IBaseProvider> _providers = new Dictionary<string, IBaseProvider> ();

    /// <summary>
    /// Retrieve database provider from list of providers
    /// </summary>
    /// <param name="options">Database connection options</param>
    /// <returns>New Database provider</returns>
    public static IBaseProvider GetProvider (DatabaseOptions options) {
      if (_providers.ContainsKey(options.Identifier)) {
        return _providers[options.Identifier];
      }

      var provider = CreateInstance (options);
      _providers[options.Identifier] = provider;

      return provider;
    }

    /// <summary>
    /// Create instance for database provider
    /// </summary>
    /// <param name="options">Database connection options</param>
    /// <returns>New Database provider</returns>
    private static IBaseProvider CreateInstance (DatabaseOptions options) {
      try {
        Assembly assembly;

        if (options.Provider == null) {
          var assemblyName = String.Format ("Necql.Database.Providers.{0}", options.Protocol.ToString());
          assembly = Assembly.Load (assemblyName);
        } else {
          assembly = Assembly.GetAssembly (options.Provider.GetType ());
        }

        var provider = (IBaseProvider)assembly.CreateInstance (assembly.GetName ().Name);
        provider.Configure (options);

        return provider;
      } catch (Exception) {
        return null;
      }
    }
  }
}