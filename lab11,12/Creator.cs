using System;
using System.Collections.Generic;

namespace lab11_12
{
    internal class Creator
    {
        HashSet<Building> buildings = new HashSet<Building> { };
        public ulong CreateBuilding(double height)
        {
            Building building = new Building(height);
            buildings.Add(building);
            return building.Number;
        }
        public ulong CreateBuilding(double height, byte storeys)
        {
            Building building = new Building(height, storeys);
            buildings.Add(building);
            return building.Number;
        }
        public void RemoveBuilding(ushort number)
        {
            buildings.RemoveWhere(building => building.Number == number);
        }
    }
}