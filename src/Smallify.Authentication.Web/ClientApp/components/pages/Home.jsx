import React from 'react';
import styled from 'styled-components';

import spotify from '../../lib/spotify';
import PrimaryButton from '../shared/PrimaryButton';

const Wrapper = styled.section`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const Home = () => (
  <Wrapper>
    <h1>Connect to Spotify</h1>
    <PrimaryButton id="connect" text="CONNECT" onClick={() => spotify.connect()} />
    <p>This will redirect you to Spotify for permission.</p>
  </Wrapper>
);

export default Home;
