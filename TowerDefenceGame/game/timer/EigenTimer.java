package com.github.hanyaeger.game.timer;

import static java.lang.System.currentTimeMillis;

public class EigenTimer {
    public long prevMs;
    public long interval;

    public EigenTimer(int interval){
        this.interval = interval;
        prevMs = currentTimeMillis();
    }

    public long getMs() {
        return currentTimeMillis();
    }


    public boolean intervalIsOver(){
        if(currentTimeMillis() - prevMs >= interval){
            prevMs = currentTimeMillis();
            return true;
        }
        return false;
    }
}
