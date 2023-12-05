import React from 'react';
import './AccountSettings.scss';

export const AccountSettings: React.FC<{}> = ({ }) => {

  return (
    <div className='account-settings'>
      <div className='account-settings__block'>
        <h3 className='account-settings__title'>{('settings')}</h3>
      </div>
    </div>
  )
};