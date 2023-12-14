import React, { useState, useEffect } from 'react';
import { getUsers } from '../../services/UserService';

interface User {
  id: number;
  name: string;
  email: string;
}

export const DoctorPage: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);

  useEffect(() => {
    async function fetchUsers() {
      try {
        const fetchedUsers = await getUsers(); 
        setUsers(fetchedUsers);
      } catch (error) {
        console.error('Error fetching users:', error);
      }
    }

    fetchUsers();
  }, []);

  return (
    <div>
      <h1>Список користувачів</h1>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Ім'я</th>
            <th>Email</th>
            {/* Додайте інші заголовки стовпців тут */}
          </tr>
        </thead>
        <tbody>
          {users.map((user) => (
            <tr key={user.id}>
              <td>{user.id}</td>
              <td>{user.name}</td>
              <td>{user.email}</td>
              {/* Додайте інші дані користувача тут */}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
