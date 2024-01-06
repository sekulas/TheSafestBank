import { useState } from "react";

const ShowHideComponent = ({ children }: { children: React.ReactNode }) => {
  const [isShown, setIsShown] = useState(false);

  const handleButtonClick = () => {
    setIsShown(true);

    setTimeout(() => {
      setIsShown(false);
    }, 5000);
  };

  return (
    <div className="show-container">
      {isShown === true ? (
        children
      ) : (
        <div className="hiding-block">00000000000000000000000000</div>
      )}
      <button onClick={handleButtonClick}>Show</button>
    </div>
  );
};

export default ShowHideComponent;
