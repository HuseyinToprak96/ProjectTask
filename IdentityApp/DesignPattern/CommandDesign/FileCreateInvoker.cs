using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.DesignPattern.CommandDesign
{
    public class FileCreateInvoker
    {
        private ITableActionCommand _tableActionCommand;
        private List<ITableActionCommand> _tableActionCommands;
        public void SetCommand(ITableActionCommand tableActionCommand)
        {
            _tableActionCommand = tableActionCommand;
        }
        public void AddCommand(ITableActionCommand tableActionCommand)
        {
            _tableActionCommands.Add(tableActionCommand);
        }

        public IActionResult CreateFile()
        {
            return _tableActionCommand.Execute();
        }
        public List<IActionResult> CreateFiles()
        {

            return _tableActionCommands.Select(x => x.Execute()).ToList();
        }

    }
}
