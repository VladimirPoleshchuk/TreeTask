using System.Text;

namespace TreeTask
{
    internal class Tree
    {
        public Node Root { get; private set; }

        public static int Count { get => Employee.Count; }

        public Tree() { }

        public Tree(Employee employee)
        {
            Root = new Node(employee);
        }

        public void Add(Employee employee)
        {
            if (Root == null)
            {
                Root = new Node(employee);
                return;
            }

            Root.Add(employee);
        }

        public void PrintEmployees()
        {
            if (Root == null)
            {
                DataStart.Print("Нет данных.");
                return;
            }

            StringBuilder stringEmployees = new StringBuilder();

            DataStart.Print(Root.GetEmployees(stringEmployees));
        }

        public void GetEmployee(int salary)
        {
            if (Root == null)
            {
                DataStart.Print("Нет данных.");
                return;
            }

            string result = "";
            Root.GetEmployee(salary, ref result);

            DataStart.Print(result);
        }
    }
}