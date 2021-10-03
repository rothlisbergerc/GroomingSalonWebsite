﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroomingSalonWebsite.Models;

namespace GroomingSalonWebsite.Data
{
    static public class SalonDB
    {
        public async static Task<int> getAllCustomers(SalonContext _context)
        {
            return await (from c in _context.Customers select c).CountAsync();
        }
    }
}