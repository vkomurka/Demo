using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL;

namespace Demo.Desktop.Model.Entities
{
    public class Setting : IEntity
    {
        public Guid Id { get; set; }
        public string  DemoWebServerUrl { get; set; }
    }
}
