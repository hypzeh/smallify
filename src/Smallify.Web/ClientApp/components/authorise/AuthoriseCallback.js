import React from "react";
import queryString from "query-string";

const CopyAccessToken = () => {
  var copyText = document.getElementById("accessToken");
  copyText.select();
  document.execCommand("copy");
};

const AuthoriseCallback = ({ location }) => {
  const { access_token } = queryString.parse(location.hash);
  return (
    <React.Fragment>
      <label>
        Access Token:
        <input id="accessToken" type="text" value={access_token} readOnly />
      </label>
      <button onClick={CopyAccessToken}>Copy</button>
    </React.Fragment>
  );
};

export default AuthoriseCallback;
