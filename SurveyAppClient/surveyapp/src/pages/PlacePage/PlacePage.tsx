import { PageHeader } from "../../components/PageHeader";
import './PlacePage.scss';
import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { getSurveyQuestions } from '../../services/SurveyQuestions';
import {} from '../../services/SurveyQuestions'

export const PlacePage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [questions, setQuestions] = useState<any[]>([]);

    useEffect(() => {
        async function fetchQuestions() {
            try {
                const data = await getSurveyQuestions(parseInt(id));
                setQuestions(data);
            } catch (error) {
                console.error('Error fetching questions:', error);
            }
        }

        fetchQuestions();
    }, [id]);

    // const renderQuestion = (question: any) => {
    //     switch (question.discriminator) {
    //         case 'SingleChoiceQuestion':
    //             return (
    //                 <div key={question.questionId}>
    //                     <p>{question.text}</p>
    //                     <input type="radio" name={`question_${question.questionId}`} value="option1" />
    //                     <label>Option 1</label>
    //                     <input type="radio" name={`question_${question.questionId}`} value="option2" />
    //                     <label>Option 2</label>
    //                     {/* Add more radio buttons/options as needed */}
    //                 </div>
    //             );
    //         case 'MultipleChoiceQuestion':
    //             return (
    //                 <div key={question.questionId}>
    //                     <p>{question.text}</p>
    //                     <input type="checkbox" name={`question_${question.questionId}_option1`} value="option1" />
    //                     <label>Option 1</label>
    //                     <input type="checkbox" name={`question_${question.questionId}_option2`} value="option2" />
    //                     <label>Option 2</label>
    //                     {/* Add more checkboxes/options as needed */}
    //                 </div>
    //             );
    //         case 'OpenTextQuestion':
    //             return (
    //                 <div key={question.questionId}>
    //                     <p>{question.text}</p>
    //                     <input type="text" name={`question_${question.questionId}_answer`} />
    //                 </div>
    //             );
    //         default:
    //             return null;
    //     }
    // };

    return (
      <>
          <PageHeader headerText={"Пройдіть опитування"}/>
          <div className="place-page">
              <h1>Питання для Survey {id}</h1>
              <ul>
                  {questions.map((question: any) => (
                      <li className='question' key={question.questionId}>{question.text} </li>
                  ))}
              </ul>
              <button className="finish_btn"/*onClick={finishSurvey}*/>Завершити опитування</button>
          </div>
      </>
    );
};