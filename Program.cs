using System;

namespace SharpStudyPr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество студентов");

            int countStudents = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество учителей:");

            int countTeachers = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество работников:");

            int countRab = int.Parse(Console.ReadLine());




            Person[] people = new Person[countStudents + countTeachers + countRab];


            for (int i = 0; i < countStudents; i++)
            {
                Console.WriteLine("Введите имя студента");
                string nameS = Console.ReadLine();
                Console.WriteLine("Введите возраст студента");
                int ageS = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите номер группы студента");
                string grS = "Группа: " + int.Parse(Console.ReadLine());
                Console.WriteLine("Введите оценка студента");
                int pointS = int.Parse(Console.ReadLine());
                Student student = new Student(nameS, ageS, grS, pointS);
                people[i] = student;
                student.ShowInfo();
            }
            for (int i = countStudents; i < countTeachers + countStudents; i++)
            {
                Console.WriteLine("Введите имя преподователя");
                string nameT = Console.ReadLine();
                Console.WriteLine("Введите возраст преподователя");
                int ageT = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите номер группы преподователя");
                string grT = "Группа: " + int.Parse(Console.ReadLine());
                Console.WriteLine("Введите стаж работника");
                int stT = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите предмет преподователя");
                string suT = "предмет: " + Console.ReadLine();
                Teacher teacher = new Teacher(nameT, ageT, suT, grT, stT);
                people[i] = teacher;
                teacher.ShowInfo();
            }

            for (int i = countTeachers + countStudents; i < countRab + countTeachers + countStudents; i++)
            {
                Console.WriteLine("Введите имя работника");
                string nameR = Console.ReadLine();
                Console.WriteLine("Введите возраст работника");
                int ageR = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите вакансию");
                string vakR = Console.ReadLine();
                Console.WriteLine("Введите стаж работника");
                int stR = int.Parse(Console.ReadLine());

                Rab rab = new Rab(nameR, ageR, vakR, stR);
                people[i] = rab;
                rab.ShowInfo();
            }

            Student student1 = new Student("Студент", 17, "ыы", 3);

            foreach (Person person in people)
            {
                student1 = person as Student;
                if (student1 != null)
                    if (student1.point == 5)
                        person.ShowInfo();
            }

            Rab rab1 = new Rab("Работник", 2, "ewfw", 2);

            foreach (Person person in people)
            {
                rab1 = person as Rab;
                if (rab1 != null)
                    if (rab1.st > 10)
                        person.ShowInfo();
            }

            Console.ReadLine();


        }
    }
}
