using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoForDummies_Extending.VirtualStructures
{
    public class Tower : APITower //extend the class APITower
    {
        public bool IsWayTower; 
        
        internal Tower(ISector sector, int number, bool waytower = false) : base(sector,number)
        {
            IsWayTower = waytower;
        }

        internal void Activate(APIActivator activator = APIActivator.XANA)
        {
            if (Activated) return; // for APITower, Activated checks if the activator isn't NONE
            this.Activator = Activator; //assign activator first
            TowerActivationEvent.Call(this); //call event second
        }

        internal void Hijack(APIActivator newActivator) 
        {
            if (!Activated) return;
            if (Activator.Equals(newActivator)) return;
            APIActivator old = Activator; //the event doesn't change the activator for you
            Activator = newActivator; //the ol' switcheroo
            TowerHijackEvent.Call(this,old,newActivator); 
        }

        internal void Deactivate()
        {
            if (!Activated) return;
            Activator = APIActivator.NONE;
            TowerDeactivationEvent.Call(this);
        }
    }
}