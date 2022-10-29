using System.Numerics;
using Raylib_CsLo;

namespace Class_Request_System;
public class Grid
{
    /// <summary>
    /// hold all of the classes(rooms) data
    /// note: the drawing of the grid should be looking like excel in the end 
    /// </summary>
    

    public Class[,] Classes = new Class[Class.RowCategories.Length, Class.ColumnCategories.Length];  // to accuses tile use [row, column]

    // setting some raylib variables
    private const int GridRenderTextureWidth = 1000;
    private const int GridRenderTextureHeight = 720;
    private readonly RenderTexture _gridRenderTexture = Raylib.LoadRenderTexture(GridRenderTextureWidth, GridRenderTextureHeight);
    private const int RequestRenderTextureWidth = 280;
    private const int RequestRenderTextureHeight = 720;
    private readonly RenderTexture _requestRenderTexture = Raylib.LoadRenderTexture(GridRenderTextureWidth, GridRenderTextureHeight);
    
    // each tile in the grid have size
    public static readonly int TileSizeX = GridRenderTextureWidth / (Class.ColumnCategories.Length + 1);
    public static readonly int TileSizeY = GridRenderTextureHeight / (Class.RowCategories.Length + 1);

    public static readonly Vector2 GridOffset = new Vector2(0, 0);
    public static readonly Vector2 GridTilesOffset = new Vector2(TileSizeX, TileSizeY);
    private static readonly Vector2 RequestOffset = new Vector2(GridRenderTextureWidth, 0);

    public void SetTileClass(Vector2 position, Class @class)
    {
        if (0 <= (position.X - GridTilesOffset.X - GridOffset.X) / TileSizeX && (position.X - GridTilesOffset.X - GridOffset.X) / TileSizeX < Class.ColumnCategories.Length &&
            0 <= (position.Y - GridTilesOffset.Y - - GridOffset.Y) / TileSizeY && (position.Y - GridTilesOffset.Y - - GridOffset.Y) / TileSizeY < Class.RowCategories.Length)
        {
            Classes[(int)(position.Y - GridTilesOffset.Y - - GridOffset.Y) / TileSizeY, (int)(position.X - GridTilesOffset.X - GridOffset.X) / TileSizeX] = @class;
        }
    }
    
    public void SetTileClass(int row, int column, Class @class)
    {
        if (0 <= row && row < Class.RowCategories.Length &&
            0 <= column && column < Class.ColumnCategories.Length)
        {
            Classes[row, column] = @class;
        }
    }

    private void DrawTiles()
    {
        Raylib.BeginTextureMode(_gridRenderTexture);
        for (int row = 0; row < Class.RowCategories.Length; row++)
        {
            for (int column = 0; column < Class.ColumnCategories.Length; column++)
            {
                Raylib.DrawRectangle((int)GridTilesOffset.X + column*TileSizeX, (int)GridTilesOffset.Y + row*TileSizeY, TileSizeX, TileSizeY, Class.ClassRoomStateColor[Classes[row, column].State]);
            }
        }
        Raylib.EndTextureMode();
    }
    
    private void DrawTilesLabels()
    {
        Raylib.BeginTextureMode(_gridRenderTexture);
        for (int column = 0; column < Class.ColumnCategories.Length; column++)
        {
            Raylib.DrawText(Class.ColumnCategories[column], (column + 1)*TileSizeX, 0, 14, Raylib.BLACK);
        }

        for (int row = 0; row < Class.RowCategories.Length; row++)
        {
            Raylib.DrawText(Class.RowCategories[row], 0, (row + 1)*TileSizeY, 14, Raylib.BLACK);
        }
        Raylib.EndTextureMode();
    }

    private void DrawRequestData()
    {
        Raylib.BeginTextureMode(_requestRenderTexture);
        Raylib.ClearBackground(Raylib.BLACK);
        Raylib.EndTextureMode();
    }
    
    public void Draw()
    {
        DrawTilesLabels();
        DrawTiles();
        DrawRequestData();
        Raylib.DrawTextureRec(_gridRenderTexture.texture, new Rectangle(0, 0, GridRenderTextureWidth, -GridRenderTextureHeight), GridOffset, Raylib.WHITE);
        Raylib.DrawTextureRec(_requestRenderTexture.texture, new Rectangle(0, 0, RequestRenderTextureWidth, -RequestRenderTextureHeight), RequestOffset, Raylib.WHITE);
    }

    public void Initialized()
    {
        for (int row = 0; row < Class.RowCategories.Length; row++)
        {
            for (int column = 0; column < Class.ColumnCategories.Length; column++)
            {
                Classes[row, column] = new Class(Class.RowCategories[row]);
            }
        }
    }

    public void Uninitialized()
    {
        Raylib.UnloadRenderTexture(_gridRenderTexture);
        Raylib.UnloadRenderTexture(_requestRenderTexture);
    }
    
    
}