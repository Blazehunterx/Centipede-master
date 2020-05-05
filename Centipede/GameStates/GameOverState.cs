using Microsoft.Xna.Framework;
using Pacman.GameObjects;
using System;
using Pacman.GameStates;


namespace Pacman.GameStates {
    class GameOverState : SpriteGameObject {

        public GameOverState() : base("spr_gameover_screen") {

        }

        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed)
                GameEnvironment.GameStateManager.SwitchTo("stateState");
        }

    }
}
