import React from "react";
import styled from "styled-components";

import { Authentication } from "../../lib/authentication";

const Button = styled.button`
  color: #fff;
  background-color: #1aa34a;
  font-size: 14px;
  line-height: 1;
  border-radius: 500px;
  padding: 18px 48px 16px;
  transition-property: background-color,border-color,color,box-shadow,filter;
  transition-duration: .3s;
  border-width: 0;
  letter-spacing: 2px;
  min-width: 160px;
  text-transform: uppercase;
  white-space: normal;
  :hover {
    background-color: #1db954;
  }
`;

const AuthoriseSpotify = () => {
  const { ClientID, RedirectURI, Scopes } = Authentication;
  window.location = `https://accounts.spotify.com/authorize
    ?client_id=${encodeURIComponent(ClientID)}
    &redirect_uri=${encodeURIComponent(RedirectURI)}
    &scope=${encodeURIComponent(Scopes)}
    &response_type=token`;
};

const AuthroiseDisplay = () => (
  <Button onClick={AuthoriseSpotify}>CONNECT</Button>
);

export default AuthroiseDisplay;
