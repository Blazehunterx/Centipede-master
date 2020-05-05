using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pacman {
    class Item : SpriteGameObject {
       
        public Item() : base("pointo") {
            position = new Vector2(GameEnvironment.Random.Next(0, 1080));
        }

        internal bool Overlaps(Player thePlayer) {
            
            return true;
        }

        public override void Reset() {
            position = new Vector2(GameEnvironment.Random.Next(100, 500));
        }
    }
    
}
