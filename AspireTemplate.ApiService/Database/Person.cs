using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspireTemplate.ApiService.Database
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
    }
}