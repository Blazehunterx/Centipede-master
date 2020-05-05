using Microsoft.Xna.Framework;
using Pacman.GameObjects;
using System;
using Pacman.GameStates;


namespace Pacman.GameStates {
    class WinState : SpriteGameObject {

        public WinState() : base("winScreen") {

        }

        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed)
                GameEnvironment.GameStateManager.SwitchTo("stateState");

        }

    }
}