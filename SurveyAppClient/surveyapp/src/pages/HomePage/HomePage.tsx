import React from 'react';
import { HomePageHeader } from '../../components/HomePageHeader/HomePageHeader';
import './HomePage.scss';
import PlacesTable from '../../components/PlacesTable/PlacesTable';
import { Link } from 'react-router-dom';

export const HomePage: React.FC = () => {
  return (
    <div className='home-page'>
      <HomePageHeader/>
      <main className="main">
        <div className="popular__places">
          <h2 className='popular_places'>{('Обрати опитування')}</h2>
          <Link to={`/user-manual`} >
            <h5 className="get-manual">Допомога</h5>
          </Link>
          <PlacesTable/>
        </div>
      </main>
    </div>
  );
};
