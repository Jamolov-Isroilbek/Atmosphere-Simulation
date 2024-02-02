//Author:   Jamolov Isroilbek
//Date:     2023.05.15
//Title:    Assignment_2

namespace Assignment_2
{
    public interface IAtmosphericVariable
    {
        LayerOfGas ChangeZ(Ozone ozone);
        LayerOfGas ChangeX(Oxygen oxygen);
        LayerOfGas ChangeC(CarbonDioxide carbonDioxide);
    }

    #region Atmospheric Variables
    public class Thunderstorm : IAtmosphericVariable
    {
        private Thunderstorm() { }
        public static Thunderstorm Instance { get; } = new Thunderstorm(); // <=> same as the code below 
        
        //private static Thunderstorm? instance;
        //public static Thunderstorm Instance()
        //{
        //    instance ??= new Thunderstorm(); <=> if (instance == null) { instance = new Thunderstorm(); }
        //    return instance;
        //}

        public LayerOfGas ChangeZ(Ozone ozone)
        {
            return new Ozone('Z', 0);
        }
        public LayerOfGas ChangeX(Oxygen oxygen)
        {
            oxygen.ModifyThickness(0.5, out double remainder);
            return new Ozone('Z', remainder);
        }
        public LayerOfGas ChangeC(CarbonDioxide carbonDioxide)
        {
            return new CarbonDioxide('C', 0);
        }     
    }

    public class Sunshine : IAtmosphericVariable
    {
        private Sunshine() { }
        public static Sunshine Instance { get; } = new Sunshine();
        public LayerOfGas ChangeZ(Ozone ozone)
        {
            return new Ozone('Z', 0);
        }
        public LayerOfGas ChangeX(Oxygen oxygen)
        {
            oxygen.ModifyThickness(0.05, out double remainder);
            return new Ozone('Z', remainder);
        }
        public LayerOfGas ChangeC(CarbonDioxide carbonDioxide)
        {
            carbonDioxide.ModifyThickness(0.05, out double remainder);
            return new Oxygen('X', remainder);
        }
    }

    public class Other : IAtmosphericVariable
    {
        private Other() { }
        public static Other Instance { get; } = new Other();
        public LayerOfGas ChangeZ(Ozone ozone)
        {

            ozone.ModifyThickness(0.05, out double remainder);
            return new Oxygen('X', remainder);
        }
        public LayerOfGas ChangeX(Oxygen oxygen)
        {

            oxygen.ModifyThickness(0.1, out double remainder);
            return new CarbonDioxide('C', remainder);
        }
        public LayerOfGas ChangeC(CarbonDioxide carbonDioxide)
        {
            return new CarbonDioxide('C', 0);
        }
    }
    #endregion
}
