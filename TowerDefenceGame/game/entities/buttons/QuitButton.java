package com.github.hanyaeger.game.entities.buttons;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.game.Game;
import javafx.scene.input.MouseButton;

public class QuitButton extends Button{
    public QuitButton(Game game, Coordinate2D initialLocation) {
        super(game, initialLocation);

        setText("Beëindig Spel");
    }

    @Override
    public void onMouseButtonPressed(MouseButton button, Coordinate2D coordinate2D) {
        game.quit();
    }
}
