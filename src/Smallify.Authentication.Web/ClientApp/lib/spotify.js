import settings from '../../appsettings.json';

class Spotify {
  constructor() {
    this.connectURL = 'https://accounts.spotify.com/authorize'
      + `?client_id=${settings.Spotify.ClientID}`
      + '&response_type=code'
      + `&redirect_uri=${settings.Spotify.RedirectURI}`
      + `&scope=${(settings.Spotify.Scopes).join('%20')}`
      + '&show_dialog=True';
  }

  connect() {
    window.location = this.connectURL;
  }
}

export default new Spotify();
