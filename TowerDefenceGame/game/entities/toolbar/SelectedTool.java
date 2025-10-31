package com.github.hanyaeger.game.entities.toolbar;

public class SelectedTool {
    private static String currentTool = "nothing";

    public static String getCurrentTool(){
        return currentTool;
    }

    public static void setCurrentTool(String tool){
        currentTool = tool;
    }
}
