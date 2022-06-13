using System.ComponentModel;

namespace IdenTicket.Enums

{
    /// <summary>
    /// Выбор пола
    /// Мужской = 1
    /// Женский = 2
    /// Другое = 3
    /// </summary>
    public enum Gender
    {
        [Description("Мужской")]
        Male = 1,
        [Description("Женский")]
        Female = 2,
        [Description("Другое")]
        Other = 3
    }
}