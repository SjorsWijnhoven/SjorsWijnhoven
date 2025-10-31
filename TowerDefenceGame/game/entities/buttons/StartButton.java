package com.github.hanyaeger.game.entities.buttons;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.game.Game;
import javafx.scene.input.MouseButton;

public class StartButton extends Button{
    private Game game;
    public StartButton(Game game, Coordinate2D initialLocation) {
        super(game, initialLocation);
        this.game = game;

        setText("Start Spel");
    }

    public StartButton(Game game, Coordinate2D initialLocation, String buttontext) {
        super(game, initialLocation);
        this.game = game;

        setText(buttontext);
    }

    @Override
    public void onMouseButtonPressed(MouseButton button, Coordinate2D coordinate2D) {
        game.setActiveScene(101);
    }
}
