using TinyFx;
using UGame.Banks.JOB.ServicesExtensions;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = AspNetHost.CreateBuilder();
            builder.Services.AddVerifyOrderService();
            // Add services to the container.
            builder.AddAspNetEx();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            app.UseAspNetEx();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
