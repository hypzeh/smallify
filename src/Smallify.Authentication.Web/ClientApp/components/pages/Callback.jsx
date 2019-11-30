import React, { useState } from 'react';
import styled from 'styled-components';
import { useLocation } from 'react-router-dom';
import qs from 'query-string';

import TextArea from '../shared/TextArea';
import PrimaryButton from '../shared/PrimaryButton';

const Wrapper = styled.section`
  flex-grow: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const Callback = () => {
  const [isCopied, setIsCopied] = useState(false);
  const { search } = useLocation();
  const { code } = qs.parse(search);

  const handleCopyClick = async () => {
    await navigator.clipboard.writeText(code);
    setIsCopied(true);
  };

  return (
    <Wrapper>
      <h1>Authentication code</h1>
      {code
        ? (
          <>
            <TextArea id="code" text={code} isReadonly />
            <PrimaryButton
              id="copy"
              text={isCopied ? 'COPIED' : 'COPY'}
              onClick={handleCopyClick}
              onMouseEnter={() => setIsCopied(false)}
            />
            <p>Copy this code and use the paste button in Smallify to finish connecting.</p>
          </>
        )
        : (
          <>
            <p>Could not find </p>
          </>
        )}
    </Wrapper>
  );
};

export default Callback;
