
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.GameStates;

namespace Pacman
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pacman : GameEnvironment
    {
        private PlayingState playingState;
        private GameOverState gameOverState;
        private StartState startState;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1080, 920);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here

            playingState = new PlayingState();
            gameOverState = new GameOverState();
            startState = new StartState();
            GameStateManager.AddGameState("playingstate", playingState);
            GameStateManager.AddGameState("gameOverState", gameOverState);
            //GameStateManager.AddGameState("stateState", startState);
            GameStateManager.SwitchTo("playingstate");
        }
    }
}
