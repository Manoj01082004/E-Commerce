# NuGet package upgrade assessment

_Mode: **quick assessment** — package API diffs only; no per-project source scan was run._

## Recommended versions

- **System.Security.Cryptography.Pkcs**: **9.0.21** (unified across 3 project(s)).

## Public API changes

> **Types moved (namespace changed) are not removals.** A moved type keeps its name and members;
> the fix is a `using`-directive change, not a rewrite. Do not treat a moved type as deleted.

- **System.Security.Cryptography.Pkcs**: no source-breaking public API changes detected — see [`apidiff/System.Security.Cryptography.Pkcs.apidiff.md`](apidiff/System.Security.Cryptography.Pkcs.apidiff.md).

## Breaking-change findings

- Version divergence findings (Pkg.0003): 0
- Requested-version-unsupported findings (Pkg.0002): 0

- Quick mode does not scan source, so there are no per-line `PkgApi` usage findings. Review the
  per-package API diffs above and rely on build errors during execution to pinpoint affected code.
- A full code scan can locate the exact source location of every breaking-change usage across the repo.
  It is opt-in and slower — re-run the assessment with `fullScan=true` only if the user requests it.

## Next steps

1. Proceed to planning to triage the API changes above and plan the code fixes (if any).

# NuGet package vulnerability assessment

## Scope

- Project: `Backend/ProductServices/ProductServices.csproj`
- Target framework: `net10.0`
- Package management: standard per-project `PackageReference`; no central package management applies.

## Direct packages inspected

- `AutoMapper` 16.2.0
- `Microsoft.AspNetCore.Authentication.JwtBearer` 10.0.14
- `Microsoft.AspNetCore.OpenApi` 10.0.14
- `Microsoft.EntityFrameworkCore.Design` 10.0.14
- `Microsoft.EntityFrameworkCore.SqlServer` 10.0.14
- `Microsoft.EntityFrameworkCore.Tools` 11.0.0-rc.3.26522.148
- `Scalar.AspNetCore` 2.18.7

## Vulnerability finding and remediation

- Vulnerable transitive package: `System.Security.Cryptography.Pkcs` 9.0.11.
- Advisories: GHSA-846f-f764-76mx (high) and GHSA-2fmv-rv2c-59x7 (moderate).
- Stable compatible version selected by `get_supported_package_version` for `net10.0`: `10.0.14`.
- Remediation: add a direct `System.Security.Cryptography.Pkcs` 10.0.14 reference in `Backend/ProductServices/ProductServices.csproj` so NuGet resolves the secure version without changing unrelated packages.

## Post-change audit

`dotnet list package --vulnerable --include-transitive` reports that ProductServices has no vulnerable packages given the configured sources. Restore completes without NU190x warnings, and the resolved package list shows `System.Security.Cryptography.Pkcs` 10.0.14.

## Build note

Restore succeeds. Compilation remains blocked by existing ProductServices source/integration errors for missing `E_CommerceDTO.Context.ECommerceDBContext`, `CartItem`, and `OrderItem` types. No unrelated source changes were made to address these baseline errors.

