import React, { Suspense, lazy } from 'react';
import { Helmet } from 'react-helmet';
import { Switch, Route } from 'react-router-dom';

import Loader from '../shared/Loader';

const Home = lazy(() => import('../pages/Home'));
const Callback = lazy(() => import('../pages/Callback'));
const NotFound = lazy(() => import('../pages/NotFound'));

const AppRouter = () => (
  <Suspense fallback={(<Loader />)}>
    <Switch>
      <Route exact path="/">
        <Helmet title="Connect" />
        <Home />
      </Route>

      <Route exact path="/callback">
        <Helmet title="Authentication code" />
        <Callback />
      </Route>

      <Route>
        <Helmet title="Page not found" />
        <NotFound />
      </Route>
    </Switch>
  </Suspense>
);

export default AppRouter;
