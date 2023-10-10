using System;

namespace SharpStudyPr
{
    public class Person
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
    }

    public class Student : Person
    {
        public string group { get; set; }
        public int point { get; set; }

        public Student(string name, int age, string group, int point) : base(name, age)
        {
            this.group = group;
            this.point = point;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Группа: {group}");
            Console.WriteLine($"Оценка: {point}");
        }


    }

    public class Teacher : Rab
    {
        public string subject { get; set; }

        public Teacher(string name, int age, string subject, string num, int st) : base(name, age, num, st)
        {
            this.subject = subject;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Предмет: {subject}");
        }
    }

    public class Rab : Person
    {
        public string num { get; set; }
        public int st { get; set; }

        public Rab(string name, int age, string num, int st) : base(name, age)
        {
            this.num = num;
            this.st = st;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Отдел: {num}");
            Console.WriteLine($"Стаж: {st}");
        }
    }
}

