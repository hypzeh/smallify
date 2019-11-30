import React, { Suspense } from 'react';
import { Switch, Route } from 'react-router-dom';

import Loader from '../shared/Loader';

const Home = React.lazy(() => import('../pages/Home'));
const Callback = React.lazy(() => import('../pages/Callback'));
const NotFound = React.lazy(() => import('../pages/NotFound'));

const AppRouter = () => (
  <Suspense fallback={(<Loader />)}>
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>

      <Route exact path="/callback">
        <Callback />
      </Route>

      <Route>
        <NotFound />
      </Route>
    </Switch>
  </Suspense>
);

export default AppRouter;
