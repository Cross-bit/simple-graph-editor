using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    public interface INode<T> {
        int Y { get; set; }
        int X { get; set; }
        (int X, int Y) Coords { get; }
        T Data { get; set; }
    }
}
