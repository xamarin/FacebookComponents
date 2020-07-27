using System.Collections.Generic;

namespace GenParamNames
{
    class Class
    {
        public string Name { get; set; }
        public string PackageName { get; set; }
        public List<Method> Methods { get; } = new List<Method>();
        public List<Method> Constructors { get; } = new List<Method>();
        public bool IsInterface { get; set; } = false;
    }
}
