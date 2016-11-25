using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using System.Data.SqlClient;
using System.Data;
using APIMvcShopping.Controllers;
using APIMvcShopping.Models;
using System.Data.Common;
using APIMvcShopping.DAL;

namespace MvcShopping.Test
{
    [TestClass]
    public class UnitTest1
    {
        private APIMvcShopping.DAL.MusicStoreEntities _ctx;
        
        [TestInitialize]
        public void Initialize()
        {
            string connStr = "";
            //DbConnection connection = new DbConnection();
            SqlConnection cn = new
                SqlConnection("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = MvcShopping; Integrated Security = True");
            //_ctx = new APIMvcShopping.DAL.MusicStoreEntities("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = MvcShopping; Integrated Security = True");
          
        }

        [TestMethod]
        public void GetAllalbums_ShouldReturnAllalbums()
        {

 

        }
        [TestMethod]
        public void Test_GetCarritos()
        {
            string connString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = MvcShopping; Integrated Security = True";
            SqlConnection cn = new SqlConnection(connString);

            using (cn)
            {
                cn.Open();

                MusicStoreEntities interop_db = new MusicStoreEntities(cn);

                var controller = new ArtistsController(interop_db);

                var result = controller.GetArtists() as List<Album>;

                Assert.IsNotNull(result.Count);


            }

              
            cn.Close();
        }

        [TestMethod]
        public void Test_GetCarritoX()
        {
            string connString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = MvcShopping; Integrated Security = True";
            SqlConnection cn = new SqlConnection(connString);

            using (cn)
            {
                cn.Open();

                MusicStoreEntities interop_db = new MusicStoreEntities(cn);

                var controller = new CartsController(interop_db);

                var result = controller.GetCart(0);

                Assert.IsNotNull(result);


            }


            cn.Close();
        }
        [TestMethod]
        public void Test_SetCarritoX()
        {
            string connString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = MvcShopping; Integrated Security = True";
            SqlConnection cn = new SqlConnection(connString);

            using (cn)
            {
                cn.Open();

                MusicStoreEntities interop_db = new MusicStoreEntities(cn);

                var controller = new CartsController(interop_db);

                Cart cart = new Cart();

             
                var result = controller.PostCart(cart);

                Assert.IsNotNull(result);


            }


            cn.Close();
        }

        [TestMethod]
        public async Task GetAllalbumsAsync_ShouldReturnAllalbums()
        {
            APIMvcShopping.DAL.MusicStoreEntities db = new APIMvcShopping.DAL.MusicStoreEntities();
            var controller = new ArtistsController(db);

            var result = controller.GetArtists() as List<Album>;
            Assert.IsNotNull(result.Count);
        }

        [TestMethod]
        public void Getalbum_ShouldReturnCorrectalbum()
        {
            APIMvcShopping.DAL.MusicStoreEntities db = new APIMvcShopping.DAL.MusicStoreEntities();
            var controller = new ArtistsController(db);

            var result = controller.GetArtists() as List<Album>;
            Assert.IsNotNull(result.Count);
        }

        [TestMethod]
        public void Test1()
        {
            var tasks = new List<Task<int>>();

            // Define a delegate that prints and returns the system tick count
            Func<object, int> action = (object obj) =>
            {
                
                SqlConnection cn = new
                SqlConnection("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = MvcShopping; Integrated Security = True");
                
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                using (cn)
                {
                    cn.Open();

                    cm.CommandText = "CreateArtist3";
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "CreateArtist3";
                    Stopwatch st = new Stopwatch();
                    st.Start();
                    // Wait for all the tasks to finish.
                    //Task.WaitAll(tasks.ToArray()); 

                    cm.ExecuteReader();

                    st.Stop();
                    TimeSpan ts = st.Elapsed;
                    Console.WriteLine(ts.Milliseconds);
                 
                    // We should never get to this point
                }
                int tickCount = Environment.TickCount;
                //Console.WriteLine("Task={0}, i={1}, TickCount={2}, Thread={3}", Task.CurrentId, i, tickCount, Thread.CurrentThread.ManagedThreadId);

                return tickCount;
            };
            
            // Construct started tasks
            for (int i = 0; i < 5000; i++)
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
                //Console.WriteLine(ts.Milliseconds);
                //Console.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.");
            }
            catch (AggregateException e)
            {
            
                
            }
        }
        public void execprocedure()
        {
            SqlConnection cn = new 
             // SqlConnection("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = MvcShopping; Integrated Security = True");
            SqlConnection("integrated security=true;data source=.\\sqlexpress;initial catalog=MusicStoreEntities");
            //SqlConnection(@"C:\Users\Aldo\Desktop\ArquiFinalDevel\TrabajoFinalArqui\MvcShopping\MvcShoppingTest\App_Data\MvcShopping.mdf");
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;

            using (cn)
            {
                cn.Open();
                cm.CommandText = "CreateArtist3";
                cm.CommandType = CommandType.StoredProcedure;
                //cm.CommandText = "CreateArtist3";
                Stopwatch st = new Stopwatch();
                st.Start();
                // Wait for all the tasks to finish.
                //Task.WaitAll(tasks.ToArray()); 

                cm.ExecuteNonQuery();

                st.Stop();
                TimeSpan ts = st.Elapsed;
                Console.WriteLine(ts.Milliseconds);
              
                // We should never get to this point
            }
        }
        [TestMethod]
        public void Test2()
        {
            // Define a delegate that prints and returns the system tick count

            // Construct started tasks

            for (int i = 0; i < 5000; i++)
            {
                int index = i;
                execprocedure();

            }
 
        }

        [TestMethod]
        public async Task GetalbumAsync_ShouldReturnCorrectalbum()
        {
            APIMvcShopping.DAL.MusicStoreEntities db = new APIMvcShopping.DAL.MusicStoreEntities();
            var controller = new ArtistsController(db);

            var result = controller.GetArtists() as List<Album>;
            Assert.IsNotNull(result.Count);

        }
        public void DoSomeWork(int i)
        {
            
        }
        [TestMethod]
        public void Getalbum_ShouldNotFindalbum()
        {
            APIMvcShopping.DAL.MusicStoreEntities db = new APIMvcShopping.DAL.MusicStoreEntities();
            var controller = new ArtistsController(db);

            var result = controller.GetArtists() as List<Album>;
            Assert.IsNotNull(result.Count);
        }

        private List<Artist> GetTestartist()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            

            
            

            var testartist = new List<Artist>();
            for (int i = 1; i < 100; i++)
            {
                testartist.Add(new Artist { Name="Martasa"});
                //Ejecutar subproceso i
            }

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            return testartist;
        }
        private async Task ProcedimientoAsincrono(List<Artist> temp)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();





            var testalbums = new List<Artist>();
            for (int i = 1; i < 1000000; i++)
            {
                testalbums.Add(new Artist { Name = "HOla"+i.ToString()});
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
