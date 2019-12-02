import React from 'react';
import styled from 'styled-components';

import history from '../../../utils/history';
import PrimaryButton from '../../shared/PrimaryButton';
import Text from '../../shared/Text';

const Wrapper = styled.section`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const NotFound = () => (
  <Wrapper>
    <h1>Page not found</h1>
    <PrimaryButton id="home" text="HOME" onClick={() => history.push('/')} />
    <Text value="¯\_(ツ)_/¯" />
  </Wrapper>
);

export default NotFound;
