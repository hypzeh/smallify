import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import AuthenticationDisplay from '../components/authentication/AuthenticationDisplay';
import AuthenticationCallback from '../components/authentication/AuthenticationCallback';

const AppRouter = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={AuthenticationDisplay} />
      <Route exact path="/callback" component={AuthenticationCallback} />
    </Switch>
  </BrowserRouter>
);

export default AppRouter;
