# UnityEngineMock

## Drop-in mock / fake / stub for UnityEngine.

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

### Mostly complete (and functioning) fakes:

- Mathf
- Vector2
- Vector3
- Vector2Int
- Debug


### Very partially implemented (but functioning) fakes:

- Time
- TextAsset
- Resources
- Application


### Mocks (incomplete, non-functioning, but helps compiling stuff):

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


