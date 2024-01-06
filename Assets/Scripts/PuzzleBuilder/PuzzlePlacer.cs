using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace PuzzleBuilder
{
    public class PuzzlePlacer
    {
        private Vector2 _currentPiecePosition = Vector2.zero;
        private const float _aproximator = 1f;
        private Vector2 _currentPieceNumber = new Vector2(1,0);
        private float _previousBottomOffset;
        private Part _prevoiusPartY;
        private List<Part> _prevoiusPartsX = new List<Part>();
        private List<Part> _parts = new List<Part>();
        private List<float> _previousOffsets = new List<float>();
        private List<float> _offsets = new List<float>();

        public void PlacePieceOnPosition(RectTransform rectTransform, Vector2 minMaxSize, float convexSize, Vector2 puzzleAreaSize, Vector2 dimensionalSize)
        {
            float convexOffsetX = 0f;
            float convexOffsetY = 0f;
            float bottomOffset = 0f;

            Part currentPartY;

            _currentPieceNumber = new Vector2(_currentPieceNumber.x, _currentPieceNumber.y + 1);
            if (_currentPieceNumber.y > dimensionalSize.y)
            {
                _currentPieceNumber = new Vector2(_currentPieceNumber.x + 1, 1);
            }

            if (_currentPieceNumber.y == 1)
            {
                _currentPiecePosition = new Vector2(_currentPiecePosition.x + minMaxSize.x, 0f);

                _prevoiusPartsX.Clear();
                foreach(Part part in _parts)
                {
                    _prevoiusPartsX.Add(part);
                }
                _parts.Clear();

                _previousOffsets.Clear();
                foreach (float offset in _offsets)
                {
                    _previousOffsets.Add(offset);
                }
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

            //Find y part format
            if (rectTransform.sizeDelta.y - _aproximator <= minMaxSize.x)
            {
                currentPartY = Part.min;
                convexOffsetY = 0f;
                _currentPiecePosition = _currentPiecePosition - new Vector2(0, rectTransform.sizeDelta.y - convexOffsetY);

                if (_currentPieceNumber.y != 1)
                {
                    _currentPiecePosition = _currentPiecePosition + new Vector2(0, _previousBottomOffset);

                    if (_prevoiusPartY == Part.middle)
                        _currentPiecePosition = _currentPiecePosition + new Vector2(0, convexSize);
                }
                
            }
            else if (rectTransform.sizeDelta.y + _aproximator >= minMaxSize.y)
            {
                //Debug.Log("Max part y");
                currentPartY = Part.max;
                convexOffsetY = convexSize;
                bottomOffset = convexSize;
                _currentPiecePosition = _currentPiecePosition - new Vector2(0, rectTransform.sizeDelta.y - convexOffsetY);
            }
            else
            {
                currentPartY = Part.middle;
                //Debug.Log("MiddlePart y");
                convexOffsetY = convexSize;

                float topOffset = 0f;
                if (_currentPieceNumber.y == 1f)
                    topOffset = convexSize;

                _currentPiecePosition = _currentPiecePosition - new Vector2(0, rectTransform.sizeDelta.y - convexOffsetY + topOffset);

                if (_currentPieceNumber.y != 1)
                {
                    _currentPiecePosition = _currentPiecePosition + new Vector2(0, _previousBottomOffset);

                    if (_prevoiusPartY == Part.max)
                        _currentPiecePosition = _currentPiecePosition - new Vector2(0, convexSize);
                }
                    
            }

            rectTransform.anchoredPosition = new Vector2(_currentPiecePosition.x - rectTransform.sizeDelta.x / 2 + convexOffsetX, _currentPiecePosition.y + rectTransform.sizeDelta.y / 2);
            _previousBottomOffset = bottomOffset;
            _offsets.Add(convexOffsetX);
            _prevoiusPartY = currentPartY;
        }

        public enum Part
        {
            min,
            middle,
            max
        }
    }
}

