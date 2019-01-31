import React from "react";
import queryString from "query-string";

import Container from "../shared/styled/container";
import Paragraph from "../shared/styled/paragraph";
import TextArea from "../shared/styled/textArea";
import Button from "../shared/styled/button";
import SmallifyIcon from "../shared/SmallifyIcon";

const CopyAccessToken = () => {
  var token = document.getElementById("token");
  token.select();
  document.execCommand("copy");
};

const AuthoriseCallback = ({ location }) => {
  const { access_token } = queryString.parse(location.hash);
  return (
    <Container>
      <SmallifyIcon />
      <Paragraph>Copy the access token below and paste it in Smallify.</Paragraph>
      <TextArea id="token" value={access_token} readOnly />
      <br />
      <Button onClick={CopyAccessToken}>COPY</Button>
    </Container>
  );
};

export default AuthoriseCallback;
