using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClickableTransparentOverlay;
using ImGuiNET;
using System.Numerics;
using System.Runtime.InteropServices;
namespace fovChanger
{
    public class Renderer : Overlay
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vkey); // GetAsyncKeyState

        private bool guiShown = true; // GUI - SHOWN
        private DateTime guiTime = DateTime.Now; // GUI - TIME
        private int guiHotkey = 0x2D; // GUI - default hotzkey

        private string appDirectory = AppContext.BaseDirectory; //get location

        private float sliderFloatVal = 0; // Class-level field
        private bool chechboxBolVal = true;

        protected override void Render()
        {
            if (GetAsyncKeyState(guiHotkey)<0)
            {
                guiShown = !guiShown;
                Thread.Sleep(100);
            }
            if (guiShown)
            {
                ImGui.Begin("Menu");
                ImGui.SetCursorPos(new Vector2(ImGui.GetWindowWidth() -75, 20));

                if (ImGui.Button("exit"))
                { 
                    Environment.Exit(0);
                }

                if (ImGui.Button("LOAD CONFIG"))
                {

                }
                ImGui.Text("loads config from location of the .exe");
                
                ImGui.SliderFloat("skbidi", ref sliderFloatVal, 0, 10);
                ImGui.Checkbox("toilet", ref chechboxBolVal);
                ImGui.End();
            }
        }
    }
}
// todo: hide/show keybind
// todo: create saving options into %TEMP%
// saving into choosen location