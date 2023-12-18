import React, { useState } from 'react';
import { PageHeader } from '../../components/PageHeader';
import './AdminPage.scss';
import { addSurvey } from '../../services/surveyService';
import { addQuestion } from '../../services/SurveyQuestions';

interface Answer {
  answerId: number;
  text: string;
  isCorrect: boolean;
}

interface Question {
  questionId: number;
  text: string;
  tooltip: string;
  hasRightAnswer: boolean;
  questionType: string;
  surveyId: number;
  answers: Answer[];
}

export const AdminPage: React.FC = () => {
  const [surveyName, setSurveyName] = useState('');
  const [sections, setSections] = useState<Question[]>([
    {
      questionId: 0,
      text: '',
      tooltip: '',
      hasRightAnswer: false,
      questionType: 'SingleChoice',
      surveyId: 0,
      answers: [{ answerId: 0, text: '', isCorrect: false }],
    },
  ]);

  const handleAddSection = () => {
    setSections([
      ...sections,
      {
        questionId: 0,
        text: '',
        tooltip: '',
        hasRightAnswer: false,
        questionType: 'Single Choice',
        surveyId: 0,
        answers: [{ answerId: 0, text: '', isCorrect: false }],
      },
    ]);
  };

  const handleAddQuestion = (sectionIndex: number) => {
    const updatedSections = [...sections];
    updatedSections[sectionIndex].answers.push({
      answerId: 0,
      text: '',
      isCorrect: false,
    });
    setSections(updatedSections);
  };

  const handleQuestionChange = (
    e: React.ChangeEvent<HTMLInputElement>,
    sectionIndex: number
  ) => {
    const updatedSections = [...sections];
    updatedSections[sectionIndex].text = e.target.value;
    setSections(updatedSections);
  };

  const handleQuestionTypeChange = (
    e: React.ChangeEvent<HTMLSelectElement>,
    sectionIndex: number
  ) => {
    const updatedSections = [...sections];
    updatedSections[sectionIndex].questionType = e.target.value;
    setSections(updatedSections);
  };

  const handleAnswerChange = (
    e: React.ChangeEvent<HTMLInputElement>,
    sectionIndex: number,
    answerIndex: number
  ) => {
    const updatedSections = [...sections];
    updatedSections[sectionIndex].answers[answerIndex].text = e.target.value;
    setSections(updatedSections);
  };

  const handleSaveSurvey = async () => {
    try {
      const surveyData = {
        surveyId: 0, 
        title: surveyName, 
        averageRating: 0, 
      };

      const surveyResponse = await addSurvey(surveyData);
      console.log(surveyResponse);
      const newSurveyId = surveyResponse.surveyId;

      for (const section of sections) {
        const questionData = {
          questionId: section.questionId,
          text: section.text,
          tooltip: section.tooltip,
          hasRightAnswer: section.hasRightAnswer,
          questionType: section.questionType,
          surveyId: newSurveyId,
          answers: section.answers,
        };

        await addQuestion(questionData);
      }
      setSurveyName('');
      setSections([
        {
          questionId: 0,
          text: '',
          tooltip: '',
          hasRightAnswer: false,
          questionType: 'SingleChoice',
          surveyId: 0,
          answers: [{ answerId: 0, text: '', isCorrect: false }],
        },
      ]);

    } catch (error) {
      console.error('Error while saving the survey', error);
    }
  };

  return (
    <>
      <PageHeader headerText="Створення опитування" />
      <div className="admin-page">
        
        <h1>Створення опитування</h1>
        <input
          type="text"
          value={surveyName}
          onChange={(e) => setSurveyName(e.target.value)}
          placeholder="Введіть назву опитування"
        />
        <button onClick={handleAddSection}>Додати питання</button>
        {sections.map((section, sectionIndex) => (
          <div key={sectionIndex} className="section-container">
            <h3>Питання {sectionIndex + 1}</h3>
            <input
              type="text"
              value={section.text}
              onChange={(e) => handleQuestionChange(e, sectionIndex)}
              placeholder="Текст питання"
            />
            <select
              value={section.questionType}
              onChange={(e) => handleQuestionTypeChange(e, sectionIndex)}
            >
              <option value="SingleChoice">Single Choice</option>
              <option value="MultipleChoice">Multiple Choice</option>
              <option value="OpenAnswer">Open Answer</option>
            </select>
            <button onClick={() => handleAddQuestion(sectionIndex)}>
              Додати відповідь
            </button>
            {section.answers.map((answer, answerIndex) => (
              <div key={answerIndex} className="answer-container">
                <input
                  type="text"
                  value={answer.text}
                  placeholder="Відповідь на питання"
                  onChange={(e) => handleAnswerChange(e, sectionIndex, answerIndex)}
                />
              </div>
            ))}
          </div>
        ))}
        <button onClick={handleSaveSurvey} className="save-button">
          Зберегти опитування
        </button>
      </div>
    </>
  );
};

