import React from "react";
import "./Pane.css";

export default function LeftPane() {
  return (
    <div className="left">
      <div>
        <span className="heading">
          <h2>ADMIN DASHBOARD</h2>
        </span>
        <hr />
        <ul>
          <li>
            Messages
          </li>
          <li>
            Reports
          </li>
        </ul>
      </div>

      <div className="neeche">
        <img className="ping" src="https://cdn-icons-png.flaticon.com/512/1144/1144760.png" alt="" srcset="" height="20px" width="20px" />
        <span className="account">Welcome, Login</span>
      </div>
      
    </div>
  );
}
