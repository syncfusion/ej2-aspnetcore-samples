using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class GameList
    {
        public string Id { get; set; }
        public string Game { get; set; }
        public string Mask { get; set; }
        public string Mode { get; set; }

        public List<GameList> GameLists()
        {
            List<GameList> game = new List<GameList>();
            game.Add(new GameList { Id = "Game1", Game = "American Football" });
            game.Add(new GameList { Id = "Game2", Game = "Badminton" });
            game.Add(new GameList { Id = "Game3", Game = "Basketball" });
            game.Add(new GameList { Id = "Game4", Game = "Cricket" });
            game.Add(new GameList { Id = "Game5", Game = "Football" });
            game.Add(new GameList { Id = "Game6", Game = "Golf" });
            game.Add(new GameList { Id = "Game7", Game = "Hockey" });
            game.Add(new GameList { Id = "Game8", Game = "Rugby" });
            game.Add(new GameList { Id = "Game9", Game = "Snooker" });
            game.Add(new GameList { Id = "Game10", Game = "Tennis" });
            return game;
        }
        public List<GameList> MaskEditModel()
        {
             List <GameList> game = new List<GameList>();
            game.Add(new GameList { Id = "#", Mask = "#" });
            game.Add(new GameList { Id = "_", Mask = "_" });
            game.Add(new GameList { Id = "*", Mask = "*" });
            game.Add(new GameList { Id = "@", Mask = "@" });
            return game;
        }
        public List<GameList> ColorPickerModeModel()
        {
             List <GameList> game = new List<GameList>();
            game.Add(new GameList { Id = "Picker", Mode = "Picker" });
            game.Add(new GameList { Id = "Palette", Mode = "Palette" });
            return game;
        }
    }

    public class chunkValues
    {
        public int chunkValue { get; set; }

        public string text { get; set; }

        public List<chunkValues> UploaderModel()
        {
            List<chunkValues> chunk = new List<chunkValues>();
            chunk.Add(new chunkValues { chunkValue = 500000, text = "500 KB" });
            chunk.Add(new chunkValues { chunkValue = 1000000, text = "1 MB" });
            chunk.Add(new chunkValues { chunkValue = 2000000, text = "2 MB" });
            return chunk;
        }
    }
    public class floatValues
    {
        public string floatValue { get; set; }

        public string text { get; set; }

        public List<floatValues> TextBoxModel()
        {
            List<floatValues> floatText = new List<floatValues>();
            floatText.Add(new floatValues { floatValue = "Auto", text = "Auto" });
            floatText.Add(new floatValues { floatValue = "Never", text = "Never" });
            floatText.Add(new floatValues { floatValue = "Always", text = "Always" });
            return floatText;
        }
    }
}

