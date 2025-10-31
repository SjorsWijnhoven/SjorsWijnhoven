package com.github.hanyaeger.game.entities.toolbar;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import javafx.scene.input.MouseButton;

import static com.github.hanyaeger.game.entities.toolbar.SelectedTool.getCurrentTool;
import static com.github.hanyaeger.game.entities.toolbar.SelectedTool.setCurrentTool;

public class BombTowerButton extends ToolBarButton{
    protected BombTowerButton(String resource, Coordinate2D initialLocation, Size size, int rows, int columns) {
        super(resource, initialLocation, size, rows, columns);
    }

    @Override
    public void onMouseButtonPressed(MouseButton button, Coordinate2D coordinate2D) {
        setCurrentTool("bombTower");
    }
}
