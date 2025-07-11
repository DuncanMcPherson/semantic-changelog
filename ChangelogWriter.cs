using System;
using System.Threading.Tasks;
using SemanticRelease.Abstractions;

namespace SemanticRelease.Changelog
{
    public class ChangelogWriter : ISemanticPlugin
    {
        public void Register(SemanticLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        private async Task WriteChangelogAsync(ReleaseContext context)
        {
            
        }
    }
}