using Microsoft.Extensions.Logging;

namespace MVVMSample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialSymbolsOutlined.ttf", "MaterialSymbols");
                    fonts.AddFont("gadi-almog-regular-aaa.otf", "AlmogRegular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            #region Dependency Inject the views, viewmodel and builder
            
            #endregion
            return builder.Build();
        }
    }
}
