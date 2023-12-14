import React from 'react';
import './AccountSettings.scss';
import { useHistory } from 'react-router-dom';
import strategyImage from '../../../assets/images/strategy.png';

export const AccountSettings: React.FC<{}> = ({ }) => {
  const history = useHistory();

  const handleSignOut = () => {
    localStorage.clear();
    history.push('/strategy');
  }
  return (
    <div className='account-settings'>
      <div className='account-settings__block'>
        <h3 className='account-settings__title'>Стратегія лікування</h3>
        
      <button className={`signout-button`} type='button' onClick = { handleSignOut }>
      <span className='signout-button__icon-container'>
        <img src={strategyImage} className='strategy'/>
      </span>
      <span className='signout-button__text'>Переглянути</span>
    </button>
      </div>
    </div>
  )
};

