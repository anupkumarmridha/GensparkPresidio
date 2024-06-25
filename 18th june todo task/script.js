$(document).ready(() => {
    // Fetch and display todos
    const fetchTodos = async () => {
      try {
        const response = await fetch('https://dummyjson.com/todos/user/1');
        const data = await response.json();
        const todos = data.todos;
        $('#todoList').empty();
        todos.forEach((todo, index) => {
          $('#todoList').append(`
            <tr>
              <th scope="row">${index + 1}</th>
              <td>${todo.todo}</td>
              <td>${todo.completed ? 'Completed' : 'In progress'}</td>
              <td>
                <button type="button" class="btn btn-danger deleteBtn" data-id="${todo.id}">Delete</button>
                <button type="button" class="btn btn-success ms-1 completeBtn" data-id="${todo.id}" data-completed="${todo.completed}">${todo.completed ? 'Undo' : 'Finished'}</button>
              </td>
            </tr>
          `);
        });
      } catch (error) {
        console.log('Error fetching todos:', error);
      }
    }

    // Add new todo
    $('#todoForm').on('submit', async (event) => {
      event.preventDefault();
      const todoText = $('#form1').val().trim();
      if (todoText) {
        try {
          await fetch('https://dummyjson.com/todos/add', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({ todo: todoText, completed: false, userId: 1 })
          });
          $('#form1').val('');
          fetchTodos();
        } catch (error) {
          console.log('Error adding todo:', error);
        }
      }
    });

    // Get all todos
    $('#getTasksBtn').on('click', () => {
      fetchTodos();
    });

    // Delete a todo
    $('#todoList').on('click', '.deleteBtn', async (event) => {
      const id = $(event.target).data('id');
      try {
        await fetch(`https://dummyjson.com/todos/${id}`, {
          method: 'DELETE'
        });
        console.log('Deleted:', id);
        fetchTodos();
      } catch (error) {
        console.log('Error deleting todo:', error);
      }
    });

    // Mark todo as complete or undo
    $('#todoList').on('click', '.completeBtn', async (event) => {
      const id = $(event.target).data('id');
      const completed = $(event.target).data('completed');
      try {
        await fetch(`https://dummyjson.com/todos/${id}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({ completed: !completed })
        });
        console.log('Completed:', !completed);
        fetchTodos();
      } catch (error) {
        console.log('Error updating todo:', error);
      }
    });
  });