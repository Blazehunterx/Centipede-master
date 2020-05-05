//using System;
//using System.Timers;

//public class Timer : GameObject {
//    Timer lTimer = new Timer();
//    uint lTicks = 0;
//    static uint MAX_TICKS = 50;

//    private void InitTimer() {
//        lTimer = new Timer();
//        lTimer.Interval = 2000;
//        lTimer.Tick += new EventHandler(Timer_Tick);
//        lTimer.Start();
//    }
//    void Timer_Tick(object sender, EventArgs e) {
//        lTicks++;
//        if (lTicks <= MAX_TICKS) {
//            //do whatever you want to do
//        }
//    }
//}