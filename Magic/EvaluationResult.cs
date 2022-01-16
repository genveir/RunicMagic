using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    public class EvalResult
    {
        public bool Success { get; }
        public object? Value { get; }

        public Action? Action { get; }

        private EvalResult(bool success, object? value)
        {
            this.Success = success;
            this.Value = value;
            this.Action = value as Action;
        }

        public static EvalResult Fail()
        {
            return new EvalResult(false, null);
        }

        public static EvalResult Succeed(object? value)
        {
            return new EvalResult(true, value);
        }

        public static EvalResult SucceedWithAction(Action action)
        {
            return new EvalResult(true, action);
        }
    }
}
