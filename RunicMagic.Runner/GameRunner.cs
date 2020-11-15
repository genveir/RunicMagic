using RunicMagic.Domain;
using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public void Run()
        {
            while(model.KeepRunning)
            {
                view.Display(model);

                var input = view.GetInput();

                model.ExecuteInput(input);
            }
        }
    }
}
