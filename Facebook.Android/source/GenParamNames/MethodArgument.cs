namespace GenParamNames
{
    class MethodArgument
    {
        public string Type { get; set; }
        public string TypeOriginal { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public bool IsGenericArgument { get; set; } = false;

        public string ToString()
        {
            return Name+ "("+Type + ")";
        }
    }

    
}
