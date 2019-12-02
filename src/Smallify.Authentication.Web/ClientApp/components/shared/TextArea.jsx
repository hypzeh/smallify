import React, { useRef, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import styled from 'styled-components';

import { PRIMARY } from '../../utils/style/variables';

const propTypes = {
  id: PropTypes.string.isRequired,
  text: PropTypes.string,
  isReadonly: PropTypes.bool,
  onChange: PropTypes.func,
};
const defaultProps = {
  text: '',
  isReadonly: false,
  onChange: null,
};

const Wrapper = styled.textarea`
  background: ${PRIMARY.background};
  border: 2px solid ${PRIMARY.highlight};
  border-radius: .2rem;
  color: ${PRIMARY.colour};
  resize: none;
  overflow: hidden;
  height: ${({ height }) => (height > 0 ? `${height}px` : 'auto')};
  width: 30rem;
  margin-bottom: 1rem;

  &:focus {
    outline: 0;
  }
`;

const TextArea = ({
  id,
  text,
  onChange,
  isReadonly,
}) => {
  const textarea = useRef();
  const [height, setHight] = useState(0);
  useEffect(() => {
    if (!textarea) return;

    setHight(textarea.current.scrollHeight);
  }, [text, textarea]);

  return (
    <Wrapper
      ref={textarea}
      id={id}
      value={text}
      readOnly={isReadonly}
      onChange={onChange}
      onClick={() => textarea.current.select()}
      height={height}
    />
  );
};

TextArea.propTypes = propTypes;
TextArea.defaultProps = defaultProps;

export default TextArea;
