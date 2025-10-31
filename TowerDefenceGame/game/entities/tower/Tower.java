package com.github.hanyaeger.game.entities.tower;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.impl.SpriteEntity;

public abstract class Tower extends SpriteEntity {
    protected int cost;
    protected int actionSpeed;
    protected double range;

    protected Tower(String imageSource, Coordinate2D coordinate, Size size, int cost, int actionSpeed, int range){
        super(imageSource, coordinate, size);
        this.cost = cost;
        this.actionSpeed = actionSpeed;
        this.range = range;
    }
}
