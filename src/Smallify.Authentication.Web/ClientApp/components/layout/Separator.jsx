import React from 'react';
import styled from 'styled-components';

import { PRIMARY } from '../../utils/style/variables';

const Wrapper = styled.hr`
  margin: 0 1rem;
  border-color: ${PRIMARY.highlight}
`;

const Separator = () => (
  <Wrapper />
);

export default Separator;
