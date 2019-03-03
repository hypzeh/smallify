import React from 'react';

import authenticationService from '../../lib/authenticationService';
import SmallifyContainer from '../shared/SmallifyContainer';
import Button from '../../styles/elements/button';

const handleConnect = () => {
  authenticationService.connect();
};

const AuthenticationDisplay = () => (
  <SmallifyContainer>
    <p>Press the button below to connect to Spotify.</p>
    <Button onClick={handleConnect}>CONNECT</Button>
    <p>This will show your access token.</p>
  </SmallifyContainer>
);

export default AuthenticationDisplay;
