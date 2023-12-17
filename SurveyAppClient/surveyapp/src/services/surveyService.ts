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

export const getSurvey = async (id: number) => {
  try {
    const response = await api.get(`api/Survey?surveyId=${id}`);
    return response.data;
  } catch (error) {
    console.error('Error while fetching survey', error);
    throw new Error(`Failed to fetch survey with id ${id}`);
  }
}

export const submitSurveyAttempt = async (surveyAttempt: SurveyAttempt) => {
  try {
    const response = await api.post('api/Survey/SaveAttempt', surveyAttempt);
    return response.data;
  } catch (error) {
    console.error('Error while submitting a survey', error);
    throw new Error(`Failed to submit an attempt for survey with id ${surveyAttempt.surveyId}`);
  }
}