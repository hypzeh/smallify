import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import AuthoriseDisplay from '../components/authorise/AuthoriseDisplay';
import NotFound from '../components/shared/NotFound';

const AppRouter = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={AuthoriseDisplay} />
      <Route path="*" component={NotFound} status={404} />
    </Switch>
  </BrowserRouter>
);

export default AppRouter;
