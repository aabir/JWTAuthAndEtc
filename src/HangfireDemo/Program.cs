using Hangfire;

namespace HangfireDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //hangfire
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=ACCESS-1F4GS93;Initial Catalog=JwtAuth;Integrated Security=True;Pooling=False"));
            builder.Services.AddHangfireServer();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHangfireDashboard();

            app.MapControllers();

            app.Run();
        }
    }
}