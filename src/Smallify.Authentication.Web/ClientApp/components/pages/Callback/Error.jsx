import React from 'react';

import history from '../../../utils/history';
import PrimaryButton from '../../shared/PrimaryButton';
import Text from '../../shared/Text';

const Error = () => (
  <>
    <PrimaryButton id="go-back" text="GO BACK" onClick={() => history.goBack()} />
    <Text value="Could not connect with Spotify." />
  </>
);

export default Error;
