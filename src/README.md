# Template9 Templates

Contains opinionated templates for building web apis, nuget packages, solution layers and common libraries.

TODO: Describe the architecture and the purpose of each layer

# Installation

In order to install the templates, you must configure this user/organization as a [Nuget source](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry).

Install the templates from the command line with an optional version number:

```
dotnet new install Template9 --version [version]
```

Packages can be update when new versions have been release using:

```
dotnet new update
```

# Project Templates

> [!NOTE]
> After creation, each template will attempt to restore dependencies and add all created projects to the solution.

| Template                       | Short Name  | Description                                                                |
|--------------------------------|-------------|----------------------------------------------------------------------------|
| Template9 Composition Layer    | [compose]() | Composition layer for wiring up controllers and dependencies for a WebApi. |
| Template9 Controllers Layer    | [ctrl]()    | Controllers and DTOs                                                       |
| Template9 Engines Layer        | [engine]()  | Abstractions, default implementation, and test package for engines         |
| Template9 Infrastructure Layer | [infra]()   | Abstractions, default implementation, and test package for infrastructure  |
| Template9 Managers Layer       | [manager]() | Abstractions, default implementation, and test package for managers        |
| Template9 Mapper Layer         | [mapper]()  | Abstractions, default implementation, and test package for mapper          |
| Template9 Utilities Layer      | [util]()    | Implementation and test package for utilities                              |

## Options

| Option                 | Description                                                                                          |
|------------------------|------------------------------------------------------------------------------------------------------|
| `--name <OUTPUT_NAME>` | The name for the created output. If no name is specified, the name of the current directory is used. |

### Mapper Layer

The mapping layer comes in two flavors. By default, the mapping layer will include all of the abstractions needed for `IAutoMapperConfiguration`. In instances where you want these abstractions to be provided using a [external library](), the name of the package can be supplied - along with an optional semver expression - and that will be used instead.

| Option                           | Default Value | Description                                                                                        |
|----------------------------------|:-------------:|----------------------------------------------------------------------------------------------------|
| `--mapper-pkg <PKG_NAME>`        | N/A           | The name of the package that will provided the `IAutoMapperConfiguration` abstractions.            |
| `--mapper-pkg-version <PKG_VER>` | 1.0.*         | The version of the above package. Must be a valid version that can be restored via a Nuget source. |

# Solution Templates

| Template                       | Short Name | Description                                                               |
|--------------------------------|------------|---------------------------------------------------------------------------|
| Template9 Nuget Class Library  | pkglib     | Nuget package project for a class library                                 |
| Template9 Nuget Client Library | client     | Nuget package project for a client class library                          |
| Template9 Common Libraries     | common     | Templates for creating a set of common libraries.                         |

## Options

| Option                     | Description                                                                                          |
|----------------------------|------------------------------------------------------------------------------------------------------|
| `--name <OUTPUT_NAME>`     | The name for the created output. If no name is specified, the name of the current directory is used. |
| `--authors <AUTHOR_NAME>`  | The name of the package author. If no author is specified, the csproj file will need to be edited.   |
| `--license <LICENSE_EXPR>` | The license expression for the package. If not specified, defaults to `MIT`.                         |
| `--github-org <ORG_NAME>`  | The GitHub organization name. When provided, the `.github` directory will be included in the output. |
| `-add-nuget`               | When used with the `--github-org` flag, will add workflows to push to Nuget.org                      |

### Common Library Options

The common libraries require an additional `--lib` flag to specify the library type using one of the following options:

| Option Value | Description                             |
|--------------|-----------------------------------------|
| abstractions | Create the common abstractions library. |
| exceptions   | Create the common exceptions library.   |
| extensions   | Create the common extensions library.   |
| logging      | Create the common logging library.      |
| mapper       | Create the common mapper library.       |
| redis        | Create the common redis library.        |
| secrets      | Create the common secrets library.      |
| testing      | Create the common testing library.      |
| webapi       | Create the common webapi library.       |

> [!TIP]
> The mapper library contains the abstractions needed for a [mapper layer](#mapper-layer) that is using an external library.

#### AWS Secrets Manager vs Azure KeyVault

For the secrets library, an additional `cloud` option must be specified to indicate which cloud platform is being used.

| Option | Platform | Description                                                                     |
|--------|----------|---------------------------------------------------------------------------------|
| cloud  | aws      | Creates a library for adding the AWS Secrets Manager as a configuration source. |
| cloud  | azure    | Creates a library for adding the Azure Key Vault as a configuration source.     |

## Using GitHub

When the `--use-github` option is set the output will include a `.github` directory which will include a [CODEOWNERS](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-code-owners) file as well as default workflows for pull requests and publishing. The `--github-org` option will be required, and will be used to update the workflows to push packages to the correct organization.