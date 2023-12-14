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