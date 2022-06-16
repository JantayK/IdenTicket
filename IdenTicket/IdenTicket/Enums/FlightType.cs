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
        [Display(Name = "Прямой в один конец")]
        DirectOneWay = 1,

        [Display(Name = "Прямой с возвратом")]
        DirectWithReturn = 2,

        [Display(Name = "Транзитный в один конец")]
        TransitOneWay = 3,

        [Display(Name = "Транзитный с возвратом")]
        TransitWithReturn = 4,

        [Display(Name = "Трансферный в один конец")]
        TransferOneWay = 5,

        [Display(Name = "Трансферный с возвратом")]
        TransferWithReturn = 6
    }
}