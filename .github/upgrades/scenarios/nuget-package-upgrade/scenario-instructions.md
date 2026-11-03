# NuGet Package Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Scope**: `Backend/OrderServices/OrderServices.csproj`
- **Target Framework**: `net10.0`
- **Package Policy**: Inspect all direct and transitive packages for known vulnerabilities; upgrade only vulnerable packages to secure compatible stable versions.
- **Pending Changes**: Preserve unrelated changes in place; do not modify unrelated services or broad solution dependencies unless required to resolve an OrderServices vulnerability.
- **Validation**: Restore and build OrderServices; report any remaining advisories.

## Source Control
- **Source Branch**: `microservices`
- **Working Branch**: `microservices` (current branch)
- **Commit Strategy**: Manual
- **Branch Sync**: Disabled

## Decisions
- OrderServices targets `net10.0` and uses standard per-project package references; no central package management applies.
- The current resolved dependency graph has no vulnerable direct or transitive packages according to `dotnet list package --vulnerable --include-transitive`.
- No package version change is warranted; all required remediation is already present in the current graph.
- Preserve unrelated pending changes and unrelated projects.
