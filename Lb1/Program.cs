using System;

namespace Lb1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ФИО ПЕРВОГО студента: ");
            string fullNameFStud = Console.ReadLine();
            Console.Write("Введите ФИО ВТОРОГО студента: ");
            string fullNameSStud = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите номер зачетной книжки ПЕРВОГО студента: ");
            string firstNum = Console.ReadLine();
            Console.Write("Введите номер зачетной книжки ВТОРОГО студента: ");
            string secondNum = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите курс ПЕРВОГО студента: ");
            int firstStudentCourse = int.Parse(Console.ReadLine());
            Console.Write("Введите курс ВТОРОГО студента: ");
            int secondStudentCourse = int.Parse(Console.ReadLine());

            Console.WriteLine("\nВведите оценки ПЕРВОГО студента: ");
            var student1 = new int[10];
            for (int i = 0; i < 10; i++) 
            {
                student1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\nВведите оценки ВТОРОГО студента: ");
            var student2 = new int[10];
            for (int i = 0; i < 10; i++)
            {
                student2[i] = int.Parse(Console.ReadLine());
            }
            //Создание обьектов типа StudentProfile
            StudentProfile FirstStudent = new(fullNameFStud, firstNum, firstStudentCourse, student1);
            StudentProfile SecondStudent = new(fullNameSStud, secondNum, secondStudentCourse, student2);
            //Вывод информации про студентов
            Console.WriteLine(FirstStudent.ToString());
            Console.WriteLine(SecondStudent.ToString());
            //Установка оценки по предмету 
            StudentProfile.SettingAGrade(ref FirstStudent, StudentProfile.Subjects.АК, 85);
            StudentProfile.SettingAGrade(ref SecondStudent, StudentProfile.Subjects.АК, 79);
            //Вывод информации с измененной оценкой
            Console.WriteLine(FirstStudent.ToString());
            Console.WriteLine(SecondStudent.ToString());
            //Сравнение студентов
            Console.WriteLine(StudentProfile.Сomparison(FirstStudent.ArrayOfRatings, SecondStudent.ArrayOfRatings));
            //Получение оценки по предмету
            StudentProfile.GettingAGrade(ref FirstStudent, StudentProfile.Subjects.АК);
        }
    }
}
