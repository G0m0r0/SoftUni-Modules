using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int initializeBulletsPerBarrel = 10;
        private const int initializeTotalBulletsBarrel = 100;
        private const int bulletUsedPerShot = 1;
        public Pistol(string name)
            : base(name, initializeBulletsPerBarrel, initializeTotalBulletsBarrel)
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
