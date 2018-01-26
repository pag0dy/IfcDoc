// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("a431388c-2787-440c-aeb1-229142deaf2a")]
	public partial class IfcSlippageConnectionCondition : IfcStructuralConnectionCondition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLengthMeasure? _SlippageX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLengthMeasure? _SlippageY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLengthMeasure? _SlippageZ;
	
	
		public IfcSlippageConnectionCondition()
		{
		}
	
		public IfcSlippageConnectionCondition(IfcLabel? __Name, IfcLengthMeasure? __SlippageX, IfcLengthMeasure? __SlippageY, IfcLengthMeasure? __SlippageZ)
			: base(__Name)
		{
			this._SlippageX = __SlippageX;
			this._SlippageY = __SlippageY;
			this._SlippageZ = __SlippageZ;
		}
	
		[Description("Slippage in x-direction of the coordinate system defined by the instance which us" +
	    "es this resource object.")]
		public IfcLengthMeasure? SlippageX { get { return this._SlippageX; } set { this._SlippageX = value;} }
	
		[Description("Slippage in y-direction of the coordinate system defined by the instance which us" +
	    "es this resource object.")]
		public IfcLengthMeasure? SlippageY { get { return this._SlippageY; } set { this._SlippageY = value;} }
	
		[Description("Slippage in z-direction of the coordinate system defined by the instance which us" +
	    "es this resource object.")]
		public IfcLengthMeasure? SlippageZ { get { return this._SlippageZ; } set { this._SlippageZ = value;} }
	
	
	}
	
}
