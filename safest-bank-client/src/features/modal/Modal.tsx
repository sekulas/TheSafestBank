import { useContext } from "react";
import ModalContext from "./context/ModalContext";

const Modal: React.FC = () => {
  const { isModalOpen, closeModal, modalTitle, modalContent } = useContext(ModalContext);

  return (
    <div className={`modal-${isModalOpen ? 'opened' : 'closed'}`}>
      <div className="modal-overlay"></div>
      <div className="modal-content">
        <h2>{modalTitle}</h2>
        <p>{modalContent}</p>
        <button className="main-action-button" onClick={closeModal}>Close</button>
      </div>
    </div>
  );
};

export default Modal;