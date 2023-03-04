using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Projects
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
