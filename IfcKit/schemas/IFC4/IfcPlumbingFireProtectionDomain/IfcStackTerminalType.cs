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
	[Guid("624a4820-5a46-41c1-93e7-ee8116a0612d")]
	public partial class IfcStackTerminalType : IfcFlowTerminalType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcStackTerminalTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of stack terminal from which the typ" +
	    "e required may be set.</p></EPM-HTML>")]
		public IfcStackTerminalTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
