﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class ManagerEditVM
    {
        public int ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public int EmployeeId { get; set; }
    }
}