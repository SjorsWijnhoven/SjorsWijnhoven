package com.github.hanyaeger.game.entities.toolbar;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.CompositeEntity;
import com.github.hanyaeger.game.Game;

public  class ToolBar extends CompositeEntity {
    public ToolBar(Coordinate2D initialLocation) {
        super(initialLocation);
    }

    @Override
    protected void setupEntities() {
        addEntity(new ToolBarSprite("yaegerimages/Onderbalk.png", new Coordinate2D(0, 0), Game.sceneSize));

        ToolBarButton archeryButton = new ArcheryButton("yaegerimages/Archery_Button.png", new Coordinate2D((Game.sceneSize.width() / 32), (31 * Game.sceneSize.height() / 36)), new Size((Game.sceneSize.width() / 8), (Game.sceneSize.height()) / 9), 1, 2);
        ToolBarButton bombTowerButton = new BombTowerButton("yaegerimages/BombTower_Button.png", new Coordinate2D((4 * Game.sceneSize.width() / 32), (31 * Game.sceneSize.height() / 36)), new Size((Game.sceneSize.width() / 8), (Game.sceneSize.height()) / 9), 1, 2);

        addEntity(archeryButton);
        addEntity(bombTowerButton);
    }
}
