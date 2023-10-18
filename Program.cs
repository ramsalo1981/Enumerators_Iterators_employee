namespace CAEnumeratorEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee e1 = new Employee{ Id = 1, Name = "rami", Salary = 1200m, Department = "AB" };
            //Employee e2 = new Employee{ Id = 1, Name = "rami", Salary = 1200m, Department = "AB" };
            Employee e1 = new Employee(1, "rami", 1200m, "AB");
            Employee e2 = new Employee(1, "rami", 1200m, "AB");
            Employee e3 = e1;
            Console.WriteLine(e1);
            Console.WriteLine(e1 == e3);//true
           
            

            //Console.WriteLine(e1 == e2); //false


            // to make e1 == e2 true we can use Equal method
            Console.WriteLine(e1.Equals(e2)); //look (1) in class employee

            //------------way(2)----------------
            Console.WriteLine(e1 == e2); //true after using nethod operator (look 2)



            Console.WriteLine(e1.GetHashCode());
            Console.WriteLine(e2.GetHashCode());

            Console.WriteLine(e1.GetHashCode() == e2.GetHashCode());
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public Employee(int id, string name, decimal salary, string department)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Department = department;
        }

        public override string ToString()
        {
            return $"ID = {Id}\n Name: {Name}\n Salary: {Salary}\n Department: {Department}";
        }

        //----------------- way(1)--------------------
        public override bool Equals(object? obj)
        {
            // if object is null or not employee return false
            if (obj == null || !(obj is Employee)) return false;

            // object is employee
            var emp = obj as Employee;

            return this.Id == emp.Id 
                && this.Name == emp.Name 
                &&  this.Salary == emp.Salary 
                && this.Department == emp.Department;
        }

        //--------------------- way(2)--------------
        public static bool operator==(Employee lhs, Employee rhs) => lhs.Equals(rhs);
        public static bool operator !=(Employee lhs, Employee rhs) => !lhs.Equals(rhs);

        // when we use equal method or operetor we must use with them get hash code method
        // , we use primary number with hash (hash = 17)

        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash * 7 + Id.GetHashCode();
            hash = hash * 7 + Name.GetHashCode();
            hash = hash * 7 + Salary.GetHashCode();
            hash = hash * 7 + Department.GetHashCode();
            return hash;
        }
    }
}