using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aroris_Platformer_Project.Src
{
    public static class CONSTANTS
    {
        public static float kGravity = 500f; //Gravity

        //Amount of distances to interpolate the position of the collision entity from the previous frame
        public static float kContinuousCollisionPrecision = 100; 
    }
}
