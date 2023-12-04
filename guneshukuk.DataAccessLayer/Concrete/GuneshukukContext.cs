﻿using guneshukuk.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guneshukuk.DataAccessLayer.Concrete
{
    public class GuneshukukContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=SRMNVLI;Initial Catalog=guneshukuk;TrustServerCertificate=True;Integrated Security=True");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Consultancy> Consultancies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
    }
}
