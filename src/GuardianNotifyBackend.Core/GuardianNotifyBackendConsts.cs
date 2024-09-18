using GuardianNotifyBackend.Debugging;

namespace GuardianNotifyBackend
{
    public class GuardianNotifyBackendConsts
    {
        public const string LocalizationSourceName = "GuardianNotifyBackend";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7b52a353bdc44e85996b8073aa7aee34";
    }
}
