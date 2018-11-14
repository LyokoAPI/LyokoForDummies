using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoForDummies_Extending.VirtualStructures
{
    public class Sector : APISector
    {
        public Sector(IVirtualWorld virtualworld, string sectorName, int towers = 0) : base(virtualworld, sectorName)
        {
            //we want to add our own Tower implementation to the list, not APITower (which is what happens if you add the tower variable to the base() )
            if (towers < 1)
            {
                return;
            }
            Towers.Add(new Tower(this,1,true)); //create a waytower
            for (int i = 2; i < towers; i++)
            {
               Towers.Add(new Tower(this,i)); //not a waytower
            }
            Towers.Add(new Tower(this,towers,true)); //waytower on the last number
        }

        public void Activate(int i, APIActivator activator = APIActivator.XANA)
        {
            Tower foundTower = GetTower(i); //we need our own Tower, because ITower doesn't contain Activate()
            foundTower?.Activate(activator); //we need to check if the tower actually exists.
        }
        public void Deactivate(int i)
        {
            Tower foundTower = GetTower(i); //we need our own Tower, because ITower doesn't contain Deactivate()
            foundTower?.Deactivate(); //we need to check if the tower actually exists.
        }

        public Tower GetTower(int i)
        {
            return Towers.Find(tower => tower.Number.Equals(i)) as Tower; //we need to cast ITower to Tower. This works because we know it's an ITower
        }

       

      
    }
}