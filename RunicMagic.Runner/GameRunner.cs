using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

            this.view.SetupInput((input) => this.HandleInput(input));
        }

        public void Run()
        {
            RunModel();

            view.Display(this.model);

            do
            {
                view.GetInput();
            } while (model.KeepRunning);
        }

        private System.Timers.Timer modelTimer;
        private void RunModel()
        {
            modelTimer = new System.Timers.Timer(100);
            modelTimer.Elapsed += ModelTimer_Elapsed;
            modelTimer.Start();
        }

        private void ModelTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.model.RunTick();
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
