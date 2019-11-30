import React from 'react';
import styled from 'styled-components';
import { Helmet } from 'react-helmet';
import { BrowserRouter } from 'react-router-dom';
import { hot } from 'react-hot-loader/root';

import { PRIMARY } from './utils/style/variables';
import GlobalStyle from './utils/style/GlobalStyle';
import AppRouter from './components/routers/AppRouter';

const Wrapper = styled.div`
  min-height: 0;
  flex: 1 1 auto;
  display: flex;
  flex-direction: row;
  flex-wrap: nowrap;
  justify-content: flex-start;
  align-items: stretch;
  background-color: ${PRIMARY.background};
`;

const App = () => (
  <BrowserRouter>
    <Helmet titleTemplate="%s / Smallify" defaultTitle="Smallify" />
    <GlobalStyle />
    <Wrapper>
      <AppRouter />
    </Wrapper>
  </BrowserRouter>
);

export default hot(App);
