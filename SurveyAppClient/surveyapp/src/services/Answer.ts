import api from './api'

export const getAnswersForQuestion = async (questionId: number) => {
    try {
        const response = await api.get(`/Answers?questionId=${questionId}`);
        return response.data; 
    } catch (error) {
        throw new Error('Failed to fetch survey questions: ' + error.message);
    }
}