import { useState } from 'react';

const PartialPasswordForm: React.FC<{ mask: number[]; onSubmit: (password: string) => void }> = ({ mask, onSubmit }) => {
  const maxInput = Math.ceil(Math.max(...mask) / 5) * 5;
  const [inputValues, setInputValues] = useState<string[]>(Array(maxInput).fill(''));

  const handleChange = (index: number, value: string) => {
    const newInputValues = [...inputValues];
    newInputValues[index] = value;
    setInputValues(newInputValues);
  };

  const handleInternalSubmit = () => {
    const selectedValues = mask.map((index) => inputValues[index - 1]);
    const joinedPassword = selectedValues.join('');
    onSubmit(joinedPassword);
  };

  return (
    <>
      <div id="partial-password-form">
        {inputValues.map((value, index) => (
          <div>
            {index + 1}
            <br />
            <input className='partial-password-input'
              key={index}
              type="password"
              maxLength={1}
              value={value}
              onChange={(e) => handleChange(index, e.target.value)}
              disabled={!mask.includes(index + 1)}
            />
          </div>
        ))}
      </div>
      <button className="main-action-button" onClick={handleInternalSubmit}>Login</button>
    </>
  );
};

export default PartialPasswordForm;