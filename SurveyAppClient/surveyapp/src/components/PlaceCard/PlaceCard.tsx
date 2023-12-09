import React from "react";
import { Link } from 'react-router-dom';
import './PlaceCard.scss'

export interface SurveyDataProps {
  SurveyId: number;
  AverageRating: number;
  Title: string;
}

interface PlaceCardProps {
  item: SurveyDataProps;
}

const PlaceCard: React.FC<PlaceCardProps> = ({ item }) => {
  return (
    <Link key={item.SurveyId} to={`/place/${item.SurveyId}`} className="place__container">
        {/* <img className="place__photo" src={item.images[0]} alt={item.Title} /> */}
        <p className="place__name">{item.Title}</p>
        <p className="place__rating">Average Rating: {item.AverageRating}</p>
        <button className="start_button">Почати опитування</button>
    </Link>
  );
};

export default PlaceCard;
