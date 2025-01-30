// add clickabletransparentoverlay nuget package
using fovChanger;
// https://www.youtube.com/watch?v=5yVpcJo_jjs


Renderer renderer = new Renderer();
Thread renderThread = new Thread(renderer.Start().Wait);
renderThread.Start();