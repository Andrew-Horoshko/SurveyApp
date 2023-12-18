import api from './api'

export const getUserSurvey = async ( userId ) => {
    try {
      const response = await api.get(`api/Survey/UserSurveys/${userId}`);
      return response.data;
    } catch (error) {
      console.error('Error fetching surveys:', error);
      throw new Error('Failed to fetch surveys');
    }
};

export const saveTreatment = async (treatmentData: any) => {
  try {
    const response = await api.post('/api/TreatmentStrategy', treatmentData);
    return response.data;
  } catch (error) {
    throw new Error('Failed to save treatment');
  }
};