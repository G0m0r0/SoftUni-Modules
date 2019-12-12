using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun, IGun
    {
        private const int initializeBulletsPerBarrel = 50;
        private const int initializeTotalBulletsBarrel = 500;
        private const int bulletUsedPerShot = 5;
        public Rifle(string name) 
            : base(name, initializeBulletsPerBarrel,initializeTotalBulletsBarrel)
        {
        }

        public override int Fire()
        {
           if(this.BulletsPerBarrel<bulletUsedPerShot)
            {
                this.Reload(initializeBulletsPerBarrel);
            }
            int fireBulltes = this.DecreaseBullets(bulletUsedPerShot);
            return fireBulltes;
        }
    }
}
