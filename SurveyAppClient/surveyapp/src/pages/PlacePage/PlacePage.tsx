import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom'
import { PageHeader } from "../../components/PageHeader";
import { foodEstablishmentData } from "../../mocks";
import './PlacePage.scss';

export const PlacePage = () => {
    const {id} = useParams<{ id: string }>();
    const place = foodEstablishmentData.find(item => item.id === parseInt(id));

    // State для питань та відповідей
    const [questions, setQuestions] = useState<string[]>([]);
    const [answers, setAnswers] = useState<string[]>([]);

    // State для відображення вспливаючих вікон
    const [showHints, setShowHints] = useState<boolean[]>([]);

    // Функція завантаження питань та їх відображення
    useEffect(() => {
        // Код для завантаження питань по ID місця
        // Оновлення стану питань
        // setQuestions([...loadedQuestions]);
        // Ініціалізація пустих значень для відповідей
        // setAnswers(Array(loadedQuestions.length).fill(''));
        // Ініціалізація показу підказок для кожного питання
        // setShowHints(Array(loadedQuestions.length).fill(false));
    }, [id]);

    // Функція для відображення підказки для певного питання
    const toggleHint = (index: number) => {
        const updatedShowHints = [...showHints];
        updatedShowHints[index] = !updatedShowHints[index];
        setShowHints(updatedShowHints);
    };

    // Функція для збереження відповідей
    const saveAnswer = (index: number, answer: string) => {
        const updatedAnswers = [...answers];
        updatedAnswers[index] = answer;
        setAnswers(updatedAnswers);
    };

    // Функція для обробки завершення проходження
    const finishSurvey = () => {
        // Логіка для обробки відправлення відповідей
    };

    return (
        <>
            <PageHeader headerText={place.name || 'Place Name'}/>
            <div className="place-page">
                {questions.map((question, index) => (
                    <div key={index} className="question-container">
                        <div className="question">
                            <span>{question}</span>
                            {/* Кнопка для відображення підказки */}
                            <button onClick={() => toggleHint(index)}>Hint</button>
                        </div>
                        {/* Вікно з підказкою (відображається, якщо showHints[index] === true) */}
                        {showHints[index] && <div className="hint">Hint text here</div>}
                        {/* Поле для введення відповіді або вибору варіанту */}
                        <input type="text" value={answers[index] || ''} onChange={(e) => saveAnswer(index, e.target.value)} />
                    </div>
                ))}
                {/* Кнопка завершення проходження */}
                <button onClick={finishSurvey}>Finish Survey</button>
            </div>
        </>
    );
};
