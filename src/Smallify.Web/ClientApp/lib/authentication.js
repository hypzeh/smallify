import Settings from '../../appsettings.json';

const Authentication = {
    ClientID: Settings.Authentication.ClientID,
    RedirectURI: Settings.Authentication.RedirectURI,
    Scopes: Settings.Authentication.Scopes
};

export { Authentication };
