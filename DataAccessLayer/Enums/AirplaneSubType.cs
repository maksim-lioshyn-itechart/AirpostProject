namespace DataAccessLayer.Enums
{
    public enum AirplaneSubType
    {
        //Commercial Airplanes
        JumboPassengerJets = 0,
        MidSizePassengerJets = 1,
        LightPassengerJets = 2,
        PassengerTurboProps = 3,
        CargoAirplanes = 4,

        //Private Jets
        VLJ = 30,
        LightBusinessJets = 31,
        MidsizeBusinessJets = 32,
        HeavyBusinessJets = 33,
        MilitaryJets = 34,

        //Private Propellor Planes
        PrivateSingleEngine = 61,
        TwinTurboprops = 62,
        Aerobatic = 63,
        Amphibious = 64,
        MilitaryTurboprops = 65
    }
}
