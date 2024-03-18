namespace BackendCase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient(); // add HttpClient for use the HttpClient

            builder.Services.AddCors(
                cors => cors.AddPolicy("myCors", pb =>
                {
                    pb.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod().Build();
                })
                );

            //builder.Services.AddScoped<InMemoryDb>();

            //builder.Services.AddScoped<IUserService, UserService>();

            //builder.Services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //builder.Services.AddAuthorization(
            //   opt =>
            //   {
            //       opt.AddPolicy(UserTypeEnums.admin.ToString(), policy => policy.RequireClaim("Role", "admin"));
            //       opt.AddPolicy(UserTypeEnums.regularUser.ToString(), policy => policy.RequireClaim("Role", "regular"));
            //   }
            //   );

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("myCors");

            app.MapControllers();

            app.Run();
        }
    }
}
