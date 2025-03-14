using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public void MoveObjectOverTime(Transform targetObject, float moveDistance, float moveDuration)
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object not assigned!");
            return;
        }

        Vector3 startPosition = targetObject.position;
        Vector3 targetPosition = startPosition + new Vector3(moveDistance, 0f, 0f);

        StartCoroutine(MoveObjectCoroutine(targetObject, startPosition, targetPosition, moveDuration));
    }

    private IEnumerator MoveObjectCoroutine(Transform targetObject, Vector3 startPosition, Vector3 targetPosition, float moveDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            targetObject.position = Vector3.Lerp(startPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetObject.position = targetPosition;
    }
}