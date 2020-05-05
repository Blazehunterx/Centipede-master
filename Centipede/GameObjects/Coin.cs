using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameObjects {
    class Coin : SpriteGameObject {
        
        public Coin(string assetName) : base(assetName) {
            position.X = GameEnvironment.Random.Next(0, 1080);
            position.Y = GameEnvironment.Random.Next(0, 980);
        }

        internal bool Overlaps(Player thePlayer) {
            return true;
        }
    }
}
