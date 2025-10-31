package com.github.hanyaeger.game.entities.projectiles;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.entities.Collider;
import com.github.hanyaeger.game.entities.enemy.Enemy;
import com.github.hanyaeger.game.gamemap.GridMap;
import com.github.hanyaeger.game.scenes.GameLevelScene;

import java.util.List;

public class Bomb extends Bullet{
    public Bomb(Coordinate2D initialLocation, double speed, double direction) {
        super("yaegerimages/Bomb.png", initialLocation, speed, direction, 3);
        setAnchorPoint(AnchorPoint.CENTER_CENTER);
    }

    public void explode() {
        GameLevelScene.instance.addEntity(new Explosion("yaegerimages/Explosion.png", getLocationInScene(), GridMap.squareSize, damage));
    }

    @Override
    public void onCollision(List<Collider> collidingObjects) {
        super.onCollision(collidingObjects);
        for(Collider collider : collidingObjects) {
            if(collider instanceof Enemy) {
                explode();
                remove();
            }
        }
    }
}
