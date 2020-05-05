using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.GameStates;

namespace Pacman.GameStates {
    class StartState : SpriteGameObject {

        public StartState() : base("StartScreen") {

        }
        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed)
                GameEnvironment.GameStateManager.SwitchTo("playingstate");
        }
    }
}

