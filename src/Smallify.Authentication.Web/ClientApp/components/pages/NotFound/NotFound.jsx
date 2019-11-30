import React from 'react';
import styled from 'styled-components';

import history from '../../../utils/history';
import PrimaryButton from '../../shared/PrimaryButton';

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
  </Wrapper>
);

export default NotFound;
