using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace Utils.CommandPattern {
    public interface ICommand
    {
        Task Execute();
    }
}
