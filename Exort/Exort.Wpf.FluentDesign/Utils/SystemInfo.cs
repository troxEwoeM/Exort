using System;
using System.Linq;
using System.Management;

namespace Exort.Wpf.FluentDesign.Utils
{
    internal class SystemInfo
    {
        public static Lazy<VersionInfo> Version { get; } = new Lazy<VersionInfo>(GetVersionInfo);


        internal static VersionInfo GetVersionInfo()
        {
            using (var mc = new System.Management.ManagementClass("Win32_OperatingSystem"))
            using (var moc = mc.GetInstances())
            {
                foreach (var managementBaseObject in moc)
                {
                    var mo = (ManagementObject) managementBaseObject;
                    if (!(mo["Version"] is string version)) continue;
                    var versionNumbers = version.Split('.')
                        .Select(int.Parse)
                        .ToList();

                    var info = new VersionInfo()
                    {
                        Major = versionNumbers[0],
                        Minor = versionNumbers[1],
                        Build = versionNumbers[2],
                    };
                    return info;
                }
            }
            return default(VersionInfo);
        }
        
        internal static bool IsWin10()
        {
            return Version.Value.Major == 10;
        }
        
        internal static bool IsWin7()
        {
            return Version.Value.Major == 6 && Version.Value.Minor == 1;
        }

        internal static bool IsWin8x()
        {
            return Version.Value.Major == 6 && (Version.Value.Minor == 2 || Version.Value.Minor == 3);
        }
    }
}