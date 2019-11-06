![Smallify](./docs/.assets/project-title.png)

[![Build Status](https://nick-smirnoff.visualstudio.com/smallify/_apis/build/status/build/smallify-CI?branchName=master)](https://nick-smirnoff.visualstudio.com/smallify/_build/latest?definitionId=13?branchName=master)

---

_Smallify is a WPF application built with .NET Core 3, aiming to provide a simple and minimalistic Spotify experience._

## Installation

## Usage

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

### Development Setup

#### Application Settings

Ensure to provide relevant values to the application settings defined in `Resources.resx`, but keep your values secret and out of source control. The CI pipeline replaces token values with a `#{` prefix and a `}` suffix.

- `APP_CENTER_CLIENT_ID` - _(Optional)_ You can get this from [App Center](https://appcenter.ms/)
- `SPOTIFY_CLIENT_ID` - _(Required)_ You can get this from [Spotify Developer Dashboard](https://developer.spotify.com/dashboard/) by registering your personal development client
- `SPOTIFY_CLIENT_SECRET` - _(Required)_ You can get this from [Spotify Developer Dashboard](https://developer.spotify.com/dashboard/) by registering your personal development client

#### Scripts

Useful scripts can be found in the `/scripts` folder.

- `Clean-Outputs.ps1` - Run this to clean out all the `bin` and `obj` folders

## Similar Projects

- ['Spofy' by eltoncezar](https://github.com/eltoncezar/Spofy) - A Spotify mini player and notifier for Windows
