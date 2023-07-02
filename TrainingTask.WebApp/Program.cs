using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TrainingTask.WebApp.Data;
using TrainingTask.WebApp.Options.Seeding;
using TrainingTask.WebApp.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["Default"], builder =>
        builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Configuration.AddJsonFile("seeding.json",false);
builder.Services.AddOptions<SeedingOption>().Bind(builder.Configuration.GetSection(SeedingOption.Seeding)).ValidateDataAnnotations();
builder.Services.AddScoped<IModelSeeder, ModelSeeder>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
