package com.github.hanyaeger.game.spawners;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.EntitySpawner;
import com.github.hanyaeger.game.entities.enemy.Bombardier;
import com.github.hanyaeger.game.entities.enemy.Enemy;
import com.github.hanyaeger.game.entities.enemy.Walker;
import com.github.hanyaeger.game.gamemap.GridMap;
import com.github.hanyaeger.game.scenes.GameLevelScene;

import java.util.Random;

public class EnemySpawner extends EntitySpawner {
    final public static Enemy[][] waves = new Enemy[][]{
            {createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie")},
            {createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie")},
            {createEnemy("zombie"), createEnemy("zombie"), createEnemy("bombardier")},
            {createEnemy("zombie"), createEnemy("zombie")},
            {createEnemy("zombie")},
            {createEnemy("bombardier")},
            {createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie")},
            {createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie")},
            {createEnemy("zombie"), createEnemy("zombie")},
            {createEnemy("zombie")},
            {createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie"), createEnemy("zombie")},
            {createEnemy("bombardier")},
    };
    private int currentWave = 0;
    public static boolean isDoneSpawning = false;
    public EnemySpawner() {
        super(2000);
    }

    private static Enemy createEnemy(String enemyName) {
        Enemy enemy;
        switch(enemyName) {
            case "zombie" -> enemy = new Walker(GameLevelScene.healthText, "yaegerimages/WalkerZombie.png", new Coordinate2D(new Random().nextDouble(-40, -20), new Random().nextDouble((GameLevelScene.instance.getHeight() / 2 - 40), (GameLevelScene.instance.getHeight() / 2 + 30))), new Size(2 * GridMap.squareSize.width() / 3, 2 * GridMap.squareSize.width() / 3),1, 2, 1, 1);
            case "bombardier" -> enemy = new Bombardier(GameLevelScene.healthText, "yaegerimages/Bombardier.png", new Coordinate2D(new Random().nextDouble(-40, -20), new Random().nextDouble((GameLevelScene.instance.getHeight() / 2 - 40), (GameLevelScene.instance.getHeight() / 2 + 30))), new Size(2 * GridMap.squareSize.width() / 3, 2 * GridMap.squareSize.height() / 3), 1, 1.5, 1, 3);
            default -> enemy = new Walker(GameLevelScene.healthText, "yaegerimages/WalkerZombie.png", new Coordinate2D(new Random().nextDouble(-40, -20), new Random().nextDouble((GameLevelScene.instance.getHeight() / 2 - 40), (GameLevelScene.instance.getHeight() / 2 + 30))), new Size(2 * GridMap.squareSize.width() / 3, 2 * GridMap.squareSize.width() / 3),1, 2, 1, 1);
        }
        return enemy;
    }


    @Override
    protected void spawnEntities() {
        if(currentWave < waves.length) {
            for(int i = 0; i < waves[currentWave].length; i++) {
                spawn(waves[currentWave][i]);
            }
        }
        currentWave++;
        if(currentWave >= waves.length){
            isDoneSpawning = true;
        }
    }
}