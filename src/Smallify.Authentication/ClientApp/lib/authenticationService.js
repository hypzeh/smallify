import Settings from '../../appsettings.json';

class AuthenticationService {
  constructor() {
    this.setupURL();
  }

  connect() {
    window.location = this.spotifyURL;
  }

  setupURL() {
    this.spotifyURL = 'https://accounts.spotify.com/authorize'
      + `?client_id=${encodeURIComponent(Settings.ClientID)}`
      + `&redirect_uri=${encodeURIComponent(Settings.RedirectURI)}`
      + `&scope=${encodeURIComponent(Settings.Scopes)}`
      + '&response_type=token';
  }
}

export default new AuthenticationService();
