import React, { useState, useEffect } from "react";
import './PlacesTable.scss'
import { fetchSurveys } from '../../services/surveyService';

import PlaceCard from "../PlaceCard/PlaceCard";

const PlacesTable: React.FC = () => {

  const [surveys, setSurveys] = useState<any[]>([]); 

  useEffect(() => {
    async function getSurveys() {
      try {
        const data = await fetchSurveys(); 
        setSurveys(data); 
      } catch (error) {
        console.error('Error fetching surveys:', error);
      }
    }

    getSurveys(); 
  }, []);

  if (!surveys) return <div>Загрузка...</div>;

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
