using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DB : DbContext
    {
        public DB() : base("SSG")
        {

        }
        public DbSet<Tbl_Company> Tbl_Companies { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Usergroup> UserGroups { get; set; }
        public DbSet<Userroles> UserRoles { get; set; }
        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<Depots> Depots { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<CostGroup> CostGroups { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountBook> AccountBooks { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Tax> Taxs { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Factors> Factors { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<EmailPanel> EmailPanel { get; set; }
        public DbSet<SendEmail> SendEmail { get; set; }
        public DbSet<SmsPanel> SmsPanel { get; set; }
        public DbSet<SendSMS> SendSMS { get; set; }
        public DbSet<PosDevice> PosDevices { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
