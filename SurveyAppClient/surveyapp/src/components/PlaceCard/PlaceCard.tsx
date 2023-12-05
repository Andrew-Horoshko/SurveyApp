import React from "react";
import { Link } from 'react-router-dom';
import './PlaceCard.scss'

export interface FoodEstablishmentDataProps {
  id: number;
  name: string;
  description: string;
  images: string[];
}

interface PlaceCardProps {
  item: FoodEstablishmentDataProps;
}

const PlaceCard: React.FC<PlaceCardProps> = ({ item }) => {
  return (
    <Link key={item.id} to={`/place/${item.id}`} className="place__container">
        <img className="place__photo" src={item.images[0]} alt={item.name} />
        <p className="place__name">{item.name}</p>
        <p className="place__description">{item.description}</p>
        <button className="start_button">Почати опитування</button>
    </Link>
  );
};

export default PlaceCard;
