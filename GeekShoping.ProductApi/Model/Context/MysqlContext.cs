using Microsoft.EntityFrameworkCore;

namespace GeekShoping.ProductApi.Model.Context;

public class MysqlContext : DbContext
{
	public MysqlContext(DbContextOptions<MysqlContext> options) : base(options) { }

	public DbSet<Product> Products { get; set; }
}
