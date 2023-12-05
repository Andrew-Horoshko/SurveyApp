import React from 'react';
import { HomePageHeader } from '../../components/HomePageHeader/HomePageHeader';
import './HomePage.scss';
import { foodEstablishmentData } from '../../mocks/foodEstablishmentData';
import PlacesTable from '../../components/PlacesTable/PlacesTable';

export const HomePage: React.FC = () => {
  return (
    <div className='home-page'>
      <HomePageHeader/>
      <main className="main">
        <div className="popular__places">
          <h2 className='popular_places'>{('Обрати опитування')}</h2>
          <PlacesTable places={foodEstablishmentData}/>
        </div>
      </main>
    </div>
  );
};
