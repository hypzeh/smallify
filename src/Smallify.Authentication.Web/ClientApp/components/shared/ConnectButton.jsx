import React from 'react';

import spotify from '../../lib/spotify';
import PrimaryButton from './PrimaryButton';

const ConnectButton = () => (
  <PrimaryButton id="connect" text="CONNECT" onClick={() => spotify.connect()} />
);

export default ConnectButton;
