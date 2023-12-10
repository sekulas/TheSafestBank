import { useContext } from "react";
import AuthContext from "../context/AuthContext";
import { ReactComponent as PersonIcon } from "../assets/icons/personIcon.svg";
import { Link } from "react-router-dom";

const Navbar = () => {
  const { isAuthenticated, name, surname, logout } = useContext(AuthContext);

  return (
    <div id="navbar">
      <Link to="/home" style={{ color: "green", textDecoration: 'none' }}>
        <h1>The Safest Bank</h1>
      </Link>
      {isAuthenticated &&
        <div id="navbar-module">
          <Link to="/client" style={{ color: "green", textDecoration: 'none' }}>
            <PersonIcon />
            {name.toUpperCase()} {surname.toUpperCase()}
          </Link>
          <button onClick={logout}>Logout</button>
        </div>
      }
    </div>
  )
}

export default Navbar;