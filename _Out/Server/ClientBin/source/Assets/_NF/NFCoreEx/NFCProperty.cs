using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace NFCoreEx
{
    public class NFCProperty : NFIProperty
    {
        public NFCProperty( NFIDENTID self, string strPropertyName, NFIDataList varData)
        {
            mSelf = self;
            msPropertyName = strPropertyName;
            mVarProperty = new NFCDataList(varData);
        }

        public override void SetValue(NFIDataList varData)
        {
            mVarProperty = varData;
        }

        public override NFIDataList GetValue()
        {
            return mVarProperty;
        }

        public override void SetUpload(bool upload)
        {
            mbUpload = upload;
        }

        public override bool GetUpload()
        {
            return mbUpload;
        }

        public override string GetKey()
        {
            return msPropertyName;
        }
		
		public override NFIDataList.VARIANT_TYPE GetType()
		{
			return mVarProperty.GetType(0);
		}

        public override Int64 QueryInt()
        {
            return mVarProperty.IntVal(0);
        }

        public override float QueryFloat()
        {
            return mVarProperty.FloatVal(0);
        }

        public override double QueryDouble()
        {
            return mVarProperty.DoubleVal(0);
        }

        public override string QueryString()
        {
            return mVarProperty.StringVal(0);
        }

        public override NFIDENTID QueryObject()
        {
            return mVarProperty.ObjectVal(0);
        }

        public override bool SetInt(Int64 value)
        {
            //client default not broadcastToSelf
            return SetInt(value, false);
        }

        public override bool SetInt(Int64 value, bool broadCastToSelf)
		{
			if (mVarProperty.IntVal(0) != value)
			{
				NFCDataList oldValue = new NFCDataList(mVarProperty);
				
				mVarProperty.SetInt(0, value);

				NFCDataList newValue = new NFCDataList(mVarProperty);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, this, oldValue, newValue, broadCastToSelf);
                }
				
			}

			return true;
		}

        public override bool SetFloat(float value)
        {
            return SetFloat(value, false);
        }

        public override bool SetFloat(float value, bool broadCastToSelf)
		{
			if (mVarProperty.FloatVal(0) - value > 0.01f
				|| mVarProperty.FloatVal(0) - value < -0.01f)
			{
				NFCDataList oldValue = new NFCDataList(mVarProperty);

				mVarProperty.SetFloat(0, value);

				NFCDataList newValue = new NFCDataList(mVarProperty);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, this, oldValue, newValue, broadCastToSelf);
                }
			}

			return true;
		}

        public override bool SetDouble(double value)
        {
            return SetDouble(value, false);
        }

        public override bool SetDouble(double value, bool broadCastToSelf)
		{
            if (mVarProperty.DoubleVal(0) - value > 0.01f
                || mVarProperty.DoubleVal(0) - value < -0.01f)
            {
                NFCDataList oldValue = new NFCDataList(mVarProperty);

                mVarProperty.SetDouble(0, value);

                NFCDataList newValue = new NFCDataList(mVarProperty);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, this, oldValue, newValue, broadCastToSelf);
                }
            }

			return true;
		}

        public override bool SetString(string value)
        {
            return SetString(value, false);
        }

        public override bool SetString(string value, bool broadCastToSelf)
		{
            if (mVarProperty.StringVal(0) != value)
            {
                NFCDataList oldValue = new NFCDataList(mVarProperty);

                mVarProperty.SetString(0, value);

                NFCDataList newValue = new NFCDataList(mVarProperty);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, this, oldValue, newValue, broadCastToSelf);
                }
            }

			return true;
		}

        public override bool SetObject(NFIDENTID value)
        {
            return SetObject(value, false);
        }

        public override bool SetObject(NFIDENTID value, bool broadCastToSelf)
		{

            if (mVarProperty.ObjectVal(0) != value)
            {
                NFCDataList oldValue = new NFCDataList(mVarProperty);

                mVarProperty.SetObject(0, value);

                NFCDataList newValue = new NFCDataList(mVarProperty);

                if (null != doHandleDel)
                {
                    doHandleDel(mSelf, this, oldValue, newValue, broadCastToSelf);
                }
            }

			return true;
		}

		public override void RegisterCallback(PropertyEventHandler handler)
		{
			doHandleDel += handler;
		}

		PropertyEventHandler doHandleDel;

		NFIDENTID mSelf;
		string msPropertyName;
		NFIDataList mVarProperty;
        bool mbUpload;
    }
}