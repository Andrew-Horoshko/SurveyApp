import React, { useState, useEffect } from 'react';
import { PageHeader } from '../../components/PageHeader';
import axios from 'axios';
import './StrategyPage.scss'

interface TreatmentStrategy {
  treatmentStrategyId: number;
  diagnosis: string;
  treatment: string;
  recommendation: string;
  patientId: number;
  doctorId: number;
}

interface Doctor {
  doctorId: number;
  username: string;
  email: string;
}

export const StrategyPage: React.FC = () => {
  const [strategyData, setStrategyData] = useState<TreatmentStrategy | null>(null);
  const [doctor, setDoctor] = useState<Doctor | null>(null);

  useEffect(() => {
    async function fetchStrategyAndDoctor() {
      try {
        const strategyResponse = await axios.get('https://localhost:7113/api/TreatmentStrategy?treatmentStrategyId=6');
        setStrategyData(strategyResponse.data);

        if (strategyResponse.data) {
          const doctorResponse = await axios.get(`https://localhost:7113/api/TreatmentStrategy/Doctor?treatmentStrategyId=${strategyResponse.data.treatmentStrategyId}`);
          setDoctor(doctorResponse.data);
        }
      } catch (error) {
        console.error('Error fetching strategy or doctor:', error);
      }
    }

    fetchStrategyAndDoctor();
  }, []);

  return (
    <>
    <PageHeader headerText='Стратегія лікування'/>
      <div className="strategy-page">
        
        {strategyData && (
          <div>
            <h2>Діагноз: {strategyData.diagnosis}</h2>
            <p>Лікування: {strategyData.treatment}</p>
            <p>Рекомендації: {strategyData.recommendation}</p>
            {doctor && (
              <div className="doctor-info">
                <h3>Лікар, який прописав стратегію лікування:</h3>
                <p>Ім'я лікаря: {doctor.username}</p>
                <p>Email: {doctor.email}</p>
              </div>
            )}
          </div>
        )}
      </div>
    </>
  );
};
