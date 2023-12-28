import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";
import { useContext } from "react";
import ModalContext from "../features/modal/context/ModalContext";
import Modal from "../features/modal/Modal";

const AppLayout = () => {
  const { isSpinnerSpinning, isModalOpen } = useContext(ModalContext);

  return (
    <div>
      <Navbar />
      {isSpinnerSpinning && <div className="spinner" />}
      {isModalOpen && <Modal />}
      <Outlet />
    </div>
  );
};

export default AppLayout;
