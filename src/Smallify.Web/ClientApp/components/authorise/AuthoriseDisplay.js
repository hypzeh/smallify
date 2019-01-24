import React from 'react';

const AuthoriseSpotify = () => {
    const clientID = 'c3e67d4f6ab143ddb876938aece626af';
    const redirectURI = 'http:%2F%2Flocalhost:5250%2Fcallback';
    const scopes = 'user-modify-playback-state%20user-read-playback-state%20user-read-currently-playing';
    const authoriseURL = `https://accounts.spotify.com/authorize?client_id=${clientID}&redirect_uri=${redirectURI}&scope=${scopes}&response_type=token`;

    window.location = authoriseURL;
}

const AuthroiseDisplay = () => (
    <button onClick={AuthoriseSpotify}>
        Connect
    </button>
);

export default AuthroiseDisplay;
