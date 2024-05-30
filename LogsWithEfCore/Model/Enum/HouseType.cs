using System.ComponentModel;

namespace LogsWithEfCore.Model.Enum;

public enum HouseType
{
    [Description("Casa terrea")]
    GroundHouse = 1,
    [Description("Apartamento")]
    Apartment = 2,
    [Description("Sobrado")]
    TownHouse = 3,

}
