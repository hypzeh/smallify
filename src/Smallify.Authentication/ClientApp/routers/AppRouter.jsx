import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import AuthenticationDisplay from '../components/authentication/AuthenticationDisplay';

const AppRouter = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={AuthenticationDisplay} />
    </Switch>
  </BrowserRouter>
);

export default AppRouter;
