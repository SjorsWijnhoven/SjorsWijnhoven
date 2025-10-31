package com.github.hanyaeger.game.gamemap;

import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.scenes.TileMap;
import com.github.hanyaeger.game.Game;


public class GridMap extends TileMap {

    //Moet buiten de defineMap vanwege methodevolgorde van GameLevelScene
    //Anders is de grootte van de array meegeven aan een entity niet mogelijk binnen GameLevelScene.setupEntities()
    //gridMap moet altijd een 16:9 ratio hebben!
    final public static int[][] gridMap = new int[][]{
            {1, 1, 1, 1, 1, 1, 1, 1, 4, 2, 2, 2, 6, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1},
            {4, 2, 2, 2, 2, 2, 2, 2, 5, 1, 1, 1, 2, 1, 4, 2},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 2, 3, 1, 2, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 2, 2, 2, 5, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    };
    //squareSize = schermgrootte / aantal vlakken in de array.
    final public static Size squareSize = new Size((Game.sceneSize.width() /gridMap[0].length), (Game.sceneSize.height() / gridMap.length));

    @Override
    public void setupEntities() {

        /*
        1 = bauwbaar
        2 = pad (direction behouden)
        3 = pad (links)
        4 = pad (rechts)
        5 = pad (boven)
        6 = pad (onder)
        */
        addEntity(1, GridSquare.class, false);
        addEntity(2, GridSquare.class, true);
        addEntity(3, GridSquare.class, true);
        addEntity(4, GridSquare.class, true);
        addEntity(5, GridSquare.class, true);
        addEntity(6, GridSquare.class, true);

    }


    @Override
    public int[][] defineMap() {
         return gridMap;
    }
}