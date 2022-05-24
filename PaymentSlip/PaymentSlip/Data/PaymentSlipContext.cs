using Microsoft.EntityFrameworkCore;
using PaymentSlip.Model;

namespace PaymentSlip
{
    public class PaymentSlipContext : DbContext
    {
        public DbSet<Slip> Slip { get; set; }

        public PaymentSlipContext(DbContextOptions<PaymentSlipContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\Luka\Documents\Repository\Vjezba_6\payment_slip.db");


    }
}

