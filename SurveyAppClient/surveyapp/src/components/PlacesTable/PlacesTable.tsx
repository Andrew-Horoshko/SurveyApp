import React, { useState, useEffect } from "react";
import './PlacesTable.scss'
import { fetchSurveys } from '../../services/surveyService';

import PlaceCard from "../PlaceCard/PlaceCard";

const PlacesTable: React.FC = () => {

  const [surveys, setSurveys] = useState<any[]>([]); // Ось тут можна визначити більш конкретний тип для масиву опитувань

  useEffect(() => {
    async function getSurveys() {
      try {
        const data = await fetchSurveys(); // Виклик функції, яка отримує дані опитувань
        setSurveys(data); // Оновлюємо стан компонента з отриманими даними
      } catch (error) {
        console.error('Error fetching surveys:', error);
      }
    }

    getSurveys(); // Викликаємо функцію при завантаженні компонента або можна викликати за необхідності
  }, []);

  return (
    <div>
      <div className="places__table">
        {surveys.map((survey ) => (
          <PlaceCard
            key={survey.surveyid}
            item={survey}
          />
        ))}
      </div>
    </div>
    
  );
};

export default PlacesTable;
