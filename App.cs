using System;

namespace DungeonAdventure
{
    /// <summary>
    /// Main entry point for the application
    /// </summary>
    public class App
    {
		ConsoleView _view;

		public static int Main(string[] args)
        {
            App app = new App();
            app.Run();
            return 0;
        }

        public void Run()
        {
			_view = new ConsoleView();

			// TODO Initialize MVC here

			GameModel gameModel = new GameModel();
			GameController gameController = new GameController(gameModel);
			gameController.OnErrorAction += OnError;
			gameController.OnGameEvent += OnGameEvent;

			// application pump
			while (gameController.IsRunning)
            {
				_view.Display();
				try
				{
					var input = _view.WaitForInput();
					gameController.HandleInput(input);
				}
				catch (Exception e)
				{
					_view.ShowError(e.Message);
				}
			}
        }

		void OnGameEvent(GameEvent gameEvent)
		{
			_view.ShowGameEvent(gameEvent);
		}

		void OnError(string errorName)
        {
			//TODO
			_view.ShowError(errorName);
		}

		/* Do all these go here?
         * TODO: add map movement event funcitons
         * private void OnMoveNorth(object source, EventArgs e)
            {
                game.MoveNorth(); etc.
            }*/
	}
}
