using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdenTicket.Enums
{
    /// <summary>
    /// Тип полёта:
    /// Прямой = 1
    /// Прямой с возвратом = 2
    /// </summary>
    public enum FlightType
    {
        [Display(Name = "Прямой")]
        DirectOneWay = 1,
        [Display(Name = "Прямой с возвратом")]
        DirectWithReturn = 2
    }
}