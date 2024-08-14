namespace RememberThis.Services
{
    public static class PlatformProperties
    {
        public const double DefaultWidthDesktop = 1920;
        public const double DefaultHeightDesktop = 1080;

        public const double DefaultWidthMobile = 1080;
        public const double DefaultHeightMobile = 1920;

        public static double WidthScaling
        {
            get
            {
                if (IsDesktop()) return 0.3164 * DeviceDisplay.Current.MainDisplayInfo.Width / DefaultWidthDesktop;
                return DeviceDisplay.Current.MainDisplayInfo.Width / DefaultWidthMobile;
            }
        }

        public static double HeightScaling
        {
            get
            {
                if (IsDesktop()) return DeviceDisplay.Current.MainDisplayInfo.Height / DefaultHeightDesktop;
                return DeviceDisplay.Current.MainDisplayInfo.Height / DefaultHeightMobile;
            }
        }

        public static bool IsDesktop() =>
            DeviceInfo.Current.Platform == DevicePlatform.WinUI ||
            DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst ||
            DeviceInfo.Current.Platform == DevicePlatform.macOS;

        public static bool IsMobile() => !IsDesktop();
    }
}