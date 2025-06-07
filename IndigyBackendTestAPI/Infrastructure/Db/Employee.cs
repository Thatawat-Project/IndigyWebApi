using System;
using System.Collections.Generic;

namespace IndigyBackendTestAPI.Infrastructure.Db;

public partial class Employee
{
    public int Id { get; set; }

    public string Empno { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Designation { get; set; }

    public DateTime? Hiredate { get; set; }

    public decimal? Salary { get; set; }

    public int? Comm { get; set; }

    public int? Deptno { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
