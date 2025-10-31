package com.github.hanyaeger.game.entities.projectiles;

import com.github.hanyaeger.api.Coordinate2D;


public class Arrow extends Bullet{
    public Arrow(Coordinate2D initialLocation, double speed, double direction) {
        super("yaegerimages/Arrow.png", initialLocation, speed, direction, 1);
    }


}
