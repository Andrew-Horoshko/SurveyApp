import React, { useState, useEffect } from 'react';
import { getUserSurvey, saveTreatment } from '../../services/UserService';
import { PageHeader } from '../../components/PageHeader';
import './DoctorPage.scss';

interface UserQuiz {
  surveyId: number;
  title: string;
  strategy: string;
  treatment: string;
  recommendation: string;
  addingTreatment?: boolean;
}

export const DoctorPage: React.FC = () => {
  const [userId, setUserId] = useState<number>(0);
  const [userQuizzes, setUserQuizzes] = useState<UserQuiz[]>([]);

  const handleUserIdChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUserId(Number(e.target.value));
  };

  useEffect(() => {
    async function fetchUserQuizzes() {
      try {
        const fetchedUserQuizzes = await getUserSurvey(userId);
        setUserQuizzes(fetchedUserQuizzes);
      } catch (error) {
        console.error('Error fetching user quizzes:', error);
      }
    }

    if (userId !== 0) {
      fetchUserQuizzes();
    }
  }, [userId]);

  const handleAssignTreatment = (surveyId: number) => {
    setUserQuizzes(prevQuizzes =>
      prevQuizzes.map(quiz =>
        quiz.surveyId === surveyId
          ? { ...quiz, addingTreatment: true }
          : quiz
      )
    );
  };

  const handleSaveTreatment = async (surveyId: number) => {
    const quizToUpdate = userQuizzes.find(quiz => quiz.surveyId === surveyId);
    if (quizToUpdate) {
      try {
        await saveTreatment({
          treatmentStrategyId: 0,
          diagnosis: quizToUpdate.strategy,
          treatment: quizToUpdate.treatment,
          recommendation: quizToUpdate.recommendation,
          patientId: userId,
          doctorId: 2,
        });
        setUserQuizzes(prevQuizzes =>
          prevQuizzes.map(quiz =>
            quiz.surveyId === surveyId ? { ...quiz, addingTreatment: false } : quiz
          )
        );
      } catch (error) {
        console.error('Error saving treatment:', error);
      }
    }
  };

  return (
    <>
      <PageHeader headerText="Сторінка лікаря" />
      <div className="doctor-page">
        <h1>Пройдені опитування користувача</h1>
        <label htmlFor="userIdInput">ID користувача:</label>
        <input
          type="number"
          id="userIdInput"
          value={userId}
          onChange={handleUserIdChange}
          placeholder="Введіть ID користувача"
        />
        <table>
          <thead>
            <tr>
              <th>Назва опитування</th>
              <th>Дії</th>
              <th>Стратегія</th>
              <th>Лікування</th>
              <th>Рекомендації</th>
              <th>Зберегти</th>
            </tr>
          </thead>
          <tbody>
            {userQuizzes.map((quiz) => (
              <tr key={quiz.surveyId}>
                <td>{quiz.title}</td>
                <td>
                  {quiz.addingTreatment ? (
                    <button onClick={() =>
                      setUserQuizzes(prevQuizzes =>
                        prevQuizzes.map(q =>
                          q.surveyId === quiz.surveyId
                            ? { ...q, addingTreatment: false }
                            : q
                        )
                      )
                    }>
                      Скасувати
                    </button>
                  ) : (
                    <button onClick={() => handleAssignTreatment(quiz.surveyId)}>
                      Назначити лікування
                    </button>
                  )}
                </td>
                <td>
                  {quiz.addingTreatment && (
                    <input
                      type="text"
                      placeholder="Стратегія"
                      value={quiz.strategy}
                      onChange={(e) =>
                        setUserQuizzes(prevQuizzes =>
                          prevQuizzes.map(q =>
                            q.surveyId === quiz.surveyId
                              ? { ...q, strategy: e.target.value }
                              : q
                          )
                        )
                      }
                    />
                  )}
                </td>
                <td>
                  {quiz.addingTreatment && (
                    <input
                      type="text"
                      placeholder="Лікування"
                      value={quiz.treatment}
                      onChange={(e) =>
                        setUserQuizzes(prevQuizzes =>
                          prevQuizzes.map(q =>
                            q.surveyId === quiz.surveyId
                              ? { ...q, treatment: e.target.value }
                              : q
                          )
                        )
                      }
                    />
                  )}
                </td>
                <td>
                  {quiz.addingTreatment && (
                    <input
                      type="text"
                      placeholder="Рекомендації"
                      value={quiz.recommendation}
                      onChange={(e) =>
                        setUserQuizzes(prevQuizzes =>
                          prevQuizzes.map(q =>
                            q.surveyId === quiz.surveyId
                              ? { ...q, recommendation: e.target.value }
                              : q
                          )
                        )
                      }
                    />
                  )}
                </td>
                <td>
                  {quiz.addingTreatment && (
                    <button onClick={() => handleSaveTreatment(quiz.surveyId)}>
                      Зберегти
                    </button>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};
