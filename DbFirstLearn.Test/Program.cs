﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstLearn.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            db_shengtongEntities db = new db_shengtongEntities();
            var v = (from c in db.tb_inventory where c.Id == 37 select c).SingleOrDefault<tb_inventory>();

            Console.ReadLine();
        }
    }
}