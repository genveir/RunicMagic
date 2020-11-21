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

        public GameRunner(IView view, IModel model)
        {
            this.view = view;
            this.model = model;

            var player = this.model.GetPlayer();
            player.SetupOutput((output) => this.HandleOutput(output));
        }

        public void Run()
        {
            while(model.KeepRunning)
            {
                view.Display(model);

                HandleInput(view.GetInput());
            }
        }

        public void HandleInput(IInput input)
        {
            model.ExecuteInput(input);
        }

        public void HandleOutput(string output)
        {
            view.DisplayOutput(output);
        }
    }
}
