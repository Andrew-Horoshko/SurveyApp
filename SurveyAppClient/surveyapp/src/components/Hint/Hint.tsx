import React, { useState } from 'react';
import './Hint.scss';
import hintIcon from '../../assets/images/hint-icon.png';

interface HintProps {
  hint: string;
}

export const Hint: React.FC<HintProps> = ({ hint }) => {
  const [showHint, setShowHint] = useState(false);

  const toggleHint = () => {
    setShowHint(!showHint);
  };

  return (
    <div className="hint-container">
        <span className="hint-question" onMouseEnter={toggleHint} onMouseLeave={toggleHint}>
            <img
            src={hintIcon}
            alt="Hint"
            className="hint-icon"
            onMouseEnter={toggleHint}
            onMouseLeave={toggleHint}
            />
      </span>
      {showHint && <div className="hint-tooltip">{hint}</div>}
    </div>
  );
};

