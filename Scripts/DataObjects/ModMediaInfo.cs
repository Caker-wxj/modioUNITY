using System;

namespace ModIO
{
    [Serializable]
    public class ModMediaInfo : IEquatable<ModMediaInfo>, IAPIObjectWrapper<API.ModMediaObject>, UnityEngine.ISerializationCallbackReceiver
    {
        // - Fields -
        [UnityEngine.SerializeField]
        private API.ModMediaObject _data;

        public string[] youtubeURLs     { get { return _data.youtube; } }
        public string[] sketchfabURLS   { get { return _data.sketchfab; } }
        public ImageInfo[] images       { get; private set; }
        
        // - IAPIObjectWrapper Interface -
        public void WrapAPIObject(API.ModMediaObject apiObject)
        {
            this._data = apiObject;

            // - Load Images -
            int imageCount = (apiObject.images == null ? 0 : apiObject.images.Length);
            this.images = new ImageInfo[imageCount];
            for(int i = 0;
                i < imageCount;
                ++i)
            {
                this.images[i] = new ImageInfo();
                this.images[i].WrapAPIObject(apiObject.images[i]);
            }
        }
        public API.ModMediaObject GetAPIObject()
        {
            return this._data;
        }

        // - ISerializationCallbackReceiver -
        public void OnBeforeSerialize() {}
        public void OnAfterDeserialize()
        {
            this.WrapAPIObject(this._data);
        }

        // - Equality Overrides -
        public override int GetHashCode()
        {
            return this._data.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ModMediaInfo);
        }

        public bool Equals(ModMediaInfo other)
        {
            return (Object.ReferenceEquals(this, other)
                    || this._data.Equals(other._data));
        }
    }
}
