import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom'
import { PageHeader } from "../../components/PageHeader";
import { foodEstablishmentData } from "../../mocks";
import './PlacePage.scss';
import { fetchSurveys } from '../../services/surveyService';

export const PlacePage = () => {
      const [surveys, setSurveys] = useState<any[]>([]); // Ось тут можна визначити більш конкретний тип для масиву опитувань

    // Функція завантаження питань та їх відображення
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
        <>
            <PageHeader headerText={/*place.name ||*/ 'Place Name'}/>
            <div className="place-page">
                
                {/* Кнопка завершення проходження */}
                <button /*onClick={finishSurvey}*/>Finish Survey</button>
            </div>
        </>
    );
};
