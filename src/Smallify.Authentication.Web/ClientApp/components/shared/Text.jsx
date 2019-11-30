import React from 'react';
import PropTypes from 'prop-types';
import styled from 'styled-components';

import { PRIMARY } from '../../utils/style/variables';

const propTypes = {
  value: PropTypes.string.isRequired,
};

const Wrapper = styled.p`
  color: ${PRIMARY.colour};
`;

const Text = ({ value }) => (
  <Wrapper>
    {value}
  </Wrapper>
);

Text.propTypes = propTypes;

export default Text;
