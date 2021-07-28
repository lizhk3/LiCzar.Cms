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
        /// Main ��������������
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)//�������淽��������һ��IHostBuilder����
                .Build()//�����淵�ص�IHostBuilder���󴴽�һ��Iwebhost����
                .Run();//�������洴����Iwebhost����Ӷ��������ǵ�webӦ�ó��򣬻��仰˵��������һ��һֱ���м���HTTP���������
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)//ʹ��Ĭ�ϵ�������Ϣ����ʼ��һ���µ�IWebHostbuilderʵ��
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();//ΪWeb hostָ�� Startup��
        //        });
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)//ʹ��Ĭ�ϵ�������Ϣ����ʼ��һ���µ�IWebHostbuilderʵ��
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var env = hostingContext.HostingEnvironment;

                 config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                       .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                       .AddJsonFile("Content.json", optional: false, reloadOnChange: false)//reloadOnChange ����Ϊ���б仯�Զ����¼��أ�����Ϊfalse�Ļ������Զ����¼���
                       .AddEnvironmentVariables();

             }).ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();//ΪWeb hostָ�� Startup��
             });
    }
}
