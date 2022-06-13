using System.ComponentModel;

namespace IdenTicket.Enums
{
    /// <summary>
    /// Тип полёта:
    /// Прямой = 1
    /// Прямой с возвратом = 2
    /// </summary>
    public enum FlightType
    {
        [Description("Прямой")]
        DirectOneWay = 1,
        [Description("Прямой с возвратом")]
        DirectWithReturn = 2
    }
}