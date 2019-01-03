using System;

namespace DungeonAdventure
{
    /// <summary>
    /// Main entry point for the application
    /// </summary>
    public class App
    {
        public static int Main(string[] args)
        {
            App app = new App();
            app.Run();
            return 0;
        }

        public void Run()
        {
            // TODO Initialize MVC here

            GameController gameController = new GameController();

            GameModel gameModel = new GameModel();

            gameModel.OnErrorAction = OnError; //TODO

            while (gameController.IsRunning)
            {
                gameController.TestGame(); //TODO remove test method
            }
        }

        void OnError(string errorName)
        {
            //TODO
        }

        /* Do all these go here?
         * TODO: add map movement event funcitons
         * private void OnMoveNorth(object source, EventArgs e)
            {
                game.MoveNorth(); etc.
            }*/
    }
}
