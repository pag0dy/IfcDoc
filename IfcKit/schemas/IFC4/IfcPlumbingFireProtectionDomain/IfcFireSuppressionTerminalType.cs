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

using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcPlumbingFireProtectionDomain
{
	[Guid("61aa9c11-fe11-4bd6-b0d1-5cec357310f0")]
	public partial class IfcFireSuppressionTerminalType : IfcFlowTerminalType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcFireSuppressionTerminalTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of fire suppression terminal from wh" +
	    "ich the type required may be set.</p></EPM-HTML>")]
		public IfcFireSuppressionTerminalTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
