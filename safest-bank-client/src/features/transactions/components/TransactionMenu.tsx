import { useContext, useState } from "react";
import MakeTransactionModal from "./MakeTransactionModal";
import AuthContext from "../../auth/context/AuthContext";
import ShowHideComponent from "../../showing-info/ShowHideComponent";

const TransactionMenu = () => {
  const [isTransactionModalOpen, setIsTransactionModalOpen] = useState(false);
  const { accountNumber, balance } = useContext(AuthContext);

  const openTransactionModal = () => {
    setIsTransactionModalOpen(true);
  };
  const closeTransactionModal = () => {
    setIsTransactionModalOpen(false);
  }

  return (
    <div id="transaction-menu">
      <div>
        <h2>ACCOUNT NUMBER</h2>
        <ShowHideComponent>
          {accountNumber}
        </ShowHideComponent>

        <h2>AVAILABLE MONEY</h2>
        <ShowHideComponent>
          {balance}
        </ShowHideComponent>
      </div>
      <button id="make-transfer-button" className="silent-action-button" onClick={openTransactionModal}>
        Make transaction
      </button>
      {isTransactionModalOpen && (<MakeTransactionModal closeModal={closeTransactionModal} />)}
    </div>
  );
};
export default TransactionMenu;
