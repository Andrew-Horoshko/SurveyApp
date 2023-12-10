import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import { getCompletedSurveys } from '../../services/CompletedSurveys'; 
import { PageHeader } from '../../components/PageHeader';

const CompletedSurveysPage: React.FC = () => {
    const history = useHistory();
    const [completedSurveys, setCompletedSurveys] = useState<any[]>([]); 

    useEffect(() => {
        async function fetchCompletedSurveys() {
            try {
                const data = await getCompletedSurveys(); 
                setCompletedSurveys(data); 
            } catch (error) {
                console.error('Error fetching completed surveys:', error);
            }
        }

        fetchCompletedSurveys();
    }, []);

    const onSurveyClick = (surveyId: number) => {
        history.push(`/completed-surveys/${surveyId}`); 
    };

    return (
        <>
            <PageHeader headerText={"Пройдені опитування"}/>
                <div>
                    <ul>
                        {completedSurveys.map((survey) => (
                            <li key={survey.surveyId} onClick={() => onSurveyClick(survey.surveyId)}>
                                {survey.title} - {survey.dateCompleted}
                            </li>
                        ))}
                    </ul>
                </div>
        </>
    );
};

export default CompletedSurveysPage;