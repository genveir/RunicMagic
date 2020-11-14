using System.Collections.Generic;

namespace RunicMagic.Spells
{
    public class Zu : IRune
    {
        public string Name => "zu";
        public List<string> Types => new List<string>{"executedstatement"};

        private IRune arg;

        public bool Parse(Stack<IRune> stack)
        {
            var arg1 = stack.Pop();
            if (!arg1.Types.Contains("reference") && !arg1.Types.Contains("statement"))
            {
                throw new System.Exception("Parse exception");
            }
            if (!arg1.Parse(stack))
            {
                return false;
            }
            arg = arg1;
            return true;
        }

        public string Debug() {
            return $"{Name}({arg.Debug()})";    
        }
    }
    public class Beh : IRune
    {
        public string Name => "beh";
        public List<string> Types => new List<string>{"reference"};
        public bool Parse(Stack<IRune> stack) { return true; }
        public string Debug() {
            return Name;
        }
    }
    public class Basdu : IRune
    {
        public string Name => "basdu";
        private IRune arg;
        public List<string> Types => new List<string>{"statement"};
        public bool Parse(Stack<IRune> stack)
        {
            var arg1 = stack.Pop();
            if (!arg1.Types.Contains("statement"))
            {
                return false;
            }
            if (!arg1.Parse(stack))
            {
                return false;
            }
            arg = arg1;
            return true;
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
        public bool Parse(Stack<IRune> stack)
        {
            if (stack.Count != 0 && stack.Peek().Types.Contains("powersource"))
            {
                var arg1 = stack.Pop();
                if (!arg1.Parse(stack))
                {
                    return false;
                }
                from = arg1;
            }
            else {
                //default
                from = new A();
            }
            if (stack.Count != 0 && stack.Peek().Types.Contains("number"))
            {
                var arg2 = stack.Pop();
                if (!arg2.Parse(stack))
                {
                    return false;
                }
                amount = arg2;
            }
            else {
                //default
                amount = new Imo();
            }
            return true;
        }
        public string Debug() {
            return $"{Name}({from.Debug()},{amount.Debug()})";    
        }
    }
    public class Oh : IRune
    {
        public string Name => "oh";
        public List<string> Types => new List<string>{"powersource"};
        public bool Parse(Stack<IRune> stack) { return true; }
        public string Debug() {
            return Name;    
        }
    }
    public class A : IRune
    {
        public string Name => "a";
        public List<string> Types => new List<string>{"scope", "powersource"};
        public bool Parse(Stack<IRune> stack) { return true; }
        public string Debug() {
            return Name;    
        }
    }
    public class Imo : IRune
    {
        public string Name => "imo";
        public List<string> Types => new List<string>{"number"};
        public bool Parse(Stack<IRune> stack) { return true; }
        public string Debug() {
            return Name;    
        }
    }
}