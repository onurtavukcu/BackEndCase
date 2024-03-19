using BackendCase.Models.Input;
using BackendCase.Models.Output;
using BackendCase.Operations.AbstractClientOperation;
using BackendCase.Operations.BookingOperation.CancelBooking;
using BackendCase.Operations.BookingOperation.PostBooking;
using BackendCase.Operations.GetDataOperation;

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

            builder.Services.AddTransient<IPostBookingService, PostBookingService>();
            builder.Services.AddTransient<ICancelBookingService, CancelBookingService>();
            builder.Services.AddTransient<IGetDoctorsDataService, GetDoctorsDataService>();
            builder.Services.AddTransient<IGetDoctorsFreeSlotsDataService, GetDoctorsFreeSlotsDataService>();


            ////Start the UI react project but there was no time 
            //builder.Services.AddCors( 
            //    cors => cors.AddPolicy("myCors", pb =>
            //    {
            //        pb.AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod().Build();
            //    })
            //    );


            ////Start the UI inMemory Db project but there was no time.
            //// The plan was; get doctors and slots data. And add this data to db. 
            //// Also normal user can auhenticate and get book appointmnt. Admin user can export the data. 
            //// So i try to add auth service and give claim for the user. And save user and authorization details in db.

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
            //app.UseCors("myCors");

            app.MapControllers();

            app.Run();
        }
    }
}
