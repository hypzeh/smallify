import { string, shape } from 'prop-types';

export default {
  location: shape({
    hash: string.isRequired,
  }).isRequired,
};
