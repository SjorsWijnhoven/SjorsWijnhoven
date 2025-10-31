package com.github.hanyaeger.game;

import com.github.hanyaeger.api.Size;
import com.github.hanyaeger.api.YaegerGame;
import com.github.hanyaeger.game.scenes.GameLevelScene;
import com.github.hanyaeger.game.scenes.GameOverScene;
import com.github.hanyaeger.game.scenes.TitleScene;
import com.github.hanyaeger.game.scenes.WinnerScene;

public class Game extends YaegerGame {
    public static Size sceneSize;

    public static void main (String[] args) {launch(args);}

    @Override
    public void setupGame() {
        setGameTitle("Tower Defender");

        sceneSize = new Size(1920, 1080);
        setSize(sceneSize);
    }

    @Override
    public void setupScenes() {

        addScene(0, new TitleScene(this));
        addScene(101, new GameLevelScene(this));
        addScene(201, new GameOverScene(this));
        addScene(202, new WinnerScene(this));
    }
}