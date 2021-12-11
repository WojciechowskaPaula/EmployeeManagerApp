using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Helpers
{
    public static class ExtensionHelpers
    {
        public static IEnumerable<SelectListItem> SetValueToText(this IEnumerable<SelectListItem> listItems)
        {
            foreach (var item in listItems)
            {
                item.Value = item.Text;
            }
            return listItems;

        }
    }
}
