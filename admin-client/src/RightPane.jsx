import React, { useState, useEffect } from 'react';

export default function RightPane() {
  const [data, setData] = useState([]);

  const loadData = async () => {
    try {
      const response = await fetch("http://localhost:6942/api/v1/home", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      });

      if (!response.ok) {
        throw new Error(`HTTP Error! Status: ${response.status}`);
      }

      const responseData = await response.json();
      setData(responseData);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  useEffect(() => {
    loadData();
  }, []);

  return (
    <div className='right bg-gradient-to-b from-gray-900 to-gray-800 text-white'>
      <h1 className='headingr font-medium text-4xl md:text-5xl'>Filed Reports</h1>
      <div className="lister bg-opacity-80 backdrop-blur-lg p-6 rounded-lg mt-6">
        {/* {data.map((item, index) => ( */}
          <div  className="item mb-4 space-y-2 pb-2">
            <div className="rounded-lg bg-gray-700 p-4">
              <p className="text-lg">Phone Number: </p>
              <p className="text-lg">Report: </p>
            </div>
          </div>
        {/* ))} */}
      </div>
    </div>
  );
}



