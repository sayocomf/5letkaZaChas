using System.Collections.Generic;
using System;

namespace ToDoListApp
{
    enum TaskStatus
    {
        New,
        InProgress,
        Completed
    }

    class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }

        public TaskItem(int id, string title, DateTime dueDate)
        {
            Id = id;
            Title = title;
            DueDate = dueDate;
            Status = TaskStatus.New;
        }

        public void Display()
        {
            Console.WriteLine($"{Id}) Название: {Title}, Дата: {DueDate.ToShortDateString()}, Статус: {Status}");
        }
    }

    class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private int nextId = 1;
        private const int MaxTasks = 100;

        public void ShowAllTasks()
        {
            Console.WriteLine("\n== Список задач ==");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            foreach (var task in tasks)
            {
                task.Display();
            }
        }

        public void AddTask()
        {
            if (tasks.Count >= MaxTasks)
            {
                Console.WriteLine("Превышен лимит задач.");
                return;
            }

            Console.Write("Введите название задачи: ");
            string title = Console.ReadLine();

            Console.Write("Введите срок (гггг-мм-дд): ");
            DateTime dueDate;
            if (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Неверный формат даты.");
                return;
            }

            tasks.Add(new TaskItem(nextId++, title, dueDate));
            Console.WriteLine("Задача добавлена.");
        }

        public void EditTask()
        {
            Console.Write("Введите ID задачи для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ID.");
                return;
            }

            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine("Задача не найдена.");
                return;
            }

            Console.Write("Новое название (оставьте пустым, чтобы не менять): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                task.Title = newTitle;
            }

            Console.Write("Новая дата (гггг-мм-дд, оставьте пустым): ");
            string dateInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime newDate))
            {
                task.DueDate = newDate;
            }

            Console.WriteLine("Выберите статус:");
            Console.WriteLine("0 - New, 1 - InProgress, 2 - Completed");
            if (Enum.TryParse(Console.ReadLine(), out TaskStatus status))
            {
                task.Status = status;
            }

            Console.WriteLine("Задача обновлена.");
        }

        public void DeleteTask()
        {
            Console.Write("Введите ID задачи для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный ID.");
                return;
            }

            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine("Задача удалена.");
            }
            else
            {
                Console.WriteLine("Задача не найдена.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
TaskManager manager = new TaskManager();

            while (true)
            {
                Console.WriteLine("\n== ToDo List Меню ==");
                Console.WriteLine("1) Показать задачи");
                Console.WriteLine("2) Добавить задачу");
                Console.WriteLine("3) Редактировать задачу");
                Console.WriteLine("4) Удалить задачу");
                Console.WriteLine("0) Выход");
                Console.Write("Ваш выбор: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        manager.ShowAllTasks();
                        break;
                    case "2":
                        manager.AddTask();
                        break;
                    case "3":
                        manager.EditTask();
                        break;
                    case "4":
                        manager.DeleteTask();
                        break;
                    case "0":
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}