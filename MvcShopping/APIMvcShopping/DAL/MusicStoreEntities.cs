using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIMvcShopping.Models;
using System.Data.Entity;
using System.Data.Common;
using System.Data.SqlClient;

namespace APIMvcShopping.DAL
{
    public class MusicStoreEntities : DbContext
    {


        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        public MusicStoreEntities() : base("MusicStoreEntities")
        {

        }

        public MusicStoreEntities(SqlConnection connection) : base(connection,true) { }
    }
}