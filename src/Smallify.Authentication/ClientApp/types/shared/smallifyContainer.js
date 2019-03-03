import { oneOfType, arrayOf, node } from 'prop-types';

export default {
  children: oneOfType([
    arrayOf(node),
    node,
  ]),
};
