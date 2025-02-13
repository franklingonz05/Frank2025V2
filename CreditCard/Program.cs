using CreditCard.Interfaces;
using CreditCard.Service;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Configurar HttpClientFactory con URL base para todos los repositorios
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://franktest2025api-fcgnhce6a6e7escx.canadacentral-01.azurewebsites.net/api/"); //'https://localhost:7218/api/Transaction/ByCard
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Registrar el repositorio genérico
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICreditCardsService, CreditCardsService>();



builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPdfService, PdfService>();

QuestPDF.Settings.License = LicenseType.Community;

// Add services to the container.
builder.Services.AddControllersWithViews();

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
