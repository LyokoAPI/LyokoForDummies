using System;
using System.IO;
using System.Reflection;
using LyokoAPI.Events;
using LyokoForDummies_Extending;
using LyokoPluginLoader;
using LyokoPluginLoader.Events;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string whatarewe = Assembly.GetEntryAssembly().Location; //get the location of the .exe
            string dir = Path.GetDirectoryName(whatarewe); //get the directory it's in
            PluginLoader loader = new PluginLoader($"{dir}/Plugins"); //the Plugins folder will be in our directory -> Plugins. It will be created on first run if it doesnt exist
            //Events.LockAll(); !! We would do this to only allow this program to make event calls, but since we're using seperate projects for that, we'll need to do it there.

            Console.WriteLine("Welcome to fake Lyoko, press enter to start a Game");
            Console.ReadKey();
            Console.WriteLine("Testing Extending");
            GameStartEvent.Call(); //game isn't in story mode, so we dont need to provide a boolean
            ExtendingTest.Test();
            Console.WriteLine("Tested, press enter to quit");
            Console.ReadKey();
        }
    }
}