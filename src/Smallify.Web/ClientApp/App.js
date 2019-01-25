import React from 'react';
import {createGlobalStyle} from 'styled-components';

import AppRouter from './routers/AppRouter';

const GlobalStyle = createGlobalStyle`
  body {
    background: #2C2C2D;
    color: #fff;
    padding: 1em;
    line-height: 1.8em;
		font-size: 15;
    -webkit-font-smoothing: antialiased;
    text-rendering: optimizeSpeed;
    word-wrap: break-word
  }
`;

const App = () => (
  <React.Fragment>
    <GlobalStyle />
    <AppRouter />
  </React.Fragment>
);

export default App;
