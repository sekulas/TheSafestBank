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
  const { balance, transactions, setTransactions, setBalance, logout } =
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
        throw new Error(`Failed to make transaction. ${data.message}`);
      } else {
        setTransactions([data, ...transactions]);
        setBalance(balance - Number(amount));
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
      !/^[0-9]+$/.test(recipientAccountNumber) ||
      getDecimalPlaces(amount) > 2
    ) {
      openModal(
        "Not all fields have been filled correctly.",
        "Please fill all the fields and remember - account number and amount of money can only contain numbers and must be positive. Additionally, the amount of money can only contain two decimal places which are separated by the '.' sign."
      );
      return false;
    }

    let amountNumber = Number(amount);

    if (amountNumber <= 0) {
      openModal(
        "Amount of money must be at least 0.01 PLN.",
        "Please provide a proper amount of money."
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

    if (balance < amountNumber) {
      openModal(
        "You don't have enough money to make this transaction.",
        "Please provide a smaller amount of money"
      );
      return false;
    }

    if (amountNumber > 1000000000) {
      openModal(
        "Amount of money must be smaller than 1 000 000 000.",
        "Please provide a smaller amount of money"
      );
      return false;
    }

    if (title.length > 100 || /[^a-zA-Z0-9 .-]/.test(title)) {
      openModal(
        "Title must contain only letters, digits, spaces, dots and dashes and must be shorter than 100 characters.",
        "Please provide a correct title."
      );
      return false;
    }

    return true;
  };

  const handleTransactionError = (errorMessage: string) => {
    openModal("Error", `${errorMessage}`);
    logout();
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
          <input id="RequestVerificationToken" type="hidden" value="@requestToken" />
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
