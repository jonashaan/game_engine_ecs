using System;
using engine.interfaces;


namespace engine.components;

public class SettingsComponent : IComponent
{
    public int WindowWidth { get; set; } = 800;
    public int WindowHeight { get; set; } = 600;
    public bool FullScreen { get; set; } = false;
    public bool LimitFps { get; set; } = true;
    public int Fps { get; set; } = 60;
    public string WindowTitle { get; set; } = "Engine";
    public bool Debug { get; set; } = false;
}