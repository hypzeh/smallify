import React from 'react';

import AuthenticationCallbackTypes from '../../types/authentication/authenticationCallback';
import SmallifyContainer from '../shared/SmallifyContainer';
import Button from '../../styles/elements/button';
import TextArea from '../../styles/elements/textarea';

const handleCopy = () => {
  document.getElementById('token').select();
  document.execCommand('copy');
};

const AuthenticationCallback = ({ location }) => (
  <SmallifyContainer>
    <p>Copy the access token below and paste it in Smallify.</p>
    <TextArea id="token" value={location.hash} readOnly />
    <br />
    <Button onClick={handleCopy}>COPY</Button>
  </SmallifyContainer>
);

AuthenticationCallback.propTypes = AuthenticationCallbackTypes;

export default AuthenticationCallback;
