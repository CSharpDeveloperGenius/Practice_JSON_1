using Practice_JSON.Models;

namespace Practice_JSON.Workers
{
    public static class ModelWorker
    {
        private const string LIST_EMPTY = "Список пуст";

        public static void PrintStudents(Data? data)
        {
            if (data is null || data.Students.Count == 0)
            {
                Console.WriteLine(LIST_EMPTY);
                return;
            }

            Console.WriteLine("Список студентов:");
            foreach (var student in data.Students)
                Console.WriteLine(student);
        }

        public static void PrintSubjects(Data? data)
        {
            if (data is null || data.Subjects.Count == 0)
            {
                Console.WriteLine(LIST_EMPTY);
                return;
            }

            Console.WriteLine("Список предметов:");
            foreach (var subject in data.Subjects)
                Console.WriteLine(subject);
        }

        public static void PrintStudentMarks(Data? data)
        {
            if (data is null || data.Subjects.Count == 0)
            {
                Console.WriteLine(LIST_EMPTY);
                return;
            }

            Console.Write("Введите код студента: ");
            var studentCode = Console.ReadLine();

            var student = data
                .Students
                .FirstOrDefault(student => student.Code == studentCode);

            if (student is null)
            {
                Console.WriteLine("Студент не найден");
                return;
            }

            var studentSubjects = data
                .EducationPlans
                .Where(plan => plan.StudentCode == studentCode)
                .ToList();

            var marks_count = studentSubjects.Count;
            var mark_5_count = 0;
            var mark_4_count = 0;
            var mark_3_count = 0;

            if (marks_count == 0)
            {
                Console.WriteLine($"У студента {student} нет оценок");
                return;
            }

            Console.WriteLine($"Оценки студента {student}");

            foreach (var studentSubject in studentSubjects)
            {
                var subject = data
                    .Subjects
                    .FirstOrDefault(subject => subject.Code == studentSubject.SubjectCode);

                var mark = studentSubject.Mark;

                if (subject is null)
                    Console.WriteLine($"Неверный код предмета ({studentSubject.SubjectCode}): {mark}");
                else
                    Console.WriteLine($"{subject.ToShortString()}: {mark}");

                if (mark == 5) mark_5_count++;
                else if (mark == 4) mark_4_count++;
                else if (mark == 3) mark_3_count++;
            }

            Console.WriteLine($"% оценок \"отлично\": {Math.Round((float)mark_5_count / marks_count, 2) * 100}%");
            Console.WriteLine($"% оценок \"хорошо\": {Math.Round((float)mark_4_count / marks_count, 2) * 100}%");
            Console.WriteLine($"% оценок \"удовлитворительно\": {Math.Round((float)mark_3_count / marks_count, 2) * 100}%");
        }

        public static void AddMarkToStudent(Data? data, JSONWorker jsonWorker)
        {
            if (data is null)
            {
                Console.WriteLine("Невозможно добавить оценку студенту");
                return;
            }

            Console.Write("Введите код студента: ");
            var studentCode = Console.ReadLine();

            var student = data
                .Students
                .FirstOrDefault(student => student.Code == studentCode);

            if (student is null)
            {
                Console.WriteLine("Студент не найден");
                return;
            }

            Console.Write("Введите код предмета: ");
            var subjectCode = Console.ReadLine();

            var subject = data
                .Subjects
                .FirstOrDefault(subject => subject.Code == subjectCode);

            if (subject is null)
            {
                Console.WriteLine("Предмет не найден");
                return;
            }

            Console.Write("Введите оценку (2..5): ");
            if (!int.TryParse(Console.ReadLine(), out int mark))
            {
                Console.WriteLine("Оценка должна быть целым числом");
                return;
            }

            if (mark > 5 || mark < 2)
            {
                Console.WriteLine("Оценка должна быть в диапазоне от 2 до 5");
                return;
            }

            data.EducationPlans.Add(new EducationPlan
            {
                StudentCode = studentCode,
                SubjectCode = subjectCode,
                Mark = mark
            });

            jsonWorker.SaveDataToJson(data);
            Console.WriteLine("Оценка успешно добавлена");
        }
    }
}
