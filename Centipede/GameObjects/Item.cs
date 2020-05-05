using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pacman {
    class Item : SpriteGameObject {
       
        public Item() : base("pointo") {
            position.X = GameEnvironment.Random.Next(0, 1080);
            position.Y = GameEnvironment.Random.Next(0, 920);
        }

        public override void Reset() {
            position.X = GameEnvironment.Random.Next(0, 1080);
            position.Y = GameEnvironment.Random.Next(0, 920);
        }
    }
    
}
