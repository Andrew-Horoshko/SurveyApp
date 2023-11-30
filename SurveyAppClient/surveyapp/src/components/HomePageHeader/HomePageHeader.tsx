import React, { useState } from 'react';
import './HomePageHeader.scss';
import defaultUserImage from '../../assets/images/user-icon.png'

export const HomePageHeader: React.FC = () => {
    const greeting = "welcome👋";
    const UserImage = defaultUserImage;

    return (
        <header className="header">
            <div className='header__user'>
                <div className="header__icon">
                    <img src={UserImage} alt="User Icon" />
                </div>
                <div className="header__username">{greeting}</div>
            </div>
            <div className="search-heart-container">
                <div className="heart-button">
                  
                </div>
                <div className="search">
                    
                </div>
            </div>
        </header>

    );
};