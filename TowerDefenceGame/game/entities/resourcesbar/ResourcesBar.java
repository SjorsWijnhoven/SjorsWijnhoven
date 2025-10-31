package com.github.hanyaeger.game.entities.resourcesbar;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.impl.SpriteEntity;

public class ResourcesBar extends SpriteEntity {
    public ResourcesBar(String resource, Coordinate2D initialLocation, Size size) {
        super(resource, initialLocation, size);
    }
}
