package com.github.hanyaeger.game.entities.projectiles;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.entities.Collided;
import com.github.hanyaeger.api.entities.Collider;
import com.github.hanyaeger.api.entities.SceneBorderCrossingWatcher;
import com.github.hanyaeger.api.entities.impl.DynamicSpriteEntity;
import com.github.hanyaeger.api.scenes.SceneBorder;
import com.github.hanyaeger.game.entities.enemy.Enemy;

import java.util.List;

public abstract class Bullet extends DynamicSpriteEntity implements Collider, Collided, SceneBorderCrossingWatcher {

    protected int damage;
    protected double speed;
    protected double direction;
    protected Coordinate2D coordinate2D;
    protected Bullet(String resource, Coordinate2D initialLocation, double speed, double direction, int damage) {
        super(resource, initialLocation);
        this.speed = speed;
        this.direction = direction;
        setMotion(speed, direction);
        coordinate2D = initialLocation;
        this.damage = damage;
    }

    @Override
    public void onCollision(List<Collider> collidingObjects) {
        for(Collider collider : collidingObjects) {
            if(collider instanceof Enemy){
                remove();
            }
        }
    }

    @Override
    public void notifyBoundaryCrossing(SceneBorder border) {
        remove();
    }

    public int getDamage() {
        return damage;
    }
}
