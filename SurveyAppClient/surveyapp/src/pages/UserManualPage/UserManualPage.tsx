import React from 'react';
import './UserManualPage.scss';
import { PageHeader } from '../../components/PageHeader';

export const UserManualPage = () => {
  return (
    <>
        <PageHeader headerText='Довідка'/>
        <div className="instructions-page">
        <h1>Інструкція користування сайтом</h1>
        <section className="instructions-section">
            <h2>Як розпочати опитування?</h2>
            <p>
            Для розпочатку опитування, перейдіть на сторінку списку доступних опитувань і оберіть необхідне опитування.
            Натисніть кнопку "Почати опитування", щоб розпочати заповнення.
            </p>
        </section>

        <section className="instructions-section">
            <h2>Як отримати довідку?</h2>
            <p>
            Щоб отримати довідку, перейдіть на сторінку зі списком місць, оберіть необхідне місце та натисніть кнопку "Отримати довідку".
            Довідка буде доступна для перегляду чи завантаження.
            </p>
        </section>

        <section className="instructions-section">
            <h2>Як переглянути результати опитування?</h2>
            <p>
            Після завершення опитування, результати будуть доступні в особистому кабінеті користувача.
            Перейдіть на сторінку результатів, де можна переглянути та аналізувати дані опитування.
            </p>
        </section>

        </div>
    </>
  );
};

