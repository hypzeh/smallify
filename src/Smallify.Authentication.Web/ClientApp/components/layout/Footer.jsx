import React from 'react';
import styled from 'styled-components';

import { PRIMARY } from '../../utils/style/variables';

const Wrapper = styled.footer`
  display: flex;
  flex-direction: row;
  justify-content: center;
`;

const Link = styled.a`
  color: ${PRIMARY.colour};
  margin: .5rem;
`;

const Footer = () => (
  <Wrapper>
    <Link href="https://github.com/hypzeh/smallify">Github</Link>
    <Link href="https://github.com/hypzeh/smallify/releases">Download</Link>
  </Wrapper>
);

export default Footer;
