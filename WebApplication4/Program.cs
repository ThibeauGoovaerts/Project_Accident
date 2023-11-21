using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AccidentContext");
builder.Services.AddDbContext<AccidentContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AccidentContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AccidentContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.Use(async (context, next) => {
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("frame-ancestors", "none");
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AccidentContext>();
    context.Database.EnsureCreated();
    PersonInitializer.Initialize(context);
    DeviationInitializer.Initialize(context);
    DeviationDetailInitializer.Initialize(context);
    MaterialAgentInitializer.Initialize(context);
    MaterialAgentDetailInitializer.Initialize(context);
    DirectMesureInitializer.Initialize(context);
    FundamentaryCauseInitializer.Initialize(context);
    ProtectionInitializer.Initialize(context);
    LocationInitializer.Initialize(context);
    LesionSeatInitializer.Initialize(context);
    LesionSeatDetailInitializer.Initialize(context);
    NatureLesionInitializer.Initialize(context);
    NatureLesionDetailInitializer.Initialize(context);
    ProposedMesureInitializer.Initialize(context);
    ProposedMesureDetailInitializer.Initialize(context);
    UsersInitializer.Initialize(services,context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
