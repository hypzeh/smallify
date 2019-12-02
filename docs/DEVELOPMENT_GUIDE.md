# Development Guide

## Application Settings

Ensure to provide relevant values to the application settings defined in `Resources.resx` and `appsettings.json`, but keep your values secret and out of source control. The CI pipeline replaces token values with a `#{` prefix and a `}` suffix.

- `APP_CENTER_CLIENT_ID` - _(Optional)_ You can get this from [App Center](https://appcenter.ms/)
- `SPOTIFY_CLIENT_ID` - _(Required)_ You can get this from [Spotify Developer Dashboard](https://developer.spotify.com/dashboard/) by registering your personal development client
- `SPOTIFY_CLIENT_SECRET` - _(Required)_ You can get this from [Spotify Developer Dashboard](https://developer.spotify.com/dashboard/) by registering your personal development client
- `SPOTIFY_REDIRECT_URI` - _(Required)_ You define this from [Spotify Developer Dashboard](https://developer.spotify.com/dashboard/) whilst registering your personal development client

You can use the following commands to include/exclude a path from Git's management, this can help keep your secrets out of source control.

```shell
git update-index --skip-worktree src/Smallify.GUI/Properties/*
git update-index --no-skip-worktree src/Smallify.GUI/Properties/*
```

## Scripts

Useful scripts can be found in the `/scripts` folder.

- `Clean-Outputs.ps1` - Run this to clean out all the `bin` and `obj` folders