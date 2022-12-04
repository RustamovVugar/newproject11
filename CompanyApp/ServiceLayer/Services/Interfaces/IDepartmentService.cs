﻿using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IDepartmentService
    {
        Department Create(Department department);
        Department Update(int id, Department department);
        void Delete(int id);
        Department GetById(int? id);
        Department GetByName(string name);
        //List<Department> GetAll();
        List<Department> Search(string searchText);
    }
}
