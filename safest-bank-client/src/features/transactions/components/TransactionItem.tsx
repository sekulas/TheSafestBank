import { useContext, useEffect } from "react";
import AuthContext, { ITransaction } from "../../auth/context/AuthContext";

const TransactionItem = ({ transaction }: { transaction: ITransaction }) => {
  const { accountNumber } = useContext(AuthContext);
  const utcDate = new Date(transaction.time);

  return (
    <div className="transaction-item">
      <div className="transaction-item-info">
        <p>
          <b>TO: </b>{transaction.recipientName} {transaction.recipientSurname}
          <b> FROM: </b>{transaction.senderName} {transaction.senderSurname}
          <b> DATE: </b>{utcDate.toString().slice(0, 21)}
        </p>
        <p><b>TITLE:</b> {transaction.title}</p>
      </div>

      {
        transaction.recipientAccountNumber.localeCompare(accountNumber) === 0 ? (
          <h1 style={{ color: "green" }}>{transaction.amount} PLN</h1>
        ) : (
          <h1>-{transaction.amount} PLN</h1>
        )
      }
    </div >
  )
}

export default TransactionItem;