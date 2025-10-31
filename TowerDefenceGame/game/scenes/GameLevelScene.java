package com.github.hanyaeger.game.scenes;

import com.github.hanyaeger.api.Coordinate2D;
import com.github.hanyaeger.api.EntitySpawnerContainer;
import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.entities.YaegerEntity;
import com.github.hanyaeger.api.scenes.DynamicScene;
import com.github.hanyaeger.api.scenes.TileMapContainer;
import com.github.hanyaeger.api.UpdateExposer;
import com.github.hanyaeger.game.Game;
import com.github.hanyaeger.game.entities.enemy.Enemy;
import java.util.ArrayList;
import java.util.Arrays;
import com.github.hanyaeger.game.entities.resourcesbar.HealthText;
import com.github.hanyaeger.game.entities.resourcesbar.ResourcesBar;
import com.github.hanyaeger.game.entities.toolbar.ToolBar;
import com.github.hanyaeger.game.gamemap.GridMap;
import com.github.hanyaeger.game.spawners.EnemySpawner;

public class GameLevelScene extends DynamicScene implements TileMapContainer, EntitySpawnerContainer, UpdateExposer {
    public static GameLevelScene instance;
    public static Game game;
    public static HealthText healthText;

    public static ArrayList<Enemy> enemies = new ArrayList<>();
    public GameLevelScene(Game game){
        instance = this;
        healthText = new HealthText(new Coordinate2D(80, 40));
        this.game = game;

    }
    @Override
    public void addEntity(YaegerEntity entity){
        super.addEntity(entity);
    }


    @Override
    public void setupScene() {
        setBackgroundImage("yaegerimages/levelbackground.jpg");
    }

    @Override
    public void setupEntities() {
        addEntity(new ResourcesBar("yaegerimages/Resources_Balk.png", new Coordinate2D(0, 0), new Size(400, 80)));
        addEntity(healthText);
        addEntity(new ToolBar(new Coordinate2D(0, 0)));

        for(int i = 0; i < EnemySpawner.waves.length; i++) {
            enemies.addAll(Arrays.asList(EnemySpawner.waves[i]));
        }
    }


    @Override
    public void setupTileMaps() {
        addTileMap(new GridMap());
    }


    @Override
    public void setupEntitySpawners() {
        addEntitySpawner(new EnemySpawner());
    }

    @Override
    public void explicitUpdate(long timestamp) {
        for(Enemy enemy : enemies) {
            enemy.move();
        }
    }


}
