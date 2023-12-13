import { PageHeader } from "../../components/PageHeader";
import './PlacePage.scss';
import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { getSurveyQuestions } from '../../services/SurveyQuestions';
import { getAnswersForQuestion } from '../../services/Answer';
import { Hint } from "../../components/Hint";

export const PlacePage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [questions, setQuestions] = useState<any[]>([]);
    const [answers, setAnswers] = useState<any[]>([]);

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
        async function fetchAnswers(questionId: number) {
            try {
                const data = await getAnswersForQuestion(questionId);
                setAnswers(prevAnswers => [...prevAnswers, ...data]);
            } catch (error) {
                console.error('Error fetching answers for question:', error);
            }
        }
    
        questions.forEach((question: any) => {
            fetchAnswers(question.questionId);
        });
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

    return (
        <>
            <PageHeader headerText={"Пройдіть опитування"} />
            <h1 className="page-header">Питання для Survey {id}</h1>
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
