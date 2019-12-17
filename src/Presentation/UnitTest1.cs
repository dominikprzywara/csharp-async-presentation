using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Presentation
{
    public class Tests
    {
        [Test]
        public async Task DispatchTest()
        {
            var testing = new DispatchTest();
            await testing.ImportantMethod();
        }

        [Test]
        public void Exception_Wait()
        {
            var sut = new Exceptions();

            var tasks = new List<Task>
            {
                sut.DownloadA(),
                sut.DownloadB(),
                sut.DownloadC()
            };

            Assert.Throws<AggregateException>(() => { Task.WaitAll(tasks.ToArray()); });
        }

        [Test]
        public void Exception_Wait_InnerExceptions()
        {
            var sut = new Exceptions();

            var tasks = new List<Task>
            {
                sut.DownloadA(),
                sut.DownloadB(),
                sut.DownloadC()
            };

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                Assert.AreEqual(3, ex.InnerExceptions.Count);
            }
        }

        [Test]
        public async Task Exception_WhenAll()
        {
            var sut = new Exceptions();

            var tasks = new List<Task>
            {
                sut.DownloadA(),
                sut.DownloadB(),
                sut.DownloadC()
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await Task.WhenAll(tasks));
        }

        [Test]
        public async Task Exception_WhenAll_InnerExceptions()
        {
            var sut = new Exceptions();

            var tasks = new List<Task>
            {
                sut.DownloadA(),
                sut.DownloadB(),
                sut.DownloadC()
            };

            Task task = Task.WhenAll(tasks);
            try
            {
                await task;
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(3, (task.Exception as AggregateException).InnerExceptions.Count);
            }
        }

        [Test]
        public async Task Eliding_Without_ExceptionHandling()
        {
            var sut = new Eliding();

            try
            {
                Console.WriteLine($"Starting {nameof(sut.WithoutEliding)}");
                var task = sut.WithoutEliding();
                Console.WriteLine("I don't really care, because await is later");
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Test]
        public async Task Eliding_With_ExceptionHandling()
        {
            var sut = new Eliding();

            try
            {
                Console.WriteLine($"Starting {nameof(sut.WithEliding)}");
                var task = sut.WithEliding();
                Console.WriteLine("I don't really care, because await is later");
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}