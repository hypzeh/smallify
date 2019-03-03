![Smallify](./docs/assets/project-title.png)
[![Build Status](https://nick-smirnoff.visualstudio.com/smallify/_apis/build/status/build/Smallify.Authentication-CI?branchName=master-authentication)](https://nick-smirnoff.visualstudio.com/smallify/_build/latest?definitionId=16&branchName=master-authentication)
---

This branch is the source for [Smallify authentication site](https://hypzeh.github.io/smallify).

Smallify is a simple WPF application built to provide a small music player for Spotify.

## Usage

- Building the ASP.NET Core Single-Page-Application project will also run `npm install` if the `node_modules` folder doesn't exist
  - (optionally) manually run `npm install` at the project directory
- `npm run build` a the project directory, this builds with webpack to `wwwroot` output
- (optionally) `npm run start` will start a webpack dev server

### Requirements
- .NET Core 2.2
- NodeJS
