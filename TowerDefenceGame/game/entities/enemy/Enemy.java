package com.github.hanyaeger.game.entities.enemy;

import com.github.hanyaeger.api.AnchorPoint;
import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.Collided;
import com.github.hanyaeger.api.entities.Collider;
import com.github.hanyaeger.api.entities.SceneBorderCrossingWatcher;
import com.github.hanyaeger.api.entities.impl.DynamicSpriteEntity;
import com.github.hanyaeger.api.scenes.SceneBorder;
import com.github.hanyaeger.game.entities.projectiles.Arrow;
import com.github.hanyaeger.game.entities.projectiles.Explosion;
import com.github.hanyaeger.game.entities.resourcesbar.HealthText;
import com.github.hanyaeger.game.gamemap.GridMap;
import com.github.hanyaeger.game.scenes.GameLevelScene;
import com.github.hanyaeger.game.spawners.EnemySpawner;

import java.util.List;

public abstract class Enemy extends DynamicSpriteEntity implements SceneBorderCrossingWatcher, Collider, Collided {
    public int health;
    protected double speed;
    protected int attackDamage;
    protected int playerHealthDamage;
    protected Coordinate2D location;
    private int iX;
    private int iY;

    public static HealthText healthText;
    private static int playerHealth = 25;

    protected Enemy(HealthText healthText, String resource, Coordinate2D initialLocation, Size size, int health, double speed, int attackDamage, int playerHealthDamage) {
        super(resource, initialLocation, size);
        this.healthText = healthText;
        this.health = health;
        this.speed = speed;
        this.attackDamage = attackDamage;
        this.playerHealthDamage = playerHealthDamage;

        healthText.displayHealth(playerHealth);
        
        location = getLocationInScene();
        iX = (int)((distanceTo(new Coordinate2D(0, location.getY())) - (GridMap.squareSize.width()) / 2) / GridMap.squareSize.width());
        iY = (int)((distanceTo(new Coordinate2D(location.getX(), 0)) - (GridMap.squareSize.height()) / 2) / GridMap.squareSize.height());
        setSpeed(speed);
        setAnchorPoint(AnchorPoint.CENTER_CENTER);
    }
    
    public void move() {
        iX = (int)(distanceTo(new Coordinate2D(0, location.getY()))  / GridMap.squareSize.width());
        iY = (int)(distanceTo(new Coordinate2D(location.getX(), 0))  / GridMap.squareSize.height());

        if(iX > GridMap.gridMap[0].length - 1 || iX < 0)
            iX = 0;
        if(iY > GridMap.gridMap.length - 1 || iY < 0)
            iY = 0;

        switch (GridMap.gridMap[iY][iX]) {
            case 3 -> setDirection(270);
            case 4 -> setDirection(90);
            case 5 -> setDirection(180);
            case 6 -> setDirection(0);
        }
    location = getLocationInScene();
    }

    protected void die() {
            remove();
            GameLevelScene.enemies.remove(this);
    }

    @Override
    public void onCollision(List<Collider> collidingObjects) {
        for(Collider collider : collidingObjects) {

            if(collider instanceof Arrow) {
                health -= ((Arrow)collider).getDamage();
            } else if (collider instanceof Explosion) {
                health -= ((Explosion)collider).getDamage();
            }
        }
        if(health <= 0) {
            die();
            
            if(GameLevelScene.enemies.size() == 0 && EnemySpawner.isDoneSpawning == true){
                GameLevelScene.game.setActiveScene(202);
            }
        }
    }

    @Override
    public void notifyBoundaryCrossing(SceneBorder border) {
        playerHealth -= playerHealthDamage;
        healthText.displayHealth(playerHealth);
        remove();
        GameLevelScene.enemies.remove(this);
        if(playerHealth <= 0){
            GameLevelScene.game.setActiveScene(201);
        }else if(GameLevelScene.enemies.size() == 0 && EnemySpawner.isDoneSpawning == true){
            GameLevelScene.game.setActiveScene(202);
        }

    }
}
