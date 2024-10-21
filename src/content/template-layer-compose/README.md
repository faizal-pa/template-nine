# Template9

Add details needed to prepare this package to run locally.
- Nuget sources
- Cloud account configurations
- Pipeline configuration
- appsettings.local.json settings

#### Disable Swagger Post Build Specification Generation

In Visual Studio Code, the Swagger post build event can be disabled by adding the following section to the build task in `./.vscode/tasks.json`.

```json
"options": {
  "env": {
    "RunPostBuildEvt": "false"
  }
},
```