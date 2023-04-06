using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class UserForBlogDto:IDTO
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}