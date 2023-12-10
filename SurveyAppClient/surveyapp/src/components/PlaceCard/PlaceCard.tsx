import React from "react";
import { Link } from 'react-router-dom';
import './PlaceCard.scss'

export interface SurveyDataProps {
  surveyId: number;
  title: string;
  averageRating: number;
}

interface PlaceCardProps {
  item: SurveyDataProps;
}

const PlaceCard: React.FC<PlaceCardProps> = ({ item }) => {
  return (
    <div className="place__container">
      {/* <img className="place__photo" src={item.images[0]} alt={item.title} /> */}
      <h3 className="place__name">{item.title}</h3>
      <h5 className="place__rating">Рейтинг: {item.averageRating}</h5>
      <Link key={item.surveyId} to={`/place/${item.surveyId}`} >
        <button className="start_button">Почати опитування</button>
      </Link>
    </div>
  );
};

export default PlaceCard;
