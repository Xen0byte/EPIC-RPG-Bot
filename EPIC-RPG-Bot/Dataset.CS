using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace BOT
{
    public static class Dataset
    {
        public static List<Item> ItemDataset = PopulateDataset();

        private static List<Item> PopulateDataset()
        {
            return new List<Item>
            {
                Apple, Coin, EpicCoin, GoldenFish,
                LifePotion, NormieFish, WolfSkin, ZombieEye
            };
        }

        public static readonly Item Apple       = new Item("APPLE",         "Apple.PNG");
        public static readonly Item Coin        = new Item("COIN",          "Coin.PNG");
        public static readonly Item EpicCoin    = new Item("EPIC COIN",     "Epic-Coin.PNG");
        public static readonly Item GoldenFish  = new Item("GOLDEN FISH",   "Golden-Fish.PNG");
        public static readonly Item LifePotion  = new Item("LIFE POTION",   "Life-Potion.PNG");
        public static readonly Item NormieFish  = new Item("NORMIE FISH",   "Normie-Fish.PNG");
        public static readonly Item WolfSkin    = new Item("WOLF SKIN",     "Wolf-Skin.PNG");
        public static readonly Item ZombieEye   = new Item("ZOMBIE EYE",    "Zombie-Eye.PNG");
    }

    public class Item
    {
        public string Name { get; set; }
        public Bitmap Bitmap { get; set; }

        public Item(string name, string image)
        {
            Name = name;
            Bitmap = new Bitmap("ASSETS" + Path.DirectorySeparatorChar + image);
        }
    }
}
