using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using static M05_UF3_P3_Frogger.Utils;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
       
        
            static void Main(string[] args)
            {
                            Lane[] lanes = new Lane[11];
                lanes[0] = new Lane(2, false, ConsoleColor.Green, true, false, 0f, Utils.charLogs, Utils.colorsLogs.ToList());
                lanes[1] = new Lane(3, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());
                lanes[2] = new Lane(4, false, ConsoleColor.Blue, true, false, .1f, Utils.charLogs, Utils.colorsLogs.ToList());
                lanes[3] = new Lane(5, false, ConsoleColor.Blue, true, false, .1f, Utils.charLogs, Utils.colorsLogs.ToList());
                lanes[4] = new Lane(6, false, ConsoleColor.Blue, true, false, .1f, Utils.charLogs, Utils.colorsLogs.ToList());
                lanes[5] = new Lane(7, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());
                lanes[6] = new Lane(8, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());
                lanes[7] = new Lane(9, false, ConsoleColor.Black, true, false, .1f, Utils.charCars, Utils.colorsLogs.ToList());
                lanes[8] = new Lane(10, false, ConsoleColor.Black, true, false, .1f, Utils.charCars, Utils.colorsLogs.ToList());
                lanes[9] = new Lane(11, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());
                lanes[10] = new Lane(12, false, ConsoleColor.Green, true, false, 0f, Utils.charCars, Utils.colorsLogs.ToList());

                Player player = new Player();
                Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

                while (gameState == Utils.GAME_STATE.RUNNING)
                {
                    Vector2Int dir = Utils.Input();
                    gameState = player.Update(dir, lanes.ToList());
                    TimeManager.NextFrame();
                    Console.Clear();
                    foreach (var lane in lanes)
                    {
                        lane.Update();
                        lane.Draw();
                        if (lane.posY == player.pos.y)
                        {
                            player.Draw(lane.background);
                        }
                    if (player.pos.y == 0)
                    {
                        Console.SetCursorPosition(0, Utils.MAP_HEIGHT + 1);
                        Console.WriteLine("¡Ganaste!");
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        gameState = Utils.GAME_STATE.WIN;
                    }
                    if (gameState == Utils.GAME_STATE.LOOSE)
                    {
                        Console.SetCursorPosition(0, Utils.MAP_HEIGHT + 1);
                        Console.WriteLine("Perdiste");
                        Console.ForegroundColor = ConsoleColor.White;
                       
                    }

                }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }




        
    }

}