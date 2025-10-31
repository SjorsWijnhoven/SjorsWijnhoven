package com.github.hanyaeger.game.entities.projectiles;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.UpdateExposer;
import com.github.hanyaeger.api.entities.Collider;
import com.github.hanyaeger.api.entities.impl.DynamicSpriteEntity;
import com.github.hanyaeger.game.timer.EigenTimer;

public class Explosion extends DynamicSpriteEntity implements Collider, UpdateExposer {
    private int damage;
    private EigenTimer timer;
    public Explosion(String resource, Coordinate2D initialLocation, Size size, int damage) {
        super(resource, initialLocation, size);
        this.damage = damage;

        this.timer = new EigenTimer(1000);
        setAnchorPoint(AnchorPoint.CENTER_CENTER);
    }

    private void delete(EigenTimer timer) {
        if(timer.intervalIsOver()){
            remove();
        }
    }


    @Override
    public void explicitUpdate(long timestamp) {
        delete(timer);
    }

    public int getDamage() {
        return damage;
    }
}
