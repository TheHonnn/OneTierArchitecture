using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoUI
    {
        private readonly TodoService _service = new();
        public void ShowTools() { 
            var todos = _service.GetAll();
            Console.WriteLine("DANH SACH CONG VIEC");
            foreach (var todo in todos){
                Console.WriteLine(todo.ToString());


            }
            if (todos.Count <= 0)
            {
                Console.WriteLine("Chua co cong viec");
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("\n Chuc Nang");
            Console.WriteLine(" 1. Them chuc nang");
            Console.WriteLine(" 2. Danh dau da hoan thanh");
            Console.WriteLine(" 3. Sua cong viec");
            Console.WriteLine(" 4. Xoa cong viec");
            Console.WriteLine(" 0. Thoat");
        }
        private void AddTodo() {
            Console.WriteLine("Nhap dung cong viec: ");
            var input = Console.ReadLine();
            _service.AddTodo(input);
        }
        private void RemoveTodo()
        {
            Console.Write("Nhập Id công việc muốn xóa: ");
            int id = int.Parse(Console.ReadLine());
            _service.DeleteTodo(id);
        }
        private void DeleteTodo()
        {
            Console.Write("Nhập Id công việc muốn xóa: ");
            int id = int.Parse(Console.ReadLine());
            _service.DeleteTodo(id);
        }
        private void ToggleTodo()
        {
            Console.Write("Nhập Id công việc muốn : ");
            int id = int.Parse(Console.ReadLine());
            _service.ToggleTodo(id);
        }
        private void UpdateTodo()
            
        {
            
            Console.Write("Nhập Id công việc muốn danh dau: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhap noi dung moi: ");
            string content = Console.ReadLine();
            _service.UpdateTodo(id, content);
            
        }
        public void Run() {
            while (true)
            {
                Console.Clear();
                ShowTools();
                ShowMenu();
                Console.Write("chon: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        ToggleTodo();
                        break;
                    case "3":
                        UpdateTodo();
                        break;
                    case "4":
                        DeleteTodo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;

                }
                Console.Write("Nhan enter de tiep tuc");
                Console.Write(" Nhan 0 de thoat.");
            }
        }
    } 
}
