import { useContext, useState } from "react";
import ModalContext from "../../modal/context/ModalContext";
import AuthContext from "../../auth/context/AuthContext";
import API_ENDPOINTS, {
  IMakeTransactionRequest,
} from "../../../services/TheSafestBankApi/safestBankServerApiEndpoints";

const MakeTransactionModal = ({ closeModal }: { closeModal: () => void }) => {
  const [recipientAccountNumber, setRecipientAccountNumber] = useState("");
  const [amount, setAmount] = useState("");
  const [title, setTitle] = useState("");
  const { openModal, openSpinner, closeSpinner } = useContext(ModalContext);
  const { balance, transactions, setTransactions, logout } =
    useContext(AuthContext);

  const makeTransaction = async () => {
    if (!isValidTransaction()) {
      return;
    }

    const transaction = {
      recipientAccountNumber,
      amount: Number(amount),
      title,
    };

    try {
      openSpinner();
      const requestBody = transaction;

      const response = await fetch(API_ENDPOINTS.MAKE_TRANSACTION, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestBody),
        credentials: "include",
      });

      const data = await response.json();

      if (!response.ok) {
        handleTransactionError(data.message, response.status);
      } else {
        setTransactions([data, ...transactions]);
        closeModal();
      }
    } catch (error) {
      handleTransactionError((error as Error).message);
    } finally {
      closeSpinner();
    }
  };

  const isValidTransaction = () => {
    if (
      !recipientAccountNumber ||
      !amount ||
      !title ||
      getDecimalPlaces(amount) > 2 ||
      Number(amount) <= 0
    ) {
      openModal(
        "Not all fields have been filled correctly.",
        "Please fill all the fields and remember - account number and amount of money can only contain numbers and must be positive. Additionally, the amount of money can only contain two decimal places which are separated by the '.' sign."
      );
      return false;
    }

    if (recipientAccountNumber.includes(" ")) {
      recipientAccountNumber.replace(" ", "");
    }

    if (recipientAccountNumber.length !== 26) {
      openModal(
        "Account number must contain 26 digits.",
        "Please provide a correct account number."
      );
      return false;
    }

    if (balance < Number(amount)) {
      openModal(
        "You don't have enough money to make this transaction.",
        "Please provide a smaller amount of money"
      );
      return false;
    }

    return true;
  };

  const handleTransactionError = (errorMessage: string, statusCode: number | null = null) => {
    openModal("Error", `Failed to make transaction. ${errorMessage}`);
    if (statusCode === 401) {
      logout();
    }
    closeModal();
  };

  const getDecimalPlaces = (amount: string) => {
    const decimalPlaces = amount.split(".")[1];
    return decimalPlaces ? decimalPlaces.length : 0;
  };


  return (
    <div className="modal-opened">
      <div className="modal-overlay"></div>
      <div className="modal-content">
        <h2>Make a transaction</h2>
        <p>Provide the following information:</p>
        <div id="transaction-form">
          <div className="transaction-field">
            <label htmlFor="recipient">Recipient account number:</label>
            <input
              type="number"
              id="recipient"
              value={recipientAccountNumber}
              onChange={(e) => setRecipientAccountNumber(e.target.value)}
            />
          </div>
          <div className="transaction-field">
            <label htmlFor="amount">Money amount:</label>
            <input
              type="number"
              id="amount"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
            />
          </div>
          <div className="transaction-field">
            <label htmlFor="title">Transaction title:</label>
            <input
              type="text"
              id="title"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
            />
          </div>
        </div>
        <div id="transaction-buttons">
          <button className="warning-action-button" onClick={makeTransaction}>
            Make transaction
          </button>
          <button className="secondary-action-button" onClick={closeModal}>
            Cancel transaction
          </button>
        </div>
      </div>
    </div>
  );
};

export default MakeTransactionModal;