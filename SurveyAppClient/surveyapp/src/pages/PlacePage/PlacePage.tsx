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

    useEffect(() => {
        const fetchSurvey = async () => {
            try {
                const survey = await getSurvey(parseInt(id));
                setSurvey(survey);
            } catch (error) {
                console.error("Error while fetching survey", error);
            }
        };
        fetchSurvey();
    }, [id]);

    useEffect(() => {
        const fetchQuestions = async () => {
            try {
                const data = await getSurveyQuestions(parseInt(id));
                setQuestions(data);
            } catch (error) {
                console.error('Error fetching questions:', error);
            }
        };
        fetchQuestions();
    }, [id]);

    useEffect(() => {
        const fetchAnswers = async () => {
            try {
                const fetchedAnswers: any[] = [];
                for (const question of questions) {
                    const answersForQuestion = await getAnswersForQuestion(question.questionId);
                    fetchedAnswers.push(...answersForQuestion);
                }
                setAnswers(fetchedAnswers);
            } catch (error) {
                console.error('Error fetching answers:', error);
            }
        };
        fetchAnswers();
    }, [questions]);

    const handleChange = (
        e: React.ChangeEvent<HTMLInputElement>,
        questionId: number,
        answerId: number,
        questionType: string
    ) => {
        const { value, checked } = e.target;

        const userAnswer: SurveyAnswer = {
            surveyAnswerId: 0,
            surveyAttemptId: 0,
            questionId: questionId,
            answerId: answerId,
        };

        if (value && questionType !== 'MultipleChoice') {
            userAnswer.openAnswer = value;
        }

        setUserAnswers(prevAnswers => {
            const updatedAnswers = [...prevAnswers.filter(a => a.questionId !== questionId)];

            if (checked || value) {
                updatedAnswers.push(userAnswer);
            }

            return updatedAnswers;
        });
    };

    const submitSurvey = () => {
        const surveyAttempt: SurveyAttempt = {
            surveyAttemptId: 0,
            userId: 1, // Replace with actual user ID
            surveyId: id,
            surveyAnswers: userAnswers,
        };

        submitSurveyAttempt(surveyAttempt)
            .then((response) => {
                // Handle success response
            })
            .catch((error) => {
                console.error('Error submitting survey attempt:', error);
            });
    };

    const renderQuestion = (question: any) => {
        let questionAnswers = answers.filter(
            (answer: any) => answer.questionId === question.questionId
        );

        switch (question.questionType) {
            case 'SingleChoice':
                return (
                    <div key={question.questionId} className="question-container">
                        <div className="question-text">
                            <span>{question.text}</span>
                            <Hint hint={question.tooltip} />
                        </div>
                        <div className="answers">
                            {questionAnswers.map((answer: any) => (
                                <label key={answer.answerId} className="answer-label">
                                    <input
                                        type="radio"
                                        name={`s_q${question.questionId}`}
                                        value={answer.text}
                                        onChange={(e) =>
                                            handleChange(
                                                e,
                                                question.questionId,
                                                answer.answerId,
                                                question.questionType
                                            )
                                        }
                                    />
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
                            <Hint hint={question.tooltip} />
                        </div>
                        <div className="answers">
                            {questionAnswers.map((answer: any) => (
                                <label key={answer.answerId} className="answer-label">
                                    <input
                                        type="checkbox"
                                        name={`m_q${question.questionId}_a${answer.answerId}`}
                                        value={answer.text}
                                        onChange={(e) =>
                                            handleChange(
                                                e,
                                                question.questionId,
                                                answer.answerId,
                                                question.questionType
                                            )
                                        }
                                    />
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
                            <Hint hint={question.tooltip} />
                        </div>
                        <input
                            type="text"
                            name={`o_q${question.questionId}_a1`}
                            className="open-answer-input"
                            onChange={(e) =>
                                handleChange(
                                    e,
                                    question.questionId,
                                    1,
                                    question.questionType
                                )
                            }
                        />
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

