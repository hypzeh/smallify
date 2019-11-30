import { createGlobalStyle } from 'styled-components';

import woff2 from '../../../wwwroot/fonts/open-sans-v16-latin-regular.woff2';
import woff from '../../../wwwroot/fonts/open-sans-v16-latin-regular.woff';
import { PRIMARY } from './variables';

import 'modern-normalize/modern-normalize.css';

const GlobalStyle = createGlobalStyle`
  @font-face {
    font-family: 'Open Sans';
    font-style: normal;
    font-weight: 400;
    font-display: fallback;
    src: local('Open Sans Regular'),
      local('OpenSans-Regular'),
      url('${woff2}') format('woff2'),
      url('${woff}') format('woff'); 
  }

  body {
    font-family: Open Sans, Segoe UI, Tahoma, sans-serif !important;
    background: ${PRIMARY.background};
    color: ${PRIMARY.colour};
    margin: 0;
    padding: 0;
    line-height: 1.8em;
    -webkit-font-smoothing: antialiased;
    text-rendering: optimizeSpeed;
    word-wrap: break-word
  }
`;

export default GlobalStyle;
