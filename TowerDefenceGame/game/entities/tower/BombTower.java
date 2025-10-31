package com.github.hanyaeger.game.entities.tower;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;

public class BombTower extends Tower{
    protected BombTower(Coordinate2D coordinate, Size size, int cost, int actionSpeed, int range) {
        super("yaegerimages/BombTower.png", coordinate, size, cost, actionSpeed, range);
        setAnchorPoint(AnchorPoint.CENTER_CENTER);
    }
}
