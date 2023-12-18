using System;

namespace Prototip.DesignPatterns.Prototype.Conceptual
{
    public class Student
    {
        public string Name;
        public int Age;
        public string Specialnist;
        public Mark mark;

        public Student ShallowCopy()
        {
            return (Student)this.MemberwiseClone();
        }

        public Student DeepCopy()
        {
            Student clone = (Student)this.MemberwiseClone();
            clone.Name = String.Copy(Name);
            clone.mark = new Mark(mark.MarkValue);
            
            return clone;
        }
    }
    public class Mark
    {
        public int MarkValue;

        public Mark(int markValue)
        {
            this.MarkValue = markValue;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.Age = 46;
            s1.Specialnist = "121";
            s1.Name = "Vladimir Makarov";
            s1.mark=new Mark(0);

            Student s2 = s1.ShallowCopy();
            Student s3 = s1.DeepCopy();

            Console.WriteLine("Оригінальне значення учнів 1,2,3: \n");
            Console.WriteLine("S1: ");
            DisplayValues(s1);
            Console.WriteLine("S2: ");
            DisplayValues(s2);
            Console.WriteLine("S3: ");
            DisplayValues(s3);

            s1.Age = 37;
            s1.Specialnist = "122";
            s1.Name = "John Price";
            s1.mark.MarkValue = 100;

            Console.WriteLine("Нове значення учнів 1,2,3: \n");
            Console.WriteLine("S1: ");
            DisplayValues(s1);
            Console.WriteLine("S2 (змінилося орієнтоване значення): ");
            DisplayValues(s2);
            Console.WriteLine("S3 (Все зилишилось як є): ");
            DisplayValues(s3);
        }
        public static void DisplayValues(Student p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, Specialnist: {2:d}",
                p.Name, p.Age, p.Specialnist);
            Console.WriteLine("      Mark: {0:d}", p.mark.MarkValue);
        }
    }

}
