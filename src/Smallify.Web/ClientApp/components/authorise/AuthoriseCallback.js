import React from "react";

const AuthoriseCallback = ({ location }) => {
  console.log(location);
  return (
    <label>
      Access Token:
      <input type="text" value={location.search} />
    </label>
  );
};

export default AuthoriseCallback;
