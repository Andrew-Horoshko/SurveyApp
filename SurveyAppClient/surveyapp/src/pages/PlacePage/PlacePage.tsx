import { PageHeader } from "../../components/PageHeader";
import './PlacePage.scss';
import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { getSurvey } from "../../services/surveyService";
import { getSurveyQuestions } from '../../services/SurveyQuestions';
import { getAnswersForQuestion } from '../../services/Answer';
import { Hint } from "../../components/Hint";

export const PlacePage: React.FC = () => {
    const [survey, setSurvey] = useState<any>();
    const { id } = useParams<{ id: string }>();
    const [questions, setQuestions] = useState<any[]>([]);
    const [answers, setAnswers] = useState<any[]>([]);

    useEffect(() => {
        async function fetchSurvey() {
            try {
                const survey = await getSurvey(parseInt(id));
                setSurvey(survey);
            } catch (error) {
                console.error("Error while fetching survey", error);
            }
        }
    
        fetchSurvey();
    }, [id]);
    
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
    
    useEffect(() => {
        async function fetchAnswersForAllQuestions() {
            try {
                for (const question of questions) {
                    const data = await getAnswersForQuestion(question.questionId);
                    setAnswers(prevAnswers => [...prevAnswers, ...data]);
                }
            } catch (error) {
                console.error('Error fetching answers for questions:', error);
            }
        }
    
        if (questions.length > 0) {
            fetchAnswersForAllQuestions();
        }
    }, [questions]);

    const renderQuestion = (question: any) => {
        let questionAnswers = answers.filter((answer: any) => answer.questionId === question.questionId);
        
        switch (question.questionType) {
            case 'SingleChoice':
                return (
                    <div key={question.questionId} className="question-container">
                        <div className="question-text">
                            <span>{question.text}</span>
                            <Hint  hint={question.tooltip} />
                        </div>
                        <div className="answers">
                            {questionAnswers.map((answer: any) => (
                                <label key={answer.answerId} className="answer-label">
                                    <input type="radio" name={`question_${question.questionId}`} value={answer.text} />
                                    <span className="answer-text">{answer.text}</span>
                                </label>
                            ))}
                        </div>
                    </div>
                );
            case 'MultipleChoice':
                return (
                    <div key={question.questionId} className="question-container">
                        <div className="question-text">
                            <span>{question.text}</span>
                            <Hint  hint={question.tooltip} />
                        </div>
                        <div className="answers">
                            {questionAnswers.map((answer: any) => (
                                <label key={answer.answerId} className="answer-label">
                                    <input type="checkbox" name={`question_${question.questionId}_${answer.text}`} value={answer.text} />
                                    <span className="answer-text">{answer.text}</span>
                                </label>
                            ))}
                        </div>
                    </div>
                );
            case 'OpenAnswer':
                return (
                    <div key={question.questionId} className="question-container">
                        <div className="question-text">
                            <span>{question.text}</span>
                            <Hint  hint={question.tooltip} />
                        </div>
                    <input type="text" name={`question_${question.questionId}_textInput`} className="open-answer-input" />
                    </div>
                );
            default:
                return null;
        }
    };

    if (!survey) return <div>Загрузка...</div>;

    return (
        <>
            <PageHeader headerText={"Пройдіть опитування"} />
            <h1 className="page-header">{survey.title}</h1>
            <div className="place-page">
                {questions.map((question: any) => (
                    <React.Fragment key={question.questionId}>
                        {renderQuestion(question)}
                    </React.Fragment>
                ))}
                <button className="finish_btn"/*onClick={finishSurvey}*/>Завершити опитування</button>
            </div>
        </>
    );
};
