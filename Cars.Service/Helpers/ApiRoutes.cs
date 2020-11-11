namespace Cars.Service.Helpers
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Register = "register";
            public const string Login = "login";
        }
    }
}
