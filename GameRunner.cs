using RunicMagic.View;
using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic
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
                view.Display();

                var input = view.GetInput();

                model.ExecuteInput(input);
            }
        }
    }
}
