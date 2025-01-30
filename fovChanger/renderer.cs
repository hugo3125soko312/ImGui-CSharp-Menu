using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClickableTransparentOverlay;
using ImGuiNET;
namespace fovChanger
{
    public class Renderer : Overlay
    {
        private float sliderFloatVal = 0; // Class-level field
        private bool btnClicked = false;
        private float labelTimer = 0.0f; // Timer to control label display duration

        protected override void Render()
        {
            ImGui.Begin("ImguiWindow");
            ImGui.Text("skbidi toilet");

            if (ImGui.Button("Click Me")) // Creating button
            {
                btnClicked = true;
                labelTimer = 3.0f; // Set timer to 3 seconds
            }

            if (btnClicked) // Handling creation of label
            {
                ImGui.LabelText("sbkidid", "sbkdidi");
                labelTimer -= ImGui.GetIO().DeltaTime; // Decrease timer by frame time
                if (labelTimer <= 0.0f)
                {
                    btnClicked = false; // Hide label after 5 seconds
                }
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

