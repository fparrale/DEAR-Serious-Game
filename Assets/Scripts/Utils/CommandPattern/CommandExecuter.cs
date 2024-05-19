

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Utils.CommandPattern {
    public class CommandExecuter {

        public async Task ExecuteCommands(List<ICommand> commands){
            foreach(ICommand command in commands){
                await command.Execute();
            }
        }
    }
}