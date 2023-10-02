//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
////[1,1,1,2,2,3]

using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Текущая директория: " + currentDirectory);

            while (true)
            {
                //Abracadabra
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Просмотр содержимого директории");
                Console.WriteLine("2. Создание новой директории");
                Console.WriteLine("3. Удаление директории или файла");
                Console.WriteLine("4. Переименование директории или файла");
                Console.WriteLine("5. Копирование файла или директории");
                Console.WriteLine("6. Перемещение файла или директории");
                Console.WriteLine("7. Просмотр свойств файла или директории");
                Console.WriteLine("8. Поиск файлов по имени или расширению");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ListDirectoryContents(currentDirectory);
                        break;
                    case 2:
                        Console.Write("Введите имя новой директории: ");
                        string newDirectoryName = Console.ReadLine();
                        CreateDirectory(currentDirectory, newDirectoryName);
                        break;
                    case 3:
                        Console.Write("Введите имя директории или файла для удаления: ");
                        string nameToDelete = Console.ReadLine();
                        DeleteFileOrDirectory(currentDirectory, nameToDelete);
                        break;
                    case 4:
                        Console.Write("Введите текущее имя директории или файла: ");
                        string currentName = Console.ReadLine();
                        Console.Write("Введите новое имя: ");
                        string newName = Console.ReadLine();
                        RenameFileOrDirectory(currentDirectory, currentName, newName);
                        break;
                    case 5:
                        Console.Write("Введите имя файла или директории для копирования: ");
                        string nameToCopy = Console.ReadLine();
                        Console.Write("Введите путь к новому месту назначения: ");
                        string destinationPath = Console.ReadLine();
                        CopyFileOrDirectory(currentDirectory, nameToCopy, destinationPath);
                        break;
                    case 6:
                        Console.Write("Введите имя файла или директории для перемещения: ");
                        string nameToMove = Console.ReadLine();
                        Console.Write("Введите путь к новому месту назначения: ");
                        string newLocation = Console.ReadLine();
                        MoveFileOrDirectory(currentDirectory, nameToMove, newLocation);
                        break;
                    case 7:
                        Console.Write("Введите имя файла или директории для просмотра свойств: ");
                        string nameToView = Console.ReadLine();
                        ViewProperties(currentDirectory, nameToView);
                        break;
                    case 8:
                        Console.Write("Введите имя файла или расширение для поиска: ");
                        string searchQuery = Console.ReadLine();
                        SearchFiles(currentDirectory, searchQuery);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }

        static void ListDirectoryContents(string directoryPath)
        {
            string[] directories = Directory.GetDirectories

(directoryPath);
            string[] files = Directory.GetFiles(directoryPath);

            Console.WriteLine("Содержимое директории " + directoryPath + ":");
            Console.WriteLine("Директории:");
            foreach (string dir in directories)
            {
                Console.WriteLine(Path.GetFileName(dir));
            }
            Console.WriteLine("Файлы:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        static void CreateDirectory(string currentDirectory, string newDirectoryName)
        {
            string newDirectoryPath = Path.Combine(currentDirectory, newDirectoryName);
            Directory.CreateDirectory(newDirectoryPath);
            Console.WriteLine("Директория " + newDirectoryName + " создана.");
        }

        static void DeleteFileOrDirectory(string currentDirectory, string nameToDelete)
        {
            string pathToDelete = Path.Combine(currentDirectory, nameToDelete);
            bool isDirectory = Directory.Exists(pathToDelete);
            if (isDirectory)
            {
                Directory.Delete(pathToDelete, true);
                Console.WriteLine("Директория " + nameToDelete + " удалена.");
            }
            else
            {
                File.Delete(pathToDelete);
                Console.WriteLine("Файл " + nameToDelete + " удален.");
            }
        }

        static void RenameFileOrDirectory(string currentDirectory, string currentName, string newName)
        {
            string currentPath = Path.Combine(currentDirectory, currentName);
            string newPath = Path.Combine(currentDirectory, newName);
            bool isDirectory = Directory.Exists(currentPath);
            if (isDirectory)
            {
                Directory.Move(currentPath, newPath);
                Console.WriteLine("Директория " + currentName + " переименована в " + newName + ".");
            }
            else
            {
                File.Move(currentPath, newPath);
                Console.WriteLine("Файл " + currentName + " переименован в " + newName + ".");
            }
        }

        static void CopyFileOrDirectory(string currentDirectory, string nameToCopy, string destinationPath)
        {
            string sourcePath = Path.Combine(currentDirectory, nameToCopy);
            string destinationFilePath = Path.Combine(destinationPath, nameToCopy);
            bool isDirectory = Directory.Exists(sourcePath);
            if (isDirectory)
            {
                CopyDirectory(sourcePath, destinationFilePath);
                Console.WriteLine("Директория " + nameToCopy + " скопирована в " + destinationPath + ".");
            }
            else
            {
                File.Copy(sourcePath, destinationFilePath);
                Console.WriteLine("Файл " + nameToCopy + " скопирован в " + destinationPath + ".");
            }
        }

        static void MoveFileOrDirectory(string currentDirectory, string nameToMove, string newLocation)
        {
            string sourcePath = Path.Combine(currentDirectory, nameToMove);
            string destinationPath = Path.Combine(newLocation, nameToMove);
            bool isDirectory = Directory.Exists(sourcePath);
            if (isDirectory)
            {
                Directory.Move(sourcePath, destinationPath);
                Console.WriteLine("Директория " + nameToMove + " перемещена в " + newLocation + ".");
            }
            else
            {
                File.Move(sourcePath, destinationPath);
                Console.WriteLine("Файл " + nameToMove + " перемещен в " + newLocation + ".");
            }
        }

        static void ViewProperties(string currentDirectory, string nameToView)
        {
            string pathToView = Path.Combine(currentDirectory, nameToView);
            bool isDirectory = Directory.Exists(pathToView);
            if (isDirectory)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(pathToView);
                Console.WriteLine("Свойства директории " + nameToView + ":");
                Console.WriteLine("Полный путь: " + directoryInfo.FullName);
                Console.WriteLine("Дата создания: " + directoryInfo.CreationTime);
                Console.WriteLine("Дата последнего изменения: " + directoryInfo.LastWriteTime);
            }
            else
            {
                FileInfo fileInfo = new FileInfo(pathToView);
                Console.WriteLine("Свойства файла " + nameToView + ":");
                Console.WriteLine("Полный путь: " + fileInfo.FullName);
                Console.WriteLine("Размер: " + fileInfo.Length + " байт");
                Console.WriteLine("Дата создания: " + fileInfo.CreationTime);
                Console.WriteLine("Дата последнего изменения: " + fileInfo.LastWriteTime);
            }
        }

        static void SearchFiles(string currentDirectory, string searchQuery)
        {
            Console.WriteLine("Результаты поиска для \"" + searchQuery + "\":");
            string[] foundFiles = Directory.GetFiles(currentDirectory, searchQuery, SearchOption.AllDirectories);
            foreach (string file in foundFiles)
            {
                Console.WriteLine(file);
            }
        }

        static void CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
        {
            Directory.CreateDirectory(destinationDirectoryPath);
            foreach (string file in Directory.GetFiles(sourceDirectoryPath))
            {
                string destinationFilePath = Path.Combine(destinationDirectoryPath, Path.GetFileName(file));
                File.Copy(file, destinationFilePath);
            }
            foreach (string subdirectory in Directory.GetDirectories(sourceDirectoryPath))
            {
                string destinationSubdirectoryPath = Path.Combine(destinationDirectoryPath, Path.GetFileName(subdirectory));
                CopyDirectory(subdirectory, destinationSubdirectoryPath);
            }
        }
    }
}