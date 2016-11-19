using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcShopping.Controllers;
using MvcShopping.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Diagnostics;
using MvcShopping.DAL;
using System.Data.SqlClient;

namespace MvcShopping.Test
{
    [TestClass]
    public class UnitTest1
    {
        private MusicStoreEntities db = new MusicStoreEntities();
        [TestMethod]
        public void GetAllalbums_ShouldReturnAllalbums()
        {
            var testalbums = GetTestalbums();
            var controller = new AlbumController(testalbums);

            var result = controller.GetAllalbums() as List<Album>;
            Assert.AreEqual(testalbums.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllalbumsAsync_ShouldReturnAllalbums()
        {
            var testalbums = GetTestalbums();
            var controller = new AlbumController(testalbums);

            var result = await controller.GetAllalbumsAsync() as List<Album>;
            Assert.AreEqual(testalbums.Count, result.Count);
        }

        [TestMethod]
        public void Getalbum_ShouldReturnCorrectalbum()
        {
            var testalbums = GetTestalbums();
            var controller = new AlbumController(testalbums);

            var result = controller.Getalbum(4) as OkNegotiatedContentResult<Album>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testalbums[3].Title, result.Content.Title);
        }

        [TestMethod]
        public void Test1()
        {
            var tasks = new List<Task<int>>();

            // Define a delegate that prints and returns the system tick count
            Func<object, int> action = (object obj) =>
            {
                //int i = (int)obj;

                //// Make each thread sleep a different time in order to return a different tick count
                //Thread.Sleep(i * 100);

                //// The tasks that receive an argument between 2 and 5 throw exceptions
                //if (2 <= i && i <= 5)
                //{
                //    //throw new InvalidOperationException("SIMULATED EXCEPTION");
                //}
                SqlConnection cn = new
                SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MvcShopping.mdf;Initial Catalog=MvcShopping;Integrated Security=True");
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                using (cn)
                {
                    cn.Open();
                    cm.CommandText = "CreateArtist3";
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "CreateArtist3";
                    Stopwatch st = new Stopwatch();
                    st.Start();
                    // Wait for all the tasks to finish.
                    //Task.WaitAll(tasks.ToArray()); 
                    cm.ExecuteNonQuery();
                    st.Stop();
                    TimeSpan ts = st.Elapsed;
                    Console.WriteLine(ts.Milliseconds);
                    Console.ReadLine();
                    // We should never get to this point
                }
                int tickCount = Environment.TickCount;
                //Console.WriteLine("Task={0}, i={1}, TickCount={2}, Thread={3}", Task.CurrentId, i, tickCount, Thread.CurrentThread.ManagedThreadId);

                return tickCount;
            };

            // Construct started tasks
            for (int i = 0; i < 1000000; i++)
            {
                int index = i;
                tasks.Add(Task<int>.Factory.StartNew(action, index));
            }
            try
            {
                Stopwatch st = new Stopwatch();
                st.Start();
                // Wait for all the tasks to finish.
                Task.WaitAll(tasks.ToArray());
                st.Stop();
                TimeSpan ts = st.Elapsed;
                // We should never get to this point
                Console.WriteLine(ts.Milliseconds);
                //Console.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.");
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }
        }

        [TestMethod]
        public async Task GetalbumAsync_ShouldReturnCorrectalbum()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();



            var testalbums = GetTestalbums();
            
            var controller = new AlbumController(testalbums);

            Task[] tasks = new Task[100];
            for (int i = 0; i < 100; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => controller.CreateAlbum());
            }
            Task.WaitAll(tasks);

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Assert.IsNotNull(stopwatch.Elapsed);
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine(ts.Milliseconds);
            Console.ReadLine();

        }
        public void DoSomeWork(int i)
        {
            
        }
        [TestMethod]
        public void Getalbum_ShouldNotFindalbum()
        {
            var controller = new AlbumController(GetTestalbums());

            var result = controller.Getalbum(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            Console.WriteLine(result);
        }

        private List<Album> GetTestalbums()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            

            
            

            var testalbums = new List<Album>();
            for (int i = 1; i < 1000000; i++)
            {
                testalbums.Add(new Album { AlbumId = i, Title = "Demo1" + i.ToString(), Price = 1 });
                //Ejecutar subproceso i
            }

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            return testalbums;
        }
        private async Task ProcedimientoAsincrono(List<Album> temp)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();





            var testalbums = new List<Album>();
            for (int i = 1; i < 1000000; i++)
            {
                testalbums.Add(new Album { AlbumId = i, Title = "Demo1" + i.ToString(), Price = 1 });
                //Ejecutar subproceso i
            }

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            temp = testalbums;
        }
    }
}
