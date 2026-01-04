# Mental Checklist (Memorize This)

When reading any paragraph:

1.  Underline **nouns**
2.  Ask: _Does this thing live over time?_
3.  Ask: _Does it have responsibility?_
4.  Ask: _Does it interact with others?_
5.  If YES → class
6. If NO → attribute / method / event

## Class Diagram (PlantUML)
```PlantUML
@startuml
abstract class Sensor {
  +readValue()
}

class TemperatureSensor
class HumiditySensor
class CO2Sensor
class SoilMoistureSensor
class LeafSensor

Sensor <|-- TemperatureSensor
Sensor <|-- HumiditySensor
Sensor <|-- CO2Sensor
Sensor <|-- SoilMoistureSensor
Sensor <|-- LeafSensor

abstract class Actuator {
  +activate()
  +deactivate()
}

class LightSystem
class HeatingSystem
class AirflowSystem
class IrrigationSystem

Actuator <|-- LightSystem
Actuator <|-- HeatingSystem
Actuator <|-- AirflowSystem
Actuator <|-- IrrigationSystem

class AIController {
  +monitor()
  +decide()
  +act()
}

class DecisionEngine {
  +evaluate()
}

class FaultDetector {
  +detectFailure()
  +prioritizeActions()
}

AIController --> Sensor
AIController --> Actuator
AIController --> DecisionEngine
AIController --> FaultDetector

class Plant
AIController --> Plant
@enduml

```
