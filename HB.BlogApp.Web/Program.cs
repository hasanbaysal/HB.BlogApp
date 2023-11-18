using HB.BlogApp.BL.Extentions;
using HB.BlogApp.DAL.Extentions;
using HB.BlogApp.Dto.EmailConfigs;
using HB.BlogApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddBLDepecenies();
builder.Services.AddDALDependencies(builder.Configuration.GetConnectionString("SqlCon"));


builder.Services.Configure<EmailOption>(builder.Configuration.GetSection("EmailOption"));
var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    var usermanager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    
    await rolemanager.CreateAsync(new AppRole() { Name = "admin" });

    await usermanager.CreateAsync(new AppUser() {Name="admin" ,SurName="admin", Email = "admin@admin.com", UserName = "sistemAdmin", EmailConfirmed = true }, "A456.!asd567gg");


     var admin = await usermanager.FindByNameAsync("sistemAdmin");

    await usermanager.AddToRoleAsync(admin, "admin");

    


}



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
