using Microsoft.EntityFrameworkCore;
using QuizWebApp; // jeśli DbContext w osobnym folderze


var builder = WebApplication.CreateBuilder(args);

// Dodanie Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


// Dodanie DbContext
builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseSqlite("Data Source=quiz.db"));

var app = builder.Build();

// Wykonanie migracji i seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<QuizDbContext>();
    db.Database.Migrate();
    seeder.Seed(db);
}

// Konfiguracja routingu
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();


app.Run();