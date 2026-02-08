# Atmosphere Simulation

A C# console application that simulates atmospheric gas layer interactions. Gas layers (ozone, oxygen, carbon dioxide) transform based on weather events, with layers growing, shrinking, or converting into other gases until the atmosphere stabilizes or collapses.

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_6-512BD4?style=flat&logo=dotnet&logoColor=white)

## How It Works

The simulation reads an initial atmosphere configuration from a text file — a set of gas layers (Ozone `Z`, Oxygen `X`, Carbon Dioxide `C`) each with a thickness value. A sequence of weather events then drives the simulation:

- **Thunderstorm** — destroys ozone and carbon dioxide, converts part of oxygen into ozone
- **Sunshine** — converts portions of oxygen into ozone and carbon dioxide into oxygen
- **Other** — degrades ozone into oxygen and oxygen into carbon dioxide

Each round, every layer is affected by the current weather event. Layers below 0.5 thickness are removed. The simulation ends when fewer than 3 layers remain or the layer count exceeds 3× the original.

### Design Patterns

- **Strategy Pattern** — weather events (`Thunderstorm`, `Sunshine`, `Other`) implement `IAtmosphericVariable`, defining how each gas type transforms
- **Singleton Pattern** — weather event instances are shared across the simulation
- **Visitor-like dispatch** — each gas layer delegates its transformation to the weather event via `Traverse()`

## Usage

```bash
dotnet run --project Assignment_2
```

When prompted, enter the input file name (e.g., `input.txt`).

### Input Format

```
4
Z 5
X 0.8
C 3
X 4
OOOSSTSTSOO
```

Line 1: number of layers. Following lines: gas type and thickness. Last line: weather event sequence (`T`/`S`/`O`).

Requires .NET 6+.

## Author

**Isroilbek Jamolov** — [GitHub](https://github.com/Jamolov-Isroilbek)
