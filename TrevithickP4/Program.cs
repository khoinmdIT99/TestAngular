//James Trevithick          jtrevithick2@cnm.edu                TrevithickP4

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace TrevithickP4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
