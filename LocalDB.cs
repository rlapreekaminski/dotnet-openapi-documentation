public static class LocalDB
{
    public static List<Session> Sessions { get; private set; } = [];

    public static void Init()
    {
        Sessions = [
            new(Guid.Parse("7B48648A-F0A9-4060-8DF9-7DF9572339FE"),
                "Test an API with Postman and Azure DevOps",
                "Romain",
                new DateTime(2022, 1, 20),
                SessionType.Intermediate,
                ["API", "Postman", "Test", "Azure DevOps"]),
            new (Guid.Parse("19041FB0-18E6-488C-9B7F-A8CEB9450C11"),
                "OWASP Top 10",
                "Eric",
                new DateTime(2022, 2, 17),
                SessionType.Beginner,
                ["Web", "Security"]),
            new (Guid.Parse("BFE2C143-AE7F-4AB0-BFA7-E82545386214"),
                "SSAS cube administration with C#",
                "Julien",
                new DateTime(2022, 2, 24),
                SessionType.Advanced,
                ["SSAS", "C#"])
        ];
    }
}