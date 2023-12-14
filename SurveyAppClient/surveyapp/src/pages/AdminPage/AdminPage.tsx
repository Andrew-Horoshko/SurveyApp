import React, { useState } from 'react';
import { PageHeader } from '../../components/PageHeader';
import './AdminPage.scss';

interface Section {
        questionType: string;
        questionText: string;
        answers: string[];
      }

export const AdminPage: React.FC = () => {
    const [surveyName, setSurveyName] = useState('');
  const [sections, setSections] = useState<Section[]>([
    {
      questionType: 'Single Choice',
      questionText: '',
      answers: [''],
    },
  ]);

  const handleAddSection = () => {
    setSections([...sections, { questionType: 'Single Choice', questionText: '', answers: [''] }]);
  };

  const handleAddQuestion = (sectionIndex: number) => {
    const updatedSections = [...sections];
    updatedSections[sectionIndex].answers.push('');
    setSections(updatedSections);
  };

  const handleQuestionChange = (e: React.ChangeEvent<HTMLInputElement>, sectionIndex: number) => {
    const updatedSections = [...sections];
    updatedSections[sectionIndex].questionText = e.target.value;
    setSections(updatedSections);
  };

  const handleQuestionTypeChange = (e: React.ChangeEvent<HTMLSelectElement>, sectionIndex: number) => {
    const updatedSections = [...sections];
    updatedSections[sectionIndex].questionType = e.target.value;
    setSections(updatedSections);
  };
  const handleSaveSurvey = () => {
    // Логіка для збереження опитування
  };
  return (
    <div>
      <PageHeader headerText='Сторінка адміна'/>
      <h1>Створення опитування</h1>
      <input
        type="text"
        value={surveyName}
        onChange={(e) => setSurveyName(e.target.value)}
        placeholder="Введіть назву опитування"
      />
      <button onClick={handleAddSection}>Додати питання</button>
      {sections.map((section, sectionIndex) => (
        <div key={sectionIndex}>
          <h3>Питання {sectionIndex + 1}</h3>
          <input
            type="text"
            value={section.questionText}
            onChange={(e) => handleQuestionChange(e, sectionIndex)}
            placeholder="Текст питання"
          />
          <select
            value={section.questionType}
            onChange={(e) => handleQuestionTypeChange(e, sectionIndex)}
          >
            <option value="Single Choice">Single Choice</option>
            <option value="Multiple Choice">Multiple Choice</option>
            <option value="Open Answer">Open Answer</option>
          </select>
          <button onClick={() => handleAddQuestion(sectionIndex)}>Додати відповідь</button>
          {section.answers.map((answer, answerIndex) => (
            <div key={answerIndex}>
              <input
                type="text"
                value={answer}
                // Логіка зміни відповіді
              />
              {/* Поле вибору для типу відповіді */}
              <select
                value={section.questionType}
                onChange={(e) => handleQuestionTypeChange(e, sectionIndex)}
              >
                <option value="Single Choice">Single Choice</option>
                <option value="Multiple Choice">Multiple Choice</option>
                <option value="Open Answer">Open Answer</option>
              </select>
            </div>
          ))}
        </div>
      ))}
      <button onClick={handleSaveSurvey} className="save-button">Зберегти опитування</button>
    </div>
  );
};