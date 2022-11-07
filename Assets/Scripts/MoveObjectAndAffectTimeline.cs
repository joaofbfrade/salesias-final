using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MoveObjectAndAffectTimeline : MonoBehaviour
{
    public PlayableDirector timeLine;

    void Update()
    {
        MoveObjectBetweenLimits();

        MoveTimelineRelativeToLocation();
    }

    public Transform objectivePos;
    float dist;

    void MoveObjectBetweenLimits()
    {
        Vector3 motionVector = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            motionVector.x -= 1;

        if (Input.GetKey(KeyCode.RightArrow))
            motionVector.x += 1;

        if (Input.GetKey(KeyCode.UpArrow))
            motionVector.z += 1;

        if (Input.GetKey(KeyCode.DownArrow))
            motionVector.z -= 1;

        transform.position += motionVector * 5 * Time.deltaTime;
        dist = Vector3.Distance(objectivePos.position, transform.position);
        Debug.Log(dist);
    }

    void MoveTimelineRelativeToLocation()
    {
        if (timeLine)
        {
            float normalizedTimeByDistanceTravelled =  -((transform.position.z - 150) / (100)) + 1;
            timeLine.time = normalizedTimeByDistanceTravelled;
            timeLine.Evaluate();
            timeLine.timeUpdateMode = DirectorUpdateMode.Manual;
        }
    }
}
