using System;

namespace SharpStudyPr
{
    public class Person : IComparable // Использование интерфейса
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Возраст: {age}");
        }

        public int CompareTo(object o) // Реализация интерфейса для сортировки по имени
        {
            Person p = o as Person;
            if (p != null)
            {
                return this.name.CompareTo(p.name);
            }
            else
            {
                throw new Exception("Такого объекта не существует!");
            }
        }

        public class Student : Person, IComparable // Использование интерфейса
        {
            public string group { get; set; }
            public int mark { get; set; }

            public Student(string name, int age, string group, int mark) : base(name, age)
            {
                this.group = group;
                this.mark = mark;
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"Группа: {group}");
                Console.WriteLine($"Оценка: {mark}");
            }
            public new int CompareTo(object o) // Реализация интерфейса для сортировки по имени
            {
                Student s = o as Student;
                if (s != null)
                {
                    return this.name.CompareTo(s.name);
                }
                else if (o is Teacher)
                {
                    return -1; // Студенты должны стоять перед преподавателями
                }
                else if (o is Laborer)
                {
                    return -1; // Студенты должны стоять перед работниками
                }
                else
                {
                    throw new Exception("Такого объекта не существует!");
                }
            }
        } // Студенты

        public class Teacher : Laborer, IComparable // Использование интерфейса
        {
            public string subject { get; set; }

            public Teacher(string name, int age, string subject, string num, int experience) : base(name, age, num, experience)
            {
                this.subject = subject;
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"Предмет: {subject}");
            }
            public new int CompareTo(object o) // Реализация интерфейса для сортировки по имени
            {
                Teacher t = o as Teacher;
                if (t != null)
                {
                    return this.name.CompareTo(t.name);
                }
                else if (o is Student)
                {
                    return 1; // Преподаватели должны быть после студентов
                }
                else if (o is Laborer)
                {
                    return -1; // Преподаватели должны стоять перед работниками
                }
                else
                {
                    throw new Exception("Такого объекта не существует!");
                }
            }
        } // Преподователи

        public class Laborer : Person, IComparable // Использование интерфейса
        {
            public string num { get; set; }
            public int experience { get; set; }

            public Laborer(string name, int age, string num, int experience) : base(name, age)
            {
                this.num = num;
                this.experience = experience;
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"Отдел: {num}");
                Console.WriteLine($"Стаж: {experience}");
            }
            public new int CompareTo(object o) // Реализация интерфейса для сортировки по имени
            {
                Laborer l = o as Laborer;
                if (l != null)
                {
                    return this.name.CompareTo(l.name);
                }
                else if (o is Student)
                {
                    return 1; // Работники должны быть после студентов
                }
                else if (o is Teacher)
                {
                    return 1; // Работники должны быть после студентов
                }
                else
                {
                    throw new Exception("Такого объекта не существует!");
                }
            }

        } // Работники

        public abstract class InputPeople // Абстракция(Собственная)
        {
            public abstract void ShowInputPeople(Person[] people, int countStudents, int countTeachers, int countLab); // Абстрактный метод
        }


        // Реализации абстрактного метода(Собственная)
        public class StudentShow : InputPeople
        {
            public override void ShowInputPeople(Person[] people, int countStudents, int countTeacher, int countLab) // Ввод\Вывод
            {
                for (int i = 0; i < countStudents; i++)
                {
                    Console.WriteLine("Введите имя студента");
                    string nameS = Console.ReadLine();

                    Console.WriteLine("Введите возраст студента");
                    int ageS = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите номер группы студента");
                    string grS = Console.ReadLine();

                    Console.WriteLine("Введите оценка студента");
                    int pointS = int.Parse(Console.ReadLine());

                    Student student = new Student(nameS, ageS, grS, pointS);
                    people[i] = student;
                    student.ShowInfo();
                }
            }
        }
        // Реализации абстрактного метода(Собственная)
        public class TeacherShow : InputPeople
        {
            public override void ShowInputPeople(Person[] people, int countStudents, int countTeachers, int countLab)
            {
                for (int i = countStudents; i < countTeachers + countStudents; i++) // Ввод\Вывод
                {
                    Console.WriteLine("Введите имя преподователя");
                    string nameT = Console.ReadLine();

                    Console.WriteLine("Введите возраст преподователя");
                    int ageT = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите номер группы преподователя");
                    string grT = Console.ReadLine();

                    Console.WriteLine("Введите стаж работника");
                    int stT = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите предмет преподователя");
                    string suT = Console.ReadLine();

                    Teacher teacher = new Teacher(nameT, ageT, suT, grT, stT);
                    people[i] = teacher;
                    teacher.ShowInfo();
                }
            }
        }
        // Реализации абстрактного метода(Собственная)
        public class LaborerShow : InputPeople
        {
            public override void ShowInputPeople(Person[] people, int countStudents, int countTeachers, int countLab) // Ввод\Вывод
            {
                for (int i = countTeachers + countStudents; i < countLab + countTeachers + countStudents; i++)
                {
                    Console.WriteLine("Введите имя работника");
                    string nameR = Console.ReadLine();

                    Console.WriteLine("Введите возраст работника");
                    int ageR = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите вакансию");
                    string vakR = Console.ReadLine();

                    Console.WriteLine("Введите стаж работника");
                    int stR = int.Parse(Console.ReadLine());

                    Laborer laborer = new Laborer(nameR, ageR, vakR, stR);
                    people[i] = laborer;
                    laborer.ShowInfo();
                }
            }
        }



    }
}

