const TransactionMenu = () => {
  return (
    <div id="transaction-menu">
      <div>
        <h2>ACCOUNT NUMBER</h2>
        <div className="show-container">
          <p>123456789</p>
          <button className="show-button">Show</button>
        </div>
        <h2>AVAILABLE MONEY</h2>
        <div className="show-container">
          <p>123456789</p>
          <button className="show-button">Show</button>
        </div>
      </div>
      <button id="make-transfer-button" className="silent-action-button">Make transfer</button>
    </div>
  );
}
export default TransactionMenu;