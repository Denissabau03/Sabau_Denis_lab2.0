using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sabau_Denis_lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    policy.RequireRole("Admin"));
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Sabau_Denis_lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sabau_Denis_lab2Context") ?? throw new InvalidOperationException("Connection string 'Sabau_Denis_lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'LibraryIdentityContextConnection' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)

    .AddEntityFrameworkStores<LibraryIdentityContext>();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();