import React from 'react';

import GlobalStyle from './styles/globalStyle';
import AppRouter from './routers/AppRouter';

const App = () => (
  <React.Fragment>
    <GlobalStyle/>
    <AppRouter />
  </React.Fragment>
);

export default App;
