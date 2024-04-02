using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    
        // SINGLE RESPONSIBILITY PRINCIPLE (Tek Sorumluluk Prensibi)
        // Her sınıf sadece bir görevi yerine getirmelidir.

        // Örnek: Bir öğrenci sınıfı, öğrenci bilgilerini içermelidir.
        public class Student
        {
            public string Name { get; set; }
            public int GradeLevel { get; set; }
        }

        // OPEN/CLOSED PRINCIPLE (Açık/Kapalı Prensip)
        // Bir sınıf, değişikliklere kapalı (closed) olmalı, ancak uzantılara açık (open) olmalıdır.

        // Örnek: Bir sınıf, hesaplama işlemlerinin bir araya getirilmesini içerir, ancak değişiklikler için genişletilebilir.
        public abstract class Calculator
        {
            public abstract int Calculate(int a, int b);
        }

        public class AdditionCalculator : Calculator
        {
            public override int Calculate(int a, int b)
            {
                return a + b;
            }
        }

        // LISKOV SUBSTITUTION PRINCIPLE (Liskov Yerine Koyma Prensibi)
        // Alt sınıflar, üst sınıflarının yerine geçebilmelidir.

        // Örnek: Kare bir dikdörtgenin alt sınıfıdır.
        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public int Area()
            {
                return Width * Height;
            }
        }

        public class Square : Rectangle
        {
            public override int Width
            {
                get { return base.Width; }
                set { base.Width = base.Height = value; }
            }

            public override int Height
            {
                get { return base.Height; }
                set { base.Width = base.Height = value; }
            }
        }

        // INTERFACE SEGREGATION PRINCIPLE (Arayüz Ayırma Prensibi)
        // Bir sınıf, kullanılmayan arayüz metotlarını uygulamamalıdır.

        // Örnek: Bir öğrenci sınıfı, sadece gerekli metotları içermelidir.
        public interface IStudent
        {
            void Study();
        }

        public interface ISportsPlayer
        {
            void PlaySports();
        }

        public class GoodStudent : IStudent
        {
            public void Study()
            {
                Console.WriteLine("Ödev yapıyor.");
            }
        }

        public class GoodSportsPlayer : IStudent, ISportsPlayer
        {
            public void Study()
            {
                Console.WriteLine("Ödev yapıyor.");
            }

            public void PlaySports()
            {
                Console.WriteLine("Spor yapıyor.");
            }
        }

        // DEPENDENCY INVERSION PRINCIPLE (Bağımlılıkları Tersine Çevirme Prensibi)
        // Yüksek seviyeli modüller, düşük seviyeli modüllere bağımlı olmamalıdır. 
        // Her ikisi de soyuta bağlı olmalıdır.

        // Örnek: Bir servis, bağımlılıkları soyut sınıflar veya arabirimler üzerinden almalıdır.
        public interface ILogger
        {
            void Log(string message);
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class StudentService
        {
            private readonly ILogger _logger;

            public StudentService(ILogger logger)
            {
                _logger = logger;
            }

            public void AddStudent(Student student)
            {
                // Öğrenci ekleme işlemi
                _logger.Log($"Öğrenci eklendi: {student.Name}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Örnek kullanım
                StudentService studentService = new StudentService(new ConsoleLogger());
                studentService.AddStudent(new Student { Name = "Ali", GradeLevel = 10 });

                Console.ReadLine();
            }
        }
    }

/*
Bu kod örneğinde, her SOLID prensibine uygun bir örnek bulunmaktadır:

Single Responsibility Principle (Tek Sorumluluk Prensibi): Student sınıfı sadece öğrenci bilgilerini içerir.
Open/Closed Principle (Açık/Kapalı Prensip): Calculator sınıfı, değişikliklere kapalı ancak genişletilebilir bir yapıdadır.
Liskov Substitution Principle (Liskov Yerine Koyma Prensibi): Square sınıfı, Rectangle sınıfının alt sınıfıdır ve Rectangle sınıfını yerine geçebilir.
Interface Segregation Principle (Arayüz Ayırma Prensibi): GoodStudent sınıfı sadece IStudent arayüzünü, GoodSportsPlayer sınıfı ise IStudent ve ISportsPlayer arayüzlerini kullanır.
Dependency Inversion Principle (Bağımlılıkları Tersine Çevirme Prensibi): StudentService sınıfı, bir ILogger arayüzüne bağımlıdır, böylece yüksek seviyeli bir modül olan StudentService, düşük seviyeli bir modül olan ConsoleLogger veya diğer bir ILogger uygulamasıyla çalışabilir. 
 */