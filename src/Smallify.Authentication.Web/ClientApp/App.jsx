import React from 'react';
import styled from 'styled-components';
import { Helmet } from 'react-helmet';
import { BrowserRouter } from 'react-router-dom';
import { hot } from 'react-hot-loader/root';

import { PRIMARY } from './utils/style/variables';
import GlobalStyle from './utils/style/GlobalStyle';
import AppLayout from './components/layout/AppLayout';
import AppRouter from './components/routers/AppRouter';

const Wrapper = styled.div`
  height: 100vh;
  width: 100vw;
  flex: 1 1 auto;
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  justify-content: flex-start;
  align-items: stretch;
  background-color: ${PRIMARY.background};
`;

const App = () => {
  if ('serviceWorker' in navigator) {
    window.addEventListener('load', () => {
      navigator.serviceWorker.register('/sw.js')
        .then((registration) => {
          // eslint-disable-next-line no-console
          console.log('SW registered:', registration);
        }).catch((error) => {
          // eslint-disable-next-line no-console
          console.log('SW registration failed:', error);
        });
    });
  }

  return (
    <BrowserRouter>
      <Helmet titleTemplate="%s / Smallify" defaultTitle="Smallify" />
      <GlobalStyle />
      <Wrapper>
        <AppLayout>
          <AppRouter />
        </AppLayout>
      </Wrapper>
    </BrowserRouter>
  );
};

export default hot(App);
