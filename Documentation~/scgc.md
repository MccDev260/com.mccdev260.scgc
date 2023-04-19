# Scene View Gamepad Control.
## Dependencies:
- Input System 1.5.1+

## Setup:
For this package to work, a scriptable object containing the settings values needs to be created in the assets folder.

- Open project window context menu (right-click).
- Create > MccDev260 > EditorTools > SCGC_Settings

Once the asset is created, customize settings to your liking, and test with the controls below.

## Controls:
|    **Action**    | **Binding** |
|:----------------:|:-----------:|
|       Move       |   L-Stick   |
|      Rotate      |   R-Stick   |
|        Up        |   R-Bumper  |
|       Down       |   L-Bumper  |
|    Select Obj    |      A      |
| Snap to Selected |      B      |

## Notes:
Object selection uses raycasting so it only works with objects with a collider.

## Known Issues:
- *Some view tool controls are unresponsive.*
  - As of *v1.0.1*, Both *move*, and *zoom* are unresponsive. *Orbit* and *flythrough mode* still work.

- *Package installed and setup correctly but there's no response to input.*
  - As the settings asset is assigned when the scriptable object is validated, selecting the asset so it shows in the inspector or changing a value should fix the problem. This is hopefully a temporary work around while other solutions are investigated.
