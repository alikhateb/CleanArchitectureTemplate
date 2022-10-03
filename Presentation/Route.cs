namespace Presentation
{
    public static class Route
    {
        private const string BaseUrl = "/api";

        public static class WebinarRoute
        {
            private const string SubBaseUrl = BaseUrl + "/webinar";
            public const string GetAll = SubBaseUrl;
            public const string GetById = SubBaseUrl + "/{id}";
            public const string Create = SubBaseUrl;
            public const string Update = SubBaseUrl;
            public const string Delete = SubBaseUrl + "/{id}";
        }
    }
}
