﻿using Microsoft.EntityFrameworkCore;
 
namespace StudentsAPI.Models
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}