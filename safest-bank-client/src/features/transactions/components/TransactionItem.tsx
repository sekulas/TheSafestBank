import { useContext } from "react";
import AuthContext, { ITransaction } from "../../auth/context/AuthContext";

const TransactionItem = ({ transaction }: { transaction: ITransaction }) => {
  const { accountNumber } = useContext(AuthContext);

  return (
    <div className="transaction-item">
      <div className="transaction-item-info">
        <p>{transaction.recipientName} {transaction.recipientSurname}</p>
        <p>{transaction.title}</p>
      </div>

      {transaction.recipientAccountNumber.localeCompare(accountNumber) === 0 ? (
        <h1 style={{ color: "green" }}>{transaction.amount} PLN</h1>
      ) : (
        <h1>-{transaction.amount} PLN</h1>
      )}
    </div>
  )
}

export default TransactionItem;