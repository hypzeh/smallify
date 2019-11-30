import React from 'react';
import PropTypes from 'prop-types';
import styled from 'styled-components';

const propTypes = {
  children: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.node),
    PropTypes.node,
  ]),
};
const defaultProps = {
  children: null,
};

const Wrapper = styled.main`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
`;

const Main = ({ children }) => (
  <Wrapper>
    {children}
  </Wrapper>
);

Main.propTypes = propTypes;
Main.defaultProps = defaultProps;

export default Main;
