using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controllers
{
    public class CarController : MonoBehaviour
    {
        [Header("引用")]
        public Transform SceneRoot;
        public Image CarImage;

        [Header("属性")]
        public float TurningSpeed;
        public List<Sprite> CarSprites;

        [Header("运行时属性")]
        public float TurningOffset;

        private bool _PressingMoveKey;
        private int _PressingMoveDir;

        private void Update()
        {
            var horizontalOffset = 0f;

            CarImage.sprite = CarSprites[0];

            if (Input.GetKey(KeyCode.A))
            {
                horizontalOffset -= TurningSpeed;
                CarImage.sprite = CarSprites[1];
            }

            if (Input.GetKey(KeyCode.D))
            {
                horizontalOffset += TurningSpeed;
                CarImage.sprite = CarSprites[2];
            }

            if (_PressingMoveKey)
            {
                CarImage.sprite = CarSprites[_PressingMoveDir == -1 ? 1 : 2];
                TurningOffset += _PressingMoveDir * TurningSpeed * Time.deltaTime;
            }

            TurningOffset += horizontalOffset * Time.deltaTime;
        }

        public void InputMoveDir(int dir)
        {
            if (dir != -1 && dir != 1) return;

            _PressingMoveKey = true;
            _PressingMoveDir = dir;

            CarImage.sprite = CarSprites[_PressingMoveDir == -1 ? 1 : 2];

            TurningOffset += _PressingMoveDir * TurningSpeed * Time.deltaTime;
        }

        public void ReleaseMoveKey()
        {
            _PressingMoveKey = false;
        }
    }
}