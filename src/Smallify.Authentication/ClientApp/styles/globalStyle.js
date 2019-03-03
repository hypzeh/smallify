import { createGlobalStyle } from 'styled-components';

const GlobalStyle = createGlobalStyle`
  body {
    background: #2C2C2D;
    color: #fff;
    padding: 1em;
    line-height: 1.8em;
    font-family: Helvetica, Arial, Sans-Serif;
    font-size: 15px;
    -webkit-font-smoothing: antialiased;
    text-rendering: optimizeSpeed;
    word-wrap: break-word;
  }
`;

export default GlobalStyle;
