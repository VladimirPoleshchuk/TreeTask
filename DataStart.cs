namespace TreeTask
{
    static class DataStart
    {
        public static void Start()
        {
            Clear();
            Print("Введите информацию о сотрудниках.");
            Tree tree = EnterEmployee();
            Print("Введите размер зарплаты, искомого сотрудника.");
            FindEmployee(ref tree);

            while (true)
            {
                Print("Нажмите - 0 если хотите начать всё сначала;");
                Print("          1 - если хотите продолжить поиск по зарплате;");
                Print("       или любую другую клавишу для завершения программы.");

                switch (Input())
                {
                    case "0":
                        {
                            Clear();
                            Print("Введите информацию о сотрудниках.");
                            tree = EnterEmployee();
                            Print("Введите размер зарплаты, искомого сотрудника.");
                            FindEmployee(ref tree);
                            break;
                        }
                    case "1":
                        {
                            Print("Введите размер зарплаты, искомого сотрудника:");
                            FindEmployee(ref tree);
                            break;
                        }
                    default:
                        {
                            Clear();
                            Print("Завершение программы.");
                            return;
                        }
                }
            }
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void FindEmployee(ref Tree tree)
        {
            tree.GetEmployee(EmployeeSalary());
        }

        private static Tree EnterEmployee()
        {
            Print("Введите имя сотрудника:");

            string name = Input();

            Tree tree = new();

            while (name != "")
            {
                if (name != null)
                {
                    Employee employee = new(name, EmployeeSalary());

                    tree.Add(employee);

                    Print("Введите имя следующего сотрудника или нажмите Enter для окончания ввода:");
                    name = Input();
                }
                else
                {
                    Print("Вы вели не корректное имя, попробуйте еще раз.");
                    Print("Введите имя сотрудника или введите пробел для окончания ввода:");

                    name = Input();
                }
            }

            tree.PrintEmployees();

            return tree;
        }

        private static int EmployeeSalary()
        {
            Print("Введите зарплату сотрудника:");

            int salary = 0;

            while (salary <= 0)
            {
                if (int.TryParse(Console.ReadLine(), out salary))
                {
                    if (salary <= 0)
                    {
                        Print("Зарплата должна быть положительным целым числом!");
                        Print("Введите зарплату сотрудника:");
                        continue;
                    }

                    return salary;
                }
                else
                {
                    Print("Вы ввели не корректные данные, попробуйте еще раз.");
                    Print("Введите зарплату сотрудника:");
                }
            }

            return 0;
        }

        public static void Print(string line)
        {
            Console.WriteLine(line);
        }

        private static string Input()
        {
            return Console.ReadLine();
        }
    }
}
