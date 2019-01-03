using System;
namespace DungeonAdventure
{
    public class GameController
    {
        public Player CurrentPlayer { get; set; }
        public Map CurrentMap { get; set; }
        public Room CurrentRoom { get; set; }
        public bool IsRunning { get; private set; } = true;

        public Action<string> OnErrorAction; //TODO

        public GameController()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Verity";

            CurrentMap = MapCreator.CreateMap();
            CurrentRoom = CurrentMap.RoomAt(2, 0);

            CurrentPlayer.Inventory.Add(ItemCreator.CreateItem(001)); //TODO remove
            CurrentPlayer.Inventory.Add(ItemCreator.CreateItem(1001)); //TODO remove
        }

        public void TestGame()
        {
            Console.WriteLine("Player name = {0}", CurrentPlayer.Name);
            //Console.WriteLine("Player location = {0}", CurrentRoom.Name);
            IsRunning = false;

            //if (error != null && OnErrorAction != null) //TODO
                //OnErrorAction("name");

        }

        // Functions use the player's CurrentRoom X and Y coordinates
        // Add or subtract 1 based on X or Y direction
        public void MoveNorth()
        {
            // TODO add if(HasRoomToNorth) for protection from invalid movement
            CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate + 1);
        }

        public void MoveEast()
        {
            // TODO add if(HasRoomToEast) for protection from invalid movement
            CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate + 1, CurrentRoom.YCoordinate);
        }

        public void MoveSouth()
        {
            // TODO add if(HasRoomToSouth) for protection from invalid movement
            CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate, CurrentRoom.YCoordinate - 1);
        }

        public void MoveWest()
        {
            // TODO add if(HasRoomToWest) for protection from invalid movement
            CurrentRoom = CurrentMap.RoomAt(CurrentRoom.XCoordinate - 1, CurrentRoom.YCoordinate);
        }
    }
}
