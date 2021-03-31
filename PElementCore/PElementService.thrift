namespace netstd PElementServer.Thrift

//Class for returning PElement
struct PElement{
1: string Name
2: string Appearance
3: double AtomicMass
4: double Boil
5: string Category
6: optional double Density
7: string DiscoveredBy
8: optional double Melt
9: optional double MolarHeat
10: string NamedBy
11: i16 Number
12: i16 Period
13: string Phase
14: string Source
15: string Summary
16: string Symbol
17: list<double> IonizationEnergies
18: optional double ElectronAffinity
19: string ElectronConfiguration
20: optional double ElectronegativityPaulimg
}

//Service
service PElementService
{
  PElement Get(1: string name)
  list<PElement> GetAll()
}

