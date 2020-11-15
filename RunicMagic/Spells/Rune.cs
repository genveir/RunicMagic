using System.Collections.Generic;
using System.Linq;

namespace RunicMagic.Spells
{
    public abstract class Rune
    {
        public abstract bool Parse(Stack<IRune> stack);

        public virtual string Name {get;}
        public List<IRune> arguments {get;}

        public Rune()
        {
            arguments = new List<IRune>();
        }

        public int EvaluateCost()
        {
            return 1 + arguments.Sum(x => x.EvaluateCost());
        }
        public string Debug()
        {
            if (arguments.Count == 0)
            {
                return Name;
            }
            var argstr = string.Join(',', arguments.Select(x => x.Debug()));
            return $"{Name}({argstr})";
        }
    }
    public class Zu : Rune, IRune
    {
        override public string Name => "zu";
        public List<string> Types => new List<string>{"executedstatement"};

        override public bool Parse(Stack<IRune> stack)
        {
            var arg1 = stack.Pop();
            if (!arg1.Types.Contains("reference") && !arg1.Types.Contains("statement"))
            {
                return false;
            }
            if (!arg1.Parse(stack))
            {
                return false;
            }
            arguments.Add(arg1);
            return true;
        }

    }
    public class Beh : Rune, IRune
    {
        override public string Name => "beh";
        public List<string> Types => new List<string>{"reference"};
        override public bool Parse(Stack<IRune> stack) { return true; }
    }
    public class Basdu : Rune, IRune
    {
        override public string Name => "basdu";
        public List<string> Types => new List<string>{"statement"};
        override public bool Parse(Stack<IRune> stack)
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
            arguments.Add(arg1);
            return true;
        }
    }
    public class Ti : Rune, IRune
    {
        override public string Name => "ti";
        public List<string> Types => new List<string>{"powersource", "statement"};
        override public bool Parse(Stack<IRune> stack)
        {
            if (stack.Count != 0 && stack.Peek().Types.Contains("powersource"))
            {
                var arg1 = stack.Pop();
                if (!arg1.Parse(stack))
                {
                    return false;
                }
                arguments.Add(arg1);
            }
            else {
                //default
                arguments.Add(new A());
            }
            if (stack.Count != 0 && stack.Peek().Types.Contains("number"))
            {
                var arg2 = stack.Pop();
                if (!arg2.Parse(stack))
                {
                    return false;
                }
                arguments.Add(arg2);
            }
            else {
                //default
                arguments.Add(new Imo());
            }
            return true;
        }
    }
    public class Oh : Rune, IRune
    {
        override public string Name => "oh";
        public List<string> Types => new List<string>{"powersource"};
        override public bool Parse(Stack<IRune> stack) { return true; }
    }
    public class A : Rune, IRune
    {
        override public string Name => "a";
        public List<string> Types => new List<string>{"scope", "powersource"};
        override public bool Parse(Stack<IRune> stack) { return true; }
    }
    public class Imo : Rune, IRune
    {
        override public string Name => "imo";
        public List<string> Types => new List<string>{"number"};
        override public bool Parse(Stack<IRune> stack) { return true; }
    }
}