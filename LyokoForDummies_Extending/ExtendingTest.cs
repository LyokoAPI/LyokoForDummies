using LyokoAPI.VirtualStructures.Interfaces;
using LyokoForDummies_Extending.VirtualStructures;

namespace LyokoForDummies_Extending
{
    /*
     * This class is just to test a simple tower activation
     */
    public static class ExtendingTest
    {

        public static void Test()
        {
            VirtualWorld virtualWorld = new VirtualWorld("lyoko"); //we would store it in ISector if we didn't need our specific methods
            virtualWorld.Sectors.Add(new Sector(virtualWorld,"ice",10));
            virtualWorld.Activate("ice",5);
        }
        
        
        
    }
}