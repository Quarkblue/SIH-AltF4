import React, { useState, useEffect } from "react";

export default function RightPane() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function dataer() {
      const res = await fetch("http://localhost:6942/api/v1/home");
      setData(await res.json());
      setLoading(false);
    }
    dataer();
  }, []);

  return (
    <div className="right bg-gradient-to-b from-gray-900 to-gray-800 text-white">
      <h1 className="headingr pl-6 md:pl-5 font-medium text-4xl md:text-5xl">
        Filed Reports
      </h1>
      <div className="lister bg-opacity-80 backdrop-blur-lg p-6 rounded-lg mt-6">
        {!loading ? (
          data.map((item, index) => (
            <div className="item mb-4 space-y-2 pb-2">
              <div className="rounded-lg bg-gray-700 p-4">
                <p className="text-lg">Phone Number : {item.phone}</p>
                <p className="text-lg">Report : {item.query}</p>
              </div>
            </div>
          ))
        ) : (
          <h1>No Queries</h1>
        )}
      </div>
    </div>
  );
}
