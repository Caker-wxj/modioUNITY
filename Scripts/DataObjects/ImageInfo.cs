using System;

namespace ModIO
{
    [Serializable]
    public class ImageInfo : IEquatable<ImageInfo>, IAPIObjectWrapper<API.ImageObject>
    {
        // - Fields -
        [UnityEngine.SerializeField]
        private API.ImageObject _data;

        public string filename          { get { return _data.filename; } }
        public string original_URL      { get { return _data.original; } }
        public string thumb320x180_URL  { get { return _data.thumb_320x180; } }
        
        // - IAPIObjectWrapper Interface -
        public void WrapAPIObject(API.ImageObject apiObject)
        {
            this._data = apiObject;
        }

        public API.ImageObject GetAPIObject()
        {
            return this._data;
        }

        // - Equality Overrides -
        public override int GetHashCode()
        {
            return this._data.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ImageInfo);
        }

        public bool Equals(ImageInfo other)
        {
            return (Object.ReferenceEquals(this, other)
                    || this._data.Equals(other._data));
        }
    }
}
