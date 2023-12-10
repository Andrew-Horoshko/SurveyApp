import api from './api'

export const getCompletedSurveys = async () => {
    try {
      const response = await api.get('');
      return response.data;
    } catch (error) {
      console.error('Error fetching surveys:', error);
      throw new Error('Failed to fetch surveys');
    }
  };