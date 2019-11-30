import React, { useState } from 'react';
import PropTypes from 'prop-types';

import Text from '../../shared/Text';
import TextArea from '../../shared/TextArea';
import PrimaryButton from '../../shared/PrimaryButton';
import ConnectButton from '../../shared/ConnectButton';

const propTypes = {
  value: PropTypes.string,
};
const defaultProps = {
  value: '',
};

const Code = ({ value }) => {
  const [isCopied, setIsCopied] = useState(false);
  const handleCopyClick = async () => {
    await navigator.clipboard.writeText(value);
    setIsCopied(true);
  };

  return value.length === 0
    ? (
      <>
        <ConnectButton />
        <Text value="Could not find a code - please try connecting again." />
      </>
    )
    : (
      <>
        <TextArea id="code" text={value} isReadonly />
        <PrimaryButton
          id="copy"
          text={isCopied ? 'COPIED' : 'COPY'}
          onClick={handleCopyClick}
          onMouseEnter={() => setIsCopied(false)}
        />
        <Text value="Copy this code and use the paste button in Smallify to finish connecting." />
      </>
    );
};

Code.propTypes = propTypes;
Code.defaultProps = defaultProps;

export default Code;
