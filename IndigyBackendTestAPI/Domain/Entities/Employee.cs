using System.ComponentModel.DataAnnotations;

namespace IndigyBackendTestAPI.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmpNo { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Designation { get; private set; }
        public DateTime HireDate { get; private set; }
        public decimal Salary { get; private set; }
        public int? Comm { get; private set; }
        public int DeptNo { get; private set; }
        public bool IsDelete { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }

        public Employee(string empNo, string firstName, string lastName, string designation,
            DateTime hireDate, decimal salary, int? comm, int deptNo,
            bool isDelete, DateTime createDate, DateTime? updateDate)
        {
            EmpNo = empNo;
            FirstName = firstName;
            LastName = lastName;
            Designation = designation;
            HireDate = hireDate;
            Salary = salary;
            Comm = comm;
            DeptNo = deptNo;
            IsDelete = isDelete;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }

        public void UpdateEmployee(
            int id,
            string firstName,
            string lastName,
            string designation,
            decimal salary,
            int? comm,
            int deptNo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Designation = designation;
            Salary = salary;
            Comm = comm;
            DeptNo = deptNo;
            UpdateDate = DateTime.Now;
        }

        public void DeleteEmployee()
        {
            if (IsDelete)
                return;

            IsDelete = true;
            UpdateDate = DateTime.Now;
        }
    }

}
