package com.github.hanyaeger.game.entities.enemy;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.game.entities.resourcesbar.HealthText;

public class Walker extends Enemy{
    public Walker(HealthText healthText, String resource, Coordinate2D initialLocation, Size size, int health, double speed, int attackDamage, int playerHealthDamage) {
        super(healthText, resource, initialLocation, size, health, speed, attackDamage, playerHealthDamage);
    }
}
