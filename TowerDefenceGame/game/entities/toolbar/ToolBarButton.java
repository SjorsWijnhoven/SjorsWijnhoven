package com.github.hanyaeger.game.entities.toolbar;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.impl.DynamicSpriteEntity;
import com.github.hanyaeger.api.userinput.MouseButtonPressedListener;
import com.github.hanyaeger.api.userinput.MouseEnterListener;
import com.github.hanyaeger.api.userinput.MouseExitListener;

public abstract class ToolBarButton extends DynamicSpriteEntity implements MouseButtonPressedListener, MouseEnterListener, MouseExitListener {


    protected ToolBarButton(String resource, Coordinate2D initialLocation, Size size, int rows, int columns) {
        super(resource, initialLocation, size, rows, columns);
        setCurrentFrameIndex(0);
    }

    @Override
    public void onMouseEntered() {
        setCurrentFrameIndex(1);
    }

    @Override
    public void onMouseExited() {
        setCurrentFrameIndex(0);
    }
}
