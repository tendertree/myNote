using UnityEngine;
using Unity.PolySpatial. InputDevices;
using UnityEngine. InputSystem. EnhancedTouch;
using Touch
UnityEngine.InputSystem. EnhancedTouch. Touch;
using TouchPhase UnityEngine. InputSystem. TouchPhase;
using UnityEngine. InputSystem.LowLevel;
public class ColorChangeOnInput: MonoBehaviour
{
void OnEnable()
{
    EnhancedTouchSupport.Enable();
}
void Update()
{
if (Touch.activeTouches.Count > 0)
{
foreach (var touch in Touch.activeTouches)
{
if (touch.phase == TouchPhase.Began)
{
SpatialPointerState touchData EnhancedSpatialPointerSupport.GetPointerState(touch);
if (touchData.targetObject != null)
{
}
