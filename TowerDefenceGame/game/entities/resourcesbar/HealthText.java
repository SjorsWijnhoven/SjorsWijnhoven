package com.github.hanyaeger.game.entities.resourcesbar;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.entities.impl.TextEntity;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;

public class HealthText extends TextEntity {

    public static HealthText healthText;
    public HealthText(Coordinate2D initialLocation) {
        super(initialLocation);
        healthText = this;

        setAnchorPoint(AnchorPoint.CENTER_CENTER);
        setFill(Color.WHITE);
        setFont(Font.font("Roboto", FontWeight.BOLD, 30));
    }

    public void displayHealth (int playerHealth){
        setText("" + playerHealth);
    }
}
