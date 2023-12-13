import api from './api'

export const getUsers = async () => {
    try {
      const response = await api.get('api/Users');
      return response.data;
    } catch (error) {
      console.error('Error fetching surveys:', error);
      throw new Error('Failed to fetch surveys');
    }
  };