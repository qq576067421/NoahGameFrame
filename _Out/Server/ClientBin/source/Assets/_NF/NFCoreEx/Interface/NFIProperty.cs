using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFCoreEx
{
    public abstract class NFIProperty
    {
	public delegate void PropertyEventHandler(NFIDENTID self, NFIProperty xProperty, NFIDataList oldVar, NFIDataList newVar, bool broadCastToSelf);

    public abstract void SetValue(NFIDataList varData);

    public abstract NFIDataList GetValue();

    public abstract void SetUpload(bool upload);

    public abstract bool GetUpload();

    public abstract string GetKey();
		
	public abstract NFIDataList.VARIANT_TYPE GetType();

    public abstract Int64 QueryInt();

    public abstract float QueryFloat();

    public abstract double QueryDouble();

    public abstract string QueryString();

    public abstract NFIDENTID QueryObject();

	public abstract bool SetInt(Int64 value);

	public abstract bool SetFloat(float value);

	public abstract bool SetDouble(double value);

	public abstract bool SetString(string value);

	public abstract bool SetObject(NFIDENTID value);

    public abstract bool SetInt(Int64 value, bool broadCastToSelf);

    public abstract bool SetFloat(float value, bool broadCastToSelf);

    public abstract bool SetDouble(double value, bool broadCastToSelf);

    public abstract bool SetString(string value, bool broadCastToSelf);

    public abstract bool SetObject(NFIDENTID value, bool broadCastToSelf);

    public abstract void RegisterCallback(PropertyEventHandler handler);
    }
}