[![Smallify](.\docs\assets\project-title.png)](#)
[![Build Status](https://nick-smirnoff.visualstudio.com/smallify/_apis/build/status/build/smallify-CI?branchName=master)](https://nick-smirnoff.visualstudio.com/smallify/_build/latest?definitionId=13?branchName=master)
---

# Smallify

This is a WPF application using `Prism` & `Unity`, intended to provide a mini Spotify player for Windows.

## Notes

- Spotify Premium required for media controls
- Smallify is **NOT** a standalone Spotify device, users will need to have an official Spotify device/application on standby
- Smallify uses [Implicit grant flow](https://developer.spotify.com/documentation/general/guides/authorization-guide/#implicit-grant-flow) for authentication, through the [project site](https://smallify.nicksmirnoff.co.uk)
  - Users are directed to `Spotify Accounts Service` with a request for the following permission scopes:
    - `user-modify-playback-state`
    - `user-read-playback-state` 
    - `user-read-currently-playing`
  - Granted access generates an `access_token`, which lasts 1 hour

## Screenshots

![player-screenshot](.\docs\assets\screenshots\player-screenshot.png)

## Related Projects

- ['Spofy'  by eltoncezar](https://github.com/eltoncezar/Spofy)
