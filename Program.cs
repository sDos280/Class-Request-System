using Raylib_CsLo;

namespace Class_Request_System
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Raylib.InitWindow(1280, 720, "Hello, Raylib-CsLo");
            Grid grid = new Grid();
            grid.Initialized();
            Raylib.SetTargetFPS(60);
            // Main game loop
            while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.RAYWHITE);
                if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
                {
                    grid.SetTileClass(Raylib.GetMousePosition(), new Class(Class.GetClassCategoriesByPosition(Raylib.GetMousePosition()).Item2));
                }
                else if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))
                {
                    grid.SetTileClass(Raylib.GetMousePosition(),
                        new Class(Class.ClassState.Used, "math",
                            Class.GetClassCategoriesByPosition(Raylib.GetMousePosition()).Item2, "me", "hello"));
                }/*else if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_MIDDLE))
                {
                    grid.SetTileState(Raylib.GetMousePosition(), Grid.ClassRoomState.Requested);
                }*/
                
                grid.Draw();
                Raylib.EndDrawing();
            }
            grid.Uninitialized();
            Raylib.CloseWindow();
        }
    }
}