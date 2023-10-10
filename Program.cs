using System;
using static SharpStudyPr.Person;

namespace SharpStudyPr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества людей
            Console.WriteLine("Введите количество студентов");
            int countStudents = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество учителей:");
            int countTeachers = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество работников:");
            int countLab = int.Parse(Console.ReadLine());


            Person[] people = new Person[countStudents + countTeachers + countLab]; // Создание объекта класса

            StudentShow ShowStudents = new StudentShow();
            ShowStudents.ShowInputPeople(people, countStudents, countTeachers, countLab); // Ввод\Вывод студентов

            TeacherShow ShowTeacher = new TeacherShow();
            ShowTeacher.ShowInputPeople(people, countStudents, countTeachers, countLab); // Ввод\Вывод учителей

            LaborerShow ShowLaborer = new LaborerShow();
            ShowLaborer.ShowInputPeople(people, countStudents, countTeachers, countLab); // Ввод\Вывод работников

            // Поиск человека с оценкой 5
            Student student1 = new Student("Иван", 19, "ИС-22-11", 5);
            foreach (Person person in people)
            {
                student1 = person as Student;
                if (student1 != null)
                    if (student1.mark == 5)
                        person.ShowInfo();
            }
            // Поиск человека со стажем больше 10 лет
            Laborer laborer1 = new Laborer("Владимир", 43, "ewfw", 15);
            foreach (Person person in people)
            {
                laborer1 = person as Laborer;
                if (laborer1 != null)
                    if (laborer1.experience > 10)
                        person.ShowInfo();
            }

            // Созданный массив с экземплярами
            //Person[] people1 = new Person[4]
            //{
            //    new Student("я", 17, "уИС-22-11", 5),
            //    new Student("г", 16, "аИС-22-11", 4),
            //    new Student("а", 12, "вИС-22-11", 1),
            //    new Student("ы", 16, "цИС-22-11", 2),
            //};

            // Вывод информации о людях в алфавитном порядке
            Console.WriteLine("До сортировки:");
            foreach (var person in people)
            {
                person.ShowInfo();
                Console.WriteLine();
            }

            Console.WriteLine("После сортировки:");
            Array.Sort(people);
            foreach (var person in people)
            {
                person.ShowInfo();
                Console.WriteLine();
            }

            // Поиск человека по индексу
            Console.WriteLine("Введите номер человека:");
            Person personToFind = people[int.Parse(Console.ReadLine())];
            int index = Array.IndexOf(people, personToFind) - 1;

            people[index].ShowInfo();
            Console.ReadKey();
        }
    }

}


