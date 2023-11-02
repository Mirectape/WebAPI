using Microsoft.AspNetCore;
using WebAPI.Data;
using WebAPI.Interfaces;


namespace WebAPI
{

    // https://habr.com/ru/company/mailru/blog/342526/
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