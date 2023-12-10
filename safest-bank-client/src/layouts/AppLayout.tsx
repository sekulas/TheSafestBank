import { Outlet } from "react-router-dom";
import Navbar from "./Navbar"

const AppLayout = () => {

  return (
    <div id="app">
      <Navbar />
      <Outlet />
    </div>
  )

}

export default AppLayout;