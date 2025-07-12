using System;
using System.IO;
using System.Threading.Tasks;
using SemanticRelease.Abstractions;

namespace SemanticRelease.Changelog
{
    public class ChangelogWriter : ISemanticPlugin
    {
        private string Name => "Changelog";
        public void Register(SemanticLifecycle lifecycle)
        {
            lifecycle.OnPrepare(WriteChangelogAsync);
        }

        private async Task WriteChangelogAsync(ReleaseContext context)
        {
            Console.WriteLine($"Beginning step 'prepare' for {Name}");
            if (!context.PluginData.TryGetValue("releaseNotesMD", out var releaseNotes) || releaseNotes is not string releaseNotesMd)
            {
                throw new Exception($"No release notes found in plugin data for {Name}");
            }
            
            if (context.DryRun)
            {
                Console.WriteLine("Dry run, no changes will be made");
                Console.WriteLine($"{releaseNotesMd}");
            }

            // Non-null safe access is safe here because the PluginConfigs dictionary must be present, populated,
            // and have a key: 'SemanticRelease.Changelog' in order for this plugin to be loaded
            var fileName = context.Config.PluginConfigs!["SemanticRelease.Changelog"] as ChangelogConfig;
            var filePath = Path.Combine(context.WorkingDirectory, fileName!.ChangelogFile);
            
            var changelogExists = File.Exists(filePath);
            Console.WriteLine(changelogExists ? $"Updating {filePath}" : $"Creating {filePath}");

            if (!changelogExists)
            {
                await File.WriteAllTextAsync(filePath, "");
            }
            
            var existingContent = await File.ReadAllTextAsync(filePath);
            releaseNotesMd += existingContent;
            await File.WriteAllTextAsync(filePath, releaseNotesMd);
            Console.WriteLine($"Finished step 'prepare' for {Name}");
        }
    }
}