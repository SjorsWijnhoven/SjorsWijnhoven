package com.github.hanyaeger.game.entities.tower;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.entities.Collided;
import com.github.hanyaeger.api.entities.Collider;
import com.github.hanyaeger.api.entities.impl.CircleEntity;
import com.github.hanyaeger.game.entities.enemy.Enemy;
import com.github.hanyaeger.game.entities.projectiles.Arrow;
import com.github.hanyaeger.game.entities.projectiles.Bomb;
import com.github.hanyaeger.game.entities.projectiles.Bullet;
import com.github.hanyaeger.game.scenes.GameLevelScene;
import com.github.hanyaeger.game.timer.EigenTimer;
import javafx.scene.paint.Color;

import java.util.List;

public class TowerHitbox extends CircleEntity implements Collided {
    private String towerType;
    private EigenTimer timer;
    final private Coordinate2D shotLocation;
    protected TowerHitbox(Coordinate2D initialLocation, double range, int actionSpeed, Coordinate2D shotLocation, String towerType) {
        super(initialLocation);
        this.shotLocation = shotLocation;
        this.towerType = towerType;

        this.timer = new EigenTimer(actionSpeed);

        setRadius(range);
        setAnchorPoint(AnchorPoint.TOP_LEFT);
        setFill(Color.TRANSPARENT);

    }

    @Override
    public void onCollision(List<Collider> collidingObjects) {
        for(Collider collider: collidingObjects){
            if(collider instanceof Enemy){
                if(timer.intervalIsOver()){
                    switch(towerType) {
                        case "archeryTower" -> GameLevelScene.instance.addEntity(shootBullet(angleTo(((Enemy) collider).getAnchorLocation()), "arrow"));
                        case "bombTower" -> GameLevelScene.instance.addEntity(shootBullet(angleTo(((Enemy) collider).getAnchorLocation()), "bomb"));
                        default -> GameLevelScene.instance.addEntity(shootBullet(angleTo(((Enemy) collider).getAnchorLocation()), "arrow"));
                    }
                }
            }
        }
    }

    public Bullet shootBullet(double direction, String bulletType){
        switch (bulletType) {
            case "arrow" -> {
                return new Arrow(shotLocation, 20, direction);
            }
            case "bomb" -> {
                return new Bomb(shotLocation, 15, direction);
            }
            default -> {
                return new Arrow(shotLocation, 20, direction);
            }
        }
    }
}
