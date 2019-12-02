import React from 'react';
import styled from 'styled-components';

import ConnectButton from '../../shared/ConnectButton';
import Text from '../../shared/Text';

const Wrapper = styled.section`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const Home = () => (
  <Wrapper>
    <h1>Connect to Spotify</h1>
    <ConnectButton />
    <Text value="This will redirect you to Spotify, please check the requested permissions." />
  </Wrapper>
);

export default Home;
