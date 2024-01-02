import { createContext } from "react";

export interface IModalContext {
  isModalOpen: boolean;
  modalTitle: string;
  modalContent: string;
  openModal: (title: string, content: string) => void;
  closeModal: () => void;
  isSpinnerSpinning: boolean;
  openSpinner: () => void;
  closeSpinner: () => void;
}

const ModalContext = createContext<IModalContext>({
  isModalOpen: false,
  modalTitle: "",
  modalContent: "",
  openModal: () => { },
  closeModal: () => { },
  isSpinnerSpinning: false,
  openSpinner: () => { },
  closeSpinner: () => { },
});

export default ModalContext;
