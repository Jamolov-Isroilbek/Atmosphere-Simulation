//Author:   Jamolov Isroilbek
//Date:     2023.05.15
//Title:    Assignment_2

namespace Assignment_2
{
    // class of abstract layers of gases
    public abstract class LayerOfGas
    {
        public class InsufficientElementException : Exception 
        {
            public InsufficientElementException() : base("Insufficient number of elements") { }
        }
        public char Type { get; }
        public double Thickness { get; protected set; }
        protected LayerOfGas(char type, double thickness) 
        { 
            Type = type; 
            Thickness = thickness; 
        }
        public bool Survived() => Thickness >= 0.5;
        public void ModifyThickness(double percent, out double remainder)
        {
            remainder = Thickness * percent;
            Thickness -= remainder;
        }    
        public void Transform(IAtmosphericVariable atmosphericVariable, ref List<LayerOfGas> layers)
        {
            int index = layers.IndexOf(this);
            LayerOfGas transformed = Traverse(atmosphericVariable);

            bool layerAdded = false;

            if(!Survived())
            {
                for (int i = index + 1; i < layers.Count; i++)
                {
                    if (layers[i].Type == Type)
                    {
                        layers[i].Thickness += Thickness + transformed.Thickness;
                        layerAdded = true;
                        break;
                    }
                }
            }

            if(!layerAdded)
            {
                for (int i = index + 1; i < layers.Count; i++)
                {
                    if (layers[i].Type == transformed.Type)
                    {
                        layers[i].Thickness += transformed.Thickness;
                        layerAdded = true;
                        break;
                    }
                }
            }
                      
            if (!layerAdded && transformed.Thickness >= 0.5)
            {
                layers.Add(transformed);
            }
        }
        protected abstract LayerOfGas Traverse(IAtmosphericVariable atmosphericVariable);
    }

    #region Layers of gases
    public class Ozone : LayerOfGas
    {
        public Ozone(char type, double thickness) : base(type, thickness) { }
        protected override LayerOfGas Traverse(IAtmosphericVariable atmosphericVariable)
        {
            return atmosphericVariable.ChangeZ(this);
        }

    }
    public class Oxygen : LayerOfGas
    {
        public Oxygen(char type, double thickness) : base(type, thickness) { }
        protected override LayerOfGas Traverse(IAtmosphericVariable atmosphericVariable)
        {
            return atmosphericVariable.ChangeX(this);
        }
    }
    public class CarbonDioxide : LayerOfGas
    {
        public CarbonDioxide(char type, double thickness) : base(type, thickness) { }
        protected override LayerOfGas Traverse(IAtmosphericVariable atmosphericVariable)
        {
            return atmosphericVariable.ChangeC(this);
        }
    }
    #endregion

}
