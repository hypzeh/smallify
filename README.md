![Smallify](./docs/assets/project-title.png)
[![Build Status](https://nick-smirnoff.visualstudio.com/smallify/_apis/build/status/build/smallify-CI?branchName=master)](https://nick-smirnoff.visualstudio.com/smallify/_build/latest?definitionId=13?branchName=master)
---

Smallify is a simple WPF application built to provide a small music player for Spotify.

## Usage

Smallify requires an `Access Token`, which can be generated on user request from `Spotify Accounts Service`, by connecting to a Spotify account, see [Smallify authentication site](https://hypzeh.github.io/smallify).

### Requirements

- Windows 10
- .NET Framework v4.7.2
- Spotify Premium

### Notes

- Smallify is **NOT** a standalone Spotify device, users will need to have an official Spotify device/application on standby (this will be the audio source)
- Smallify uses [Implicit grant flow](https://developer.spotify.com/documentation/general/guides/authorization-guide/#implicit-grant-flow) for authentication
  - Users are directed to `Spotify Accounts Service` with a request for the following permission scopes:
    - `user-modify-playback-state`
    - `user-read-playback-state` 
    - `user-read-currently-playing`
  - Tokens last one hour

## Screenshots

![player-screenshot](./docs/assets/screenshots/player-screenshot.png)

## Related Projects

- ['Spofy' by eltoncezar](https://github.com/eltoncezar/Spofy) - A Spotify mini player and notifier for Windows
