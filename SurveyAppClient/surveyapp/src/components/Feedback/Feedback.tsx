import React, { useState } from 'react';
import './Feedback.scss';

interface StarRatingProps {
  onChange: (rating: number) => void;
  disabled: boolean;
  value: number;
}

export const StarRating: React.FC<StarRatingProps> = ({ onChange, disabled, value }) => {
  const [rating, setRating] = useState(value);
  const [hoverRating, setHoverRating] = useState(0);
  const [hasRated, setHasRated] = useState(false);

  const onMouseEnter = (starRating: number) => {
    if (!disabled && !hasRated) {
      setHoverRating(starRating);
    }
  };

  const onMouseLeave = () => {
    if (!disabled && !hasRated) {
      setHoverRating(0);
    }
  };

  const onSaveRating = (starRating: number) => {
    if (!disabled && !hasRated) {
      setRating(starRating);
      onChange(starRating);
      setHasRated(true);
    }
  };

  const starArray = Array.from({ length: 5 }, (_, index) => index + 1);

  return (
    <div className="star-rating">
      {starArray.map((star) => (
        <span
          key={star}
          className={`star ${star <= (hoverRating || rating) ? 'filled' : ''} ${hasRated && 'rated'}`}
          onMouseEnter={() => onMouseEnter(star)}
          onMouseLeave={onMouseLeave}
          onClick={() => onSaveRating(star)}
        >
          ★
        </span>
      ))}
    </div>
  );
};
