using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ВАРИАНТ 3 - ПРОФИЛЬ СТУДЕНТА УНИВЕРСИТЕТА
//В проекте предусмотреть разделение части интерфейса и части логики типов данных,
//которые будут созданы при выполнении задания. Предусмотреть создание / генерацию исключений при вводе некоректных значений.

//ДАННЫЕ ТИПА
// * ФИО студента: не может быть пустым или содержать цифры
// * Номер зачетной книжки: только цифры без пробелов
// * курс: целое число
// * средний балл: дробное число, зависит от оценок по предметам
// * массив оценок по 10 предметам по 100-балльной шкале 

//МЕТОДЫ ТИПА
// * инициализирущий конструктор
// * установка оценки по указанному предмету
// * получение по указанному предмету (все 10 предметов должны быть уникальными)
// * переопределить метод ToString
// * метод сравнения двух студентов по оценкам - возвращаемый результат представлен в виде массива разницы баллов по предметам
namespace Lab1
{
    class StudentProfile
    {
        public string FullName { get; set; }
        public string Number { get; set; }
        public int Course { get; set; }
        public double AvgScore { get; set; }
        public int[] MyArr { get; set; }

        public StudentProfile(string fullName, string number, int course, double avgScore, int[] myArr)
        {
            FullName = fullName;
            Number = number;
            Course = course;
            AvgScore = avgScore;
            MyArr = myArr;
        }
        public override string ToString()
        {
            return $"ФИО: {FullName}\nНомер зачётной книжки: {Number}\nКурс: {Course}\nСредний балл: {AvgScore}\nОценки: {string.Join(", ", MyArr)}\n";
        }
        public static void Сomparison(int[] newArr, int[] newArr1, string[] sub)
        {
            int[] n = new int[10];
            for (int i = 0; i < 10; i++)
            {
                n[i] = newArr[i] < newArr[i] ? newArr1[i] - newArr[i] : newArr[i] - newArr1[i];
            }
            int k = 0;
            Console.Write("Разница оценок двух студентов: ");
            foreach (var item in n)
            {
                Console.Write(sub[k++] + ": " + item + "; ");        
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] subjects = { "СПЗ", "АК", "СКБД", "IntT", "ИССп", "КСх", "МПМК", "МодС", "ФВ", "ООП" };
            int[] newArr = new int[10];
            int[] newArr1 = new int[10];

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

            Console.WriteLine("\nВведите оценки 1 студента: ");
            for (int i = 0; i < newArr.Length; i++)
            {
                Console.Write($"{subjects[i]}: ");
                newArr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nВведите оценки 2 студента: ");
            for (int i = 0; i < newArr1.Length; i++)
            {
                Console.Write($"{subjects[i]}: ");
                newArr1[i] = int.Parse(Console.ReadLine());
            }

            StudentProfile FirstStudent = new StudentProfile(fullNameFStud, firstNum, firstStudentCourse, Queryable.Average(newArr.AsQueryable()), newArr);
            StudentProfile SecondStudent = new StudentProfile(fullNameSStud, secondNum, secondStudentCourse, Queryable.Average(newArr1.AsQueryable()), newArr1);

            Console.WriteLine(FirstStudent);
            Console.WriteLine(SecondStudent);

            StudentProfile.Сomparison(newArr, newArr1, subjects);

            Console.ReadKey();
        }
    }
}


