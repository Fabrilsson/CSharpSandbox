using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApiRequester
{
    class Program
    {
        public static HttpClient _client = new HttpClient();

        static async Task Main(string[] args)
        {
            var sw = new CustomStopwatch();

            sw.Start();

            for (var i = 0; i < 100; i++)
            {
                var tasks = new List<Task>();

                for (var j = 0; j < 5000; j++)
                {
                    var request = new HttpRequestMessage
                    (
                        HttpMethod.Get,
                        "http://127.0.0.1:3030/bigstringRust"
                    );

                    var task = _client.SendAsync(request);
                    tasks.Add(task);
                }

                await Task.WhenAll(tasks);
            }

            sw.Stop();

            Console.WriteLine
            (
                "Rust Stopwatch elapsed: {0}, StartAt: {1}, EndAt: {2}",
                sw.ElapsedMilliseconds,
                sw.StartAt.Value,
                sw.EndAt.Value
            );

            sw.Reset();

            sw.Start();

            for (var i = 0; i < 100; i++)
            {
                var tasks = new List<Task>();

                for (var j = 0; j < 5000; j++)
                {
                    var request = new HttpRequestMessage
                    (
                        HttpMethod.Get,
                        "http://localhost:5000/api/bigstringCS"
                    );

                    var task = _client.SendAsync(request);
                    tasks.Add(task);
                }

                await Task.WhenAll(tasks);
            }

            sw.Stop();

            Console.WriteLine
            (
                "CS Stopwatch elapsed: {0}, StartAt: {1}, EndAt: {2}",
                sw.ElapsedMilliseconds,
                sw.StartAt.Value,
                sw.EndAt.Value
            );
        }
    }

    public class CustomStopwatch : Stopwatch
    {

        public DateTime? StartAt { get; private set; }
        public DateTime? EndAt { get; private set; }

        public void Start()
        {
            StartAt = DateTime.Now;

            base.Start();
        }

        public void Stop()
        {
            EndAt = DateTime.Now;

            base.Stop();
        }

        public void Reset()
        {
            StartAt = null;
            EndAt = null;

            base.Reset();
        }

        public void Restart()
        {
            StartAt = DateTime.Now;
            EndAt = null;

            base.Restart();
        }

    }
}
