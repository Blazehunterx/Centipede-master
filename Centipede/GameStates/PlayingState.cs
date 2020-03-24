using Centipede.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede.GameStates {
    class PlayingState : GameObjectList{
        Player thePlayer;
        public PlayingState()  {
            this.Add(new SpriteGameObject("spr_background"));
        }
    }
}
