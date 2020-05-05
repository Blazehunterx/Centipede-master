using Pacman.GameObjects;
using Pacman.GameStates;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace Pacman.GameStates {
    class PlayingState : GameObjectList {
        GameObjectList ghosts;
        PacmanLife thepacmanLife;
        Player thePlayer;
        GameObjectList items;

        GameObjectList coins;
        Score theScore;

        int fontSize = 20;
        bool itemHasBeenPickedUp = false;
        bool Attack = false;
        static int startXPosition = GameEnvironment.Random.Next(0, 1080),
               startYPosition = GameEnvironment.Random.Next(0,920),
               nGhostsPerLevel = 10,
               ghostWidth = GameEnvironment.Random.Next(10, 80),
               ghostHeight = GameEnvironment.Random.Next(15, 70);
        
        float timeSinceItemPickup = 0f;
        float timeSinceHitByEnemy = 0f;
        bool canPlayerBeDamaged = true;
        

        public PlayingState() {

            this.Add(new SpriteGameObject("BackGround2.0"));

            ghosts = new GameObjectList();
            wave();
            this.Add(ghosts);

            coins = new GameObjectList();
            String[] assetName = { "Dot" };
            int nCoinPerlevel = 100;
            for (int iCoinType = 0; iCoinType < assetName.Length; iCoinType++)
                for (int ICoin = 0; ICoin < nCoinPerlevel; ICoin++)
                    coins.Add(new Coin(assetName[iCoinType]));
            this.Add(coins);

            thePlayer = new Player();
            this.Add(thePlayer);

            items = new GameObjectList();
            Items();
            this.Add(items);
            

            theScore = new Score("GameFont");
            Add(theScore);
            thepacmanLife = new PacmanLife("GameFont");
            thepacmanLife.Position = new Vector2(0, fontSize);
            Add(thepacmanLife);
            Reset();
        }
        public void Items() {
            String[] assetName = { "pointo" };
            int nItemPerLevel = 5;
            for (int iItemType = 0; iItemType < assetName.Length; iItemType++)
                for (int iItem = 0; iItem < nItemPerLevel; iItem++)
                    items.Add(new Item(assetName[iItemType]));
        }
        
        public void wave() {
             int getRandomNotNullValue(int min, int max) {
                Random random = new Random();
                int value = random.Next(min, max);
                while (value == 0) {
                    value = random.Next(min, max);
                }
                return value;
                }
            String[] assetNames = { "Red1", "BlueGhost", "YellowGhost" };

            for (int iGhostType = 0; iGhostType < assetNames.Length; iGhostType++)
                for (int IGhost = 0; IGhost < nGhostsPerLevel; IGhost++)
                    ghosts.Add(new Ghost(assetNames[iGhostType],
                        new Vector2(startXPosition + IGhost * ghostWidth, startYPosition + iGhostType * ghostHeight),
                        new Vector2(getRandomNotNullValue(-10, 10), getRandomNotNullValue(-10, 10))));

        }
                        
        
        public override void Reset() {
            int aantalLives = 3;
            thepacmanLife.Lives = aantalLives;
            wave();
        }


        public override void Update(GameTime gameTime) {
            int eatGhostScore = 10;
           
            timeSinceHitByEnemy += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (canPlayerBeDamaged == false) {
                if (timeSinceHitByEnemy > 5f) {
                    canPlayerBeDamaged = true;
                    
                }
            }
            
            foreach (Ghost ghost in ghosts.Children) {

                bool bCollide = (ghost as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                if (bCollide && canPlayerBeDamaged) {

                    if (Attack) {
                        ghost.Visible = false;
                        nGhostsPerLevel--;
                        theScore.points += eatGhostScore;


                    } else {

                        thepacmanLife.Lives--;
                        canPlayerBeDamaged = false;
                        timeSinceHitByEnemy = 0f;
                        if (thepacmanLife.Lives == 0) {
                            GameEnvironment.GameStateManager.SwitchTo("gameOverState");
                        }
                    }
                    if (nGhostsPerLevel == -5) {
                        GameEnvironment.GameStateManager.SwitchTo("winState");

                    }

                }
            }
            foreach (Ghost ghost in ghosts.Children) {
                foreach (Item items in items.Children) { 
                    bool bCollides = (items as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                    if (bCollides) {
                    itemHasBeenPickedUp = true;
                        if (itemHasBeenPickedUp) {
                        timeSinceItemPickup += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        }
                    Attack = true;
                    items.Visible = false;
                            if (timeSinceItemPickup > 2f) {
                        Attack = false;
                        items.Visible = true;
                            timeSinceItemPickup = 0f;
                            }
                       
                            
                            
                        
                    
                    }
                }
                foreach (Coin coin in coins.Children) {
                        bool bCollid = (coin as SpriteGameObject).CollidesWith(thePlayer as SpriteGameObject);
                        if (bCollid) {
                            theScore.Points++;
                            coin.Visible = false;
                        }
                }
                    
                
            }
            base.Update(gameTime);
        }
    }
}


