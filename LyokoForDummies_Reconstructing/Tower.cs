using System;
using System.Linq;
using LyokoAPI.API;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;

namespace LyokoForDummies_Reconstructing
{
    public class Tower
    {
        /*
         * These are just as an example that you can completely choose your own structure
         */
        private static readonly string[] PossibleActivators = {"none", "hopper", "jeremie", "xana"};
        public int Number { get; }
        public string Activator { get; private set; }
        public bool Activated => Activator != "none";
        public string Sector { get; }

        public Tower(string sector, int number)
        {
            Number = number;
            Sector = sector;
            Activator = "none";
        }

        public void Activate(string activator)
        {
            if(Activated) return;
            if (!PossibleActivators.Contains(activator.ToLower())) return;
            
            Activator = activator;
            TowerActivationEvent.Call("lyoko",Sector,Number,Activator); //you can call the event with only strings, using the info from your class.
                                                                        //This will also give 0 control over this class to the listeners.
        }
        
        
        
    }
}