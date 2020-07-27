using System.Collections.Generic;

namespace GenParamNames
{
    class Method
    {
        public string Name { get; set; }
        public List<MethodArgument> Arguments { get; } = new List<MethodArgument>();
        public bool HasGenericArguments { get; set; } = false;
    }
}
