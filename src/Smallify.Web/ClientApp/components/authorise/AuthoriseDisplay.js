import React from 'react';

import { Authentication } from '../../lib/authentication';

const AuthoriseSpotify = () => {
    const { ClientID, RedirectURI, Scopes } = Authentication;
    window.location = `https://accounts.spotify.com/authorize?client_id=${encodeURIComponent(ClientID)}&redirect_uri=${encodeURIComponent(RedirectURI)}&scope=${encodeURIComponent(Scopes)}&response_type=token`;
}

const AuthroiseDisplay = () => (
    <button onClick={AuthoriseSpotify}>
        Connect
    </button>
);

export default AuthroiseDisplay;
