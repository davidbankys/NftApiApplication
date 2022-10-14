using NftApiApplication;
using NftApiApplication.Services;

namespace NftApiApplication;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        DependencyService.Register<NftapiDataStoreAPI>();
        DependencyService.Register<WebClientService>();
        MainPage = new AppShell();
    }
}