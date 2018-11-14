using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoForDummies_Extending.VirtualStructures
{
    public class VirtualWorld : APIVirtualWorld
    {
        public VirtualWorld(string name, params Sector[] sectors) : base(name, sectors) //we can choose to force our own implementation as a parameter
        {
        }

        public void Activate(string sector, int tower,APIActivator activator = APIActivator.XANA) 
        {
            GetSector(sector)?.Activate(tower,activator);
        }

        public Sector GetSector(string sectorname)
        {
            return Sectors.Find(sector => sector.Name.Equals(sectorname)) as Sector; //we want our specific implementation. We can do this because we know the list contains Sector objects
                                                                                     //if it somehow cant be cast, this will return null
        }
    }
}