using Microsoft.EntityFrameworkCore;
using IndigyBackendTestAPI.Domain.Interfaces.Repositories;
using System;
using IndigyBackendTestAPI.Infrastructure.Db;
using Azure.Core;

namespace IndigyBackendTestAPI.Infrastructure.Repositories
{
    public class EmployeeRepositories : IEmployeeRepositories
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepositories(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entities.Employee>> GetAllAsync(int pageNumber, int pageSize)
        {
            IQueryable<Employee> query = _dbContext.Employees.Where(e => e.IsDelete != true).OrderBy(e => e.Id);

            if (pageSize > 0)
            {
                query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }

            var dbEmployees = await query.ToListAsync();

            var domainEmployees = dbEmployees.Select(e => new Domain.Entities.Employee(
                e.Empno,
                e.FirstName ?? string.Empty,
                e.LastName ?? string.Empty,
                e.Designation ?? string.Empty,
                e.Hiredate ?? default,
                e.Salary ?? 0,
                e.Comm,
                e.Deptno ?? 0,
                e.IsDelete ?? false,
                e.CreateDate ?? default,
                e.UpdateDate
            )).ToList();

            return domainEmployees;
        }

        public async Task<Domain.Entities.Employee?> GetByIdAsync(int id)
        {
            var dbEmployee = await _dbContext.Employees.FindAsync(id);
            if (dbEmployee == null) return null;

            return new Domain.Entities.Employee(
                 empNo: dbEmployee.Empno,
                 firstName: dbEmployee.FirstName ?? string.Empty,
                 lastName: dbEmployee.LastName ?? string.Empty,
                 designation:dbEmployee.Designation ?? string.Empty,
                 hireDate:dbEmployee.Hiredate ?? default,
                 salary:dbEmployee.Salary ?? 0, 
                 comm:dbEmployee.Comm ?? 0,
                 deptNo:dbEmployee.Deptno ?? 0,
                 isDelete:dbEmployee.IsDelete ?? false,
                 createDate:dbEmployee.CreateDate ?? default,
                 updateDate:dbEmployee.UpdateDate
             );
        }


        public async Task AddAsync(Domain.Entities.Employee employee)
        {
            var data = new Employee
            {
                Empno = employee.EmpNo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Designation = employee.Designation,
                Hiredate = employee.HireDate,
                Salary = employee.Salary,
                Comm = employee.Comm,
                Deptno = employee.DeptNo,
                IsDelete = employee.IsDelete,
                CreateDate = employee.CreateDate,
                UpdateDate = employee.UpdateDate
            };

            _dbContext.Employees.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Employee employee)
        {
            var dbEmployee = await _dbContext.Employees.FindAsync(employee.Id);
            if (dbEmployee == null) return;

            dbEmployee.FirstName = employee.FirstName;
            dbEmployee.LastName = employee.LastName;
            dbEmployee.Comm = employee.Comm;
            dbEmployee.Deptno = employee.DeptNo;
            dbEmployee.Salary = employee.Salary;
            dbEmployee.Designation = employee.Designation;
            dbEmployee.UpdateDate = employee.UpdateDate;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var dbEmployee = await _dbContext.Employees.FindAsync(Id);
            if (dbEmployee == null || dbEmployee.IsDelete == true) return;

            dbEmployee.IsDelete = true;
            dbEmployee.UpdateDate = DateTime.Now;

            _dbContext.Employees.Update(dbEmployee);
            await _dbContext.SaveChangesAsync();
        }

        public string GenerateNextEmpNo()
        {
            var maxEmpNo = _dbContext.Employees
                .AsEnumerable()
                .Select(e =>
                {
                    bool parsed = int.TryParse(e.Empno, out int empNo);
                    return parsed ? empNo : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            int nextEmpNo = maxEmpNo + 1;
            return nextEmpNo.ToString("D4");
        }

    }
}
