using System.Collections.Generic;

namespace RunicMagic.Spells
{
    public class Zu : IRune
    {
        public string Name => "zu";
        public List<string> Types => new List<string>{"executedstatement"};

        private IRune arg;

        public void Parse(Stack<IRune> stack)
        {
            var arg1 = stack.Pop();
            if (!arg1.Types.Contains("reference") && !arg1.Types.Contains("statement"))
            {
                throw new System.Exception("Parse exception");
            }
            arg1.Parse(stack);
            arg = arg1;
        }
    }
    public class Beh : IRune
    {
        public string Name => "beh";
        public List<string> Types => new List<string>{"reference"};
        public void Parse(Stack<IRune> stack) {}
    }
    public class Basdu : IRune
    {
        public string Name => "basdu";
        public List<string> Types => new List<string>{"statement"};
        public void Parse(Stack<IRune> stack) {}
    }
    public class Ti : IRune
    {
        public string Name => "ti";
        public List<string> Types => new List<string>{"powersource", "statement"};
        public void Parse(Stack<IRune> stack) {}
    }
    public class Oh : IRune
    {
        public string Name => "oh";
        public List<string> Types => new List<string>{"powerreservoir+"};
        public void Parse(Stack<IRune> stack) {}
    }
}