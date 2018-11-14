using System;
using System.IO;
using System.Reflection;
using LyokoAPI.Events;
using LyokoForDummies_Extending;
using LyokoForDummies_Reconstructing;
using LyokoPluginLoader;
using LyokoPluginLoader.Events;
using Events = LyokoAPI.Events.Events;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string whatarewe = Assembly.GetEntryAssembly().Location; //get the location of the .exe
            string dir = Path.GetDirectoryName(whatarewe); //get the directory it's in
            PluginLoader loader = new PluginLoader($"{dir}/Plugins"); //the Plugins folder will be in our directory -> Plugins. It will be created on first run if it doesnt exist

            Events.SetMaster(); //Make it so that only this application can lock or unlock events
            XanaAwakenEvent.Lock(); //locking an event
            //note: since this application is different from LyokoForDummies_Extending for example, it will not be able to call this event either, which is not what we want in this case.
            //You'll probably want to use Events.LockAll() in most cases though
                
            Console.WriteLine("Welcome to fake Lyoko, press enter to start a Game");
            Console.ReadKey();
            Console.WriteLine("Testing Extending");
            
            GameStartEvent.Call(); //game isn't in story mode, so we dont need to provide a boolean
            ExtendingTest.Test();
            GameEndEvent.Call(false);
            
            Console.WriteLine("Tested. Press enter to test Reconstructing");
            GameStartEvent.Call(); //game isn't in story mode, so we dont need to provide a boolean
            GameEndEvent.Call(false);
            ReconstructingTest.Test();

            Console.WriteLine("Tested, press enter to quit");
            Console.ReadKey();
            
        }
    }
}