using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FourTask_Lucas.Areas.Identity.Data;
using FourTask_Lucas.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FourTask_LucasContextConnection") ?? throw new InvalidOperationException("Connection string 'FourTask_LucasContextConnection' not found.");

builder.Services.AddDbContext<FourTask_LucasContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FourTask_LucasContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Isso aqui serve para configurar a injeção de dependência nos Repositories
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages(); //Adicionado

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
