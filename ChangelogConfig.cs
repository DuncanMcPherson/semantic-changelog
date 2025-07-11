namespace SemanticRelease.Changelog;

public class ChangelogConfig
{
    public string ChangelogFile { get; } = "CHANGELOG.md";

    public ChangelogConfig(string? changelogFile = null)
    {
        ChangelogFile = changelogFile ?? ChangelogFile;
    }
}