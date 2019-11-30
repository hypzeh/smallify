import React from 'react';
import styled, { keyframes } from 'styled-components';

const progress = keyframes`
  0% { margin-left: 0; margin-right: 100%; }
  50% { margin-left: 25%; margin-right: 0; }
  100% { margin-left: 100%; margin-right: 0; }
`;

const Wrapper = styled.div`
  min-height: inherit;
  height: 100%;
  width: 100%;
  text-align: center;
`;

const ProgressLine = styled.div`
  display: flex;
  position: sticky;
  top: 0;
  height: .1rem;
  width: 100%;
  margin: 0;
  background: transparent;

  &::before {
    content: '';
    width: 100%;
    background: white;
    animation: ${progress} 2s infinite;
  }
`;

const Loader = () => (
  <Wrapper>
    <ProgressLine />
  </Wrapper>
);

export default Loader;
