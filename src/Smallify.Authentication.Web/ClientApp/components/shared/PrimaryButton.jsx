import React from 'react';
import PropTypes from 'prop-types';
import styled from 'styled-components';

import { PRIMARY } from '../../utils/style/variables';

const propTypes = {
  id: PropTypes.string.isRequired,
  text: PropTypes.string.isRequired,
  onClick: PropTypes.func.isRequired,
  onMouseEnter: PropTypes.func,
  onMouseLeave: PropTypes.func,
};
const defaultProps = {
  onMouseEnter: null,
  onMouseLeave: null,
};

const Wrapper = styled.button`
  background-color: ${PRIMARY.highlight};
  border-radius: 500px;
  border-width: 0px;
  padding: 1rem 3rem;
  color: ${PRIMARY.colour};
  letter-spacing: 2px;
  min-width: 10rem;
  text-transform: uppercase;
  white-space: normal;
  cursor: pointer;

  transition-property: background-color, border-color, color, box-shadow, filter;
  transition-duration: 0.3s;

  &:hover {
    background-color: ${PRIMARY.highlightLighter};
  }

  &:active {
    background-color: ${PRIMARY.highlightDarker};
  }

  &:focus {
    outline: 0;
  }
`;

const PrimaryButton = ({
  id,
  text,
  onClick,
  onMouseEnter,
  onMouseLeave,
}) => (
  <Wrapper id={id} onClick={onClick} onMouseEnter={onMouseEnter} onMouseLeave={onMouseLeave}>
    {text}
  </Wrapper>
);

PrimaryButton.propTypes = propTypes;
PrimaryButton.defaultProps = defaultProps;

export default PrimaryButton;
