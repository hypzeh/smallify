import React from 'react';
import styled from 'styled-components';
import { useLocation } from 'react-router-dom';
import qs from 'query-string';

import Error from './Error';
import Code from './Code';

const Wrapper = styled.section`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const Callback = () => {
  const { search } = useLocation();
  const { code, error } = qs.parse(search);

  return (
    <Wrapper>
      <h1>Authentication code</h1>
      {error
        ? (<Error />)
        : (<Code value={code} />)}
    </Wrapper>
  );
};

export default Callback;
