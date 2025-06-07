using System.ComponentModel.DataAnnotations;

namespace IndigyBackendTestAPI.Application.Model.View
{
    public class EmployeeView
    {
        public string EmpNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? Comm { get; set; }
        public int DeptNo { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
