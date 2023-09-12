import React from "react";
import "./Pane.css";
import { FaBars } from "react-icons/fa"; // Import the FaBars icon from react-icons/fa

export default function LeftPane() {
  return (
    <div className="left bg-[#262942] text-white">
      <div className="my-10">
        <span className="heading text-lg text-center">
          <h2 className="flex justify-between items-center px-5 pb-5">
            DASHBOARD <button className="hover:bg-[#371D42]"><FaBars className="hamburger-icon" /></button>
          </h2>
        </span>
        <ul className="py-2 text-[18px] text-md">
          <li className="py-2 px-5 bg-transparent hover:bg-[#4D3791] rounded-md">
            Messages
          </li>
          <li className="py-2 px-5 bg-transparent hover:bg-[#4D3791] rounded-md">
            Reports
          </li>
        </ul>
      </div>

      <div className="neeche bg-white">
        <img
          className="ping"
          src="https://cdn-icons-png.flaticon.com/512/1144/1144760.png"
          alt=""
          srcSet=""
          height="20px"
          width="30px"
        />
        <span className="account text-sm text-black py-2">Welcome, Login</span>
      </div>
    </div>
  );
}
