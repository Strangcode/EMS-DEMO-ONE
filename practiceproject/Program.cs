using Microsoft.EntityFrameworkCore;
using practiceproject.DbContextData;
using practiceproject.Models;
using practiceproject.HelperClasses;
using practiceproject.Repository;
using practiceproject.Repository.NewIemployee;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using practiceproject.Repository.AttendanceRepos;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextClass>(
    opt=> opt.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection"))
    );

builder.Services.AddScoped<IDepartment,DepartmentRepository>();
builder.Services.AddScoped<NewIemployeeRepository,NewEmployeeReppository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

builder.Services.AddSession();

var app = builder.Build();


// Creating scope for Admin Creation
// step 1 : Create a scope for the services
using (var scope = app.Services.CreateScope())
{
    // step 2 : Get the required services from the scope
    var context = scope.ServiceProvider.GetRequiredService<ContextClass>();
    // step 3 : Check if the admin user already exists
    var admninuser = context.RegisterUsers.FirstOrDefault(u=>u.Role == "Admin");

    // step 4 : If the admin user does not exist, create one

    if(admninuser == null)
    {
        // Create the admin user
        var objectuser = new UserRegistration()
        {
            Id = Guid.NewGuid(),
            Email = "Admin123@gmail.com",
            PasswordHash = PasswordHasher.Passwordhashing("Admin@!123"),
            Role = "Admin"

        };
        // step 5 : Add the admin user to the database and save changes
        context.RegisterUsers.Add(objectuser);
        context.SaveChanges();

    }



}



// finish scope for User Creation

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AuthentiCation}/{action=RegisterViewModel}/{id?}");

app.Run();
