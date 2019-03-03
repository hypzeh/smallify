import React from 'react';

import SmallifyContainerTypes from '../../types/shared/smallifyContainer';
import S from '../../styles/components/shared/smallifyContainer';
import SmallifyIcon from './SmallifyIcon';

const SmallifyContainer = ({ children }) => (
  <S.Container>
    <SmallifyIcon />
    <S.Content>
      {children}
    </S.Content>
  </S.Container>
);

SmallifyContainer.propTypes = SmallifyContainerTypes;

export default SmallifyContainer;
