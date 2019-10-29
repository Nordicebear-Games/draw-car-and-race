using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCar : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject wheelPrefab;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;

    private Vector3 wheelPos;

    void Update()
    {
        userUnput();
    }

    private void userUnput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
            {
                UpdateLine(tempFingerPos);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            createWheel();
            (currentLine as GameObject).transform.parent = gameObject.transform;
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
    }

    private void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
    }

    private void createWheel()
    {
        for (int i = 0; i < 2; i++)
        {
            if (i == 0){
                wheelPos = new Vector3(fingerPositions[0].x, fingerPositions[0].y);
            }
            else if (i == 1)
            {
                wheelPos = new Vector3(fingerPositions[fingerPositions.Count - 1].x, fingerPositions[fingerPositions.Count - 1].y);
            }
            GameObject wheel = Instantiate(wheelPrefab, wheelPos, Quaternion.identity);
            (wheel as GameObject).transform.parent = gameObject.transform;
        }
    }
}
