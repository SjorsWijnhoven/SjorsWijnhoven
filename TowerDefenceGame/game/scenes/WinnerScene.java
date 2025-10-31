package com.github.hanyaeger.game.scenes;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.entities.impl.TextEntity;
import com.github.hanyaeger.api.scenes.StaticScene;
import com.github.hanyaeger.game.Game;
import com.github.hanyaeger.game.entities.buttons.QuitButton;
import com.github.hanyaeger.game.entities.buttons.StartButton;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;

public class WinnerScene extends StaticScene {
    private Game game;

    public WinnerScene(Game game) {
        this.game = game;
    }
    @Override
    public void setupScene() {
        setBackgroundImage("yaegerimages/winningbackground.jpg");
    }

    @Override
    public void setupEntities() {
        //TODO Titel toevoegen
        var titleText = new TextEntity(
                new Coordinate2D(getWidth() / 2, getHeight() / 2), "You Defended The Tower"
        );
        titleText.setAnchorPoint(AnchorPoint.CENTER_CENTER);
        titleText.setFill(Color.WHITE);
        titleText.setFont(Font.font("Roboto", FontWeight.BOLD,80));
        addEntity(titleText);

        addEntity(new StartButton(game, new Coordinate2D(getWidth() / 2, (getHeight() / 2) + 80), "Nog een keertje"));
        addEntity(new QuitButton(game, new Coordinate2D(getWidth() / 2, (getHeight() / 2) + 120)));
    }
}

