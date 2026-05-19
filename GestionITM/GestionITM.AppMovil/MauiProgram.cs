using GestionITM.AppMovil.Handlers;
using GestionITM.AppMovil.Services;
using GestionITM.AppMovil.ViewModels;
using GestionITM.AppMovil.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace GestionITM.AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()          // necesario para CommunityToolkit.Mvvm
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // ── URL base de la API ──────────────────────────────────────────
            // En emulador Android, 10.0.2.2 apunta a localhost de tu PC
            const string baseUrl = "http://10.0.2.2:5016/";

            // ── Handler del token (interceptor) ────────────────────────────
            builder.Services.AddTransient<AuthTokenHandler>();

            // ── HttpClient para AuthService (sin token, es el login) ───────
            builder.Services.AddHttpClient<AuthService>(c =>
                c.BaseAddress = new Uri(baseUrl));

            // ── HttpClient para CursoService y MatriculaService (con token) ─
            builder.Services.AddHttpClient<CursoService>(c =>
                c.BaseAddress = new Uri(baseUrl))
                .AddHttpMessageHandler<AuthTokenHandler>();

            builder.Services.AddHttpClient<MatriculaService>(c =>
                c.BaseAddress = new Uri(baseUrl))
                .AddHttpMessageHandler<AuthTokenHandler>();

            // ── ViewModels ─────────────────────────────────────────────────
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<CursosViewModel>();

            // ── Páginas ────────────────────────────────────────────────────
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<CursosPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}