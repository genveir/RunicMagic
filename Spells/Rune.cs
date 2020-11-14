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

        public string Debug() {
            return $"{Name}({arg.Debug()})";    
        }
    }
    public class Beh : IRune
    {
        public string Name => "beh";
        public List<string> Types => new List<string>{"reference"};
        public void Parse(Stack<IRune> stack) {}
        public string Debug() {
            return Name;
        }
    }
    public class Basdu : IRune
    {
        public string Name => "basdu";
        private IRune arg;
        public List<string> Types => new List<string>{"statement"};
        public void Parse(Stack<IRune> stack)
        {
            var arg1 = stack.Pop();
            if (!arg1.Types.Contains("statement"))
            {
                throw new System.Exception("Parse exception");
            }
            arg1.Parse(stack);
            arg = arg1;
        }
        public string Debug() {
            return $"{Name}({arg.Debug()})";    
        }
    }
    public class Ti : IRune
    {
        public string Name => "ti";
        private IRune from;
        private IRune amount;
        public List<string> Types => new List<string>{"powersource", "statement"};
        public void Parse(Stack<IRune> stack)
        {
            if (stack.Count != 0 && stack.Peek().Types.Contains("powersource"))
            {
                var arg1 = stack.Pop();
                arg1.Parse(stack);
                from = arg1;
            }
            else {
                //default
                from = new A();
            }
            if (stack.Count != 0 && stack.Peek().Types.Contains("number"))
            {
                var arg2 = stack.Pop();
                arg2.Parse(stack);
                amount = arg2;
            }
            else {
                //default
                amount = new Imo();
            }
        }
        public string Debug() {
            return $"{Name}({from.Debug()},{amount.Debug()})";    
        }
    }
    public class Oh : IRune
    {
        public string Name => "oh";
        public List<string> Types => new List<string>{"powersource"};
        public void Parse(Stack<IRune> stack) {}
        public string Debug() {
            return Name;    
        }
    }
    public class A : IRune
    {
        public string Name => "a";
        public List<string> Types => new List<string>{"scope", "powersource"};
        public void Parse(Stack<IRune> stack) {}
        public string Debug() {
            return Name;    
        }
    }
    public class Imo : IRune
    {
        public string Name => "imo";
        public List<string> Types => new List<string>{"number"};
        public void Parse(Stack<IRune> stack) {}
        public string Debug() {
            return Name;    
        }
    }
}