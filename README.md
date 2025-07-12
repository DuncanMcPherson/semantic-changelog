# SemanticRelease.Changelog

A .NET library for automatically generating and updating CHANGELOG files as part of semantic release workflows.

## Overview

SemanticRelease.Changelog is a plugin for the semantic-release ecosystem that automates the creation and maintenance of changelog files. It integrates with your CI/CD pipeline to generate structured, consistent release notes based on your commit history.

## Features

- Automatic generation of CHANGELOG.md files
- Integration with semantic-release workflows
- Configurable changelog format
- Support for dry-run mode to preview changes

## Installation

You can install the plugin via the CLI:
```bash
dotnet add package SemanticRelease.Changelog
```

You can also allow the [semantic-release](https://github.com/DuncanMcPherson/dotnet-semantic-release) tool to resolve the package reference by using it in your
`semantic-release.json` file.

## Usage

This library implements the `ISemanticPlugin` interface from the SemanticRelease.Abstractions package. To use it in your semantic-release workflow:

Add the plugin to your plugins list after any release notes generation plugins:
```json
{
  "pluginConfigs": [
    "SemanticRelease.Changelog"
  ]
}
```

## Configuration

The default configuration uses "CHANGELOG.md" as the target file, but you can customize this:

```json
{
  "pluginConfigs": [
    {
      "name": "SemanticRelease.Changelog",
      "options": {
        "changelogFile": "custom-file-name.md"
      }
    }
  ]
}
```

At the time of this writing, alternate file formats are NOT supported

## Requirements

- .NET Standard 2.1
- SemanticRelease.Abstractions package

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
