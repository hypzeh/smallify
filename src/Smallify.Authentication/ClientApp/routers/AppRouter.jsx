import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

const AppRouter = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" />
    </Switch>
  </BrowserRouter>
);

export default AppRouter;
