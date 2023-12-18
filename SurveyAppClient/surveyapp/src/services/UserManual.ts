import api from './api'

export const getUserManual = async (userManualId) => {
    try {
      const response = await api.get(`api/UserManual?userManualId=${userManualId}`);
      return response.data;
    } catch (error) {
      console.error('Error fetching surveys:', error);
      throw new Error('Failed to fetch surveys');
    }
  };
