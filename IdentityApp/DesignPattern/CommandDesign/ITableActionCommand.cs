using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.DesignPattern.CommandDesign
{
    public interface ITableActionCommand
    {
        IActionResult Execute();
    }
}
