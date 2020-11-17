using System.Collections.Generic;
using System.Linq;

using RunicMagic.Domain;
using RunicMagic.Model.World;

namespace RunicMagic.Spells
{
    public abstract class Rune
    {
        public virtual string Name {get;}
        public List<IRune> Arguments {get;}
        public abstract List<RuneArgument> ArgTypesAndDefaults {get;}

        public Rune()
        {
            Arguments = new List<IRune>();
        }

        public int EvaluateCost()
        {
            return 1 + Arguments.Sum(x => x.EvaluateCost());
        }
        public bool Parse(Stack<IRune> stack)
        {
            foreach (RuneArgument ra in ArgTypesAndDefaults)
            {
                if (stack.Count == 0)
                {
                    if (ra.Default == null)
                    {
                        return false;
                    }
                    Arguments.Add(ra.Default);
                    continue;
                }
                var arg1 = stack.Pop();
                if (ra.Types.Intersect(arg1.Types) == null)
                {
                    if (ra.Default == null)
                    {
                        return false;
                    }
                    Arguments.Add(ra.Default);
                    continue;
                }
                if (!arg1.Parse(stack))
                {
                    return false;
                }
                Arguments.Add(arg1);
            }
            return true;
        }
        public string Debug()
        {
            if (Arguments.Count == 0)
            {
                return Name;
            }
            var argstr = string.Join(',', Arguments.Select(x => x.Debug()));
            return $"{Name}({argstr})";
        }
        public virtual void Execute(IPlayer player, object executor){}
    }
    public class RuneArgument
    {
        public HashSet<string> Types {get;}
        public IRune Default {get;}
        public RuneArgument(HashSet<string> types, IRune def)
        {
            Types = types;
            Default = def;
        }
    }
    public class Zu : Rune, IRune
    {
        override public string Name => "zu";
        public HashSet<string> Types => new HashSet<string>{"executedstatement"};

        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>{
                new RuneArgument(new HashSet<string>{"reference", "statement"}, null)
            };

        public override void Execute(IPlayer player, object executor)
        {
            Arguments.First().Execute(player, executor);
        }
    }
    public class Beh : Rune, IRune
    {
        override public string Name => "beh";
        public HashSet<string> Types => new HashSet<string>{"reference"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>();
    }
    public class Basdu : Rune, IRune
    {
        override public string Name => "basdu";
        public HashSet<string> Types => new HashSet<string>{"statement"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>{
                new RuneArgument(new HashSet<string>{"statement"}, null)
            };
    }
    public class Ti : Rune, IRune
    {
        override public string Name => "ti";
        public HashSet<string> Types => new HashSet<string>{"powersource", "statement"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>{
                new RuneArgument(new HashSet<string>{"powersource"}, new A()),
                new RuneArgument(new HashSet<string>{"number"}, new Imo())
            };
    }
    public class Oh : Rune, IRune
    {
        override public string Name => "oh";
        public HashSet<string> Types => new HashSet<string>{"powersource"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>();
    }
    public class A : Rune, IRune
    {
        override public string Name => "a";
        public HashSet<string> Types => new HashSet<string>{"scope", "powersource"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>();
    }
    public class Imo : Rune, IRune
    {
        override public string Name => "imo";
        public HashSet<string> Types => new HashSet<string>{"number"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>();
    }

    // debug runes
    public class AlleDurOpe : Rune, IRune
    {
        override public string Name => "alledurope";
        public HashSet<string> Types => new HashSet<string>{"statement"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>();

        public override void Execute(IPlayer player, object executor)
        {
            // open all doors in the room where the caster is standing
            var room = player.Location;
            foreach (IExit exit in room.Exits.Values)
            {
                if (exit.Door == null) continue;
                exit.Door.Open = true;
            }
        }

    }

    public class DezeDurOpe : Rune, IRune
    {
        override public string Name => "dezedurope";
        public HashSet<string> Types => new HashSet<string>{"statement"};
        public override List<RuneArgument> ArgTypesAndDefaults => new List<RuneArgument>();

        public override void Execute(IPlayer player, object executor)
        {
            // open door if indicated
            var door = player.IndicatedTarget as Door;
            if (door == null)
            {
                return;
            }
            door.Open = true;
        }

    }
}