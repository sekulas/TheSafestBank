import { createContext } from 'react';

export interface IModalContext {
  isModalOpen: boolean;
  modalTitle: string;
  modalContent: string;
  openModal: (title: string, content: string) => void;
  closeModal: () => void;
}

const ModalContext = createContext<IModalContext>({ isModalOpen: false, modalTitle: '', modalContent: '', openModal: () => { }, closeModal: () => { } });

export default ModalContext;