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
        private int? guiLastPressedKey = null; // GUI - last pressed key
        private float sliderFloatVal = 0; // Class-level field
        private bool hotkeyChanging = false;
        private string hotkeyString = "change hotkey";

        protected override void Render()
        {
            if (GetAsyncKeyState(0x2D)<0)
            {
                guiShown = !guiShown;
                Thread.Sleep(100);
            }
            if (guiShown && hotkeyChanging == false)
            {
                ImGui.Begin("Menu");
                ImGui.SetCursorPos(new Vector2(ImGui.GetWindowWidth() -75, 20));
                if (ImGui.Button("exit"))
                {
                    Environment.Exit(0);
                }
                if (ImGui.Button(hotkeyString))
                {
                    hotkeyChanging = true;
                    hotkeyString = "waiting for input";
                    // after press with user32.dll
                    /*GetAsyncKeyState();                
                    hotkeyString = $"hotkey: {vkey}";*/



                }
                ImGui.Text("Entity colors:");
                ImGui.ColorButton("Friendly players",new Vector4(0.0f, 0.0f, 1.0f, 1.0f)); // friendly
                ImGui.ColorButton("Enemy players", new Vector4(1.0f, 0.0f, 0.0f, 1.0f)); // enemy
                ImGui.ColorButton("Whitelisted players", new Vector4(1.0f, 1.0f, 1.0f, 1.0f)); // whitelist

                if (ImGui.Button("Click Me")) // Creating button
                {
                    Console.WriteLine($"[{guiTime}] Button \"Click Me\" clicked..");
                }

                if (ImGui.IsItemHovered())
                {
                    // The button is being hovered
                    ImGui.SetTooltip("This is a button. Click to perform an action.");
                }

                ImGui.LabelText("abc", "def");
                ImGui.SliderFloat("skbidi", ref sliderFloatVal, 0, 10);
                ImGui.End();
            }
        }
    }
}
// todo: hide/show keybind
// todo: create saving options into %TEMP%
// saving into choosen location
//saving logs fron console
// and loggin it all into console