# Version Manager

A .NET console application that manages semantic versioning in JSON configuration files.

## Overview

This application handles version number updates in a JSON file following semantic versioning principles (Major.Minor.Patch). It supports two types of version updates:
- Minor release: Increments the minor version and resets the patch version to 0
- Patch release: Increments the patch version

## Features

- Semantic version management
- JSON file manipulation
- Preserves other JSON content
- Error handling and validation
- Unit test coverage

## Prerequisites

- .NET 9.0 SDK or later
- Windows operating system

## Installation

Clone the repository and build the project:

```bash
dotnet build
```
## Usage
Run the application with the following command:

```bash
<project-path>\c#\bin\Debug\net9.0\c#.exe <release-type> <json-file-path>
 ```
```

Parameters:
- project-path : Path to the project directory
- release-type : Type of release ( minor or patch )
- json-file-path : Path to the JSON file containing version information
Example:

```bash
<project-path>\bin\Debug\net9.0\c#.exe minor "e:\test\c#\ProjectDetails.json"
 ```

## JSON File Format
The application expects a JSON file with the following structure:

```json
{
  "Version": "1.9.0",
  "Patch": {
    "Name": "Patch022024",
    "Directory": "Patch022024",
    "Ordinal": "1",
    "Scripts": [
      "script1.sql",
      "script2.sql"
    ]
  }
}
 ```

## Version Update Rules
1. Minor Release:
   
   - Increments the minor version number
   - Resets patch number to 0
   - Example: 1.9.0 → 1.10.0
2. Patch Release:
   
   - Increments the patch number
   - Example: 1.9.0 → 1.9.1
## Testing
Run the unit tests using:

```bash
dotnet test
 ```

The test suite covers:

- Minor version updates
- Patch version updates
- Error handling scenarios
- File operations
## Error Handling
The application handles various error scenarios:

- Invalid release type
- Invalid version format
- File access issues
- JSON parsing errors
## Project Structure
- Program.cs : Main entry point and command-line handling
- VersionManager.cs : Core version management logic
- VersionManagerTests.cs : Unit tests
- ProjectDetails.json : Sample configuration file