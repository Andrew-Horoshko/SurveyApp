import React, { useState, useEffect } from "react";
import { getUserManual } from "../../services/UserManual";

const UserManualPage = ({ match }) => {
  const [userManualData, setUserManualData] = useState(null);
  const surveyId = match.params.surveyId;

  useEffect(() => {
    const fetchUserManual = async () => {
      try {
        const data = await getUserManual();
        setUserManualData(data);
      } catch (error) {
        console.error('Error fetching user manual:', error);
      }
    };

    fetchUserManual();
  }, [surveyId]);

  return (
    <div>
      <h1>User Manual</h1>
      {userManualData && (
        <div>
          {/* Відображення даних про User Manual */}
          <p>Description: {userManualData.description}</p>
          <p>Instructions: {userManualData.instructions}</p>
          {/* Додайте інші дані, які ви хочете відобразити */}
        </div>
      )}
    </div>
  );
};

export default UserManualPage;
