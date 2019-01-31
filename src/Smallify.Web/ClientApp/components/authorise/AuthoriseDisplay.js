import React from "react";

import { Authentication } from "../../lib/authentication";
import Container from "../shared/styled/container";
import Button from "../shared/styled/button";
import SmallifyIcon from "../shared/SmallifyIcon";

const AuthoriseSpotify = () => {
  const { ClientID, RedirectURI, Scopes } = Authentication;
  window.location =
    "https://accounts.spotify.com/authorize" +
    `?client_id=${encodeURIComponent(ClientID)}` +
    `&redirect_uri=${encodeURIComponent(RedirectURI)}` +
    `&scope=${encodeURIComponent(Scopes)}` +
    `&response_type=token`;
};

const AuthroiseDisplay = () => (
  <Container>
    <SmallifyIcon />
    <p>Press the button below to connect to Spotify.</p>
    <Button onClick={AuthoriseSpotify}>CONNECT</Button>
    <p>This will show your access token.</p>
  </Container>
);

export default AuthroiseDisplay;
