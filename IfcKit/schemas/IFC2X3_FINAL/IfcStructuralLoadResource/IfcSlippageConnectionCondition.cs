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
	[Guid("eca9e451-2662-4a57-8f8a-2638170a1b97")]
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
	
		[Description("Slippage of that connection. Defines the maximum displacement in x-direction with" +
	    "out any loading applied. \r\n")]
		public IfcLengthMeasure? SlippageX { get { return this._SlippageX; } set { this._SlippageX = value;} }
	
		[Description("Slippage of that connection. Defines the maximum displacement in y-direction with" +
	    "out any loading applied. \r\n")]
		public IfcLengthMeasure? SlippageY { get { return this._SlippageY; } set { this._SlippageY = value;} }
	
		[Description("Slippage of that connection. Defines the maximum displacement in z-direction with" +
	    "out any loading applied. \r\n")]
		public IfcLengthMeasure? SlippageZ { get { return this._SlippageZ; } set { this._SlippageZ = value;} }
	
	
	}
	
}
