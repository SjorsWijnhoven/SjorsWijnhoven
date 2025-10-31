package com.github.hanyaeger.game.entities.tower;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.CompositeEntity;
import com.github.hanyaeger.game.gamemap.GridMap;

public class ComposingTower extends CompositeEntity {
    private String towerType;
    private  Coordinate2D coordinate2D;
    private Size size;
    public ComposingTower(Coordinate2D coordinate2D, Size size, String towerType){
        super(coordinate2D);
        this.coordinate2D = coordinate2D;
        this.size = size;
        this.towerType = towerType;
    }
    @Override
    protected void setupEntities() {
        switch (towerType) {
            case "archeryTower" -> {
                var archeryTower = new ArcheryTower(new Coordinate2D(GridMap.squareSize.width() / 2, GridMap.squareSize.height() / 2), size, 50, 500, 150);
                addEntity(archeryTower);
                var archeryHitbox = new TowerHitbox(new Coordinate2D((-(archeryTower.range)) / 3, (-(archeryTower.range)) / 3), archeryTower.range, archeryTower.actionSpeed, new Coordinate2D((coordinate2D.getX() + GridMap.squareSize.width() / 2), (coordinate2D.getY() + GridMap.squareSize.height() / 2)), "archeryTower");
                addEntity(archeryHitbox);
            }
            case "bombTower" -> {
                var bombTower = new BombTower(new Coordinate2D(GridMap.squareSize.width() / 2, GridMap.squareSize.height() / 2), size, 70, 800, 180);
                addEntity(bombTower);
                var bombTowerHitbox = new TowerHitbox(new Coordinate2D((-(bombTower.range)) / 3, (-(bombTower.range)) / 3), bombTower.range, bombTower.actionSpeed, new Coordinate2D((coordinate2D.getX() + GridMap.squareSize.width() / 2), (coordinate2D.getY() + GridMap.squareSize.height() / 2)), "bombTower");
                addEntity(bombTowerHitbox);
            }
        }
    }
}
