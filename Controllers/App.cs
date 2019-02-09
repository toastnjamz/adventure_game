using System;

namespace AdventureGame
{
    /// <summary>
    /// Main entry point for the application
    /// </summary>
    public class App
    {
        private GameLogic _gameLogic;
        private GameController _gameController;
        private ConsoleView _view;

		public static int Main(string[] args)
        {
            App app = new App();
            app.Run();
            return 0;
        }

        public void Run()
        {
            // Initializing MVC
            _gameLogic = new GameLogic();
            _view = new ConsoleView();
            _gameController = new GameController(_gameLogic, _view);

            // Controller signals to view to show initial setup text
            _gameController.Start();

            // Application pump
            while (_gameController.IsRunning)
            {
                _view.Display();

                try
                {
                    var input = _view.WaitForInput();
                    _gameController.HandleInput(input);
                }
                catch (Exception e)
                {
                    _view.ShowError(e.Message);
                }
            }
        }
    }
}