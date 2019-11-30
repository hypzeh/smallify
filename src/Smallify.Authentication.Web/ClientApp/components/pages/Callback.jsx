import React from 'react';
import { useLocation } from 'react-router-dom';
import qs from 'query-string';

const Callback = () => {
  const { search } = useLocation();
  const { code } = qs.parse(search);

  return (
    <>
      <h1>Callback</h1>
      {!!code && (
        <section>
          <label htmlFor="code">
            <span>Code:</span>
            <textarea id="code" readOnly value={code} />
          </label>
        </section>
      )}
    </>
  );
};

export default Callback;
