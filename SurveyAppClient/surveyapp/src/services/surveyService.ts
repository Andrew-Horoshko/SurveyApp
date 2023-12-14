import api from './api'

export const fetchSurveys = async () => {
    try {
      const response = await api.get('api/Survey/AllSurveys');
      return response.data;
    } catch (error) {
      console.error('Error fetching surveys:', error);
      throw new Error('Failed to fetch surveys');
    }
  };