import { PageHeader } from "../../components/PageHeader";
import './PlacePage.scss';
import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { getSurvey, submitSurveyAttempt } from "../../services/surveyService";
import { getSurveyQuestions } from '../../services/SurveyQuestions';
import { getAnswersForQuestion } from '../../services/Answer';
import { Hint } from "../../components/Hint";

export const PlacePage: React.FC = () => {
    const [survey, setSurvey] = useState<any>();
    const { id } = useParams<{ id: string }>();
    const [questions, setQuestions] = useState<any[]>([]);
    const [answers, setAnswers] = useState<any[]>([]);

    const [userAnswers, setUserAnswers] = useState<SurveyAnswer[]>([]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {

        // Parse data from input name
        const { name, value } = e.target;
        const identifiers: string[] = name.split(/[q_a]+/);
        console.log(name);
        console.log(identifiers);
        const questionType: string = identifiers[0];
        const questionId: number = parseInt(identifiers[1]);
        const answerId: number = parseInt(identifiers[2]);

        // Create new user answer entry
        const userAnswer: SurveyAnswer = {
            surveyAnswerId: 0,
            surveyAttemptId: 0,
            questionId: questionId,
            answerId: answerId,
        };
        if (value) {
            userAnswer.openAnswer = value;
        }

        // Update user answers state
        setUserAnswers(prevData => {

            // Handle checkbox input
            if (questionType == 'm') {
                const prevAnswerIndex = prevData.findIndex(a => 
                    a.questionId == userAnswer.questionId && 
                    a.answerId == userAnswer.answerId);
                if (prevAnswerIndex == -1) {
                    prevData.push(userAnswer);
                }

                return prevData;
            }

            // Handle radiobutton/text input
            const prevAnswerIndex = prevData.findIndex(a => a.questionId == userAnswer.questionId);
            if (prevAnswerIndex != -1) {
                prevData.splice(prevAnswerIndex, 1);
            }
            prevData.push(userAnswer);

            return prevData;
        });

        console.log(userAnswers);
    }

    function submitSurvey() {
        const surveyAttempt: SurveyAttempt = {
            surveyAttemptId: 0,
            userId: 1, // TODO: pass actual user id
            surveyId: id,
            surveyAnswers: userAnswers
        };

        submitSurveyAttempt(surveyAttempt);
    }

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
    }, [survey]);

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
                                    <input type="radio" name={`s_q${question.questionId}_a${answer.answerId}`} value={answer.text} 
                                        onChange={handleChange} />
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
                                    <input type="checkbox" name={`m_q${question.questionId}_a${answer.answerId}`} value={answer.text} 
                                        onChange={handleChange} />
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
                        <input type="text" name={`o_q${question.questionId}_a1`} className="open-answer-input" 
                            onChange={handleChange} />
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
                <button className="finish_btn" onClick={submitSurvey}>Завершити опитування</button>
            </div>
        </>
    );
};
