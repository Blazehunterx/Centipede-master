using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameObjects {
    class Coin : SpriteGameObject {

        public Coin(string assetName) : base(assetName) {

        }

        internal bool Overlaps(Player thePlayer) {
            return true;
        }
    }
}
