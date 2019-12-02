import React from 'react';
import PropTypes from 'prop-types';

import Header from './Header';
import Main from './Main';
import Footer from './Footer';
import Separator from './Separator';

const propTypes = {
  children: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.node),
    PropTypes.node,
  ]).isRequired,
};

const AppLayout = ({ children }) => (
  <>
    <Header />
    <Main>
      {children}
    </Main>
    <Separator />
    <Footer />
  </>
);

AppLayout.propTypes = propTypes;

export default AppLayout;
