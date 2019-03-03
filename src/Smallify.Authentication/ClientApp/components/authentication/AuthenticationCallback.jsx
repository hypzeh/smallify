import React from 'react';

import SmallifyContainer from '../shared/SmallifyContainer';
import Button from '../../styles/elements/button';

const handleCopy = () => {
  document.getElementById('token').select();
  document.execCommand('copy');
};

const AuthenticationCallback = () => (
  <SmallifyContainer>
    <p>Copy the access token below and paste it in Smallify.</p>
    <textarea id="token">this is a test...</textarea>
    <br />
    <Button onClick={handleCopy}>COPY</Button>
  </SmallifyContainer>
);

export default AuthenticationCallback;
