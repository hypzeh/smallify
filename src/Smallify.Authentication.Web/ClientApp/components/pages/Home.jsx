import React from 'react';
import styled from 'styled-components';

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
    <PrimaryButton id="connect" text="Connect" onClick={() => {}} />
    <p>This will show your access token.</p>
  </Wrapper>
);

export default Home;
