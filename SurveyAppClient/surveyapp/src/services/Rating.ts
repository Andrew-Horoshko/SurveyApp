import api from './api'

export const sendRatingToServer = async (ratingData) => {
  try {
    const response = await api.post('/api/Ratings', ratingData);
    console.log('Rating sent successfully:', response.data);
  } catch (error) {
    console.error('Error sending rating:', error);
  }
};
