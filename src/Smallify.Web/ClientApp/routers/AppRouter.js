import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import NotFound from '../components/shared/NotFound';

const AppRouter = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={() => <p>Test</p>} />
      <Route path="*" component={NotFound} status={404} />
    </Switch>
  </BrowserRouter>
);

export default AppRouter;
