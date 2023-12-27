import { useState } from 'react';

const PartialPasswordForm: React.FC<{ mask: number[]; onSubmit: (password: string) => void }> = ({ mask, onSubmit }) => {
  const fullPasswordInput = (Math.ceil(mask[mask.length - 1] / 5) + 1) * 5;
  const [inputValues, setInputValues] = useState<string[]>(Array(fullPasswordInput).fill(''));

  const handleChange = (index: number, value: string) => {
    const newInputValues = [...inputValues];
    newInputValues[index] = value;
    setInputValues(newInputValues);
  };

  const handleInternalSubmit = () => {
    const selectedValues = mask.map((index) => inputValues[index]);
    const joinedPassword = selectedValues.join('');
    onSubmit(joinedPassword);
  };

  return (
    <>
      <div id="partial-password-form">
        {inputValues.map((value, index) => (
          <div key={index}>
            {index + 1}
            <br />
            <input className='partial-password-input'
              type="password"
              maxLength={1}
              value={value}
              onChange={(e) => handleChange(index, e.target.value)}
              disabled={!mask.includes(index)}
            />
          </div>
        ))}
      </div>
      <button className="main-action-button" onClick={handleInternalSubmit}>Login</button>
    </>
  );
};

export default PartialPasswordForm;