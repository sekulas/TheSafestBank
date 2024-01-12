import { useContext, useEffect } from "react";
import AuthContext from "../../auth/context/AuthContext";
import TransactionItem from "./TransactionItem";

const TransactionList = () => {
  const { transactions } = useContext(AuthContext);

  return (
    <div id="transaction-list">
      <h1 id="transaction-list-title">TRANSACTIONS:</h1>
      {transactions.length !== 0 ?
        transactions.map((transaction, index) => (
          <TransactionItem key={index} transaction={transaction} />
        ))
        :
        <h1>No transactions</h1>
      }
    </div>
  )
}
export default TransactionList;