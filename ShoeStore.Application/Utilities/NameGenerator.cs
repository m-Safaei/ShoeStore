using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Application.Utilities
{
    public class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
