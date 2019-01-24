import React from "react";
import queryString from 'query-string';

const AuthoriseCallback = ({ location }) => {
  const { access_token } = queryString.parse(location.hash);
  return (
    <label>
      Access Token:
      <input type="text" value={access_token} />
    </label>
  );
};

export default AuthoriseCallback;
