import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";

const AppRouter = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={() => <p>Test</p>} />
    </Switch>
  </BrowserRouter>
);

export default AppRouter;
