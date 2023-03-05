using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StreamRipper.Extensions;
using StreamRipper.Interfaces;
using StreamRipper.Models;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Error)
                .AddStreamRipper()
                .BuildServiceProvider();

            var streamRipperFactory = serviceProvider.GetService<IStreamRipperFactory>();

            var stream = streamRipperFactory.New(new StreamRipperOptions
            {
                Url = new Uri("https://desertmountainbroadcasting.streamguys1.com/KYYA"),
                MaxBufferSize = 50 * 1000000    // stop when buffer size passes 50 megabytes
            });

            stream.SongChangedEventHandlers += (_, arg) =>
            {
                Console.WriteLine(arg.SongInfo);

                string fileName = arg.SongInfo.SongMetadata.ToString();

                foreach(char invalidPathChar in Path.GetInvalidFileNameChars())
                {
                    fileName = fileName.Replace(invalidPathChar.ToString(), string.Empty);
                }

                File.WriteAllBytes($"{fileName}.mp3", arg.SongInfo.Stream.ToArray());
            };
            
            stream.Start();

            Console.ReadKey();
        }
    }
}