using UnityEngine;
using System.IO.Ports;

public class VibrateMotor : MonoBehaviour
{
    SerialPort serialPort;

    void Start()
    {
        serialPort = new SerialPort("COM5", 9600); // Adjust the port accordingly
        serialPort.Open();
    }

    void OnDestroy()
    {
        serialPort.Close();
    }

    void Update()
    {
        // Check for any key press
        if (Input.anyKeyDown)
        {
            VibrateMotorFunction(true);
        }
        // Check for any key release
        else if (Input.anyKey)
        {
            VibrateMotorFunction(false);
        }
    }

    void VibrateMotorFunction(bool vibrate)
    {
        if (vibrate)
        {
            serialPort.Write("1"); // Send '1' to Arduino to turn on the motor
        }
        else
        {
            serialPort.Write("0"); // Send '0' to Arduino to turn off the motor
        }
    }
}

