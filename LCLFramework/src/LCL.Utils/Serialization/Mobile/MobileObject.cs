﻿
using System;

namespace LCL.Serialization.Mobile
{
    /// <summary>
    /// 当使用 MobileFormatter 作为序列化时，才会运行此类的代码。
    /// 也就是说，二进制序列化不会使用以下代码。
    /// </summary>
    [Serializable]
    public abstract class MobileObject : IMobileObject
    {
        #region IMobileObject 成员

        void IMobileObject.SerializeRef(ISerializationContext info)
        {
            OnMobileSerializeRef(info);
        }

        void IMobileObject.SerializeState(ISerializationContext info)
        {
            OnMobileSerializeState(info);
        }

        void IMobileObject.DeserializeState(ISerializationContext info)
        {
            OnMobileDeserializeState(info);
        }

        void IMobileObject.DeserializeRef(ISerializationContext info)
        {
            OnMobileDeserializeRef(info);
        }

        #endregion

        /// <summary>
        /// Override this method to insert your child object
        /// references into the MobileFormatter serialzation stream.
        /// </summary>
        /// <param name="context">
        /// Object containing the data to serialize.
        /// </param>
        /// <param name="formatter">
        /// Reference to MobileFormatter instance. Use this to
        /// convert child references to/from reference id values.
        /// </param>
        protected virtual void OnMobileSerializeRef(ISerializationContext context)
        {
            FieldsSerializationHelper.SerialzeFields(this, context);
        }

        /// <summary>
        /// Override this method to insert your field values
        /// into the MobileFormatter serialzation stream.
        /// </summary>
        /// <param name="context">
        /// Object containing the data to serialize.
        /// </param>
        /// <param name="e">
        /// The StateMode indicating why this method was invoked.
        /// </param>
        protected virtual void OnMobileSerializeState(ISerializationContext context)
        {
            FieldsSerializationHelper.SerialzeFields(this, context);
        }

        /// <summary>
        /// Override this method to retrieve your field values
        /// from the MobileFormatter serialzation stream.
        /// </summary>
        /// <param name="context">
        /// Object containing the data to serialize.
        /// </param>
        /// <param name="e">
        /// The StateMode indicating why this method was invoked.
        /// </param>
        protected virtual void OnMobileDeserializeState(ISerializationContext context)
        {
            FieldsSerializationHelper.DeserialzeFields(this, context);
        }

        /// <summary>
        /// Override this method to retrieve your child object
        /// references from the MobileFormatter serialzation stream.
        /// </summary>
        /// <param name="context">
        /// Object containing the data to serialize.
        /// </param>
        /// <param name="formatter">
        /// Reference to MobileFormatter instance. Use this to
        /// convert child references to/from reference id values.
        /// </param>
        protected virtual void OnMobileDeserializeRef(ISerializationContext context)
        {
            FieldsSerializationHelper.DeserialzeFields(this, context);
        }
    }
}
