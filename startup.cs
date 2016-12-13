using System.Collections.Generic;
using System.IO;
using Microsoft.AspNet.Builder;
using Nancy;
using Nancy.Owin;
using Nancy.ViewEngines.Razor;

namespace ToDoList
{
  public static class DBConfiguration
  {
    // epicodus server
    public static string ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=todo;Integrated Security=SSPI";
    // home server
    // public static string ConnectionString = "Data Source=desktop-ddsnb9e;Initial Catalog=todo;Integrated Security=SSPI";
  }
  public class Startup
  {
    public void Configure(IApplicationBuilder app)
    {
      app.UseOwin(x => x.UseNancy());
    }
  }
  public class CustomRootPathProvider : IRootPathProvider
  {
    public string GetRootPath()
    {
      return Directory.GetCurrentDirectory();
    }
  }
  public class RazorConfig : IRazorConfiguration
  {
    public IEnumerable<string> GetAssemblyNames()
    {
      return null;
    }

    public IEnumerable<string> GetDefaultNamespaces()
    {
      return null;
    }

    public bool AutoIncludeModelNamespace
    {
      get { return false; }
    }
  }
}
