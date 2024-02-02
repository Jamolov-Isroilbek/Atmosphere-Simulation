using Assignment_2;
using System.Text;

namespace Assignment_2Tests
{
    [TestClass]
    public class Assignment2Test
    {
        [TestMethod]
        public void ZeroNumberOfLayersExpectedException()
        {
            List<LayerOfGas> layers = new();
            var atmosphericVariable = Thunderstorm.Instance;

            Assert.AreEqual(0, layers.Count);

            int previousCountOfLayers = layers.Count;
            int n = layers.Count;
            int round = 0;

            string result = "";
            if (layers.Count >= 3)
            {
                while (layers.Count >= 3 && layers.Count < n * 3)
                {
                    ++round;
                    for (int i = 0; i < layers.Count; i++)
                    {
                        layers[i].Transform(atmosphericVariable, ref layers);
                        if (!layers[i].Survived()) layers.RemoveAt(i);

                        if (layers.Count < previousCountOfLayers) // if the old layer removed then go one index back
                        {
                            previousCountOfLayers = layers.Count;
                            i--;
                        }
                    }
                }
            }
            else
            {
                result = "No operation performed";
            }
            
            Assert.AreEqual("No operation performed", result);
        }

        [TestMethod]
        public void OneNumberOfLayersExpectedTheEndOfSimalation()
        {
            List<LayerOfGas> layers = new();
            var carbonDioxideLayer = new CarbonDioxide('C', 0.3);
            var atmosphericVariable = Thunderstorm.Instance;
            layers.Add(carbonDioxideLayer);

            Assert.AreEqual(1, layers.Count);

            int previousCountOfLayers = layers.Count;
            int n = layers.Count;
            int round = 0;

            string result = "";
            if (layers.Count >= 3)
            {
                while (layers.Count >= 3 && layers.Count < n * 3)
                {
                    ++round;
                    for (int i = 0; i < layers.Count; i++)
                    {
                        layers[i].Transform(atmosphericVariable, ref layers);
                        if (!layers[i].Survived()) layers.RemoveAt(i);

                        if (layers.Count < previousCountOfLayers) // if the old layer removed then go one index back
                        {
                            previousCountOfLayers = layers.Count;
                            i--;
                        }
                    }
                }
            }
            else
            {
                result = "No operation performed";
            }

            Assert.AreEqual("No operation performed", result);

        }

        [TestMethod]
        public void TwoNumberOfLayersExpectedTheEndOfSimalation()
        {
            List<LayerOfGas> layers = new();
            var carbonDioxideLayer = new CarbonDioxide('C', 0.3);
            var atmosphericVariable = Thunderstorm.Instance;
            layers.Add(carbonDioxideLayer);
            layers.Add(carbonDioxideLayer);

            Assert.AreEqual(2, layers.Count);

            int previousCountOfLayers = layers.Count;
            int n = layers.Count;
            int round = 0;

            string result = "";
            if (layers.Count >= 3)
            {
                while (layers.Count >= 3 && layers.Count < n * 3)
                {
                    ++round;
                    for (int i = 0; i < layers.Count; i++)
                    {
                        layers[i].Transform(atmosphericVariable, ref layers);
                        if (!layers[i].Survived()) layers.RemoveAt(i);

                        if (layers.Count < previousCountOfLayers) // if the old layer removed then go one index back
                        {
                            previousCountOfLayers = layers.Count;
                            i--;
                        }
                    }
                }
            }
            else
            {
                result = "No operation performed";
            }

            Assert.AreEqual("No operation performed", result);
        }

        [TestMethod]
        public void ThreeNumberOfLayersExpectedToProcessCorrectlyAndCreateNewOzoneLayer()
        {
            List<LayerOfGas> layers = new();

            var carbonDioxideLayer = new CarbonDioxide('C', 0.6);
            var ozoneLayer = new Ozone('Z', 1.0);
            var oxygenLayer = new Oxygen('X', 1.2);

            layers.Add(carbonDioxideLayer);
            layers.Add(ozoneLayer);
            layers.Add(oxygenLayer);

            Assert.AreEqual(3, layers.Count);

            var atmosphericVariable = Thunderstorm.Instance;

            oxygenLayer.Transform(atmosphericVariable, ref layers);

            Assert.AreEqual(4, layers.Count);


            Assert.AreEqual('C', layers[0].Type);
            Assert.AreEqual(0.6, layers[0].Thickness);
            Assert.AreEqual('Z', layers[1].Type);
            Assert.AreEqual(1.0, layers[1].Thickness);
            Assert.AreEqual('X', layers[2].Type);
            Assert.AreEqual(0.6, layers[2].Thickness);
            Assert.AreEqual('Z', layers[3].Type);
            Assert.AreEqual(0.6, layers[3].Thickness);
        }

        [TestMethod]
        public void FinalResultOfThreeNumberOfLayersExpectedNumberOfElementsToBeLessThanThree()
        {
            List<LayerOfGas> layers = new();

            var cabonDioxideLayer = new CarbonDioxide('C', 0.6);
            var ozoneLayer = new Ozone('Z', 1.0);
            var oxygenLayer = new Oxygen('X', 0.9);

            layers.Add(cabonDioxideLayer);
            layers.Add(ozoneLayer);
            layers.Add(oxygenLayer);

            var atmospherciVariable = Sunshine.Instance;

            Assert.AreEqual(3, layers.Count);
            Assert.AreEqual('C', layers[0].Type);
            Assert.AreEqual(0.6, layers[0].Thickness);
            Assert.AreEqual('Z', layers[1].Type);
            Assert.AreEqual(1.0, layers[1].Thickness);
            Assert.AreEqual('X', layers[2].Type);
            Assert.AreEqual(0.9, layers[2].Thickness);

            int previousCountOfLayers = layers.Count;
            int n = layers.Count;
            while (layers.Count >= 3 && layers.Count < n * 3)
            {
                for (int i = 0; i < layers.Count; i++)
                {
                    layers[i].Transform(atmospherciVariable, ref layers);
                    if (!layers[i].Survived()) layers.RemoveAt(i);

                    if (layers.Count < previousCountOfLayers) // if the old layer removed then go one index back
                    {
                        previousCountOfLayers = layers.Count;
                        i--;
                    }
                }
            }

            Assert.AreEqual(2, layers.Count);
            Assert.AreEqual('Z', layers[0].Type);
            Assert.AreEqual(1, layers[0].Thickness);
            Assert.AreEqual('X', layers[1].Type);
            Assert.AreEqual(0.830796375, layers[1].Thickness);
        }

        [TestMethod]
        public void FinalResultOfThreeNumberOfLayersExpectedNumOfElemToBeMoreOrEqualToTriple()
        {
            List<LayerOfGas> layers = new();

            var oxygenLayer1 = new Oxygen('X', 50);
            var carbonDioxide = new CarbonDioxide('C', 60);
            var oxygenLayer2 = new Oxygen('X', 100);

            layers.Add(oxygenLayer1);
            layers.Add(carbonDioxide);
            layers.Add(oxygenLayer2);

            List<IAtmosphericVariable> atmosphericVariables = new();
            var atmosphericVariable1 = Thunderstorm.Instance;
            var atmosphericVariable2 = Other.Instance;

            atmosphericVariables.Add(atmosphericVariable1);
            atmosphericVariables.Add(atmosphericVariable2);

            Assert.AreEqual(3, layers.Count);
            Assert.AreEqual('X', layers[0].Type);
            Assert.AreEqual(50, layers[0].Thickness);
            Assert.AreEqual('C', layers[1].Type);
            Assert.AreEqual(60, layers[1].Thickness);
            Assert.AreEqual('X', layers[2].Type);
            Assert.AreEqual(100, layers[2].Thickness);

            Assert.AreEqual(2, atmosphericVariables.Count);
            Assert.AreEqual(Thunderstorm.Instance, atmosphericVariables[0]);
            Assert.AreEqual(Other.Instance, atmosphericVariables[1]);

            
            int n = layers.Count;
            int round = 0;
            int index = 0;
            while (layers.Count >= 3 && layers.Count < (n * 3))
            {
                ++round;               
                int previousCountOfLayers = layers.Count;
                for (int i = 0; i < layers.Count; i++)
                {                  
                    layers[i].Transform(atmosphericVariables[index % atmosphericVariables.Count], ref layers);
                    if (!layers[i].Survived()) layers.RemoveAt(i);

                    if (layers.Count < previousCountOfLayers) // if the old layer removed then go one index back
                    {
                        previousCountOfLayers = layers.Count;
                        i--;
                    }
                }
                index++;
            }
            Assert.AreEqual(10, round); 
            Assert.AreEqual(9, layers.Count);
            Assert.AreEqual(('X', 0.922640625) , (layers[0].Type, layers[0].Thickness));
            Assert.AreEqual(('C', 64.46157812499999), (layers[1].Type, layers[1].Thickness));
            Assert.AreEqual(('X', 1.84528125), (layers[2].Type, layers[2].Thickness));
            Assert.AreEqual(('Z', 107.63425781250001), (layers[3].Type, layers[3].Thickness));
            Assert.AreEqual(('C', 8.923156249999998), (layers[4].Type, layers[4].Thickness));
            Assert.AreEqual(('X', 9.064300781250001), (layers[5].Type, layers[5].Thickness));
            Assert.AreEqual(('Z', 11.839078125000002), (layers[6].Type, layers[6].Thickness));
            Assert.AreEqual(('C', 3.5669882812500004), (layers[7].Type, layers[7].Thickness));
            Assert.AreEqual(('X', 0.5607984375000001), (layers[8].Type, layers[8].Thickness));
        }

        [TestMethod]
        public void NegativeLayerThicknessWhileThNumOfLayersAreValidExpectedToPerishAfterTransformation()
        {
            List<LayerOfGas> layers = new();

            var carbonDioxideLayer = new CarbonDioxide('C', -5);
            var oxygenLayer = new Oxygen('X', 5);
            var ozoneLayer = new Ozone('Z', 1.0);

            layers.Add(carbonDioxideLayer);
            layers.Add(oxygenLayer);
            layers.Add(ozoneLayer);

            var atmosphericVariable = Thunderstorm.Instance;

            int previousCountOfLayers = layers.Count;
            int n = layers.Count;
            int round = 0;

            Assert.AreEqual(3, layers.Count);

            while (layers.Count >= 3 && layers.Count < n * 3)
            {
                ++round;
                for (int i = 0; i < layers.Count; i++)
                {
                    layers[i].Transform(atmosphericVariable, ref layers);
                    if (!layers[i].Survived()) layers.RemoveAt(i);

                    if (layers.Count < previousCountOfLayers) // if the old layer removed then go one index back
                    {
                        previousCountOfLayers = layers.Count;
                        i--;
                    }
                }
            }

            Assert.AreEqual(1, round);
            Assert.AreEqual(2, layers.Count);   
        }
    }   
}