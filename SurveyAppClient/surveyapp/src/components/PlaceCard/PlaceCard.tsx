import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
import './PlaceCard.scss'
import { Hint } from "../Hint";
import { getUserManual } from "../../services/UserManual";

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
  const [userManualContent, setUserManualContent] = useState('');

  useEffect(() => {
    async function fetchUserManualContent() {
      try {
        const userManual = await getUserManual(item.surveyId);
        setUserManualContent(userManual.content);
      } catch (error) {
        console.error('Error fetching user manual:', error);
      }
    }

    fetchUserManualContent();
  }, [item.userManualId]);

  return (
    <div className="place__container">
      <div className="place__info">
        <h3 className="place__name">{item.title}</h3>
        <Hint hint={userManualContent} />
      </div>
  
      <h5 className="place__rating">Рейтинг: {item.averageRating}</h5>

      <Link key={item.surveyId} to={`/place/${item.surveyId}`} >
        <button className="start_button">Почати опитування</button>
      </Link>
    </div>
  );
};

export default PlaceCard;
