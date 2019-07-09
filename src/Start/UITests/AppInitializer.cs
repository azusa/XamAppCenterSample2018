using Xamarin.UITest;

namespace XamAppCenterSample2018.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .PreferIdeSettings()
                    .InstalledApp("XamAppCenterSample2018")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .EnableLocalScreenshots()
                .PreferIdeSettings()
                .InstalledApp("jp.fieldnotes.XamAppCenterSample2018")
                .StartApp();
        }
    }
}