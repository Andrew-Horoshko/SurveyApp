import api from './api';

export const getSurveyQuestions = async (surveyId: number) => {
    try {
        const response = await api.get(`api/Survey/Questions/${surveyId}`);
        return response.data;
    } catch (error) {
        console.error('Error fetching survey questions:', error);
        throw new Error('Failed to fetch survey questions');
    }
};

export const addQuestion = async (questionData) => {
    try {
      const response = await api.post('/api/Question', questionData);
      console.log('Question add successfully:', response.data);
    } catch (error) {
      console.error('Error sending Question:', error);
    }
  };