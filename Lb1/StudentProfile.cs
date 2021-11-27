using System;
using System.Linq;
using System.Text;

namespace Lb1
{
    class StudentProfile
    {
        //Перечисление 10 предметов
        public enum Subjects
        {
            СПЗ, 
            АК, 
            СКБД, 
            IntT, 
            ИССп, 
            КСх, 
            МПМК, 
            МодС, 
            ФВ,
            ООП
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Поля класса
        public string FullName { get; set; } //ФИО
        public string Number { get; set; } //Номер зачетной книжки
        public int Course { get; set; } //Курс
        public double AvgScore { get; set; } //Средний балл
        public int[] ArrayOfRatings { get; set; } //Массив оценок по предметам
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Конструктор
        public StudentProfile(string fullName, string number, int course, int[] arrayOfRatings)
        {
            if (string.IsNullOrEmpty(fullName)) //Проверка на пустоту строки
                throw new ArgumentException(); //Недопустимый аргумент
            else
                for (int i = 0; i < fullName.Length; i++) //Цикл для проверки каждого символа
                    if (char.IsNumber(fullName[i])) //Проверка на наличие цифры в строке
                        throw new ArgumentException();
                    else
                        FullName = fullName;
        //-------------------------------------------------------------------------------------------
            if (number.Contains(" ")) //Проверка на наличие пробелов
                throw new ArgumentException();//Недопустимый аргумент
            else
                for (int i = 0; i < number.Length; i++)//Цикл для проверки каждого символа
                    if (char.IsLetter(number[i])) //Проверка на наличие буквы в строке
                        throw new ArgumentException();
                    else
                        Number = number;
        //-------------------------------------------------------------------------------------------
            Course = course;
        //-------------------------------------------------------------------------------------------
            bool check = true;
            for (int i = 0; i < 10; i++) //Цикл для проверки каждой оценки
                if (arrayOfRatings[i] < 1 && arrayOfRatings[i] > 100) //Проверка диапазона оценок
                    check = false; //Если оценка вышла за диапазон
            if (check == true) //Если оценок лежит в пределах диапазона
                ArrayOfRatings = arrayOfRatings;
            else
                throw new IndexOutOfRangeException();
        //-------------------------------------------------------------------------------------------
            AvgScore = Queryable.Average(arrayOfRatings.AsQueryable()); //Расчёт среднего балла
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Переопределение метода ToString
        public override string ToString()
        {
            return $"\nФИО: {FullName}\n" + $"Номер зачётной книжки: {Number}\n" + $"Курс: {Course}\n" + $"Средний балл: {AvgScore}\n" + $"Оценки: {string.Join(", ", ArrayOfRatings)}\n";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Методы класса
        
        public static string Сomparison(int[] firstArray, int[] secondArray) //Cравнение оценок студентов 
        {
            StringBuilder sb = new(""); //Создает динамическую строку
            int[] DifferenceInRatings = new int[10]; //Массив разницы оценок
            for (int i = 0; i < 10; i++) //Заполнение массива разностью оценок
                DifferenceInRatings[i] = firstArray[i] < secondArray[i] ? secondArray[i] - firstArray[i] : firstArray[i] - secondArray[i];
            sb.Append("Разница оценок двух студентов: "); //Добавление подстроки в sb
            for (int i = 0; i < 10; i++) //Цикл для получения разницы каждого предмета
            {
                sb.Append($"{(Subjects)i}: {DifferenceInRatings[i]}; "); //Добавление в выходную строку информации
            }
            sb.Append('\n');
            return sb.ToString(); //Возвращение сформированной строки
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SettingAGrade(ref StudentProfile Student, Subjects subj, int score) //Установка оценки
        {
            Student.ArrayOfRatings[(int)subj] = score; //Установка оценки
            Student.AvgScore = Queryable.Average(Student.ArrayOfRatings.AsQueryable()); //Перерасчет среднего балла
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void GettingAGrade(ref StudentProfile Student, Subjects subj) => //Получение оценки по предмету
            Console.WriteLine($"Оценка студента {Student.FullName} по предмету {subj}: " + $"{Student.ArrayOfRatings[(int)subj]};");
    }
}
