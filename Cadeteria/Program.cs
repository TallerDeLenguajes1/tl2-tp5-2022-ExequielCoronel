using Cadeteria.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICadeteRepositorio, CadeteRepositorio>();
builder.Services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

builder.Services.AddSession();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loggin}/{action=Form}/{id?}");

app.Run();
