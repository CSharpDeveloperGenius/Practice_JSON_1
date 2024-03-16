using Practice_JSON.Workers;

const string WRONG_ACTION = "Неверное действие. Попробуйте еще раз";

var worker = new JSONWorker("data/data.json");

while (true)
{
    Console.WriteLine("\n\nВыберите действие:" +
        "\n1. Посмотреть список студентов" +
        "\n2. Посмотреть список предметов" +
        "\n3. Посмотреть оценки студента" +
        "\n4. Добавить оценку студенту" +
        "\n0. Выход\n");

    if (!int.TryParse(Console.ReadLine(), out int action))
    {
        Console.WriteLine(WRONG_ACTION);
        continue;
    }

    var data = worker.ReadDataFromJson();

    switch (action)
    {
        case 1:
            ModelWorker.PrintStudents(data);
            break;
        case 2:
            ModelWorker.PrintSubjects(data);
            break;
        case 3:
            ModelWorker.PrintStudentMarks(data);
            break;
        case 4:
            ModelWorker.AddMarkToStudent(data, worker);
            break;
        case 0:
            return 0;
        default:
            Console.WriteLine(WRONG_ACTION);
            break;
    }
}





