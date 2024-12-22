using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using Game.Player;
using Game.Player.InputImpls;
public class DebugPlayerInput : MonoBehaviour
{

    [SerializeField]
    private Text textGyro;
    [SerializeField]
    private Text textAccel;
    [SerializeField]
    private Text textTouch;

    [SerializeField] private PlayerInputEventProvider _player;

    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                var Gyro = UnityEngine.InputSystem.Gyroscope.current;
                string str = "";
                if (Gyro != null)
                {
                    str += "Gyro: ";
                    if (Gyro.enabled)
                    {
                        str += "On";
                        str += "Value: " + Gyro.angularVelocity.ReadValue();
                    }
                    else
                    {
                        str += "Off";
                    }
                }


                textGyro.text = str;
            }).AddTo(this);

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                var Accel = UnityEngine.InputSystem.Accelerometer.current;
                string str = "";
                if (Accel != null)
                {
                    str += "Accel: ";
                    if (Accel.enabled)
                    {
                        str += "On";
                        str += "Value: " + Accel.acceleration.ReadValue();
                    }
                    else
                    {
                        str += "Off";
                    }
                }

                textAccel.text = str;
            }).AddTo(this);

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                var Touch = UnityEngine.InputSystem.Touchscreen.current;
                string str = "";
                if (Touch != null)
                {
                    str += "Touch: ";
                    if (Touch.enabled)
                    {
                        str += "On";
                        str += "Value: " + Touch.primaryTouch.position.ReadValue();
                    }
                    else
                    {
                        str += "Off";
                    }
                }

                textTouch.text = str;
            }).AddTo(this);
    }
    public void EnableTouch()
    {
        _player.EnableTouch();
    }
}
