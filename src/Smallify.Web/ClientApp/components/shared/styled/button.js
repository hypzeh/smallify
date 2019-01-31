import styled from 'styled-components';

const Button = styled.button`
  color: #fff;
  background-color: #1aa34a;
  font-size: 14px;
  line-height: 1;
  border-radius: 500px;
  padding: 18px 48px 16px;
  transition-property: background-color,border-color,color,box-shadow,filter;
  transition-duration: .3s;
  border-width: 0;
  letter-spacing: 2px;
  min-width: 160px;
  text-transform: uppercase;
  white-space: normal;
  :hover {
    background-color: #1db954;
  }
`;

export default Button;
