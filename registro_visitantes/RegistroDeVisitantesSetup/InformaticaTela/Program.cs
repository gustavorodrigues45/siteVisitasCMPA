using InformaticaTela.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Configuração dos serviços
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddScoped<IVisitService, MockVisitService>();

        // HttpClient para o Blazor consumir a API
        builder.Services.AddHttpClient();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host"); // funciona em Blazor Server

        // 👉 Endpoint que retorna visitas em JSON (mock)
        app.MapGet("/api/visitas", (IVisitService service) =>
        {
            return Results.Json(service.GetVisitasDiarias());
        });

        app.Run();
    }
}
