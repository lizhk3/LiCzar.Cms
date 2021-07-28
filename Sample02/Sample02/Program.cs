using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample02
{
    public class Program
    {
        /// <summary>
        /// Main 方法，程序的入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)//调用下面方法，返回一个IHostBuilder对象
                .Build()//用上面返回的IHostBuilder对象创建一个Iwebhost对象
                .Run();//运行上面创建的Iwebhost对象从而运行我们的web应用程序，换句话说就是启动一个一直运行监听HTTP请求的任务。
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)//使用默认的配置信息来初始化一个新的IWebHostbuilder实例
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();//为Web host指定 Startup类
        //        });
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)//使用默认的配置信息来初始化一个新的IWebHostbuilder实例
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var env = hostingContext.HostingEnvironment;

                 config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                       .AddJsonFile("Content.json", optional: false, reloadOnChange: false)//reloadOnChange 设置为则有变化自动重新加载，设置为false的话不能自动重新加载
                       .AddEnvironmentVariables();

             }).ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();//为Web host指定 Startup类
             });
    }
}
