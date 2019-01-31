import React from 'react';

import { Authentication } from '../../lib/authentication';
import Container from '../shared/styled/container';
import Button from '../shared/styled/button';
import SmallifyIcon from '../shared/SmallifyIcon';

const AuthoriseSpotify = () => {
  const { ClientID, RedirectURI, Scopes } = Authentication;
  window.location = "https://accounts.spotify.com/authorize"
    + `?client_id=${encodeURIComponent(ClientID)}`
    + `&redirect_uri=${encodeURIComponent(RedirectURI)}`
    + `&scope=${encodeURIComponent(Scopes)}`
    + `&response_type=token`;
};

const AuthroiseDisplay = () => (
  <Container>
    <SmallifyIcon />
    <br />
    <Button onClick={AuthoriseSpotify}>CONNECT</Button>
  </Container>
);

export default AuthroiseDisplay;
