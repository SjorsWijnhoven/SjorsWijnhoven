package com.github.hanyaeger.game.entities.enemy;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.game.entities.resourcesbar.HealthText;
import com.github.hanyaeger.game.entities.projectiles.Bomb;
import com.github.hanyaeger.game.scenes.GameLevelScene;

public class Bombardier extends Enemy{
    public Bombardier(HealthText healthText, String resource, Coordinate2D initialLocation, Size size, int health, double speed, int attackDamage, int playerHealthDamage) {
        super(healthText, resource, initialLocation, size, health, speed, attackDamage, playerHealthDamage);
    }

    @Override
    public void die() {
        GameLevelScene.instance.addEntity(new Bomb(getLocationInScene(), 0, 0d));
        remove();
        GameLevelScene.enemies.remove(this);
    }
}
