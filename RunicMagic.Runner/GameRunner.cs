using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace RunicMagic.Runner
{
    public class GameRunner
    {
        private IView view;
        private IModel model;

        private Timer throughPutTimer;

        public GameRunner(IView view, IModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Run()
        {
            while(model.KeepRunning)
            {
                HandleOutput("");

                HandleInput(view.GetInput());
            }
        }

        public void HandleInput(IInput input)
        {
            model.ExecuteInput(input);
        }

        public void HandleOutput(string output)
        {
            view.Display(model);
        }
    }
}
