# Contributing to the IDS peak Example Repository

Thank you for your interest in contributing! This repository contains example code demonstrating the
use of **IDS peak**. We welcome improvements, fixes, new examples, and documentation enhancements.

## How to Contribute

### Reporting Issues
- Open an issue and include OS, SDK/runtime version, camera model, and the language/example you used.
- Provide minimal steps to reproduce, error messages and logs (if applicable).
- Only create issues for the examples in this repository. For general issues with the SDK contact support@ids-imaging.com.

### Submitting Pull Requests
- Keep each PR focused on a single topic (e.g., one example, one bugfix, one documentation change).
- Ensure your branch builds on supported platforms.
- Add/adjust README notes if behavior or prerequisites change.
- Follow code style guidelines below.

## Code Style Guidelines
### General
- Keep examples short and focused on illustrating API usage.
- Avoid unnecessary complexity or verbose code.
- Keep dependencies minimal.
- Whenever possible, write examples to work seamlessly across all supported `IDS peak` platforms.

### C
- All C code in this repository must target the C11 standard.
- Use `clang-format` for formatting. The repository includes a `.clang-format` file.
- Use `clang-tidy` for static checks where appropriate.

### C++
- All C++ code in this repository must target the C++14 standard.
- Use `clang-format` for formatting. The repository includes a `.clang-format` file.
- Use `clang-tidy` for static checks where appropriate.
- Prefer RAII and modern C++ constructs appropriate for C++14.

### Python
- Follow **PEP 8** style conventions.
- Use **ruff** for linting and basic fixes. A `ruff.toml` is provided.
- Add type hints to all Python code and validate them using `mypy`. A `mypy.ini` configuration file is provided in the repository to ensure consistent type-checking behavior.

### C# (.NET)
- An `.editorconfig` is provided to control common formatting rules.
- Examples must target **.NET Framework 4.6.1** or **.NET 6**.
- Prefer idiomatic C#: use standard naming conventions, modern language features, and patterns that are common in the C# community.


## Dependencies & Runtime Notes

### IDS peak Setup
- All C/C++ examples require the [IDS peak Setup](https://en.ids-imaging.com/download-peak.html) with development files to be installed on the target machine.
- Python and C# bindings include the necessary runtime DLLs to *run* the examples. However, the **IDS peak Runtime Setup** is still required to provide GenTL and driver integration.

### Python Packages (PyPI)
- ids-peak: https://pypi.org/project/ids-peak/
- ids-peak-ipl: https://pypi.org/project/ids-peak-ipl/
- ids-peak-afl: https://pypi.org/project/ids-peak-afl/
- ids-peak-icv: https://pypi.org/project/ids-peak-icv/
- ids-peak-common: https://pypi.org/project/ids-peak-common/


## Licensing & Code of Conduct
- Respect third-party licenses for any code you add.
- Be civil and constructive in code reviews and issues.

Thank you for contributing!
