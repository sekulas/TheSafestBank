import { useState, ReactNode } from 'react';
import ModalContext, { IModalContext } from './ModalContext';

const ModalProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [modalTitle, setModalTitle] = useState('');
  const [modalContent, setModalContent] = useState('');
  const [isSpinnerSpinning, setIsSpinnerSpinning] = useState(false);

  const openModal = (title: string, content: string) => {
    setModalTitle(title);
    setModalContent(content);
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  const openSpinner = () => {
    setIsSpinnerSpinning(true);
  };

  const closeSpinner = () => {
    setIsSpinnerSpinning(false);
  };

  const contextValue: IModalContext = {
    isModalOpen,
    modalTitle,
    modalContent,
    openModal,
    closeModal,
    isSpinnerSpinning,
    openSpinner,
    closeSpinner,
  };

  return (
    <ModalContext.Provider value={contextValue}>
      {children}
    </ModalContext.Provider>
  )
};

export default ModalProvider;