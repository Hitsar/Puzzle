using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace PuzzleBuilder
{
    public class PuzzlePlacer
    {
        [Inject]
        public PuzzlePlacer()
        {

        }

        private Vector2 _currentPiecePosition = Vector2.zero;
        private const float _aproximator = 1f;
        private Vector2 _currentPieceNumber = new Vector2(1,0);
        private List<Part> _prevoiusPartsX = new List<Part>();
        private List<Part> _parts = new List<Part>();
        private List<float> _previousOffsets = new List<float>();
        private List<float> _offsets = new List<float>();

        public void PlacePieceOnPosition(RectTransform rectTransform, Vector2 minMaxSize, float convexSize, Vector2 puzzleAreaSize, Vector2 dimensionalSize)
        {
            float convexOffsetX = 0f;
            float convexOffsetY = 0f;

            _currentPieceNumber = new Vector2(_currentPieceNumber.x, _currentPieceNumber.y + 1);
            if (_currentPieceNumber.y > dimensionalSize.y)
            {
                _currentPieceNumber = new Vector2(_currentPieceNumber.x + 1, 1);
            }

            if (_currentPieceNumber.y == 1)
            {
                _currentPiecePosition = new Vector2(_currentPiecePosition.x + minMaxSize.x, 0f);

                _prevoiusPartsX.Clear();
                _prevoiusPartsX.AddRange(_parts);
                _parts.Clear();

                _previousOffsets.Clear();
                _previousOffsets.AddRange(_offsets);
                _offsets.Clear();
            }

            //Find x part format
            if (rectTransform.sizeDelta.x - _aproximator <= minMaxSize.x)
            {
                _parts.Add(Part.min);
            }
            else if (rectTransform.sizeDelta.x + _aproximator >= minMaxSize.y)
            {
                _parts.Add(Part.max);

                if (_currentPieceNumber.x > 1)
                {
                    if (_prevoiusPartsX[_parts.Count - 1] == Part.min)
                        convexOffsetX = convexSize;

                    if (_prevoiusPartsX[_parts.Count - 1] == Part.middle)
                        convexOffsetX = convexSize;
                }
            }
            else
            {
                _parts.Add(Part.middle);
                convexOffsetX = convexSize;
                if (_currentPieceNumber.x > 1)
                {
                    if (_prevoiusPartsX[_parts.Count - 1] == Part.min)
                    {
                        convexOffsetX = 0f;
                    }
                    else if( _prevoiusPartsX[_parts.Count - 1] == Part.middle)
                    {
                        convexOffsetX = 0f;
                        if (_previousOffsets[_parts.Count - 1] != 0)
                            convexOffsetX = convexSize;
                    }
                }
            }

            if (_currentPieceNumber.y > 1)
                convexOffsetY = convexSize;

            float positionOffset = 0f;
            if (_currentPieceNumber.y > 2)
                positionOffset = convexOffsetY;
                
            _currentPiecePosition = _currentPiecePosition - new Vector2(0, rectTransform.sizeDelta.y - positionOffset);

            rectTransform.anchoredPosition = new Vector2(_currentPiecePosition.x - rectTransform.sizeDelta.x / 2 + convexOffsetX, _currentPiecePosition.y + rectTransform.sizeDelta.y / 2 + convexOffsetY);
            _offsets.Add(convexOffsetX);
        }

        public enum Part
        {
            min,
            middle,
            max
        }
    }
}

