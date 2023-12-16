using DG.Tweening;
using Level;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzles
{
    public class PuzzleVfx : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        private Image _image;
        private Image _parentImage;

        private void OnValidate()
        {
            if (_image == null) _image = GetComponent<Image>();
            if (_parentImage == null) _parentImage = GetComponentInParent<Image>();
        }

        private void Start()
        {
            Sprite sprite = _sprites[FindAnyObjectByType<LevelsController>().Level];
            _image.sprite = sprite;
            _parentImage.sprite = sprite;
        }
        
        public void MoveTo(Vector2 position) => transform.DOMove(position, 0.5f).SetEase(Ease.OutBack);
        public void Select() => transform.DOScale(transform.localScale * 1.5f, 0.3f).SetEase(Ease.OutBack);
        public void Deselect() => transform.DOScale(transform.localScale / 1.5f, 0.3f).SetEase(Ease.OutBack);
    }
}