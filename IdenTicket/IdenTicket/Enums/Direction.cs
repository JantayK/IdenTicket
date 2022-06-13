using System.ComponentModel;

namespace IdenTicket.Enums
{
    /// <summary>
    /// Направление
    /// Туда = 1
    /// Обратно = 2
    /// </summary>
    public enum Direction
    {
        [Description("Туда")]
        Forth = 1,
        [Description("Обратно")]
        Back = 2
    }
}
