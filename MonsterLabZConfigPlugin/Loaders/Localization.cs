extern alias MonsterLabZN;

namespace MonsterLabZConfig.Loaders
{
    internal static class LocalizationLoader
    {
        internal static void Load()
        {
            MonsterLabZN::LocalizationManager.Localizer.Load();
        }
    }
}
