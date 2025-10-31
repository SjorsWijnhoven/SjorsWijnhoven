package com.github.hanyaeger.game.entities.buttons;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.entities.impl.TextEntity;
import com.github.hanyaeger.api.userinput.MouseButtonPressedListener;
import com.github.hanyaeger.api.userinput.MouseEnterListener;
import com.github.hanyaeger.api.userinput.MouseExitListener;
import com.github.hanyaeger.game.Game;
import javafx.scene.Cursor;
import javafx.scene.input.MouseButton;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;

public abstract class Button extends TextEntity implements MouseButtonPressedListener, MouseEnterListener, MouseExitListener {
    protected Game game;
    public Button(Game game, Coordinate2D initialLocation) {
        super(initialLocation);
        this.game = game;

        setAnchorPoint(AnchorPoint.CENTER_CENTER);
        setFill(Color.WHITE);
        setFont(Font.font("Roboto", FontWeight.BOLD, 30));
    }

    @Override
    public abstract void onMouseButtonPressed(MouseButton button, Coordinate2D coordinate2D);

    @Override
    public void onMouseEntered() {
        setFill(Color.RED);
        setCursor(Cursor.HAND);
    }

    @Override
    public void onMouseExited() {
        setFill(Color.WHITE);
        setCursor(Cursor.DEFAULT);
    }
}
