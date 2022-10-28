using Microsoft.EntityFrameworkCore;
using WebMvc_oracle.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var stringConexao = "User Id=rm88264;Password=250203;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=ORACLE.FIAP.COM.BR)(PORT=1521)))(CONNECT_DATA=(SID=ORCL)))";

builder.Services.AddDbContext<Contexto>
    (options => options.UseOracle(stringConexao));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
