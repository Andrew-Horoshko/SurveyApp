import React from "react";
import { Link } from 'react-router-dom';
import './PlaceCard.scss'

export interface SurveyDataProps {
  surveyId: number;
  title: string;
  averageRating: number;
  userManualId: number;
}

interface PlaceCardProps {
  item: SurveyDataProps;
}

const PlaceCard: React.FC<PlaceCardProps> = ({ item }) => {
  return (
    <div className="place__container">
      <h3 className="place__name">{item.title}</h3>
      <h5 className="place__rating">Рейтинг: {item.averageRating.toFixed(1)}</h5>

      <Link key={item.surveyId} to={`/user-manual/${item.surveyId}`} >
      <h5 className="get-manual">Отримати довідку</h5>
      </Link>

      <Link key={item.surveyId} to={`/place/${item.surveyId}`} >
        <button className="start_button">Почати опитування</button>
      </Link>
    </div>
  );
};

export default PlaceCard;
