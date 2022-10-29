using System.Numerics;
using Raylib_CsLo;

namespace Class_Request_System;

public class Class
{
    /// <summary>
    /// a C# class for the classes(rooms) with the some data
    /// </summary>
    
    // categories for each class, ColumnCategories => room number(room place), RowCategories => hours of use(time)
    public static readonly string[] ColumnCategories = { "101", "102", "103", "104", "105", "106", "107", "201", "202", "203", "204", "205", "206", "207", "208", "I1", "I2", "I3", "High\nSchool \n1", "High\nSchool \n2" };
    public static readonly string[] RowCategories = { "7:00-\n8:00", "8:00-\n9:00", "9:00-\n10:00", "10:00-\n11:00", "11:00-\n12:00", "12:00-\n13:00", "13:00-\n14:00", "14:00-\n15:00", "15:00-\n16:00", "16:00-\n17:00", "17:00-\n18:00" };
    
    // enum for all of the Class States
    public enum ClassState
    {
        Used,
        Unused,
        //Requested
    }
    
    // each tile in the grid have color that determent by his ClassRoomState
    public static readonly Dictionary<ClassState, Color> ClassRoomStateColor = new()
    {
        { ClassState.Used, new Color(255, 0, 0, 255) },
        { ClassState.Unused, new Color(0, 255, 0, 255) },
        //{ClassRoomState.Requested, new Color(255, 153, 0, 255)}
    };

    public ClassState State;  // the state of the ClassRoom: Used, Unused
    public string Subject;  // the subject of the class
    public string Time;  // the time that the class is occupied 
    public string Manager;  // the manager(teacher) of the class
    public string Description;  // the description of the use of the class
    
    // constructor for the class that is used(/Requested)
    public Class(ClassState state, string subject, string time, string manager, string description)
    {
        State = state;
        Subject = subject;
        Time = time;
        Manager = manager;
        Description = description;
    }
    
    // constructor for the class that is unused 
    public Class(string time)
    {
        State = ClassState.Unused;
        Subject = "the class room is unused, no subject.";
        Time = time;
        Manager = "the class room is unused, no manager.";
        Description = "the class room is unused, no Description.";
    }
    
    // return the Categories(RowCategories, ColumnCategories) of the class in some position of the grid
    public static (string, string) GetClassCategoriesByPosition(Vector2 position)
    {
        if (0 <= (position.X - Grid.GridTilesOffset.X - Grid.GridOffset.X) / Grid.TileSizeX && (position.X - Grid.GridTilesOffset.X - Grid.GridOffset.X) / Grid.TileSizeX < ColumnCategories.Length &&
            0 <= (position.Y - Grid.GridTilesOffset.Y - - Grid.GridOffset.Y) / Grid.TileSizeY && (position.Y - Grid.GridTilesOffset.Y - - Grid.GridOffset.Y) / Grid.TileSizeY < RowCategories.Length)
        {
            return (RowCategories[(int)(position.Y - Grid.GridTilesOffset.Y - Grid.GridOffset.Y) / Grid.TileSizeY],
                ColumnCategories[(int)(position.X - Grid.GridTilesOffset.X - Grid.GridOffset.X) / Grid.TileSizeX]);
        }

        return ("", "");
    }
}