package com.github.hanyaeger.game.gamemap;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.impl.SpriteEntity;
import com.github.hanyaeger.api.userinput.MouseButtonPressedListener;
import com.github.hanyaeger.game.entities.tower.ComposingTower;
import com.github.hanyaeger.game.scenes.GameLevelScene;
import javafx.scene.input.MouseButton;


import static com.github.hanyaeger.game.entities.toolbar.SelectedTool.getCurrentTool;
import static com.github.hanyaeger.game.entities.toolbar.SelectedTool.setCurrentTool;

public class GridSquare extends SpriteEntity implements MouseButtonPressedListener {
    private boolean isWalkable;


    public GridSquare(Coordinate2D initialLocation, Size size, Boolean isWalkable) {
        super("yaegerimages/twosquare.png", initialLocation, size, 1, 2);
        this.isWalkable = isWalkable;
        if(isWalkable){
            setCurrentFrameIndex(1);
        }else{
            setCurrentFrameIndex(0);
        }
    }

    @Override
    public void onMouseButtonPressed(MouseButton button, Coordinate2D coordinate2D) {
        if(!isWalkable){
            if(getCurrentTool() != ("nothing")){
                Coordinate2D gridLocatie = getLocationInScene();
                var archeryTower = new ComposingTower(gridLocatie, GridMap.squareSize, getCurrentTool());
                GameLevelScene.instance.addEntity(archeryTower);
                setCurrentTool("nothing");
            }
        }
    }
}