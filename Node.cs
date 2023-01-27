using System.Text;

namespace TreeTask
{
    internal class Node : IComparable<Node>
    {
        public Employee Employee { get; private set; }

        public Node Left { get; private set; }

        public Node Right { get; private set; }

        public Node(Employee employee)
        {
            Employee = employee;
        }

        internal void Add(Employee employee)
        {
            Node current = this;
            Node node = new(employee);

            if (current.CompareTo(node) < 1)
            {
                if (current.Left == null)
                {
                    current.Left = node;
                }
                else
                {
                    current = current.Left;
                    current.Add(employee);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = node;
                }
                else
                {
                    current = current.Right;
                    current.Add(employee);
                }
            }
        }

        public int CompareTo(Node other)
        {
            return (other.Employee.Salary).CompareTo(this.Employee.Salary);
        }

        internal string GetEmployees(StringBuilder stringEmployees)
        {
            Node current = this;

            if (current.Left != null)
            {
                (current.Left).GetEmployees(stringEmployees);
            }

            if (current != null)
            {
                stringEmployees.Append($"{current.Employee.Name} - {current.Employee.Salary};" + Environment.NewLine);
            }

            if (current.Right != null)
            {
                (current.Right).GetEmployees(stringEmployees);
            }

            return stringEmployees.ToString();
        }

        internal void GetEmployee(int salary, ref string result)
        {
            Node current = this;

            if (current.Employee.Salary == salary)
            {
                result = current.Employee.Name;
                return;
            }

            if (salary < current.Employee.Salary)
            {
                if (current.Left == null)
                {
                    result = "Такой сотрудник не найден!";
                }
                else
                {
                    current = current.Left;
                    current.GetEmployee(salary, ref result);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    result = "Такой сотрудник не найден!";
                }
                else
                {
                    current = current.Right;
                    current.GetEmployee(salary, ref result);
                }
            }
        }
    }
}