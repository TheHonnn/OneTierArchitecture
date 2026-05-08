using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos = new();
        private string _filepath = "rodos.txt";
        private int _nextId = 1;

        public TodoRepository()
        {
            LoadFormFile();
        }

        private void LoadFormFile()
        {
            if (!File.Exists(_filepath)) return;
            foreach (var line in File.ReadAllLines(_filepath))
            {
                var todo = Todo.FromFileString(line);
                _todos.Add(todo);
                if (todo.Id >= _nextId)
                {
                    _nextId = todo.Id++;
                }
            }
        }
        private void SaveChanges()
        {
            File.WriteAllLines(
                _filepath,
                _todos.Select(x =>x.ToFileString())
                );
        }
        public Todo CreateTodo(string title)
        {
            var todo = new Todo()
            {
                Title = title,
                Id = _nextId++,
                IsSuccess = false,
            };
            _todos.Add(todo);
            SaveChanges();
            return todo;

        }
        public bool UpdateTodo(int id, string title) {
            var item = _todos.FirstOrDefault(X => X.Id == id);
                if (item != null) {
                    item.Title = title;
                    SaveChanges();
                    return true;
                }
                return false;
        }
        public bool DeleteTodo (int id)
        {
            var item = _todos.FirstOrDefault(X => X.Id == id);
            if (item != null)
            {
                _todos.Remove(item);
                SaveChanges();
                return true;
            }
            return false;
        }
        public List<Todo> GetTodos() => _todos;
        public bool ToggleTodo(int id) {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsSuccess = !item.IsSuccess;
                SaveChanges();
                return true;
            }
            return false;
        }
    }
    
}
