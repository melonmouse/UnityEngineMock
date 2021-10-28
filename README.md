# UnityEngineMock

Note: this project is not affiliated with Unity. The implementation was done
without looking at the source code of Unity.

## Drop-in mock / fake / stub for UnityEngine

UnityEngineMock can be useful if you have your own build process, and some
lingering (but not critical) dependenies on Unity. It can also be useful for
(unit-/integration-)testing purposes.

This project was hacked together quickly, if it is missing functionality feel
free to let me know (open an issue) or write a pull request.

To use this, you could do something like:

```c#
#if MOCK_UNITYENGINE
using UnityEngineMock;
#else
using UnityEngine;
#endif
```

### Fakes - Mostly complete and functioning

These will mostly work as you are used to. Some parts are not implemented (yet).

- Mathf
- Vector2
- Vector3
- Vector2Int
- Debug


### Fakes - Incomplete but functioning

Only specific parts are implemented. Those parts will mostly work as you are used to.

- Time
- TextAsset
- Resources
- Application


### Stubs - Incomplete, non-functioning

These are meant to help compile. They don't have much functionality.

- MonoBehavior
- GameObject
- Object
- Component
- Transform
- RectTransform
- Quaternion
- Color
- Image
- Canvas
- Input
- KeyCode


